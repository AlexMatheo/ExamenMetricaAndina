using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test_MA_WebForm_Negocio;
using Test_MA_WebForm_Entidades;
using Microsoft.Win32;
using System.Diagnostics.Contracts;

namespace Test_MA_WebForm_Presentacion.Paginas
{
    public partial class Sedes : System.Web.UI.Page
    {
        public static string sID = "-1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();

                    CargarDatosCliente();
                    refreshdata();
                }                
            }
        }

        void CargarDatosCliente()
        {
            DataTable dt = new DataTable();

            negocio balobj = new negocio();

            dt = balobj.CargaDatosCliente(sID);

            DataRow row = dt.Rows[0];

            this.lblRazonSocial.Text = "Cliente :  "+ row[2].ToString();
            this.lblRuc.Text = "RUC :  " + row[1].ToString();
        }

        public void refreshdata()
        {
            DataTable dt = new DataTable();

            negocio balobj = new negocio();

            dt = balobj.CargaDatosSedes(sID);

            if (dt.Rows.Count == 0)
            {
                Entidades entidades = new Entidades()
                {
                    CodCliente = sID,
                    Pais = null,
                    Departamento = null,
                    Direccion = null,
                    TelefonoSede = null,
                    ContactoSede = null
                };
                balobj.RegistrarSede(entidades);

                refreshdata();
            }
            else
            {
                gvSedes.DataSource = dt;
                gvSedes.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvSedes.DataKeys[e.RowIndex].Values["CODSEDE"].ToString();
            negocio balobj = new negocio();
            bool i = balobj.EliminarSede(id);

            if (i)
            {
                Response.Write(" <script> alert('Registro eliminado exitosamente') </script>");
            }
            else
            {
                Response.Write(" <script> alert('No se puedo eliminar el registro') </script>");
            }
            refreshdata();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSedes.EditIndex = e.NewEditIndex;
            refreshdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSedes.EditIndex = -1;
            refreshdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox pais = gvSedes.Rows[e.RowIndex].FindControl("txtPais") as TextBox;
            TextBox departamento = gvSedes.Rows[e.RowIndex].FindControl("txtDepartamento") as TextBox;
            TextBox direccion = gvSedes.Rows[e.RowIndex].FindControl("txtDireccion") as TextBox;
            TextBox telefono = gvSedes.Rows[e.RowIndex].FindControl("txtTelefono") as TextBox;
            TextBox contacto = gvSedes.Rows[e.RowIndex].FindControl("txtContacto") as TextBox;

            Entidades entidades = new Entidades()
            {
                CodSede = gvSedes.DataKeys[e.RowIndex].Values["CODSEDE"].ToString(),
                Pais = pais.Text,
                Departamento = departamento.Text,
                Direccion = direccion.Text,
                TelefonoSede = telefono.Text,
                ContactoSede = contacto.Text
            };

            negocio balobj = new negocio();
            bool i = balobj.ActualizarSede(entidades);
            gvSedes.EditIndex = -1;

            if (i)
            {
                Response.Write(" <script> alert('Actualización Exitosa') </script>");
            }
            else
            {
                Response.Write(" <script> alert('Su actualización no tuvo éxito') </script>");
            }

            refreshdata();
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add New"))
            {
                TextBox pais = (TextBox)gvSedes.FooterRow.FindControl("addpais");
                TextBox departamento = (TextBox)gvSedes.FooterRow.FindControl("adddepartamento");
                TextBox direccion = (TextBox)gvSedes.FooterRow.FindControl("adddireccion");
                TextBox telefono = (TextBox)gvSedes.FooterRow.FindControl("addtelefono");
                TextBox contacto = (TextBox)gvSedes.FooterRow.FindControl("addcontacto");

                Entidades entidades = new Entidades()
                {
                    CodCliente = sID,
                    Pais = pais.Text,
                    Departamento = departamento.Text,
                    Direccion = direccion.Text,
                    TelefonoSede = telefono.Text,
                    ContactoSede = contacto.Text
                };

                negocio balobj = new negocio();
                bool i = balobj.RegistrarSede(entidades);

                if (i)
                {
                    Response.Write(" <script> alert('Registro Exitoso') </script>");
                }
                else
                {
                    Response.Write(" <script> alert('No se puede registrar una sede del mismo País y Departamento.') </script>");
                }

                refreshdata();
            }
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}
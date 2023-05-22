using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test_MA_WebForm_Entidades;
using Test_MA_WebForm_Negocio;

namespace Test_MA_WebForm_Presentacion.Paginas
{
    public partial class Clientes : System.Web.UI.Page
    {
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo cliente";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de cliente";
                            this.BtnGestionarSedes.Visible = true;
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar cliente";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar cliente";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            DataTable dt = new DataTable();

            negocio balobj = new negocio();

            dt = balobj.CargaDatosCliente(sID);

            DataRow row = dt.Rows[0];

            txtRuc.Text = row[1].ToString();
            txtRazonSocial.Text = row[2].ToString();
            txtTelefono.Text = row[3].ToString();
            txtContacto.Text = row[4].ToString();
        }

        protected void BtnCreate_Click (object sender, EventArgs e)
        {
            Entidades entidades = new Entidades()
            {
                Ruc = txtRuc.Text,
                RazonSocial = txtRazonSocial.Text,
                Telefono = txtTelefono.Text,
                Contacto = txtContacto.Text
            };

            negocio balobj = new negocio();
            bool i = balobj.RegistrarCliente(entidades);

            if (i)
            {
                Response.Write(" <script> alert('Registro Exitoso') </script>");
            }
            else
            {
                Response.Write(" <script> alert('Registro Sin Exito') </script>");
            }

            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Entidades entidades = new Entidades()
            {
                CodCliente = sID,
                Ruc = txtRuc.Text,
                RazonSocial = txtRazonSocial.Text,
                Telefono = txtTelefono.Text,
                Contacto = txtContacto.Text
            };

            negocio balobj = new negocio();
            bool i = balobj.ActualizarCliente(entidades);

            if (i)
            {
                Response.Write(" <script> alert('Actualización Exitosa') </script>");
            }
            else
            {
                Response.Write(" <script> alert('La actualización no tuvo éxito') </script>");
            }

            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            negocio balobj = new negocio();
            bool i = balobj.EliminarCliente(sID);

            if (i)
            {
                Response.Write(" <script> alert('Registro eliminado satisfactoriamente') </script>");
            }
            else
            {
                Response.Write(" <script> alert('El registro no se pudo eliminar') </script>");
            }

            Response.Redirect("Index.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void BtnGestionarSedes_Click (object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Sedes.aspx?id=" + sID);
        }
    }
}
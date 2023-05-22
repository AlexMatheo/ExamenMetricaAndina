using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Test_MA_WebForm_Negocio;
using System.Diagnostics.Contracts;
using Test_MA_WebForm_Entidades;

namespace Test_MA_WebForm_Presentacion.Paginas
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refreshdata();
            }
        }

        public void refreshdata()
        {
            negocio balobj = new negocio();

            DataTable dt = balobj.CargarListaDeClientes();

            gvClientes.DataSource = dt;
            gvClientes.DataBind();
        }

        public void BtnCreate_Click (object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Clientes.aspx?op=C");
        }

        public void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/Clientes.aspx?id="+id+"&op=R");
        }

        public void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/Clientes.aspx?id=" + id + "&op=U");
        }

        public void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/Clientes.aspx?id=" + id + "&op=D");
        }
    }
}
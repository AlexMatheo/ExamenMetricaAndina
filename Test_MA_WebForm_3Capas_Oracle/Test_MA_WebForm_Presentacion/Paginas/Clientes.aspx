<%@ Page Title="" Language="C#" MasterPageFile="~/MA.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Test_MA_WebForm_Presentacion.Paginas.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">RUC</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtRuc" MaxLength="11"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Razon Social</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtRazonSocial"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Telefono</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefono"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Contacto</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtContacto"></asp:TextBox>
            </div>

            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Update" Visible="false" onclick="BtnUpdate_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="True" OnClick="BtnVolver_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnGestionarSedes" Text="GestionarSedes" Visible="false" OnClick="BtnGestionarSedes_Click" />
        </div>
    </form>
</asp:Content>
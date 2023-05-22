<%@ Page Title="" Language="C#" MasterPageFile="~/MA.Master" AutoEventWireup="true" CodeBehind="Sedes.aspx.cs" Inherits="Test_MA_WebForm_Presentacion.Paginas.Sedes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 500px">
        <asp:Label runat="server" CssClass="h3" ID="lblRazonSocial"></asp:Label>
        <br>
        <asp:Label runat="server" CssClass="h3" ID="lblRuc"></asp:Label>
        <hr />
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div>
            <%--DataKeyNames="id"--%>
                <asp:GridView ID="gvSedes" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3"  onrowcancelingedit="GridView1_RowCancelingEdit" DataKeyNames="CODSEDE"
                onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" OnRowCommand="gvDetails_RowCommand"
                onrowupdating="GridView1_RowUpdating" CellSpacing="2"> 
                    <Columns> 
                        <asp:TemplateField HeaderText="Operations">
                            <EditItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="addnew" runat="server" CommandName="Add New" Text="Add New" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CodSede" Visible ="false">
                            <EditItemTemplate> 
                                <asp:TextBox ID="txtSede" runat="server" Text='<%# Bind("CODSEDE") %>'></asp:TextBox> 
                            </EditItemTemplate> 
                            <ItemTemplate> 
                                <asp:Label ID="lblSede" runat="server" Text='<%# Bind("CODSEDE") %>'></asp:Label> 
                            </ItemTemplate> 
                            <FooterTemplate>
                                <asp:TextBox ID="addcodigo" runat="server" ></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pais">
                            <EditItemTemplate> 
                                <asp:TextBox ID="txtPais" runat="server" Text='<%# Bind("PAIS") %>'> ESCRIBA SU PAIS </asp:TextBox> 
                            </EditItemTemplate> 
                            <ItemTemplate> 
                                <asp:Label ID="lblPais" runat="server" Text='<%# Bind("PAIS") %>'></asp:Label> 
                            </ItemTemplate> 
                            <FooterTemplate>
                                <asp:TextBox ID="addpais" runat="server" ></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Departamento"> 
                            <EditItemTemplate> 
                                <asp:TextBox ID="txtDepartamento" runat="server" Text='<%# Bind("DEPARTAMENTO") %>'> LIMA </asp:TextBox> 
                            </EditItemTemplate> 
                            <ItemTemplate> 
                                <asp:Label ID="lblDepartamento" runat="server" Text='<%# Bind("DEPARTAMENTO") %>'></asp:Label> 
                            </ItemTemplate> 
                            <FooterTemplate>
                                <asp:TextBox ID="adddepartamento" runat="server" ></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Direccion"> 
                            <EditItemTemplate> 
                                <asp:TextBox ID="txtDireccion" runat="server" Text='<%# Bind("DIRECCION") %>'></asp:TextBox> 
                            </EditItemTemplate> 
                            <ItemTemplate> 
                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("DIRECCION") %>'></asp:Label> 
                            </ItemTemplate> 
                            <FooterTemplate>
                                <asp:TextBox ID="adddireccion" runat="server" ></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Telefono"> 
                            <EditItemTemplate> 
                                <asp:TextBox ID="txtTelefono" runat="server" Text='<%# Bind("TELEFONO") %>'></asp:TextBox> 
                            </EditItemTemplate> 
                            <ItemTemplate> 
                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("TELEFONO") %>'></asp:Label> 
                            </ItemTemplate> 
                            <FooterTemplate>
                                <asp:TextBox ID="addtelefono" runat="server" ></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Contacto"> 
                            <EditItemTemplate> 
                                <asp:TextBox ID="txtContacto" runat="server" Text='<%# Bind("CONTACTO") %>'></asp:TextBox> 
                            </EditItemTemplate> 
                            <ItemTemplate> 
                                <asp:Label ID="lblContacto" runat="server" Text='<%# Bind("CONTACTO") %>'></asp:Label> 
                            </ItemTemplate> 
                            <FooterTemplate>
                                <asp:TextBox ID="addcontacto" runat="server" ></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField> 
                    </Columns> 
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" /> 
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" /> 
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" /> 
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" /> 
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" /> 
                    <SortedAscendingCellStyle BackColor="#FFF1D4" /> 
                    <SortedAscendingHeaderStyle BackColor="#B95C30" /> 
                    <SortedDescendingCellStyle BackColor="#F1E5CE" /> 
                    <SortedDescendingHeaderStyle BackColor="#93451F" /> 
                </asp:GridView>             
            </div>
            <div>
                <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnRegresar" Text="Retroceder" Visible="True" OnClick="BtnRegresar_Click" />
            </div>
        </div>        

    </form>
</asp:Content>

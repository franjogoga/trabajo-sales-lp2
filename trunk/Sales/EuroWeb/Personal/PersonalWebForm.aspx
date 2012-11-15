<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalWebForm.aspx.cs" Inherits="EuroWeb.Personal.PersonalWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="idPersonal" HeaderText="Código" 
                SortExpression="idPersonal" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" 
                SortExpression="Nombres" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" 
                SortExpression="Apellidos" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="FechaContrato" HeaderText="Fecha Contrato" 
                SortExpression="FechaContrato" />
            <asp:BoundField DataField="Direccion" HeaderText="Dirección" 
                SortExpression="Direccion" />
            <asp:BoundField DataField="Sueldo" HeaderText="Sueldo" 
                SortExpression="Sueldo" />
            <asp:BoundField DataField="Puesto" HeaderText="Puesto" 
                SortExpression="Puesto" />
            <asp:BoundField DataField="IdArea" HeaderText="IDArea" 
                SortExpression="IdArea" />
            <asp:BoundField DataField="DNI" HeaderText="DNI" SortExpression="DNI" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
</asp:Content>

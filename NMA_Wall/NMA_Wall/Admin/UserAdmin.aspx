<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserAdmin.aspx.cs" Inherits="NMA_Wall.Admin.UserAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Title added using the C# Title property of the Page reference --%>
    
    <%-- Uncomment when DB works --%>
     <% Page.Title = "Admin"; %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <h2 class="h1">Welcome <small><%= LoggedInUser.Username %></small></h2>
            <p>Account Type: <%= DB.UserGetType(LoggedInUser) %></p>
    <section class="secActions">
        <asp:Button Text="Moderate Comments" runat="server" ID="btnModCom" CssClass="btn-default" />
    </section>
</asp:Content>

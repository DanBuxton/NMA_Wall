<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserAdmin.aspx.cs" Inherits="NMA_Wall.Admin.UserAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="secActions">
        <asp:Button Text="Moderate Comments" runat="server" ID="btnModCom" CssClass="btn-default" />
    </section>
</asp:Content>

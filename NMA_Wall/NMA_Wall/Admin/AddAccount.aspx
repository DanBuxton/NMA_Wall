<%@ Page Title="Add User" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="NMA_Wall.Admin.AddAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <section>
        <fieldset>
            <label for="txtUsername">Username</label>
            <asp:TextBox ID="txtUsername" runat="server" />
            <p>Password is 'NMA_User' by default</p>
        </fieldset>
        <fieldset>
            <select id="selAccountType" runat="server">
                <option value="Contributer" selected="selected">Contributor</option>
                <option value="Admin">Admin</option>
                <option value="Super_Admin">Super Admin</option>
            </select>
        </fieldset>
        <fieldset>
            <asp:Button ID="btnUserAdd" Text="Add User" runat="server" />
        </fieldset>
    </section>
</asp:Content>

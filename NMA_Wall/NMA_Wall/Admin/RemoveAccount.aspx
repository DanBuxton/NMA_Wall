<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RemoveAccount.aspx.cs" Inherits="NMA_Wall.Admin.RemoveAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Remove Account</h1>

    <select id="selUsers" runat="server">
        <option value="">Please Select</option>
    </select>
    <asp:Button ID="btnRemove" Text="Remove" runat="server" />
</asp:Content>

﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NMA_Wall.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadArea" runat="server">
    <%-- Title added using the C# Title property of the Page reference --%>
    <link href="css/LoginStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyArea" runat="server">
    <h1>Login</h1>
    <div class="login-page">
        <div class="form">
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Password" />
            <%--<asp:Button ID="btnSubmit" Text="Submit!" runat="server" />--%>
            <input type="submit" id="btnSubmit" value="Login" runat="server" />
            <%-- Ben is gay --%>
            <input type="button" name="btnBack" value="Back" onclick="Back()" />
        </div>
    </div>
</asp:Content>

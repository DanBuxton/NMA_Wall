<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NMA_Wall.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadArea" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyArea" runat="server">
    <div class="login-page">
        <div class="form">
            <input type="text" placeholder="Username" />
            <input type="password" placeholder="Password" />
            <button>Login!</button>
        </div>
    </div>
</asp:Content>

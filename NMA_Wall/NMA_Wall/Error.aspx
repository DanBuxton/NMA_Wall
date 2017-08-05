<%@ Page Title="Technical Issue" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="NMA_Wall.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadArea" runat="server">
    <%-- Title added using the C# Title property of the Page reference --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyArea" runat="server">
    <h2>Error:</h2>
    <p></p>
    <asp:Label ID="FriendlyErrorMsg" runat="server" Text="Label" Font-Size="Large" Style="color: red" />

    <asp:Panel ID="DetailedErrorPanel" runat="server" Visible="false">
        <p>&nbsp;</p>
        <h4>Detailed Error:</h4>
        <p>
            <asp:Label ID="ErrorDetailedMsg" runat="server" Font-Size="Small" /><br />
        </p>

        <h4>Error Handler:</h4>
        <p>
            <asp:Label ID="ErrorHandler" runat="server" Font-Size="Small" /><br />
        </p>

        <h4>Detailed Error Message:</h4>
        <p>
            <asp:Label ID="InnerMessage" runat="server" Font-Size="Small" /><br />
        </p>
        <p>
            <asp:Label ID="InnerTrace" runat="server" />
        </p>
    </asp:Panel>
</asp:Content>

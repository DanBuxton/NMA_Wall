<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NMA_Wall.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadArea" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyArea" runat="server">

    <div id="Upload images">

    </div>


    <div id="Comment">
        
        <p>Please choose all that apply to your visit today</p>
        <select multiple="multiple">
            <option value="FirstTime visitor">First-Time visitor</option>
            <option value="Repeat visitor">Repeat visitor</option>
            <option value="Forces visitor">Forces current/ex</option>
            <option value="Event visitor">Visitor to an event</option>
            <option value="Organised visitor">Member of an organised visit</option>
            <option value="TRBL member">The Royal British Legion member</option>
            <option value="NMA friend">NMA Friend</option>
            <option value="International visitor">International visitor</option>
        </select>
    </div>
</asp:Content>

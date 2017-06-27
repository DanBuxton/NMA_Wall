<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NMA_Wall.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadArea" runat="server">
    <meta name="description" content="" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyArea" runat="server">
    <h2 class="h1"><%= MemorialName %> momorial comments</h2>

    <section id="<%= MemorialName %>comments">
        <div id="comment">
            <p>
                MessageBody

                <br />

                Posted by 
                <b>
                    <abbr>Anonymous</abbr>
                </b>
            </p>
        </div>
    </section>

    <section>
        <textarea></textarea>

        <div id="UploadImage">
            <%--<asp:FileUpload runat="server" AllowMultiple="false" />--%>
            <label for="imgComment">Add an image</label>

            <br />

            <input id="imgComment" type="file" name="Image" accept="image/*" />
        </div>

        <br />

        <div id="commentOptions">
            <asp:Label Text="Please choose all that apply to your visit today" runat="server" />

            <br />

            <select id="select-multi" multiple="multiple">
                <option value="FirstTime visitor">First-Time visitor</option>
                <option value="Repeat visitor">Repeat visitor</option>
                <option value="Forces visitor">Forces (current/ex)</option>
                <option value="Event visitor">Visitor to an event</option>
                <option value="Organised visitor">Member of an organised visit</option>
                <option value="TRBL member">The Royal British Legion member</option>
                <option value="NMA friend">NMA Friend</option>
                <option value="International visitor">International visitor</option>
            </select>
        </div>

        <input type="submit" name="btnSubmit" value="Post" />
    </section>
</asp:Content>


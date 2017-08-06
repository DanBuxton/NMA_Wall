<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NMA_Wall.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadArea" runat="server">
    <%-- Title added using the C# Title property of the Page reference --%>
    <%--<title><%= MemorialName %> Comments</title>--%>

    <% Page.Title = MemorialName + " Comments"; %>

    <meta name="description" content="" />
    <meta name="keywords" content="" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyArea" runat="server">
    <h2 class="h2"><%= MemorialName %> Memorial Comments</h2>

    <section id="comments">
        <%-- Comment templates --%>
        <div class="comment">
            <h3 class="comment-h3">Good Example</h3>
            <p>
                This is a great example of what happend during WW1
                <br />
                <span class="message-details">Posted by Anonymous at 11:32</span>
            </p>
        </div>
        <div class="comment">
            <h3 class="comment-h3"><span class="comment-removed removed-by-admin">Comment removed</span></h3>
            <p>
                <span class="comment-removed removed-by-admin">Sorry, this comment has been flagged and removed by an admin</span>
                <br />
                <span class="message-details">Posted by Anonymous at 12:27</span>
            </p>
        </div>
        <div class="comment">
            <h3 class="comment-h3">Beautiful place of peace</h3>
            <p>
                It was a lovely, warm feeling to see my grandad's name here :cry:
                <br />
                <span class="message-details">Posted by Anonymous at 14:58</span>
            </p>
        </div>
    </section>

    <div class="clear"></div>

    <section class="bottom" style="bottom: 0px; text-align: center; position: absolute; margin-bottom: 50px; width: 90%;">
        <label for="txtSubject"><span class="required"></span>&nbsp;Subject:-</label>
        <input runat="server" type="text" name="messageSubject" value="" id="txtSubject" style="width: 100%;" placeholder="Subject" autocomplete="off" />

        <br />
        <br />

        <label for="txtMessage"><span class="required"></span>&nbsp;Message:-</label> <label><small>Uses <a href="https://emojipedia.org/" target="_blank">Emojipedia shortcodes</a> for emojis</small></label>
        <%--<input type="text" name="Message" id="txtMessage" value="" runat="server" style="width: 100%; vertical-align: text-top;" placeholder="Message" autocomplete="off" />--%>
        <asp:TextBox runat="server" AutoCompleteType="None" TextMode="MultiLine" name="message" ID="txtMessage" Width="100%" Height="100" Placeholder="Message" />

        <br />
        <br />

        <div id="commentOptions">
                <asp:Label Text="Error:-" runat="server" ID="lblError" CssClass="right" Visible="false" />
            <div id="UploadImage">
                <%--<asp:FileUpload runat="server" AllowMultiple="false" />--%>

                <label for="imgComment">Add an image</label>

                <br />

                <input  id="imgComment" type="file" name="messageImage" accept="image/*" runat="server" />
            </div>

            <br />

            <label><span class="required"></span>&nbsp;Please choose all that apply to your visit today: </label>

            <select id="selOptions" name="messageOptions" multiple="true" runat="server">
                <option value="FirstTime visitor">First-Time visitor</option>
                <option value="Repeat visitor">Repeat visitor</option>
                <option value="International visitor">International visitor</option>
                <option value="Forces visitor">Forces (current/ex)</option>
                <option value="Event visitor">Visitor to an event</option>
                <option value="Organised visitor">Member of an organised visit</option>
                <option value="NMA friend">NMA Friend</option>
                <option value="TRBL member">Royal British Legion member</option>
            </select>
        </div>

        <br />

        <asp:Button Text="Post" runat="server" CssClass="btn-default" ID="btnPostMessage" />
    </section>

    <%--<script src="js/Homepage.js"></script>--%>
</asp:Content>

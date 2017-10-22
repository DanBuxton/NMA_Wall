<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NMA_Wall.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadArea" runat="server">
    <%-- Title added using the C# Title property of the Page reference --%>
    <% 

    %>

    <meta name="description" content="" />
    <meta name="keywords" content="Nation Memorial Arboretum; thenma.org.uk" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyArea" runat="server">
    <h2 class="h2"><%= MemorialName %> Memorial Comments</h2>

    <section id="comments" itemtype="http://schema.org/Blog">
        <%-- Comment templates --%>
        <section class="comment" itemprop="itemListElement" itemscope="itemscope">
            <h3 class="comment-h3">Good Example</h3>
            <p itemtype="http://schema.org/Review">
                <img src="img/Comments/1.JPG" alt="Image 01" width="150" height="150" itemprop="image" itemtype="http://schema.org/Photograph" class="image" />
                <br />
                <span class="message-details">Posted by Anonymous at 11:32</span>
            </p>
        </section>
        <section class="comment" itemprop="itemListElement" itemscope="itemscope">
            <h3 class="comment-h3"><span class="comment-removed removed-by-admin">Comment removed</span></h3>
            <p itemtype="http://schema.org/Review">
                <span class="comment-removed removed-by-admin">Sorry, this comment has been flagged and removed by an admin</span>
                <br />
                <span class="message-details">Posted by Anonymous at 12:27</span>
            </p>
        </section>
        <section class="comment" itemprop="itemListElement" itemscope="itemscope">
            <h3 class="comment-h3">Beautiful place of peace</h3>
            <p itemtype="http://schema.org/Review">
                It was a lovely, warm feeling to see my granddad's name here :cry:
                <br />
                <span class="message-details">Posted by Anonymous at 14:58</span>
            </p>
        </section>
    </section>

    <div class="clear"></div>

    <section id="secCommentDetails">
        <label for="subject"><span class="required"></span>&nbsp;Subject:-</label>
        <input type="text" name="subject" value="" id="txtSubject" style="width: 100%;" placeholder="Subject" autocomplete="off" runat="server" required="required" />

        <br />
        <br />

        <label for="txtComment"><span class="required"></span>&nbsp;Comment:-</label>
        <label><small>(Uses <a href="https://emojipedia.org/" target="_blank">Emojipedia shortcodes</a> for emojis)</small></label>
        <%--<input type="text" name="message" id="txtMessage" value="" runat="server" style="width: 100%; vertical-align: text-top;" placeholder="Message" autocomplete="off" />--%>
        <input type="text" name="comment" value="" id="txtComment" style="width: 100%;" placeholder="Comment" autocomplete="off" runat="server" required="required" />
        <%--<asp:TextBox runat="server" AutoCompleteType="None" TextMode="MultiLine" ID="txtMessage" Width="100%" Height="100" Placeholder="Comment" />--%>

        <br />
        <br />

        <div id="commentOptions">
            <div id="UploadImage">
                <%--<asp:FileUpload runat="server" AllowMultiple="false" />--%>

                <label for="messageImage">Add an image</label>

                <br />

                <input id="imgComment" type="file" name="messageImage" accept="image/*" runat="server" />
            </div>

            <br />

            <label><span class="required"></span>&nbsp;Please choose all that apply to your visit today: </label>

            <select id="selOptions" name="messageOptions" multiple="true" runat="server" required="required">
                <option value="FirstTime visitor">First-Time visitor</option>
                <option value="Forces visitor">Forces (current/ex)</option>
                <option value="International visitor">International visitor</option>
                <option value="Repeat visitor">Repeat visitor</option>
                <option value="Organised visitor">Member of an organised visit</option>
                <option value="NMA friend">NMA Friend</option>
                <option value="TRBL member">Royal British Legion member</option>
                <option value="Event visitor">Visitor to an event</option>
            </select>
        </div>

        <br />

        <input type="submit" name="submit" value="Post" class="btn-default" />
    </section>

    <img src="http://placehold.it/150x150" alt="" id="imgFullscreen" />

    <script src="js/Homepage.js"></script>
</asp:Content>

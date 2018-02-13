<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NMA_Wall.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadArea" runat="server">
    <meta name="description" content="" />
    <meta name="keywords" content="Nation Memorial Arboretum; thenma.org.uk" />

    <script src="js/AJAX_Request.js"></script>
    <script>
        GetData("", funtionName);

        function funtionName(xhttp) {
            //xhttp - contains data from app
        }
    </script>

    <script>
        $.getScript("/js/GPS.js", function () {
            // Handle GPS here
            let gps = new GPS();
            var gpspos = gps.getLocation();

            // Undefined
            /*
            alert(
                "Lat: " + gpspos.lat + "\n" +
                "Lon: " + gpspos.lon);
            /**/
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyArea" runat="server">
    <%-- Comment templates --%>
    <section id="comments" style="margin: 0 0; width: auto;" runat="server">
        <section class="comment">
            <p>It was a lovely, warm feeling to see my granddads name here :cry:</p>
            <br />
            <p class="message-details">Posted by Anonymous at 14:58</p>
        </section>

        <hr />

        <section class="comment">
            <p class="comment-removed removed-by-admin">Sorry, this comment has been flagged and removed by an admin</p>
            <br />
            <p class="message-details">Posted by Anonymous at 12:27</p>
        </section>

        <hr />

        <section class="comment">
            <p>
                <img src="img/Comments/1.JPG" alt="Image 01" width="150" height="150" class="image" />
            </p>
            <br />
            <p class="message-details">Posted by Anonymous at 11:32</p>
        </section>

        <hr />
    </section>

    <br />

    <span id="newComment" style="cursor: pointer; text-decoration: underline; color: #a2c617;">Click to add comment</span>

    <br />

    <div class="clear"></div>

    <section id="secCommentDetails" style="display: normal;">
        <span id="hideNewComment" style="cursor: pointer; text-decoration: underline; color: #a2c617; float: right; padding: 5px 10px 0px 0px">Hide</span>

        <br />

        <label for="txtSubject">Subject:-</label>
        <input tabindex="1" type="text" name="subject" id="txtSubject" style="width: 100%;" placeholder="Subject" autocomplete="off" runat="server" />

        <br />
        <br />

        <label for="txtComment"><span class="required"></span>&nbsp;Comment:-</label>
        <label><small>(Uses <a href="https://emojipedia.org/" target="_blank">Emojipedia shortcodes</a> for emojis)</small></label>
        <%--<input type="text" name="message" id="txtMessage" value="" runat="server" style="width: 100%; vertical-align: text-top;" placeholder="Message" autocomplete="off" />--%>
        <input tabindex="2" type="text" name="comment" id="txtComment" style="width: 100%;" placeholder="Comment" autocomplete="off" runat="server" required="required" />
        <%--<asp:TextBox runat="server" AutoCompleteType="None" TextMode="MultiLine" ID="txtMessage" Width="100%" Height="100" Placeholder="Comment" />--%>

        <br />
        <br />

        <div id="commentOptions">
            <div id="UploadImage">
                <label for="fuCommentImage">Add an image</label>

                <asp:FileUpload TabIndex="3" ID="fuCommentImage" runat="server" AllowMultiple="false" />
            </div>

            <br />

            <label><span class="required"></span>&nbsp;Please choose all that apply to your visit today: </label>

            <select tabindex="4" id="selOptions" name="messageOptions" multiple="true" runat="server" required="required">
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

        <input tabindex="5" id="btnSubmit" runat="server" type="submit" name="submit" value="Post" class="btn-default" />
    </section>

    <div class="comment" id="fullscreen_image_container" style="position: static; width: 100%; height: 100%; background-color: rgba(128, 128, 128, 0.5);">
        <span class="close" style="display: none; right: 50px; top: 50px; position: absolute; color: black;">X</span>

        <div style="position: fixed; top: 50%; left: 50%; margin-top: -250px; margin-left: -350px; display: block; margin-right: 35px; width: 700px; height: 500px;">
            <img src="http://placehold.it/700x500" id="imgFullscreen" width="700" height="500" />
        </div>
    </div>

    <script>
        var newComment = $("#newComment");

        $("#secCommentDetails").css("display", "none");
        newComment.css("display", "normal");
    </script>

    <script src="js/Homepage.js"></script>
</asp:Content>

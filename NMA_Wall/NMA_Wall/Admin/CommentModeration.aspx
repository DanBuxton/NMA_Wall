<%@ Page Title="Comment Moderation - National Menorial Arboretum" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CommentModeration.aspx.cs" Inherits="NMA_Wall.Admin.CommentModeration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Title added using the C# Title property of the Page reference --%>
    <style>
        #comments {
            /* Some good looking styles */
            margin: auto;
            width: 100%;
        }

            #comments .commentsRowData, #comments th {
                border: solid 1px black;
                margin: -1px;
                padding: -1px;
            }

            #comments .commentsRow:nth-child(even),
            #comments th {
                background-color: #DDDDDD;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <% var bp = new NMA_Wall.BasePage(); %>
    <span>Welcome: <%=$"{bp.LoggedInUser.Username}" %></span>

    <h1 class="h1">Comment Moderation</h1>

    <section style="align-content: center; width: 100%;" id="comment-mod">
        <% if (currentMessage != null)
            { %>
        <table style="text-align: center;" id="comments">
            <thead>
                <tr id="commentsRow">
                    <% if (Request.IsLocal && NMA_Wall.Global.IsDebug)
                        { %>
                    <th>ID (debugging only)</th>
                    <% }%>
                    <%--<th>Memorial</th>--%>
                    <th>Comment</th>
                    <th>Image</th>
                    <th>Date Added</th>
                    <th>Ok?</th>
                </tr>
            </thead>
            <tbody>
                <%-- Get All unmoderated messages into an array to display --%>
                <tr id="<%=$"{currentMessage.Id}" %>" class="comment commentsRowData">
                    <%
                        if (Request.IsLocal && NMA_Wall.Global.IsDebug)
                        {
                    %>
                    <td class="commentsRowData">
                        <p><%=currentMessage.Id %></p>
                    </td>
                    <%
                        }
                    %>
                    <td class="commentsRowData">
                        <p><%=currentMessage.MessageBody %></p>
                    </td>
                    <td class="commentsRowData">
                        <%
                            if (currentMessage.HasImage || (Request.IsLocal && NMA_Wall.Global.IsDebug))
                            {
                        %>
                        <img src="<%=$@"..\img\Comments\{currentMessage.Id}.jpg" %>" width="150" height="150" class="image" />
                        <%
                            }
                            else
                            {
                        %>
                        <p>No Image</p>
                        <%
                            }
                        %>
                    </td>
                    <td class="commentsRowData">
                        <p><time><%=$"{currentMessage.DateAdded.ToString("D")} {currentMessage.DateAdded.ToString("t")}" %></time></p>
                    </td>
                    <td class="commentsRowData">
                        <%-- RadioButtonList ID = message Id (can't when runat="server") --%>
                        <%-- RadioButtonList renders as a HTML table?? --%>
                        <asp:RadioButtonList ID="rblIsCommentValid" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes" />
                            <asp:ListItem Text="No" Value="No" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </tbody>
        </table>
        <% }
            else
            {
        %>
        <p style="text-align: center;"><b>There aren't any comments to moderate</b></p>
        <% } %>

        <p id="lat"></p>
        <p id="lon"></p>

        <script type="text/javascript">
            $(function () {
                if (navigate.geolocation) {
                    var options = {

                    }

                    navigator.geolocation.getCurrentPosition(showPos, posError, options);

                    function showPos(pos) {
                        var coords = pos.coords;
                        $("#lat").innerHTML = coords.latitude;
                        $("#lon").innerHTML = coords.longitude;
                    }

                    function posError(pos) {
                        alert("Error: " + pos.code);
                    }
                } else {
                    alert("GEO-Location isn't supported on your device");
                }
            });
        </script>

        <br />

        <%--<input id="btnModerateComments" runat="server" type="button" value="Update moderated messages" class="btn-default" style="width: 100%;" />--%>

        <asp:Button ID="btnModerateComments" runat="server" Text="Update moderated messages" CssClass="btn-default" Style="width: 100%;" />
    </section>
</asp:Content>

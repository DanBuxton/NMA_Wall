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
                <%
                    foreach (var message in Messages)
                    {
                %>
                <tr id="<%=$"{message.Id}" %>" class="comment commentsRowData">
                    <%
                        if (Request.IsLocal && NMA_Wall.Global.IsDebug)
                        {
                    %>
                    <td class="commentsRowData">
                        <p><%=message.Id %></p>
                    </td>
                    <%
                        }
                    %>
                    <td class="commentsRowData">
                        <p><%=message.MessageBody %></p>
                    </td>
                    <td class="commentsRowData">
                        <%
                            if (message.HasImage || (Request.IsLocal && NMA_Wall.Global.IsDebug))
                            {
                        %>
                        <img src="<%=$@"..\img\Comments\1.jpg" %>" width="150" height="150" class="image" />
                        <%
                            }
                            else
                            {
                        %>
                        <p>No Image</p>
                        <p><%=$"{message.ImagePath}" %></p>
                        <%
                            }
                        %>
                    </td>
                    <td class="commentsRowData">
                        <p><time><%=$"{message.DateAdded.ToString("D")} {message.DateAdded.ToString("t")}" %></time></p>
                    </td>
                    <td class="commentsRowData">
                        <%-- RadioButtonList ID = message Id (can't when in runat="server") --%>
                        <asp:RadioButtonList ID="Hello" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes" />
                            <asp:ListItem Text="No" Value="No" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <%
                    }
                %>
            </tbody>
        </table>

        <br />

        <%--<input id="btnModerateComments" runat="server" type="button" value="Update moderated messages" class="btn-default" style="width: 100%;" />--%>

        <asp:Button ID="btnModerateComments" runat="server" Text="Update moderated messages" class="btn-default" Style="width: 100%;" />
    </section>
</asp:Content>

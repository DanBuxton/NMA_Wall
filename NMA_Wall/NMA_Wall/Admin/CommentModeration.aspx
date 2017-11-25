<%@ Page Title="Comment Moderation - National Menorial Arboretum" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CommentModeration.aspx.cs" Inherits="NMA_Wall.Admin.CommentModeration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Title added using the C# Title property of the Page reference --%>
    <style>
        table {
            /* Some good looking styles */
            margin: auto;
            width: 100%;
        }

            table td, table th {
                border: solid 1px black;
                margin: -1px;
                padding: -1px;
            }

            table tr:nth-child(even),
            table th {
                background-color: #DDDDDD;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1 class="h1">Comment Moderation</h1>
    <section style="align-content: center; width: 100%;" id="comment-mod">
        <table style="text-align: center;">
            <thead>
                <tr>
                    <% if (Request.IsLocal && false)
                        { %>
                    <th>ID (local)</th>
                    <% }%>
                    <%--<th>Memorial</th>--%>
                    <th>MessageBody</th>
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
                <tr>
                    <%
                        if (Request.IsLocal && false)
                        {
                    %>
                    <td>
                        <p><%=message.Id %></p>
                    </td>
                    <%
                        }
                    %>
                    <td>
                        <p><%=message.MessageBody %></p>
                    </td>
                    <td>
                        <%
                            if (message.HasImage || (Request.IsLocal && false))
                            {
                        %>
                        <img src="<%=$@"{message.ImagePath}" %>" />
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
                    <td>
                        <p><time><%=$"{message.DateAdded.ToString("D")} {message.DateAdded.ToString("t")}" %></time></p>
                    </td>
                    <td>
                        <form>
                            <label>
                                <input type="radio" name="CommentValid" value="Yes" />
                                Yes
                            </label>
                            <br />
                            <label>
                                <input type="radio" name="CommentValid" value="No" />
                                No
                            </label>
                        </form>
                    </td>
                </tr>
                <%
                    }
                %>
            </tbody>
        </table>

        <br />

        <input runat="server" type="button" value="Update moderated messages" class="btn-default" style="width: 100%;" />
    </section>
</asp:Content>

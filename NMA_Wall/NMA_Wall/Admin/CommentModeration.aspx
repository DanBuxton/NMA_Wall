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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="h1">Comment Moderation</h1>
    <section style="align-content: center; height: 100%; width: 100%;" id="comment-mod">
        <table style="text-align: center;">
            <thead>
                <tr>
                    <% if (Request.IsLocal)
                        { %>
                    <th>ID</th>
                    <% }%>
                    <th>Title</th>
                    <th>MessageBody</th>
                    <th>Image</th>
                    <th>Date Added</th>
                    <th>Ok?</th>
                </tr>
            </thead>
            <tbody>
                <%-- Get All unmoderated messages into an array to display --%>
                <%-- NMA_Wall.BO.Message[] messages = DB.MessageGetAwaitingModeration().ToArray(); --%>
                <%--<tr>
                    <%
                        foreach (var message in messages)
                        {
                            if (Request.IsLocal)
                            {
                    %><td><%=message.Id %></td>
                    <%
                            }
                    %><td><%= message.Title %></td>
                    <%
                    %><td><%=message.MessageBody %></td>
                    <%
                    %><td><%=message.Id %></td>
                    <%
                    %><td><%=message.DateAdded %></td>
                    <%
                        }
                    %>
                </tr>--%>
                <tr>
                    <% if (Request.IsLocal)
                        { %>
                    <td>25</td>
                    <% }%>
                    <td>
                        <label>Great Memorial</label>
                    </td>
                    <td>
                        <label>This Memorial is the best</label>
                    </td>
                    <td>
                        <img src="http://placehold.it/100x100" alt="Alternate Text" />
                    </td>
                    <td>
                        <label><%= DateTime.Now.Date.ToShortDateString() %></label>
                    </td>
                    <td>
                        <form action="/" method="post">
                            <label runat="server">
                                Yes<br />
                                <input type="radio" name="name" value="" /></label>
                            <br />
                            <label runat="server">
                                No<br />
                                <input type="radio" name="name" value="" /></label>
                        </form>
                    </td>
                </tr>
                <tr>
                    <% if (Request.IsLocal)
                        { %>
                    <td>26</td>
                    <% }%>
                    <td>
                        <label>Great Memorial</label></td>
                    <td>
                        <label>This Memorial is the best</label>
                    </td>
                    <td>
                        <img src="http://placehold.it/100x100" alt="Alternate Text" />
                    </td>
                    <td>
                        <label><%= DateTime.Now.Date.ToShortDateString() %></label>
                    </td>
                    <td>
                        <label runat="server">
                            Yes<br />
                            <input type="radio" name="name" value="" /></label>
                        <br />
                        <label runat="server">
                            No<br />
                            <input type="radio" name="name" value="" /></label>
                    </td>
                </tr>
            </tbody>
        </table>

        <br />

        <input type="button" name="name" value="Update moderated messages" class="btn-default" style="width: 100%;" />
    </section>
</asp:Content>

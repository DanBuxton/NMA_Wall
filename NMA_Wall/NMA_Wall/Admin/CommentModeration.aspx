<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CommentModeration.aspx.cs" Inherits="NMA_Wall.Admin.CommentModeration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Comment Moderation - National Menorial Arboretum</title>
    <style>
        table {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <table style="text-align: center;">
            <thead>
                <tr>
                    <%
#if DEBUG
                            { %>
                    <th>ID (Development Only)</th>
                    <% }
#endif %>
                    <th>Title</th>
                    <th>MessageBody</th>
                    <th>Image</th>
                    <th>Date Added</th>
                    <th>Ok?</th>
                </tr>
            </thead>
            <tbody>
                <%  %>
                <tr>
                    <%
#if DEBUG
                            { %>
                    <td>ID</td>
                    <% }
#endif %>
                    <td>
                        <label><%  %></label>
                    </td>
                    <td>
                        <label><%  %></label>
                    </td>
                    <td>
                        <label><%  %></label>
                    </td>
                    <td>
                        <label><%  %></label>
                    </td>
                </tr>
                <tr><%
#if DEBUG
                            { %>
                    <td>
                        <label>25</label>
                    </td>
                    <% }
#endif %>
                    <td>
                        <label>Great Memorial</label>
                    </td>
                    <td>
                        <label>
                            This Memorial is the best
                        </label>
                    </td>
                    <td>
                        <img src="http://placehold.it/100x100" alt="Alternate Text" />
                    </td>
                    <td>
                        <label>
                            <%= DateTime.Now.Date.ToShortDateString() %>
                        </label>
                    </td>
                </tr>
                <tr><%
#if DEBUG
                            { %>
                    <td>
                        <label>26</label>
                    </td>
                    <% }
#endif %>
                    
                    <td>
                        <label>Great Memorial</label></td>
                    <td>This Memorial is the best</td>
                    <td>
                        <img src="http://placehold.it/100x100" alt="Alternate Text" />
                    </td>
                    <td><%= DateTime.Now.Date.ToShortDateString() %></td>
                </tr>
            </tbody>
        </table>
    </section>
</asp:Content>

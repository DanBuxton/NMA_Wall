<%@ Page Title="Comment Moderation - National Menorial Arboretum" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CommentModeration.aspx.cs" Inherits="NMA_Wall.Admin.CommentModeration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Title added using the C# Title property of the Page reference --%>
    <style>
        table {
            /* Some good looking styles */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <table style="text-align: center;">
            <thead>
                <tr>
                    <% if (Request.IsLocal)
                        { %>
                    <th>ID</th>
                    <!-- Dev eyes only -->
                    <% }%>
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
                    <% if (Request.IsLocal)
                        { %>
                    <td>ID</td>
                    <!-- Dev eyes only -->
                    <% }%>
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
                <tr>
                    <%
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
                <tr>
                    <%
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

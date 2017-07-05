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
                    <th>ID</th>
                    <th>Title</th>
                    <th>MessageBody</th>
                    <th>Image</th>
                    <th>Date Added</th>
                    <th>Ok?</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <label>25</label></td>
                    <td>
                        <label>Great Memorial</label></td>
                    <td>This Memorial is the best</td>
                    <td>
                        <img src="http://placehold.it/100x100" alt="Alternate Text" />
                    </td>
                    <td><%= DateTime.Now.Date.ToShortDateString() %></td>
                </tr>
                <tr>
                    <td>
                        <label>26</label></td>
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

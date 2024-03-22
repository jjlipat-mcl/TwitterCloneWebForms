<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="TwitterClone.UserPage" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
    <style>
       
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <div class="post-list">
        <div class="profile-info">
            <div class="profile-picture"></div>
            <h2><%= viewingUser.Username %> </h2>
            <hr />
        </div>
        <% foreach (var post in posts) %>
        <% { %>
        <div class="post-container">
            <div class="profile-picture"></div>
            <a href="/UserPage.aspx?username=<%= post.PostedBy %>" class="posted-by"><%= post.PostedBy %></a>
            <p class="posted-on"><%= post.PostedOn.ToString("ddd mm yyyy hh:mm tt") %></p>
            <p class="post-content"><%= post.Content %> </p>
            <div class="post-actions">
                <img src="/Assets/Heart.svg" alt="Like" />
                <img src="/Assets/Comment.svg" alt="Comment" />
                <img src="/Assets/Retweet.svg" alt="Retweet" />
                <img src="/Assets/Share.svg" alt="Share" />
            </div>
        </div>
        <% } %>
    </div>

</asp:Content>

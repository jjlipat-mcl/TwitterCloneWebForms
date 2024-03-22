<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TwitterClone.Default" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
    <style>
    </style>
</asp:Content>

<asp:Content ID="DefaultMainContent" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <h2>Home</h2>
    <div class="create-post-container">
        <asp:TextBox ID="postContent" runat="server" placeholder="What's on your mind?" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="submitButton" runat="server" Text="Post" OnClick="submitButton_Click" />
    </div>
    <div class="post-list">
        <% foreach (var post in feedPosts) %>
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

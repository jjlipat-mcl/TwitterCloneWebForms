<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultRepeater.aspx.cs" Inherits="TwitterClone.DefaultRepeater" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
    <style>
        .create-post-container {
            display: flex;
            flex-direction: column;
        }

            .create-post-container textarea {
                margin-bottom: 8px;
                border-radius: 16px;
                font-size: 16px;
                padding: 12px;
            }

            .create-post-container input[type="submit"] {
                align-self: flex-end;
                width: 150px;
                padding: 10px;
                border-radius: 16px;
                background-color: deepskyblue;
                border: 0px;
                font-size: 16px;
                color: white;
            }
    </style>
</asp:Content>

<asp:Content ID="DefaultMainContent" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <h2>Home</h2>
    <div class="create-post-container">
        <asp:TextBox ID="postContent" runat="server" placeholder="What's on your mind?" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="submitButton" runat="server" Text="Post" OnClick="submitButton_Click" />
    </div>
    <div class="post-list">
        <asp:Repeater ID="feedPostsRepeater" runat="server">
            <ItemTemplate>
                <div class="post-container">
                    <div class="profile-picture"></div>
                    <a href="/UserPage.aspx?username=<%# Eval("postedBy")  %>" class="posted-by"><%# Eval("PostedBy") %></a>
                    <p class="posted-on"><%# Eval("PostedOn")   %></p>
                    <p class="post-content"><%# Eval("Content") %> </p>
                    <div class="post-actions">
                        <img src="/Assets/Heart.svg" alt="Like" />
                        <img src="/Assets/Comment.svg" alt="Comment" />
                        <img src="/Assets/Retweet.svg" alt="Retweet" />
                        <img src="/Assets/Share.svg" alt="Share" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


    </div>

</asp:Content>

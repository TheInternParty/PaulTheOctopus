<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataGatheringTesting.aspx.cs" Inherits="PaulTheOctopusGame.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="GetTeams" 
    Width="85px" />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="GetMatchesList" />
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
        style="margin-top: 0px" Text="AddMatches" Width="89px" />
    <asp:TextBox ID="TextBox1" runat="server" Width="54px"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" Width="37px"></asp:TextBox>
    <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 4px" Width="36px"></asp:TextBox>
</asp:Content>

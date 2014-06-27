<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Completed.aspx.cs" Inherits="PaulTheOctopusGame.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" Height="194px" 
        Width="481px" HorizontalAlign="Center">
        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>

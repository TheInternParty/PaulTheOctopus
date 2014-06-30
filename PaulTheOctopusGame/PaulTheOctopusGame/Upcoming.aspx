<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upcoming.aspx.cs" Inherits="PaulTheOctopusGame.Upcoming" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" 
        OnRowCommand="GridView1_RowCommand"  DataKeyNames="matchid" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Team1 score">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='0'></asp:TextBox>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Team2 score">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='0'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Save">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("matchId") + ";" +Eval("matchId")%>'
                        CommandName="Add" Text="Save"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </asp:Content>

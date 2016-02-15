<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Caching._Default" %>

<%@ Register Src="~/UserControls/TodayUserControl.ascx" TagPrefix="Cache" TagName="TodayUserControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Cache</h1>
        <asp:Label class="lead" runat="server" ID="Label"></asp:Label>
    </div>
    <Cache:TodayUserControl runat="server" ID="TodayUserControl" />
</asp:Content>

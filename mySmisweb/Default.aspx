<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Default.aspx.cs" Inherits="mySmisweb._Default" %>


<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <%-- DXCOMMENT: Configure ASPxGridView control --%>
<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="True" DataSourceID="SqlDataSource1" ClientInstanceName="ASPxGridView1"
    Width="100%">
    <SettingsPager PageSize="50" />
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
    <%-- DXCOMMENT: Configure ASPxGridView's columns in accordance with datasource fields --%>
    <Columns>
        <dx:GridViewDataColumn>
        </dx:GridViewDataColumn>
        <dx:GridViewDataColumn>
        </dx:GridViewDataColumn>
        <dx:GridViewDataColumn>
        </dx:GridViewDataColumn>
        <dx:GridViewDataColumn>
        </dx:GridViewDataColumn>
        <dx:GridViewDataColumn>
        </dx:GridViewDataColumn>
    </Columns>
</dx:ASPxGridView>


<%-- DXCOMMENT: Configure your datasource for ASPxGridView --%>
<asp:SqlDataSource ID="SqlDataSource1" runat="server">
</asp:SqlDataSource>


</asp:Content>
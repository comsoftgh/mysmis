<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="documentviewer.aspx.cs" Inherits="mySmis.documentviewer" %>

<%@ Register Assembly="DevExpress.XtraReports.v16.1.Web, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        REPORT VIEWER
    </div>
    <%--<dx:ASPxHyperLink ID="goBack" runat="server" Visible="false" Text="<<Back" />--%>
    <dx:ASPxMenu ID="mMain" Visible="false" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                                    <Items>
                                                        <dx:MenuItem Name="mitBack" Text="<<Back"></dx:MenuItem>
                                                        
                                                    </Items>
                                                </dx:ASPxMenu>
    <br />
    <dx:ASPxDocumentViewer SettingsReportViewer-ShouldDisposeReport="false" ID="docViewer" Visible="false" runat="server"></dx:ASPxDocumentViewer>
    <iframe id="docViewers"  width="1000" height="500"  runat="server" Visible="false"></iframe>
</asp:Content>


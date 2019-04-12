<%@ Page Title="" Language="C#" MasterPageFile="~/admintutor.Master" AutoEventWireup="true" CodeBehind="admintutordashboard.aspx.cs" Inherits="mySmis.admintutordashboard" %>

<%@ Register Assembly="DevExpress.Dashboard.v16.1.Web, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        DASHBOARD
    </div>

    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="~/dashboard/studentfeesdashboard.xml" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" Height="600px" Width="100%" ></dx:ASPxDashboardViewer>


    
</asp:Content>


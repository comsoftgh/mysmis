<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="adminfeesrevenuedashboard.aspx.cs" Inherits="mySmis.adminfeesrevenuedashboard" %>

<%@ Register Assembly="DevExpress.Dashboard.v16.1.Web, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle">
                                        FEES REVENUE DASHBOARD
                                    </div>
     <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" DashboardTheme="Light" runat="server" DashboardSource="~/dashboard/studentfeesdashboard.xml" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" Height="580px" Width="100%" ></dx:ASPxDashboardViewer>

                                </asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="adminstudentpopulationdashboard.aspx.cs" Inherits="mySmis.adminstudentpopulationdashboard" %>
<%@ Register Assembly="DevExpress.Dashboard.v16.1.Web, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle">
                                        STUDENT POPULATION DASHBOARD
                                    </div>
    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" DashboardTheme="Light" runat="server" DashboardSource="~/dashboard/studentdemography.xml" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" Height="580px" Width="100%" ></dx:ASPxDashboardViewer>

                                </asp:Content>


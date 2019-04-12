<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="mySmis.events" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register assembly="DevExpress.XtraScheduler.v16.1.Core, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        EVENTS
                                    </div>
    <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="SqlDataSource1" ClientIDMode="AutoID" Start="2015-11-14" >
        <Views>
            <WeekView Enabled="false"></WeekView>
            <FullWeekView Enabled="true">
            </FullWeekView>
        </Views>

    </dxwschs:ASPxScheduler>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                                </asp:Content>


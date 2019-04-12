<%@ Page Title="My Audit Log - mySmis MIS" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myauditlog.aspx.cs" Inherits="mySmis.myauditlog" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle">MY AUDIT LOG
                                    </div>
    
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <dx:ASPxHiddenField ID="hiddenMode" runat="server"></dx:ASPxHiddenField>
            <asp:UpdatePanel ID="UpdatePanelStaff" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <dx:ASPxGridView ID="gvAuditLog" runat="server" AutoGenerateColumns="False" KeyFieldName="LogId" Width="98%" EnableCallBacks="False" Font-Names="Tahoma" Font-Size="11px">

                            <SettingsSearchPanel Visible="True" />

                            <Columns>
                                
                                
                                <dx:GridViewDataTextColumn FieldName="LogId" VisibleIndex="1" Visible="false" ReadOnly="True" Width="30px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="UserId" VisibleIndex="1" Visible="false" ReadOnly="True" Width="80px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="LogEvent" VisibleIndex="2" Width="140px" Caption="Activity" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Details" Visible="false" VisibleIndex="3" ReadOnly="false" Width="250" Caption="Details">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="UserName" VisibleIndex="4" ReadOnly="True" Width="100px" Caption="Username">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FName" Caption="User Full Name" VisibleIndex="5" ReadOnly="True" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="LogTime" Caption="Activity Date" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy HH:mm:ss" VisibleIndex="1" Width="120px">
                                    <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy HH:mm:ss">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                
                            </Columns>
                            <Settings ShowFilterRow="True" VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" EnableCustomizationWindow="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSize="15">
                            </SettingsPager>
                            <SettingsEditing Mode="Inline" />
                            
                        </dx:ASPxGridView>
                </ContentTemplate>
            </asp:UpdatePanel>
                          </asp:Content>




<%@ Page Title="Audit Log - Mantra MIS" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="auditlog.aspx.cs" Inherits="Mantra.auditlog" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >AUDIT LOG
                                    </div>
    <div style="width:98%;float:right;height:auto;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <dx:ASPxHiddenField ID="hiddenMode" runat="server"></dx:ASPxHiddenField>
            <asp:UpdatePanel ID="UpdatePanelStaff" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <dx:ASPxGridView ID="gvAuditLog" runat="server" AutoGenerateColumns="False" KeyFieldName="LogId" Width="100%" EnableCallBacks="False" Font-Names="Tahoma" Font-Size="11px">

                            <SettingsSearchPanel Visible="True" />

                            <Columns>
                                
                                
                                <dx:GridViewDataTextColumn FieldName="LogId" VisibleIndex="1" Visible="false" ReadOnly="True" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="UserId" VisibleIndex="1" Visible="false" ReadOnly="True" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="LogEvent" VisibleIndex="2"  Caption="ACTIVITY" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Details" VisibleIndex="3" ReadOnly="True"  Caption="DETAILS">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="UserName" VisibleIndex="4" ReadOnly="True"  Caption="USERNAME">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FName" Caption="NAME" VisibleIndex="5" ReadOnly="True" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="LogTime" Caption="ACTIVITY DATE" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy HH:mm:ss" VisibleIndex="24" >
                                    <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy HH:mm:ss">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                
                            </Columns>
                            <Settings ShowFilterRow="True" />
                            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" EnableCustomizationWindow="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSize="20">
                            </SettingsPager>
                            <SettingsEditing Mode="Inline" />
                            
                        </dx:ASPxGridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
                                </asp:Content>



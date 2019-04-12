﻿<%@ Page Title="" MasterPageFile="~/main.Master" Language="C#" AutoEventWireup="true" CodeBehind="studentlist.aspx.cs" Inherits="mySmis.studentlist" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                   <div class="Separator Pagetitle" >
                                        LIST OF STUDENTS
                                    </div>
    
            <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="True" ShowPopOutImages="True">
                <Items>
                    <dx:MenuItem Name="mitExportxls" Enabled="false" Text="Export">
                        <Image IconID="export_exporttoxlsx_16x16">
                        </Image>
                    </dx:MenuItem>
                    <dx:MenuItem Name="mitReport" Enabled="false" Text="Report">
                        <Image IconID="reports_report_16x16">
                        </Image>
                    </dx:MenuItem>
                </Items>
            </dx:ASPxMenu>
            <br />
                    <dx:ASPxGridView ID="gvStudents" runat="server" AutoGenerateColumns="False" KeyFieldName="UserId" Width="100%" EnableCallBacks="False" OnStartRowEditing="gvStudents_StartRowEditing" OnSelectionChanged="gvStudents_SelectionChanged" OnCommandButtonInitialize="gvStudents_CommandButtonInitialize">

                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" Width="10%"  Caption=" #" ShowClearFilterButton="True" ShowEditButton="true" ShowSelectButton="true"/>
                            <dx:GridViewDataTextColumn FieldName="IndexNo" VisibleIndex="1" Caption="INDEX NO." ReadOnly="True" >
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="UserId" VisibleIndex="1" Caption="USER ID" Visible="false" ReadOnly="True" >
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="2" Caption="TITLE" ReadOnly="True" Visible="false" >
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="FNames" VisibleIndex="3"  Caption="FIRST NAME" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="SName" VisibleIndex="4" ReadOnly="True"  Caption="SURNAME">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ONames" VisibleIndex="4" ReadOnly="True"  Caption="OTHER NAMES">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Gender" VisibleIndex="4" ReadOnly="True"  Caption="GENDER">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="xAge" VisibleIndex="4" ReadOnly="True"  Caption="AGE">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Mobile" ReadOnly="True" Visible="false" VisibleIndex="6" Caption="MOBILE">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="13" Caption="Email Address" Visible="false" >
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Tel" ReadOnly="True" Visible="false" VisibleIndex="6" Caption="TEL">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PostAdd" Visible="false" VisibleIndex="16" Caption="Postal Address" ReadOnly="True" >
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Admissiondate" Caption="ADMISSION DATE" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" VisibleIndex="24" >
                                <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="DateCreated" Visible="false" Caption="DATE ADDED" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" VisibleIndex="25" >
                                <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>

                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" EnableCustomizationWindow="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                        <SettingsPager PageSize="20">
                        </SettingsPager>
                        <SettingsEditing Mode="Inline" />

                        <Settings ShowFilterRow="True" VerticalScrollBarMode="Auto" VerticalScrollableHeight="400"/>
                        <SettingsSearchPanel Visible="True" />
                        <SettingsCommandButton>
                            <EditButton Text="Profile"/>
                            <SelectButton Text="View/Edit" ButtonType="Link"/>
                        </SettingsCommandButton>
                        
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="gvStudents" ExportedRowType="All"></dx:ASPxGridViewExporter>
                
                    
                </ContentTemplate>
            </asp:UpdatePanel>

                                </asp:Content>




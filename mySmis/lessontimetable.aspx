<%@ Page Language="C#" MasterPageFile="~/main.Master" Title="mySmis - Timetable" AutoEventWireup="true" CodeBehind="lessontimetable.aspx.cs" Inherits="mySmis.lessontimetable" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        COURSE/SUBJECT TIMETABLE
                                    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
           <div class="appWorkspace">
            <table style="width: 100%;">
                    <tr>

                        <td class="auto-style40">
                            <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                
                    <tr>

                        <td>

                            <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="false" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="50%" AutoResizeWithContainer="true" AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                <Columns>

                                    <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                    <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />

                                </Columns>

                                <GridViewProperties>
                                    <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                    <SettingsPager NumericButtonCount="3" />
                                    <Settings ShowFilterRow="true" />
                                </GridViewProperties>
                                <ClearButton Visibility="True" DisplayMode="Always">
                                </ClearButton>
                            </dx:ASPxGridLookup>


                        </td>
                       
                    </tr>
                <tr>
                    <td style="height:10px;"></td>
                </tr>
                <tr>
                    <td>
            <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                 <Items>
                    
                    <dx:MenuItem Name="mitReport" Enabled="false" Text="Report">
                        <Image IconID="reports_report_16x16">
                        </Image>
                    </dx:MenuItem>
                     <dx:MenuItem Name="mitExportxls" Visible="false" Enabled="false" Text="Export">
                        <Image IconID="export_exporttoxlsx_16x16">
                        </Image>
                    </dx:MenuItem>
                </Items>
            </dx:ASPxMenu>
                    </td>
                </tr>

                    

                </table>
           </div>
                <br />
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="dgTimetable" EnableCallBacks="false" AutoGenerateColumns="False" >
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" Visible="false" />
                    <dx:GridViewDataTextColumn Name="c2" FieldName="LessDay" Caption="DAY" Visible="false" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xLessonCode" Caption="CODE" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xLessonTitle" Caption="TITLE" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="LessTime" Caption="PERIOD" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xVenueName" Caption="VENU" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xTutorName" Caption="TUTOR" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn GroupIndex="0" Name="LessDay" FieldName="LessDay" Caption="DAY" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>

                </Columns>
                
                <SettingsPager PageSize="15" Visible="False">
                </SettingsPager>
                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" AutoExpandAllGroups="True" />
                <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False" />
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgProgram" FileName="Course_Subject Scheduling"></dx:ASPxGridViewExporter>
        </ContentTemplate>
    </asp:UpdatePanel>
    
                                </asp:Content>







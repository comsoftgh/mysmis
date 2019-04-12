<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="examinationscheduling.aspx.cs" Inherits="mySmis.examinationscheduling" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        COURSE/SUBJECT SCHEDULING
    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                 <Items>
                    <dx:MenuItem Name="mitNew" Enabled="false" Text="New">
                        <Image IconID="actions_add_16x16">
                        </Image>
                    </dx:MenuItem>
                    <dx:MenuItem Name="mitCancel" Enabled="false" Text="Cancel">
                        <Image IconID="actions_cancel_16x16">
                        </Image>
                    </dx:MenuItem>
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
            <div id="divLessons" runat="server" visible="false" class="appWorkspace">
               
                <table style="width: 100%;">
                    <tr>

                        <td class="auto-style40">
                            <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>

                        <td>

                            <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged" IncrementalFilteringMode="StartsWith">
                                <Columns>

                                    <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="ACADEMIC BATCH" />
                                    <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="CLASS SIZE" />

                                </Columns>

                                <GridViewProperties>
                                    <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                    <SettingsPager NumericButtonCount="3" />
                                    <Settings ShowFilterRow="true" />
                                </GridViewProperties>
                                <ClearButton Visibility="True">
                                </ClearButton>
                            </dx:ASPxGridLookup>


                        </td>

                    </tr>


                    <tr>

                        <td>

                            <dx:ASPxGridView ID="gvClassLessons" EnableCallBacks="false" AutoGenerateColumns="False" KeyFieldName="ID" runat="server" Width="100%" OnCommandButtonInitialize="gvClassLessons_CommandButtonInitialize" OnCellEditorInitialize="gvClassLessons_CellEditorInitialize"
                                SettingsBehavior-AllowFocusedRow="true" SettingsEditing-Mode="Inline"
                                OnRowUpdating="gvClassLessons_RowUpdating" SettingsBehavior-AllowSelectSingleRowOnly="true" >
                                <Columns>
                                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" SelectAllCheckboxMode="Page" Width="10%">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Name="c2" FieldName="xLessonTitle" Caption="SUBJECT/LESSON" VisibleIndex="1" ReadOnly="True" Width="25%">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="LessonID" Visible="false" FieldName="LessonID" Name="clLessonID" VisibleIndex="4">
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="ModuleID" Visible="false" FieldName="ModuleID" Name="clModID" VisibleIndex="5">
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="ClassID" Visible="false" FieldName="ClassID" Name="clClassID" VisibleIndex="6">
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="Bgroup" Visible="false" FieldName="Bgroup" Name="clBgroup" VisibleIndex="6">
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn Caption="LESSON DAY" FieldName="xLessDay" Name="clLessonDay" VisibleIndex="3" Width="15%">
                                        <PropertiesComboBox TextField="LValue" ValueField="LValue" Width="100%" />
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbLessonDay" OnValidation="cmbLessonDay_Validation" Width="150%"
                                                OnInit="cmbLessonDay_Init" OnUnload="cmbLessonDay_Unload" runat="server" SelectionMode="Single" TextField="LValue" ValueField="LValue">

                                                <Columns>
                                                    <dx:ListBoxColumn FieldName="LValue" Caption="Time Periods" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn Caption="TIME PERIOD" FieldName="xLessTime" Name="clLessonTime" VisibleIndex="3" Width="15%">
                                        <PropertiesComboBox TextField="LValue" ValueField="LValue" Width="100%" />
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbclLessonTime" OnValidation="cmbclLessonTime_Validation" Width="150%" OnInit="cmbclLessonTime_Init" OnUnload="cmbclLessonTime_Unload" runat="server" SelectionMode="Single" TextField="LValue" ValueField="LValue">

                                                <Columns>
                                                    <dx:ListBoxColumn FieldName="LValue" Caption="Time Periods" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn Caption="Tutor" FieldName="xTutorName" Name="clLessonTutor" VisibleIndex="3" Width="15%">
                                        <PropertiesComboBox TextField="TutorName" ValueField="TutorID" Width="100%" />
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbTutorList" OnValidation="cmbTutorList_Validation" Width="150%"
                                                OnInit="cmbTutorList_Init" OnUnload="cmbTutorList_Unload" runat="server" SelectionMode="Single" TextField="TutorName" ValueField="TutorID">
                                                <Columns>
                                                    <dx:ListBoxColumn FieldName="TutorName" Caption="Available Tutors" />
                                                    <dx:ListBoxColumn FieldName="TutorID" Visible="false" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>
                                    
                                    <dx:GridViewDataComboBoxColumn Caption="VENU" FieldName="xVenueName" Name="lessonVenus" VisibleIndex="3" Width="20%" >
                                        <PropertiesComboBox TextField="xVenueName" ValueField="ID" Width="100%" />
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="lessonVenuslist" OnValidation="lessonVenuslist_Validation" Width="140%" KeyFieldName="ID" DisplayFormatString="{0}" TextFormatString="{0}"
                                                OnInit="lessonVenuslist_Init" OnUnload="lessonVenuslist_Unload" runat="server" SelectionMode="Single" TextField="RoomName" ValueField="ID">
                                                <Columns>
                                                    <dx:ListBoxColumn FieldName="RoomName" Caption="Available Rooms" />
                                                    <dx:ListBoxColumn FieldName="ID" Visible="false" />
                                                    <dx:ListBoxColumn FieldName="Size" Visible="true" Caption="Size"  />
                                                    <dx:ListBoxColumn FieldName="xVenuName" Visible="true" Caption="Building / Block" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>

                                </Columns>
                                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                <SettingsPopup>
                                    <EditForm MinWidth="600" Modal="true"  />
                                </SettingsPopup>
                                <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                <SettingsEditing Mode="Inline">
                                </SettingsEditing>
                                <SettingsDataSecurity AllowInsert="False" />
                            </dx:ASPxGridView>

                        </td>
                    </tr>

                </table>
            </div>
            <div id="div_error" runat="server" class="div_error" visible="false"></div>

            <br />
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="dgProgram" EnableCallBacks="False" AutoGenerateColumns="False" OnRowDeleting="dgProgram_RowDeleting" OnStartRowEditing="dgProgram_StartRowEditing" OnCommandButtonInitialize="dgProgram_CommandButtonInitialize">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="false" ShowDeleteButton="True" />
                    <dx:GridViewDataTextColumn Name="c2" FieldName="LessDay" Caption="DAY" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="ID" Visible="false" Caption="ID" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xLessonTitle" Caption="COURSE/SUBJECT" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="LessTime" Caption="PERIOD" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xVenueName" Caption="VENU" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xTutorName" Caption="TUTOR" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn GroupIndex="0" Name="ClassSche" FieldName="xClassSche" Caption=":" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>

                </Columns>
                

                <SettingsPager PageSize="15"></SettingsPager>
                <SettingsDetail ExportMode="All" />
                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                <SettingsDataSecurity AllowInsert="False" />

            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgProgram" FileName="Course_Subject Scheduling"></dx:ASPxGridViewExporter>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="batchmangemment.aspx.cs" Inherits="mySmis.batchmangemment" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        MANAGE BATCHES
                                    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
    <dx:ASPxGridView ID="gvBatches" EnableCallBacks="true" EnableRowsCache="true" AutoGenerateColumns="False" KeyFieldName="ID" runat="server" Width="100%" OnCommandButtonInitialize="gvBatches_CommandButtonInitialize"  OnRowUpdating="gvBatches_RowUpdating" OnBatchUpdate="gvBatches_BatchUpdate"  SettingsBehavior-AllowSelectSingleRowOnly="true">
                                <SettingsSearchPanel Visible="True" />
                                <Columns>
                                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" SelectAllCheckboxMode="Page" Width="10%">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Name="c2" FieldName="Title" Caption="BATCHES" VisibleIndex="1" ReadOnly="True" Width="50%">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn GroupIndex="0" Caption="ACADEMIC YEAR"  FieldName="AcademicYear" Name="clBgroup" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataComboBoxColumn Caption="TIMETABLE" FieldName="xTimetable" Name="cTimetable" VisibleIndex="3" Width="10%">
                                        <PropertiesComboBox TextField="xTimetable" ValueField="Timetable" ValueType="System.Int32" />
                                        
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbTimetable"   OnValidation="cmbTimetable_Validation" OnUnload="cmbTimetable_Unload"  Width="180%"  runat="server" SelectionMode="Single" TextField="xTimetable" ValueField="Timetable">
                                                <Items>
                                                    <dx:ListEditItem Text="Completed" Value="1" />
                                                    <dx:ListEditItem Text="Not Completed" Value="0" />
                                                </Items>
                                                
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn Caption="REGISTRATION" FieldName="xRegistration" Name="cRegistration" VisibleIndex="3" Width="10%">
                                        <PropertiesComboBox TextField="xRegistration" ValueField="Registration" ValueType="System.Int32" />
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbRegistration"  OnValidation="cmbRegistration_Validation" OnUnload="cmbRegistration_Unload"  Width="180%"  runat="server" SelectionMode="Single" TextField="xRegistration" ValueField="Registration">
                                                <Items>
                                                    <dx:ListEditItem Text="Completed" Value="1" />
                                                    <dx:ListEditItem Text="Not Completed" Value="0" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn Caption="TEST SCORES" FieldName="xIA" Name="cTestscores" VisibleIndex="3" Width="10%">
                                        <PropertiesComboBox TextField="xIA" ValueField="IA" ValueType="System.Int32" />
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbTestscores"   OnValidation="cmbTestscores_Validation" OnUnload="cmbTestscores_Unload"  Width="180%"  runat="server" SelectionMode="Single" TextField="xIA" ValueField="IA">
                                                <Items>
                                                    <dx:ListEditItem Text="Completed" Value="1" />
                                                    <dx:ListEditItem Text="Not Completed" Value="0" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>
                                    
                                    <dx:GridViewDataComboBoxColumn Caption="EXAMS SCORES" FieldName="xExams" Name="cExamsscores" VisibleIndex="3" Width="10%" >
                                        <PropertiesComboBox TextField="xExams" ValueField="Exams" ValueType="System.Int32" />
                                        
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbExamsscore"   OnValidation="cmbExamsscore_Validation" OnUnload="cmbExamsscore_Unload"  Width="180%"  runat="server" SelectionMode="Single" TextField="xExams" ValueField="Exams">
                                                <Items>
                                                    <dx:ListEditItem Text="Completed" Value="1" />
                                                    <dx:ListEditItem Text="Not Completed" Value="0" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>

                                </Columns>
                                <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                <SettingsEditing Mode="Batch">
                   
                                    <BatchEditSettings EditMode="Cell" />
                                </SettingsEditing>
                                <SettingsDataSecurity AllowInsert="False" />
        <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                            </dx:ASPxGridView>

            </ContentTemplate>
        </asp:UpdatePanel>
                                </asp:Content>


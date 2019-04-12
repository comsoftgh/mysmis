<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="academicsinterimassessment.aspx.cs" Inherits="mySmis.academicsinterimassessment" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        INTERIM ASSESSMENT
                                    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            

                                <asp:UpdatePanel ID="upFeesBatches" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                      

                                        <div runat="server" class="appWorkspace">
                                            <table style="width: 100%;">
                                                
                                                <tr>

                                                    <td>

                                                        <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="true" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%"  AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                                            <Columns>

                                                                <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="ClassID" Visible="false" Caption="ClassID" />
                                                            </Columns>

                                                            <GridViewProperties>
                                                                <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                                                <SettingsPager NumericButtonCount="3" />
                                                                <Settings ShowFilterRow="true" ColumnMinWidth="300" />
                                                            </GridViewProperties>
                                                            <ValidationSettings>
                                                                <RequiredField IsRequired="true" />
                                                                <ErrorFrameStyle Border-BorderColor="LightPink"></ErrorFrameStyle>
                                                            </ValidationSettings>
                                                            <ClearButton Visibility="True">
                                                            </ClearButton>
                                                        </dx:ASPxGridLookup>
                                                        

                                                    </td>

                                                </tr>
                                                <tr>

                                                    <td class="auto-style40">
                                                        <dx:ASPxComboBox runat="server" ID="cmbLessons" NullText="Choose Lesson/Course ..." AutoPostBack="true" Enabled="false" OnValueChanged="cmbLessons_ValueChanged" >
                                                            <ValidationSettings>
                                                                <RequiredField IsRequired="true" />
                                                                <ErrorFrameStyle Border-BorderColor="LightPink"></ErrorFrameStyle>
                                                            </ValidationSettings>
                                                            <ClearButton Visibility="True"> </ClearButton>
                                                        </dx:ASPxComboBox>
                                                    </td>

                                                </tr>
                                            </table>
                                            </div>
                                        <br />
                                       
                                        <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvStudents" EnableCallBacks="False"  AutoGenerateColumns="False" OnCellEditorInitialize="gvStudents_CellEditorInitialize" OnCommandButtonInitialize="gvStudents_CommandButtonInitialize" OnBatchUpdate="gvStudents_BatchUpdate" >
                                                <SettingsSearchPanel Visible="True" />
                                                <Columns>
                                                    
                                                    <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="LESSON CODE" FieldName="xLessCode" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="LESSON/COURSE" FieldName="xLesson" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataSpinEditColumn Caption="TEST SCORE" FieldName="TestMarks" Name="testScore" VisibleIndex="4" >
                                                       <PropertiesSpinEdit MinValue="0" MaxLength="2"></PropertiesSpinEdit>
                                                    </dx:GridViewDataSpinEditColumn>
                                                    
                                                    
                                                </Columns>
                                            
                                                <SettingsPager PageSize="25">
                                                </SettingsPager>
                                                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                                <SettingsDataSecurity AllowInsert="False" AllowDelete="False" />
                                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                            <SettingsEditing Mode="Batch" />
                                            </dx:ASPxGridView>
                                        <dx:ASPxGridViewExporter ID="gridExp" runat="server" GridViewID="dgEvent">
                                        </dx:ASPxGridViewExporter>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                           
            
        </ContentTemplate>
    </asp:UpdatePanel>
                                </asp:Content>


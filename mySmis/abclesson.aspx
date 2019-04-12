<%@ Page Language="C#" Title="" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="abclesson.aspx.cs" Inherits="mySmis.abclesson" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                       COURSES/SUBJECTS
                                    </div>
   
                <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                    </asp:ScriptManager>
                    <dx:ASPxMenu ID="mMainProgram" runat="server" OnItemClick="mMainProgram_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                <Items>
                                    <dx:MenuItem Name="mitNew" Enabled="false" Text="New">
                                        <Image IconID="actions_add_16x16">
                                        </Image>
                                    </dx:MenuItem>
                                    <%--<dx:MenuItem Name="mitCancel" Enabled="false" Text="Cancel">
                        <Image IconID="actions_cancel_16x16">
                        </Image>
                    </dx:MenuItem>--%>
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
                    <div id="divLessons" runat="server"  visible="false" class="appWorkspace"> 
                        <table style="width: 80%;">
                            <tr>
                                <td class="auto-style25" style="width:20%">&nbsp;</td>
                                <td class="auto-style40">
                                    <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style26" style="text-align:right;"> Program :</td>
                                <td>
                                 
                                    <dx:ASPxGridLookup ID="cmbProgram" runat="server" KeyFieldName="ID" NullText="Choose..." SelectionMode="Single" TextFormatString="{0} - ({1})" Width="70%" >
                                        <Columns>
                                            <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="PROGRAM" Width="200px" /> 
                                            <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ModuleName" Caption="MODULE" Width="150px" />
                                            
                                        </Columns>
                                       
                                        <GridViewProperties>
                                            <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" />
                                            <SettingsPager NumericButtonCount="3" />
                                            <Settings ShowFilterRow="true" />
                                        </GridViewProperties>
                                        <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"></ValidationSettings>
                                    </dx:ASPxGridLookup>

                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style26" style="text-align:right;">Course/Subject :</td>
                                <td>
                                    <dx:ASPxTextBox ID="txtName" NullText="Name of Subject/Course" runat="server" Width="60%">
                                        <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"></ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style26" style="text-align:right;">Code :</td>
                                <td>
                                    <dx:ASPxTextBox ID="txtCode" NullText="Lesson/Subject/Course Code" runat="server" Width="30%">
                                        <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"></ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td class="auto-style26" style="text-align:right;">Credit Hours :</td>
                                <td>
                                    <dx:ASPxSpinEdit MinValue="1" MaxValue="10" MaxLength="1" NullText="Credit Hours" ID="spnCredit" runat="server" Width="30%">
                                        <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"></ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style26" style="text-align:right;">Type :</td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbType" NullText="Type of Subject/Course" runat="server" Width="30%">
                                        <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"></ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style26" style="text-align:right; vertical-align:top;">Syllabus :</td>
                                <td>
                                    <dx:ASPxMemo ID="txtDesc" NullText="Subject/Coures content" runat="server" Width="100%" Height="100px">
                                        
                                    </dx:ASPxMemo>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25"></td>
                                <td class="auto-style38">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="auto-style24">
                                                <dx:ASPxButton ID="btnSaveLesson" runat="server"  EnableTheming="True"  Text="Save" OnClick="btnSaveLesson_Click" >
                                                     <Image IconID="save_save_16x16"></Image> 
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btnCancel" runat="server" EnableTheming="True" Text="Cancel" OnClick="btnCancel_Click">
                                            <Image IconID="actions_cancel_16x16"></Image>
                                        </dx:ASPxButton>
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                   
                    <br />
                     <dx:ASPxGridView KeyFieldName="ID" OnCommandButtonInitialize="dgProgram_CommandButtonInitialize" runat="server" Width="1100px" ID="dgProgram"  EnableCallBacks="False" AutoGenerateColumns="False" OnRowDeleting="dgProgram_RowDeleting" OnStartRowEditing="dgProgram_StartRowEditing" >
                         <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True"/>
                            <dx:GridViewDataTextColumn Name="Code" FieldName="Code" Caption="CODE" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="Title" FieldName="Title" Caption="COURSE/SUBJECT" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="Description" Visible="false" FieldName="Description" Caption="DESCRIPTION" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="Credit" FieldName="Credit" Caption="CREDIT HOURS" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="Credit" FieldName="Type" Caption="TYPE" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn GroupIndex="0" Name="ClassName" FieldName="ClassName" Caption=":" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <GroupSummary>
                                 <dx:ASPxSummaryItem FieldName="Title" DisplayFormat="Number :{0}" SummaryType="Count" />
                        </GroupSummary>
                        
                        <SettingsPager PageSize="30" />
                        <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                        <SettingsDataSecurity AllowInsert="False" />
                      <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                    </dx:ASPxGridView>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
                <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgProgram" FileName="Courses or Subjects List">
                </dx:ASPxGridViewExporter>
            
                                </asp:Content>





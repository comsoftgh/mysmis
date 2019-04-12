<%@ Page Language="C#" Title="" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="classScheduler.aspx.cs" Inherits="mySmis.classScheduler" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        ACADEMIC BATCH SCHEDULING
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
            <div id="divLessons" runat="server" visible="false" class="appWorkspace">
                
                <table style="width: 80%;">
                    <tr>
                        <td class="auto-style25" style="width: 25%;">&nbsp;</td>
                        <td class="auto-style40">
                            <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                            <dx:ASPxTextBox ID="txtModuleID" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                            <dx:ASPxTextBox ID="txtClassID" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26" style="text-align: right;">Program/Level<i class="required">*</i> :</td>
                        <td>

                            <dx:ASPxGridLookup ID="cmbProgram" runat="server" NullText="Choose Program/Level" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False">
                                <Columns>

                                    <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Program/Level" />
                                    <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ModuleName" Caption="School/Department" />

                                </Columns>

                                <GridViewProperties>
                                    <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                    <SettingsPager NumericButtonCount="3" />
                                    <Settings ShowFilterRow="true" />
                                </GridViewProperties>
                            </dx:ASPxGridLookup>


                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26" style="text-align: right;">Title :</td>
                        <td>
                            <dx:ASPxTextBox ID="txtDesc" NullText="Batch Title/Name" runat="server" Width="60%" ReadOnly="true">
                                <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26" style="text-align: right;">Academic Term<i class="required">*</i> :</td>
                        <td>
                            <dx:ASPxComboBox ID="cmbTerms" NullText="Choose..." runat="server" Width="30%">
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26" style="text-align: right;">Academic Year<i class="required">*</i> :</td>
                        <td>
                            <dx:ASPxTextBox ID="txtAcademicYear" NullText="eg. 2016/2017" runat="server" Width="30%">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26" style="text-align: right;">Grading System <i class="required">*</i>:</td>
                        <td>
                            <dx:ASPxComboBox ID="cmbGradSystem" NullText="Choose..." runat="server" Width="30%" >
                                <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True" >
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26" style="text-align: right;">Class Size<i class="required">*</i> :</td>
                        <td>
                            <dx:ASPxSpinEdit ID="spnSize" runat="server" Width="20%" MaxValue="10000" MinValue="1">
                                <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                </ValidationSettings>
                            </dx:ASPxSpinEdit>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25"></td>
                        <td class="auto-style38">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="auto-style1" colspan="2">
                                        <dx:ASPxButton ID="btnSaveClassSchedule" runat="server" Image-IconID="" EnableTheming="True" Text="Save" OnClick="btnSaveClassSchedule_Click">              
                                            <Image IconID="save_save_16x16"></Image>                   
                                        </dx:ASPxButton>
                                    
                                        <dx:ASPxButton ID="btnCancel" runat="server" EnableTheming="True" Text="Cancel" OnClick="btnCancel_Click">
                                            <Image IconID="actions_cancel_16x16"></Image>
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="div_error" runat="server" class="div_error" visible="false"></div>
            <br />
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="dgProgram" EnableCallBacks="False" OnCommandButtonInitialize="dgProgram_CommandButtonInitialize" AutoGenerateColumns="False" OnRowDeleting="dgProgram_RowDeleting" OnStartRowEditing="dgProgram_StartRowEditing">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Name="c1" VisibleIndex="0" Width="10%" ShowEditButton="True" ShowDeleteButton="True" />
                    <dx:GridViewDataTextColumn Name="c2" FieldName="Title" Caption="ACADEMIC BATCH" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="Term" Caption="ACADEMIC TERM" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn  Name="c2" Width="10%" FieldName="AcademicYear" Caption="ACADEMIC YEAR" VisibleIndex="2" GroupIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn  Name="c2" Width="10%" FieldName="xBgsid" Caption="GRADING SYSTEM" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" Width="10%" FieldName="ClassSize" Caption="CLASS SIZE" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="CreatedDate" Caption="Created Date" VisibleIndex="5" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy">
                        <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>

                </Columns>
                <SettingsPager PageSize="30">
                </SettingsPager>
                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                <Settings ShowFilterRow="True" VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="AcademicYear" Visible="true" />
                </GroupSummary>
            </dx:ASPxGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgEvent" FileName="Class Schedules">
    </dx:ASPxGridViewExporter>

</asp:Content>




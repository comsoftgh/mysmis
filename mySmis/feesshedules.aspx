<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="feesshedules.aspx.cs" Inherits="mySmis.feesshedules" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        FEES SCHEDULE
    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <dx:ASPxPageControl EnableHierarchyRecreation="false" ID="memberTabs" runat="server" ActiveTabIndex="0" Height="100%" Width="98%" Font-Size="11px">
                <TabPages>
                    <dx:TabPage Text="Batch Fees Scheduling">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl1" runat="server" SupportsDisabledAttribute="True">

                                <asp:UpdatePanel ID="upFeesBatches" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                            <Items>
                                                <dx:MenuItem Name="mitNew" Enabled="false" Text="New">
                                                    <Image IconID="actions_add_16x16">
                                                    </Image>
                                                </dx:MenuItem>
                                                <dx:MenuItem Name="mitCancel" Enabled="true" Text="Cancel">
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
                                        <div id="div_FeesBatch" runat="server" visible="false" class="appWorkspace">
                                      
                                            <table style="width: 100%;">
                                                <tr>

                                                    <td class="auto-style40">
                                                        <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                                                        </dx:ASPxTextBox>
                                                    </td>

                                                </tr>
                                                <tr>

                                                    <td>

                                                        <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                                            <Columns>

                                                                <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="ClassID" Visible="false" Caption="ClassID" />
                                                            </Columns>

                                                            <GridViewProperties>
                                                                <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                                                <SettingsPager NumericButtonCount="3" />
                                                                <Settings ShowFilterRow="true" />
                                                            </GridViewProperties>
                                                            <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"> </ValidationSettings>
                                                            <ClearButton Visibility="True" DisplayMode="Always">
                                                            </ClearButton>
                                                        </dx:ASPxGridLookup>


                                                    </td>

                                                </tr>


                                                <tr>

                                                    <td>

                                                        <dx:ASPxGridView ID="gvFeesBatch" EnableCallBacks="false" AutoGenerateColumns="False" KeyFieldName="ID" runat="server" Width="100%" SettingsBehavior-AllowFocusedRow="true" SettingsEditing-Mode="Batch"
                                                            SettingsBehavior-AllowSelectSingleRowOnly="true" OnBatchUpdate="gvFeesBatch_BatchUpdate" OnCommandButtonInitialize="gvFeesBatch_CommandButtonInitialize">
                                                            <Columns>


                                                                <dx:GridViewDataTextColumn Name="c2" FieldName="Title" Caption="FEE CATEGORY" VisibleIndex="2" ReadOnly="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="#" FieldName="ID" ReadOnly="true" Name="clLessonID" VisibleIndex="1">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataSpinEditColumn Caption="FEE VALUE" PropertiesSpinEdit-NumberType="Float" PropertiesSpinEdit-DecimalPlaces="2" PropertiesSpinEdit-MinValue="0" PropertiesSpinEdit-MaxValue="100000000" FieldName="xFeevalue" Width="20%" Name="clBgroup" VisibleIndex="3">
                                                                </dx:GridViewDataSpinEditColumn>
                                                            </Columns>
                                                            <SettingsEditing Mode="Batch" />
                                                            <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                                                            <SettingsPager PageSize="15"></SettingsPager>
                                                        </dx:ASPxGridView>

                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                        <br />
                                        <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvBatchFees" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="gvBatchFees_CommandButtonInitialize">
                                            <Columns>
                                                <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowDeleteButton="True" ShowEditButton="True" />
                                                <dx:GridViewDataTextColumn Name="c2" FieldName="xTitle" Caption="FEE TYPE" VisibleIndex="1" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="xFeeId" Visible="false" FieldName="xFeeId" Name="clLessonID" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="FEE VALUE" FieldName="Feevalue" Name="clBgroup" VisibleIndex="6">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn GroupIndex="0" Caption="BATCH" FieldName="xBatchTitle" Name="clBgroup" VisibleIndex="6">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <GroupSummary>
                                                <dx:ASPxSummaryItem FieldName="Feevalue" DisplayFormat="TOTAL AMOUNT : {0}" SummaryType="Sum" />
                                            </GroupSummary>

                                            <SettingsPager PageSize="15">
                                            </SettingsPager>
                                            <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                                            <SettingsDataSecurity AllowInsert="False" AllowEdit="true" />
                                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                        </dx:ASPxGridView>
                                        <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgProgram" FileName="Programs"></dx:ASPxGridViewExporter>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>

                    <dx:TabPage Text="Individual Fees Scheduling">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl2" runat="server" SupportsDisabledAttribute="True">

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <dx:ASPxGridLookup ID="cmbStudentBatch" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbStudentBatch_ValueChanged">
                                            <Columns>

                                                <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                                <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                                <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                            </Columns>

                                            <GridViewProperties>
                                                <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                                <SettingsPager NumericButtonCount="3" />
                                                <Settings ShowFilterRow="true" />
                                            </GridViewProperties>
                                            <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"> </ValidationSettings>
                                            <ClearButton Visibility="True" DisplayMode="Always">
                                            </ClearButton>
                                        </dx:ASPxGridLookup>
                                            <br />
                                        <div id="div_students" runat="server" visible="false" class="appWorkspace">
                                        
                                            <table style="width: 100%;">
                                                <tr>

                                                    <td class="auto-style40">
                                                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Visible="False" Width="50px" Text="0">
                                                        </dx:ASPxTextBox>
                                                    </td>

                                                </tr>

                                                <tr>

                                                    <td>

                                                        <dx:ASPxGridView ID="gvIndividualFee" EnableCallBacks="true" AutoGenerateColumns="False" KeyFieldName="ID" runat="server" Width="100%" SettingsBehavior-AllowFocusedRow="true" SettingsEditing-Mode="Batch"
                                                            SettingsBehavior-AllowSelectSingleRowOnly="true" OnBatchUpdate="gvIndividualFee_BatchUpdate" OnCommandButtonInitialize="gvIndividualFee_CommandButtonInitialize">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Name="c2" FieldName="Title" Caption="FEE TYPE" VisibleIndex="2" ReadOnly="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="#" FieldName="ID" ReadOnly="true" Name="clLessonID" VisibleIndex="1">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-NumberType="Float" PropertiesSpinEdit-DecimalPlaces="2" PropertiesSpinEdit-MinValue="0" PropertiesSpinEdit-MaxValue="100000000"  Caption="FEE VALUE" FieldName="xFeevalue" Width="20%" Name="clBgroup" VisibleIndex="3">
                                                                </dx:GridViewDataSpinEditColumn>
                                                            </Columns>
                                                            <SettingsEditing Mode="Batch" />
                                                            <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                                                            <SettingsPager PageSize="15"></SettingsPager>
                                                        </dx:ASPxGridView>

                                                    </td>
                                                </tr>

                                            </table>


                                            <br />
                                            <dx:ASPxGridView KeyFieldName="UserId" runat="server" Width="100%" ID="gvStudents" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="gvStudents_CommandButtonInitialize">
                                                <SettingsSearchPanel Visible="True" />
                                                <Columns>
                                                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" ShowClearFilterButton="True" />
                                                    <dx:GridViewDataTextColumn Name="c2" FieldName="IndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="GENDER" FieldName="Gender" Name="clBgroup" VisibleIndex="6">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="ADMISSION DATE" FieldName="Admissiondate" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" Name="clBgroup" VisibleIndex="6">
                                                        <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>

                                                <SettingsPager PageSize="15">
                                                </SettingsPager>
                                                <Settings ShowFilterRow="True" />
                                                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                                <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False" />

                                            </dx:ASPxGridView>
                                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="dgEvent">
                                            </dx:ASPxGridViewExporter>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                </TabPages>
            </dx:ASPxPageControl>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


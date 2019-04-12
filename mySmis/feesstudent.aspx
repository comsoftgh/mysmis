<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="feesstudent.aspx.cs" Inherits="mySmis.feesstudent" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        STUDENT'S FEES
    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>


            <asp:UpdatePanel ID="upFeesBatches" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                        <Items>
                            <dx:MenuItem Name="mitExportxls" Enabled="false" Text="Export">
                                <Image IconID="export_exporttoxlsx_16x16">
                                </Image>
                            </dx:MenuItem>

                            <dx:MenuItem Name="mitReportOne" Enabled="false" Text="Report (Student)">
                                <Image IconID="reports_report_16x16">
                                </Image>
                            </dx:MenuItem>
                            <dx:MenuItem Name="mitReportAll" Enabled="false" Text="Report (All Students)">
                                <Image IconID="reports_report_16x16">
                                </Image>
                            </dx:MenuItem>
                        </Items>
                    </dx:ASPxMenu>
                    <br />
                    <div class="appWorkspace" >
                    <table style="width: 100%;">
                        <tr>

                            <td class="auto-style40">
                                <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                                </dx:ASPxTextBox>
                            </td>

                        </tr>
                        <tr>

                            <td>

                                <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="true" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
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
                                    <ClearButton Visibility="True" DisplayMode="Always"></ClearButton>
                                    <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true">
                                        <RequiredField IsRequired="true" />

                                    </ValidationSettings>
                                    <ClearButton Visibility="True">
                                    </ClearButton>
                                </dx:ASPxGridLookup>


                            </td>

                        </tr>


                        <tr>

                            <td></td>
                        </tr>

                    </table>
                    </div>
                    <br />



                </ContentTemplate>
            </asp:UpdatePanel>
            <dx:ASPxGridView ID="gvStudenFess" ClientInstanceName="gvStudenFess" EnableCallBacks="false" runat="server" KeyFieldName="UserId" Width="100%" OnStartRowEditing="gvStudenFess_StartRowEditing">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="true" />
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="STUDENT ID" VisibleIndex="1" ReadOnly="True">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="STUDENT NAME" Visible="true" FieldName="xFullName" Name="clLessonID" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="UserId" Visible="false" Caption="STUDENT ID" VisibleIndex="2" ReadOnly="True">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvBatchFees" EnableCallBacks="False" AutoGenerateColumns="False" OnBeforePerformDataSelect="gvBatchFees_BeforePerformDataSelect" OnCommandButtonInitialize="gvBatchFees_CommandButtonInitialize">
                            
                            <Columns>
                                <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowDeleteButton="True" />
                                <dx:GridViewDataTextColumn Name="c2" FieldName="xFeeTitle" Caption="FEE TYPE" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="FeeCateId" Visible="false" FieldName="xFeeId" Name="clLessonID" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="FEE VALUE" FieldName="xFeevalue" Name="clBgroup" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>

                            </Columns>
                            
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="xFeevalue" DisplayFormat="TOTAL FEES DUE : {0}" SummaryType="Sum" />
                            </TotalSummary>

                            <SettingsPager PageSize="15">
                            </SettingsPager>
                            <Settings ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
                            <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                            <SettingsDataSecurity AllowInsert="False" AllowEdit="False" />

                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
                <SettingsCommandButton>
                    <EditButton Text="Fees Slip" ></EditButton>
                </SettingsCommandButton>
                <SettingsDetail ShowDetailRow="true" />
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgEvent" FileName="">
            </dx:ASPxGridViewExporter>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


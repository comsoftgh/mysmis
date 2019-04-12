<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="feespaymentlist.aspx.cs" Inherits="mySmis.feespaymentlist" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        FEES PAYMENTS LIST
    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <dx:ASPxMenu ID="mMain" runat="server" AllowSelectItem="True" AutoPostBack="True" ShowPopOutImages="True" OnItemClick="mMain_ItemClick">
                <Items>

                    <dx:MenuItem Name="mitExport" Text="Export">
                        <Image IconID="export_exporttoxlsx_16x16"></Image>
                    </dx:MenuItem>
                    <dx:MenuItem Name="mitReport" Text="Report">
                        <Image IconID="reports_report_16x16"></Image>
                    </dx:MenuItem>
                </Items>
            </dx:ASPxMenu>
            <br />
            <div class="appWorkspace">
            <table style="width: 100%;">
                
                <tr>
                    <td class="table_tr_left" style="width:120px;"> Academic Batch :</td>
                    <td class="table_tr_right">

                        <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                            <Columns>

                                <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="ACADEMIC BATCH" />
                                <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="CLASS SIZE" />
                                <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="ClassID" Visible="false" Caption="ClassID" />
                            </Columns>

                            <GridViewProperties>
                                <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                <SettingsPager NumericButtonCount="3" />
                                <Settings ShowFilterRow="true" />
                            </GridViewProperties>
                            <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" SetFocusOnError="true">
                                <RequiredField IsRequired="true" />

                            </ValidationSettings>
                            <ClearButton Visibility="True" DisplayMode="Always">
                            </ClearButton>
                        </dx:ASPxGridLookup>


                    </td>

                </tr>

            </table>
                </div>
            <br />
            <dx:ASPxGridView ID="gvPayments" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" EnableCallBacks="False" Font-Names="Tahoma" Font-Size="11px" OnStartRowEditing="gvPayments_StartRowEditing" OnCommandButtonInitialize="gvPayments_CommandButtonInitialize" OnSelectionChanged="gvPayments_SelectionChanged" OnRowDeleting="gvPayments_RowDeleting">

                <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true" />

                <SettingsSearchPanel Visible="True" />

                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="false" ShowSelectButton="true" ShowDeleteButton="false" Width="10%" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="xIndexNo" Caption="STUDENT ID" Visible="true" ReadOnly="True" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="xFullName" Caption="STUDENT NAME" ReadOnly="True" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="PayType" Caption="PAYMENT TYPE" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ReceiptNo" Caption="RECEIPT NO." VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Payvalue" Caption="AMMOUNT" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="PaidBy" Caption="PAID IN BY" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Cleared" Caption="CASHED" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DateCreated" Caption="Payment Date" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" VisibleIndex="7">
                        <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy"></PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>

                </Columns>
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="Payvalue" DisplayFormat="TOTAL PAYMENTS : {0}" SummaryType="Sum" />
                </TotalSummary>
                <Settings ShowFilterRow="True" ShowFooter="true" />
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" EnableCustomizationWindow="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                <SettingsPager PageSize="25">
                </SettingsPager>
                <SettingsEditing Mode="Inline" />
                <SettingsCommandButton>
                    
                    <SelectButton Text="Receipt"></SelectButton>
                    
                </SettingsCommandButton>
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="gvInventoryItems" ExportedRowType="All"></dx:ASPxGridViewExporter>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


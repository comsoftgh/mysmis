<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="libbookpublisher.aspx.cs" Inherits="mySmis.libbookpublisher" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle">
                                        BOOK PUBLISHERS
                                    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <dx:ASPxMenu ID="mMain" runat="server" AllowSelectItem="True" OnItemClick="mMain_ItemClick" AutoPostBack="True" ShowPopOutImages="True">
                <Items>
                    <dx:MenuItem Name="mitNew" Enabled="false" Text="New">
                        <Image IconID="actions_add_16x16">
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
            <div id="divClasses" runat="server" visible="false" class="appWorkspace">
                <table style="width: 80%;">
                    <tr>
                        <td class="table_tr_left">Company Name :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtFName" NullText="First Name" runat="server" Width="70%">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                   
                    <tr>
                        <td class="table_tr_left">Country :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbNationality" NullText="Choose..." runat="server" IncrementalFilteringMode="StartsWith">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left">
                            <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>

                        </td>
                        <td class="table_tr_right">

                            <dx:ASPxButton ID="btnSaveClasses" runat="server" Text="Save" OnClick="btnSaveClasses_Click">
                                <Image IconID="save_save_16x16"></Image>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click">
                                <Image IconID="actions_cancel_16x16"></Image>
                            </dx:ASPxButton>


                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="dgAuthor" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="dgAuthor_CommandButtonInitialize" OnRowDeleting="dgAuthor_RowDeleting" OnStartRowEditing="dgAuthor_StartRowEditing">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" />
                    <dx:GridViewDataTextColumn Name="AuthorName" FieldName="PubName" Caption="COMPANY's NAME" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="Country" FieldName="Country" Caption="COUNTRY" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="xNumBooks" FieldName="xNumBooks" Caption="NUMBER OF BOOKS" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="Title" SummaryType="Count" />
                </GroupSummary>

                <SettingsPager PageSize="30"></SettingsPager>
                <SettingsDetail ExportMode="All" />
                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                <SettingsDataSecurity AllowInsert="False" />
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
            </dx:ASPxGridView>

            <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgAuthor" FileName="List of Book Publishers"></dx:ASPxGridViewExporter>
        </ContentTemplate>
    </asp:UpdatePanel>
                                </asp:Content>


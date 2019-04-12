<%@ Page Language="C#" Title="" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="abcprogram.aspx.cs" Inherits="mySmis.abcprogram" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        SCHOOLS/DEPARTMENTS
    </div>

    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <dx:ASPxMenu ID="mMainProgram" runat="server" OnItemClick="mMainProgram_ItemClick" AllowSelectItem="True" AutoPostBack="True" ShowPopOutImages="True">
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
            <div id="divProgram" runat="server" visible="false" class="appWorkspace">
                <table style="width: 80%;">
                    <tr>
                        <td class="table_tr_left">&nbsp;</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left" style="width: 120px;">School/Department :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtName" runat="server" Width="70%">
                                <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"></ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left" style="text-align: right;">Description :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtDesc" runat="server" Width="70%">
                                <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25"></td>
                        <td class="auto-style38">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="auto-style24">
                                        <dx:ASPxButton ID="btnSaveProgram" runat="server" EnableTheming="True" Text="Save" OnClick="btnSaveProgram_Click">
                                            <Image IconID="save_save_16x16"></Image>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btnCancel" runat="server" EnableTheming="True" Text="Cancel" OnClick="btnCancel_Click">
                                            <Image IconID="actions_cancel_16x16"></Image>
                                        </dx:ASPxButton>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            
            <br />

            <dx:ASPxGridView KeyFieldName="ModuleID" runat="server" Width="100%" ID="dgProgram" EnableCallBacks="false" AutoGenerateColumns="False" OnCommandButtonInitialize="dgProgram_CommandButtonInitialize" OnRowDeleting="dgProgram_RowDeleting" OnStartRowEditing="dgProgram_StartRowEditing">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" />
                    <dx:GridViewDataTextColumn Name="c2" FieldName="ModuleName" Caption="SCHOOL/DEPARTMENT" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="Description" Caption="DESCRIPTION" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>

                </Columns>
                <SettingsPager PageSize="15"></SettingsPager>
                <SettingsDetail ExportMode="All" />
                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                <SettingsDataSecurity AllowInsert="False" />
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400"/>
            </dx:ASPxGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgProgram" FileName="Schools or Department List"></dx:ASPxGridViewExporter>

</asp:Content>






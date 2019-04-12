<%@ Page Language="C#" Title="" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="abcclass.aspx.cs" Inherits="mySmis.abcclass" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        PROGRAMS/LEVELS
    </div>

    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <dx:ASPxMenu ID="mMainProgram" runat="server" OnItemClick="mMainProgram_ItemClick" AllowSelectItem="True" AutoPostBack="True" ShowPopOutImages="True">
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
                        <td class="table_tr_left" >&nbsp; asjcjasdjdfffffcc</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left">School/Department :</td>
                        <td class="table_tr_right">

                            <dx:ASPxComboBox TextField="ModuleName" DisplayFormatString="{0}" NullText="Choose..." TextFormatString="{0}" ValueField="ModuleID" ID="cmbProgram" runat="server" Width="100%" ValueType="System.Int32">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Program" FieldName="ModuleName" Width="60px" />
                                </Columns>
                                <ClearButton DisplayMode="OnHover">
                                </ClearButton>
                                <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true" ErrorText="*">
                                    
                                </ValidationSettings>
                            </dx:ASPxComboBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left">Program/Level :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtName" runat="server" Width="70%">
                                <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left">Description :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtDesc" runat="server" Width="70%">
                                <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left"></td>
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
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="1100px" ID="dgProgram" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="dgProgram_CommandButtonInitialize" OnRowDeleting="dgProgram_RowDeleting" OnStartRowEditing="dgProgram_StartRowEditing">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" />
                    <dx:GridViewDataTextColumn Name="Title" FieldName="Title" Caption="PROGRAM/LEVEL" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="Description" FieldName="Description" Caption="DESCRIPTION" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn GroupIndex="0" Name="ProgramName" FieldName="ModuleName" Caption=":" VisibleIndex="3">
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

            <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgProgram" FileName="Programs"></dx:ASPxGridViewExporter>
        </ContentTemplate>
    </asp:UpdatePanel>
    

</asp:Content>









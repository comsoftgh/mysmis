<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="libbookborrowing.aspx.cs" Inherits="mySmis.libbookborrowing" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        BORROW BOOK 
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
                <table style="width: 100%;">
                    <tr>


                        <td class="table_tr_left">Student/Staff :</td>
                        <td class="table_tr_right" colspan="3">
                            <dx:ASPxComboBox ID="cmbSearcUser" runat="server" AutoPostBack="True" CallbackPageSize="10" DropDownRows="10" DropDownStyle="DropDown" EnableCallbackMode="True" FilterMinLength="2" Font-Size="10pt" Height="16px" IncrementalFilteringMode="Contains" TextFormatString="{0} - {1}" ValueField="UserId" Width="70%" OnItemRequestedByValue="cmbSearcUser_ItemRequestedByValue" OnItemsRequestedByFilterCondition="cmbSearcUser_ItemsRequestedByFilterCondition" >
                                <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="xIndexNo" Width="60px" />
                                    <dx:ListBoxColumn Caption="Full Name" FieldName="xFullName" Width="250px" />
                                    <dx:ListBoxColumn Caption="Other Info" FieldName="xContactInfo" Width="300px" />
                                </Columns>
                                
                            </dx:ASPxComboBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">ISBN :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtISBN" ReadOnly="true" MaxLength="25" NullText="ISBN" runat="server" Width="60%">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td class="table_tr_left">Title :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtTitle" ReadOnly="true" NullText="Book Title" runat="server" Width="100%">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>


                        <td class="table_tr_left">Subtitle :</td>
                        <td class="table_tr_right" colspan="3">
                            <dx:ASPxTextBox ID="txtSubtitle" ReadOnly="true" NullText="Book Subtitle" runat="server" Width="100%">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Author :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbAuthor" ReadOnly="true" Width="60%" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith" ValueType="System.Int32">
                                <ClearButton DisplayMode="OnHover">
                                </ClearButton>
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td class="table_tr_left">Publisher :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbPublisher" ReadOnly="true" Width="60%" NullText="Choose..." runat="server" IncrementalFilteringMode="StartsWith" ValueType="System.Int32">
                                <ClearButton DisplayMode="OnHover">
                                </ClearButton>
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
                        <td class="table_tr_right" colspan="3">

                            <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click">
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
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="1100px" ID="dgBook" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="dgBook_CommandButtonInitialize" OnStartRowEditing="dgBook_StartRowEditing">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowClearFilterButton="True" />
                    <dx:GridViewDataTextColumn Name="BookISBN" FieldName="BookISBN" Caption="ISBN" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="BookTitle" FieldName="BookTitle" Caption="TITLE" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="SubTitle" FieldName="SubTitle" Caption="SUBTITLE" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="AuthorName" FieldName="AuthorName" Caption="AUTHOR" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="PubName" FieldName="PubName" Caption="PUBLISHER" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="BookQty" FieldName="BookQty" Caption="QTY." VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="xNumBooks" FieldName="xNumBooks" Caption="NO. AVAILABLE" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsCommandButton>
                    <EditButton Text="Issue This Book"></EditButton>
                </SettingsCommandButton>
                <SettingsPager PageSize="30"></SettingsPager>
                <SettingsDetail ExportMode="All" />
                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                <SettingsDataSecurity AllowInsert="False" />
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" ShowFilterRow="True" />
            </dx:ASPxGridView>

            <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgAuthor" FileName="List of Books"></dx:ASPxGridViewExporter>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


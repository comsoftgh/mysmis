<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="libbookcataloguing.aspx.cs" Inherits="mySmis.libbookcataloguing" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle">
                                        BOOK CATALOGUING
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
                        <td class="table_tr_left">ISBN :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtISBN" MaxLength="25" NullText="ISBN" runat="server" Width="60%">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                         <td class="table_tr_left">Author :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbAuthor" Width="60%" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith" ValueType="System.Int32">
                                <ClearButton DisplayMode="OnHover">
                                </ClearButton>
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left">Publisher :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbPublisher" Width="60%" NullText="Choose..." runat="server" IncrementalFilteringMode="StartsWith" ValueType="System.Int32">
                                <ClearButton DisplayMode="OnHover">
                                </ClearButton>
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                    
                        <td class="table_tr_left">No. Of Pages :</td>
                        <td class="table_tr_right">
                            <dx:ASPxSpinEdit ID="spinNoPages" runat="server">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxSpinEdit>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Title :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtTitle" NullText="Book Title" runat="server" Width="100%">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>

                        <td class="table_tr_left">Subtitle :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="txtSubtitle" NullText="Book Subtitle" runat="server" Width="100%">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    
                    
                    <tr>
                        <td class="table_tr_left">Book Copy : 
                        </td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbCopy" OnValueChanged="cmbCopy_ValueChanged" AutoPostBack="true" Width="60%" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*" />
                                <Items>
                                    <dx:ListEditItem Text="Hard Copy" Value="Hard Copy" />
                                    <dx:ListEditItem Text="Electronic" Value="Electronic" />
                                </Items>
                            </dx:ASPxComboBox>
                            <asp:FileUpload ID="fileUp" AllowMultiple="false" Visible="false" runat="server"></asp:FileUpload>
                        </td>
                        <td class="table_tr_left">Description :</td>
                        <td class="table_tr_right">
                            <dx:ASPxMemo ID="momDescription" runat="server" Rows="4" Columns="40" Width="100%">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>
                            </dx:ASPxMemo>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="table_tr_left">Block :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbBlock" AutoPostBack="True" Width="60%" OnValueChanged="cmbBlock_ValueChanged" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith" ValueType="System.Int32">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*"></ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td class="table_tr_left">Shelve :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbShelve" AutoPostBack="true" Enabled="false" Width="60%" OnValueChanged="cmbShelve_ValueChanged" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith" ValueType="System.Int16">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*"></ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Stack Column :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="cmbStack" AutoPostBack="true" Enabled="False" Width="60%" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith" ValueType="System.Int32">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*"></ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td class="table_tr_left">Quantity :</td>
                        <td class="table_tr_right">
                            <dx:ASPxSpinEdit ID="spinQty" runat="server">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*"></ValidationSettings>
                            </dx:ASPxSpinEdit>
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
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="1100px" ID="dgAuthor" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="dgAuthor_CommandButtonInitialize" OnRowDeleting="dgAuthor_RowDeleting" OnStartRowEditing="dgAuthor_StartRowEditing">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" ShowClearFilterButton="True" />
                    <dx:GridViewDataTextColumn Name="BookISBN" FieldName="BookISBN" Caption="ISBN" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="BookTitle"  FieldName="BookTitle" Caption="TITLE" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="SubTitle" FieldName="SubTitle" Caption="SUBTITLE" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="AuthorName"  FieldName="AuthorName" Caption="AUTHOR" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="PubName"  FieldName="PubName" Caption="PUBLISHER" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="BookPages" FieldName="BookPages" Caption="PAGES" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                </Columns>
                
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


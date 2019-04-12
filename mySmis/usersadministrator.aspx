<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="usersadministrator.aspx.cs" Inherits="mySmis.usersadministrator" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        ACCESS AND PRIVILLAGES
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="div_permissions" runat="server" visible="false">
                <br />
                <table style="width: 60%;">
                    <tr>
                        <td style="width: 120px;"></td>
                        <td class="auto-style40">
                            <dx:ASPxTextBox ID="txtstaffId" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 120px;text-align:right;">Access Level :</td>
                        <td>
                            <dx:ASPxComboBox ID="cmbMainMenu" ValueField="ID" Width="60%" AutoPostBack="True" runat="server" OnValueChanged="cmbMainMenu_ValueChanged">
                                <Columns>
                                    <dx:ListBoxColumn FieldName="Title" Caption="MENU ACCESS" Visible="true" />
                                    <dx:ListBoxColumn FieldName="Menu" Visible="false" />
                                    <dx:ListBoxColumn FieldName="ID" Visible="false" />
                                </Columns>
                                <ClearButton Visibility="True">
                                </ClearButton>

                            </dx:ASPxComboBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvPrivillages" EnableCallBacks="false" AutoGenerateColumns="False" OnCellEditorInitialize="gvPrivillages_CellEditorInitialize" OnCommandButtonInitialize="gvPrivillages_CommandButtonInitialize" OnBatchUpdate="gvPrivillages_BatchUpdate">
                                <Columns>

                                    <dx:GridViewDataTextColumn Caption="#" FieldName="ID" Visible="true" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="SUBMENU" FieldName="Title" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTokenBoxColumn Caption="PRIVILLAGES" FieldName="xActivity" Name="xActivity" VisibleIndex="4" ReadOnly="false">
                                        <PropertiesTokenBox AllowCustomTokens="false" ValueField="LValue" TextField="LValue" ValueSeparator=";" TextSeparator=","></PropertiesTokenBox>
                                    </dx:GridViewDataTokenBoxColumn>

                                </Columns>

                                <SettingsPager PageSize="10">
                                </SettingsPager>
                                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                <SettingsDataSecurity AllowInsert="False" AllowDelete="False" />

                                <SettingsEditing Mode="Batch" />
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="float: right;">
                            <dx:ASPxMenu ID="mMainPrivilage" runat="server" OnItemClick="mMainPrivilage_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                <Items>

                                    <dx:MenuItem Name="mitCancel" Text="Cancel"></dx:MenuItem>

                                </Items>
                            </dx:ASPxMenu>

                        </td>
                    </tr>

                </table>
            </div>
</ContentTemplate>
        </asp:UpdatePanel>
            
            
            <asp:UpdatePanel runat="server" ID="UpPrivillages" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="div_editpermissions" runat="server" visible="false">
                <table  style="width:60%">
                    <tr>
                        <td style="width: 120px; text-align:right;">Name :</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvEditpermissions" EnableCallBacks="true" AutoGenerateColumns="False" OnCellEditorInitialize="gvEditpermissions_CellEditorInitialize" OnCommandButtonInitialize="gvEditpermissions_CommandButtonInitialize" OnRowUpdating="gvEditpermissions_RowUpdating" OnStartRowEditing="gvEditpermissions_StartRowEditing" OnRowDeleting="gvEditpermissions_RowDeleting" >
                                <Columns>
                                     <dx:GridViewCommandColumn Width="15%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" />
                                    <dx:GridViewDataTextColumn Caption="#" FieldName="ID" Visible="false" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn Caption="ACCESS" FieldName="MainMenu" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="ACCESS" FieldName="SubMenu" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTokenBoxColumn Caption="PRIVILLAGES" FieldName="Activity" Name="Activity" VisibleIndex="4" ReadOnly="false">
                                        <PropertiesTokenBox AllowCustomTokens="false" ValueField="LValue" TextField="LValue" ValueSeparator=";" TextSeparator=","></PropertiesTokenBox>
                                    </dx:GridViewDataTokenBoxColumn>

                                </Columns>

                                <SettingsPager PageSize="15">
                                </SettingsPager>
                                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                <SettingsDataSecurity AllowInsert="true" />
                                <SettingsCommandButton>
                                    <EditButton Text="Edit"></EditButton>
                                    <DeleteButton Text="Delete"></DeleteButton>
                                </SettingsCommandButton>
                                <SettingsEditing Mode="Inline" />
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="float: right;">
                            <dx:ASPxMenu ID="mMaineditpermissions" runat="server" OnItemClick="mMaineditpermissions_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                <Items>

                                    <dx:MenuItem Name="mitCancel" Text="Cancel"></dx:MenuItem>

                                </Items>
                            </dx:ASPxMenu>

                        </td>
                    </tr>
                </table>
            </div>
            <br />

            <dx:ASPxGridView KeyFieldName="UserId" runat="server" Width="100%" ID="gvStaffUsers" EnableCallBacks="false"  AutoGenerateColumns="False" OnCommandButtonInitialize="gvStaffUsers_CommandButtonInitialize" OnRowDeleting="gvStaffUsers_RowDeleting" OnStartRowEditing="gvStaffUsers_StartRowEditing" >
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn  Width="15%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" />
                    <dx:GridViewDataTextColumn Name="c2" FieldName="UserId" Caption="USER ID" Visible="false" VisibleIndex="1" ReadOnly="True">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="UserName" Caption="USERNAME" VisibleIndex="2" ReadOnly="True">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DATE CREATED" FieldName="DateCreated" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" Name="clLessonID" VisibleIndex="5" ReadOnly="True">
                        <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView KeyFieldName="ID"  runat="server" Width="100%" ID="gvStaffPermission" OnBeforePerformDataSelect="gvStaffPermission_BeforePerformDataSelect" EnableCallBacks="true" AutoGenerateColumns="False">

                            <Columns>
                                
                                    
                                <dx:GridViewDataTextColumn GroupIndex="0" Caption="MAIN MENU" FieldName="MainMenu" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ACCESS" FieldName="SubMenu" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTokenBoxColumn Caption="PRIVILLAGES" FieldName="Activity" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                    <PropertiesTokenBox AllowCustomTokens="false" TextSeparator=";" TextField="Activity" ValueField="Activity" ValueSeparator=";">
                                    </PropertiesTokenBox>
                                </dx:GridViewDataTokenBoxColumn>
                                <dx:GridViewDataTextColumn Caption="DATE CREATED" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" FieldName="DateCreated" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Name="c2" FieldName="MainId" Caption="MainId" Visible="false" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Name="c2" FieldName="SubId" Caption="SubId" Visible="false" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>

                            </Columns>
                            <Settings ShowFooter="false" />
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="xFullName" Visible="true" SummaryType="None" />
                </GroupSummary>
                <SettingsPager PageSize="15">
                </SettingsPager>
                <SettingsDetail ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="true" ExportMode="All" />
                <SettingsBehavior AllowFocusedRow="True"  />
                <SettingsDataSecurity AllowInsert="False" />
                <SettingsCommandButton>
                    <EditButton Text="Add Access"></EditButton>
                    <DeleteButton Text="Edit Access"></DeleteButton>
                </SettingsCommandButton>
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gridExp" runat="server" GridViewID="dgEvent">
            </dx:ASPxGridViewExporter>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="lectureblocks.aspx.cs" Inherits="mySmis.lectureblocks" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        SCH. BLOCKS/LECTURE HALLS
    </div>

    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <dx:ASPxHiddenField ID="hiddenMode" runat="server"></dx:ASPxHiddenField>

            <dx:ASPxPageControl EnableHierarchyRecreation="false" ID="memberTabs" runat="server" ActiveTabIndex="0" Height="100%" Width="100%">
                <TabPages>
                    <dx:TabPage Text="Sch. Blocks/Lecture Halls">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl1" runat="server" SupportsDisabledAttribute="True">

                                <asp:UpdatePanel ID="upBlocks" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="True" ShowPopOutImages="True">
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
                                        <div id="divProgram" runat="server" visible="false" class="appWorkspace">
                                            <table style="width: 80%;">
                                                <tr>
                                                    <td class="table_tr_left"></td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_tr_left">Sch. Block/Lecture Hall :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtName" runat="server" Width="70%">
                                                            <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"></ValidationSettings>
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
                                                    <td class="table_tr_left">&nbsp;</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxButton ID="btnSaveProgram" runat="server" EnableTheming="True" Text="Save" OnClick="btnSaveProgram_Click">
                                                            <Image IconID="save_save_16x16"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnCancel" runat="server" EnableTheming="True" Text="Cancel" OnClick="btnCancel_Click">
                                                            <Image IconID="actions_cancel_16x16"></Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>

                                        <br />
                                        <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="dgBlocks" EnableCallBacks="false" AutoGenerateColumns="False" OnCommandButtonInitialize="dgBlocks_CommandButtonInitialize" OnStartRowEditing="dgBlocks_StartRowEditing">
                                            <SettingsSearchPanel Visible="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" />
                                                <dx:GridViewDataTextColumn Name="c2" FieldName="VenuName" Caption="SCH BLOCK/LECTURE HALL" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="c2" FieldName="Description" Caption="DESCRIPTION" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>

                                            </Columns>
                                            <SettingsPager PageSize="15"></SettingsPager>
                                            <SettingsDetail ExportMode="All" />
                                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                            <SettingsDataSecurity AllowInsert="False" />
                                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                        </dx:ASPxGridView>
                                        <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgBlocks" FileName="School Blocks or Lecture Halls List">
                                        </dx:ASPxGridViewExporter>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="Class/Lecture Rooms">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl2" runat="server" SupportsDisabledAttribute="True">

                                <asp:UpdatePanel ID="upRooms" runat="server" UpdateMode="Conditional">

                                    <ContentTemplate>
                                        <dx:ASPxMenu ID="mMainRooms" runat="server" OnItemClick="mMainRooms_ItemClick" AllowSelectItem="True" AutoPostBack="True" ShowPopOutImages="True">
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
                                                    <td class="table_tr_left">&nbsp;</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtIDRoom" runat="server" Visible="False" Width="50px" Text="0">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_tr_left">Sch. Blocks/Lecture Hall :</td>
                                                    <td class="table_tr_right">

                                                        <dx:ASPxComboBox TextField="VenuName" DisplayFormatString="{0}" NullText="Choose..." TextFormatString="{0}" IncrementalFilteringMode="Contains" ValueField="ID" ID="cmbVenus" runat="server" Width="70%">
                                                            <Columns>
                                                                <dx:ListBoxColumn Caption="Sch. Block/Lecture Hall" FieldName="VenuName" Width="60px" />
                                                            </Columns>
                                                            <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true" ErrorText="*"></ValidationSettings>
                                                        </dx:ASPxComboBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_tr_left">Class/Lecture Room :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtNameRoms" runat="server" Width="70%">
                                                            <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" SetFocusOnError="true">
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_tr_left">Size :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxSpinEdit ID="spinSize" runat="server" Increment="1" MinValue="0" NumberType="Integer" MaxValue="10000000">
                                                            <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" SetFocusOnError="true">
                                                            </ValidationSettings>
                                                        </dx:ASPxSpinEdit>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td class="table_tr_left"></td>
                                                    <td class="table_tr_right">

                                                        <dx:ASPxButton ID="btnSaveRooms" runat="server" Text="Save" OnClick="btnSaveRooms_Click">
                                                            <Image IconID="save_save_16x16"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnCanceRooms" runat="server" Text="Cancel" OnClick="btnCanceRooms_Click">
                                                            <Image IconID="actions_cancel_16x16"></Image>
                                                        </dx:ASPxButton>


                                                    </td>
                                                </tr>
                                            </table>
                                        </div>

                                        <br />
                                        <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="dgRooms" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="dgRooms_CommandButtonInitialize" OnStartRowEditing="dgRooms_StartRowEditing">
                                            <SettingsSearchPanel Visible="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True"  />
                                                <dx:GridViewDataTextColumn Name="RoomName" FieldName="RoomName" Caption="CLASS/LECTURE ROOM" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="Size" FieldName="Size" Caption="SIZE" VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn GroupIndex="0" Name="xVenuName" FieldName="xVenuName" Caption=":" VisibleIndex="3">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <GroupSummary>
                                                <dx:ASPxSummaryItem FieldName="RoomName" SummaryType="Count" />
                                            </GroupSummary>

                                            <SettingsPager PageSize="30"></SettingsPager>
                                            <SettingsDetail ExportMode="All" />
                                            <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                                            <SettingsDataSecurity AllowInsert="False" />

                                        </dx:ASPxGridView>

                                        <dx:ASPxGridViewExporter ID="expRooms" runat="server" GridViewID="dgRooms" FileName="School Blocks or Lecture Halls and Rooms List"></dx:ASPxGridViewExporter>
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


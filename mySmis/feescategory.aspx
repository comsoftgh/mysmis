<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="feescategory.aspx.cs" Inherits="mySmis.feescategory" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        FEES CATEGORIES
                                    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                    </asp:ScriptManager>
                    
                    <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
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
                        
                        <table style="width:600px;">
                            
                            <tr>
                                <td class="table_tr_left" style="text-align:right;">Title :</td>
                                <td class="table_tr_right">
                                    <dx:ASPxTextBox ID="txtName" runat="server" Width="100%">
                                        <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true"></ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="table_tr_left" >Description :</td>
                                <td class="table_tr_right">
                                    <dx:ASPxTextBox ID="txtDesc" runat="server" Width="100%">
                                        <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="table_tr_left" >Applies To :</td>
                                <td class="table_tr_right">
                                    <dx:ASPxComboBox ID="cmbApplyto" runat="server">
                                        <Items>
                                            <dx:ListEditItem Text="Choose ..." Value="" />
                                            <dx:ListEditItem Text="All Students" Value="All Students" />
                                            <dx:ListEditItem Text="Particular Students" Value="Particular Students"/>
                                        </Items>
                                        <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="table_tr_left"><dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                                    </dx:ASPxTextBox></td>
                                <td class="table_tr_right">
                                    
                                                <dx:ASPxButton ID="btnSaveProgram" runat="server"  Text="Save" OnClick="btnSaveProgram_Click" >
                                                   <Image IconID="save_save_16x16"></Image>  
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" >
                                                     <Image IconID="actions_cancel_16x16"></Image>
                                                </dx:ASPxButton>
                                           
                                       
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                    <br />
                    <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvFeesCategory" EnableCallBacks="False" AutoGenerateColumns="False" OnRowDeleting="gvFeesCategory_RowDeleting" OnStartRowEditing="gvFeesCategory_StartRowEditing" OnCommandButtonInitialize="gvFeesCategory_CommandButtonInitialize" >
                        <Columns>
                            <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True"/>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="Title" Caption="TITLE" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="Description" Caption="DESCRIPTION" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="Applyto" Caption="APPLIES TO" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>

                        </Columns>
                        <SettingsPager PageSize="15">
                        </SettingsPager>
                        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                        <Settings ShowFilterRow="True" />
                        <SettingsDataSecurity AllowInsert="False" />
                        <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgProgram" FileName="Fees Categories"></dx:ASPxGridViewExporter>
                </ContentTemplate>
            </asp:UpdatePanel>
                                </asp:Content>


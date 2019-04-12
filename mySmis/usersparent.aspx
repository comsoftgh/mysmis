<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="usersparent.aspx.cs" Inherits="mySmis.usersparent" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        PARENT USERS
                                    </div>
                                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <dx:ASPxHiddenField ID="hiddenMode" runat="server"></dx:ASPxHiddenField>
            <asp:UpdatePanel ID="UpdatePanelStaff" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick"  AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                        <Items>
                            <dx:MenuItem Name="mitNew" Text="New User"></dx:MenuItem>
                            
                        </Items>
                    </dx:ASPxMenu>


                    
                    <br />
                    <div runat="server" id="divLogin" visible="false">
                        <table class="main_table" style="width:500px">
                             <tr>
                                 <td style="width:120px;">Select Student :</td>
                                            <td>
                                             <dx:ASPxComboBox ID="cmbStaffs" runat="server" AutoPostBack="True" CallbackPageSize="10" DropDownRows="10" DropDownStyle="DropDown" EnableCallbackMode="True" FilterMinLength="0" Font-Size="10pt" Height="16px" IncrementalFilteringMode="Contains" TextFormatString="{0} - {1}" ValueField="UserId" Width="70%">
                                                 <Columns>
                                                     <dx:ListBoxColumn Caption="Name" FieldName="xFullName" Visible="true" />
                                                     <dx:ListBoxColumn Caption="User ID" FieldName="UserId" Visible="false" />
                                                     <dx:ListBoxColumn Caption="Contact" FieldName="Mobile" Visible="true" />
                                                 </Columns>
                                             </dx:ASPxComboBox>
                                                <dx:ASPxTextBox runat="server" ID="txtUserID" Text="0" Visible="false"></dx:ASPxTextBox>
                                                 <dx:ASPxTextBox runat="server" ID="txtStfID" Text="0" Visible="false"></dx:ASPxTextBox>
                                                 <dx:ASPxTextBox runat="server" ID="txtActive" Text="0" Visible="false"></dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:120px;">Username :</td>
                                            <td>
                                                <dx:ASPxTextBox runat="server" ID="txtUserName" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" >
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                    
                                                </dx:ASPxTextBox>
                                            </td>
                                            
                                            
                                                
                                            
                                        </tr>
                                        <tr>
                                            <td>Password :</td>
                                            <td>
                                                <dx:ASPxTextBox runat="server" ID="txtPassword" Password="true" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" >
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                            </tr>
                            <tr>
                                            <td>Confirm :</td>
                                            <td>
                                                <dx:ASPxTextBox runat="server" ID="txtPass" Password="true" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" >
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                            
                            <tr>
                                <td></td>
                                <td>
                                                <dx:ASPxButton ID="btnSaveLogin" runat="server"  Text="Save" OnClick="btnSaveLogin_Click"  >
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btnCancel" runat="server" OnClick="btnCancelLogin_Click"  Text="Cancel" >
                                                </dx:ASPxButton>
                                    <dx:ASPxButton ID="btnActive" Visible="false" runat="server"  Text="" OnClick="btnActive_Click" >
                                                </dx:ASPxButton>
                                    <dx:ASPxButton ID="btnReset" Visible="false" runat="server"  Text="Reset Password" OnClick="btnReset_Click" >
                                                </dx:ASPxButton>
                                                
                                 </td>
                            </tr>
                        </table>

                    </div>

                    <br />
                    
                        <dx:ASPxGridView ID="gvStaff" runat="server" AutoGenerateColumns="False" KeyFieldName="UserId" Width="100%" EnableCallBacks="False" OnStartRowEditing="gvStaff_StartRowEditing" Font-Names="Tahoma" Font-Size="11px">

                            <SettingsDataSecurity AllowInsert="False" AllowDelete="False" />

                            <SettingsSearchPanel Visible="True" />

                            <Columns>
                                <dx:GridViewCommandColumn VisibleIndex="0" Width="5%" Caption=" #" ShowEditButton="True">
                                    
                                </dx:GridViewCommandColumn>
                               
                                <dx:GridViewDataTextColumn FieldName="UserID" VisibleIndex="1" Visible="false" ReadOnly="True" >
                                </dx:GridViewDataTextColumn>
                                
                                <dx:GridViewDataTextColumn FieldName="UserName" VisibleIndex="16" Visible="true" Caption="USERNAME" ReadOnly="True" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="xFullName" VisibleIndex="16" Visible="true" Caption="TUTOR NAME" ReadOnly="True" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="xActive" VisibleIndex="16" Visible="true" Caption="STATUS" ReadOnly="True" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DateCreated" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" VisibleIndex="24" >
                                    <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="LastModify" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" VisibleIndex="25" >
                                    <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>

                            </Columns>
                            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" EnableCustomizationWindow="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSize="25">
                            </SettingsPager>
                            <SettingsEditing Mode="Inline" />
                            <SettingsCommandButton>
                                
                                <EditButton Text="Edit" Image-ToolTip="Edit User" > </EditButton>
                                
                                
                            </SettingsCommandButton>
                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                        </dx:ASPxGridView>
                   

                </ContentTemplate>
            </asp:UpdatePanel>
    
                                </asp:Content>

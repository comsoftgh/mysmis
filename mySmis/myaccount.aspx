<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myaccount.aspx.cs" Inherits="mySmis.myaccount" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle">MY ACCOUNT
                                    </div>
    
                     
                         <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
                          <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanelUser">
                                                                       <ContentTemplate>
                        <div runat ="server" class="appWorkspace">
                                                                            <table>

                         <tr>
                             
                                     <td colspan="4"><strong>  Login Details</strong></td>
                                 </tr>
                                 <tr>
                                     <td class="table_tr_left">User Name :</td>
                                     <td class="table_tr_right"><dx:ASPxTextBox runat="server" ReadOnly="true" ID="txtUserName" Width="100%"></dx:ASPxTextBox></td>
                                     <td ><dx:ASPxTextBox runat="server" ID="txtID" Text="0" Visible="false"></dx:ASPxTextBox></td>
                                     <td ><dx:ASPxTextBox runat="server" ID="txtUserID" Text="0" Visible="false"></dx:ASPxTextBox></td>
                                 </tr>
                             <tr>
                                     <td class="table_tr_left" >Old Password :</td>
                                     <td class="table_tr_right"><dx:ASPxTextBox runat="server" ID="txtOldPass" Password="true" Width="100%">
                                         <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                                            
                                          </dx:ASPxTextBox></td>
                                     
                                 </tr>
                                 <tr>
                                     <td class="table_tr_left">New Password :</td>
                                     <td  class="table_tr_right"><dx:ASPxTextBox runat="server" ID="txtPassword" Password="true" Width="100%">
                                         <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                                            
                                          </dx:ASPxTextBox></td>
                                  </tr>
                                  <tr>
                                     <td class="table_tr_left">Confirm :</td>
                                     <td class="table_tr_right" ><dx:ASPxTextBox runat="server" ID="txtPass" Password="true" Width="100%">
                                         <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                                            
                                          </dx:ASPxTextBox></td>    
                                 </tr>
                                 
                                 <tr>
                                     
                                     <td class="table_tr_left" ></td>
                                     <td class="table_tr_right">
                                         <dx:ASPxButton ID="btnSave" runat="server" OnClick="btnSave_Click"   Text="Change Password"  >
                                             <Image IconID="save_save_16x16"></Image>
                                            </dx:ASPxButton>
                                            
                                     </td>
                                 </tr>
                             </table>
                            </div>
</ContentTemplate>
                              </asp:UpdatePanel>
                                          
                                </asp:Content>



<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="settingsacademics.aspx.cs" Inherits="mySmis.settingsacademics" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        ACADEMICS SETTINGS
                                    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <dx:aspxhiddenfield ID="hiddenMode" runat="server"></dx:aspxhiddenfield>

    <asp:UpdatePanel ID="upPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="appWorkspace">
               
            <table style="width: 800px;">
                
                <tr>
                    <td class="table_tr_left">Subject/Course Registration By :</td>
                    <td class="table_tr_right">
                        
                        <dx:ASPxComboBox ID="lessonsRegistration" runat="server">
                            <Items>
                                <dx:ListEditItem Text="None" Value="" />
                                <dx:ListEditItem Text="Administration" Value="Administration" />
                                <dx:ListEditItem Text="Students" Value="Students" />
                            </Items>

                        </dx:ASPxComboBox>
                    </td>

                </tr>
                <tr>
                    <td class="table_tr_left">Examination Score :</td>
                    <td class="table_tr_right">
                        <dx:ASPxSpinEdit runat="server" ID="examshigerscore" NumberType="Integer" MaxLength="3" MaxValue="100" MinValue="30"></dx:ASPxSpinEdit>
                    </td>
                </tr>
                <tr>
                    <td class="table_tr_left">Attendance Taken :</td>
                    <td class="table_tr_right">
                        
                        <dx:ASPxComboBox ID="studentAttendance" runat="server">
                            <Items>
                                <dx:ListEditItem Text="Daily Attendance" Value="Daily Attendance" />
                                <dx:ListEditItem Text="Per Subject/Course" Value="Per Subject/Course" />
 
                            </Items>

                        </dx:ASPxComboBox>
                    </td>

                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style24">
                        <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click">
                            <Image IconID="save_save_16x16"></Image>

                        </dx:ASPxButton>

                    </td>
                </tr>
            </table>
                <br />
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
                                </asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="settingsstudent.aspx.cs" Inherits="mySmis.settingsstudent" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        STUDENT MANAGEMENT SETTINGS
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <dx:ASPxHiddenField ID="hiddenMode" runat="server"></dx:ASPxHiddenField>

    <asp:UpdatePanel ID="upPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="appWorkspace">
                <br />
            <table style="width: 500px;">
                <tr>

                    <td class="auto-style27" style="width: 150px; text-align: right;">Student's ID begins with :</td>
                    <td class="auto-style24" style="width: 350px; text-align: left;">
                        <dx:ASPxTextBox ID="indexString" runat="server" Width="100%" NullText="MYSMIS">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">Student's ID sperator :</td>
                    <td>
                        
                        <dx:ASPxComboBox ID="indexSeperator" runat="server">
                            <Items>
                                <dx:ListEditItem Text="None" Value="" />
                                <dx:ListEditItem Text="/" Value="/" />
                                <dx:ListEditItem Text="-" Value="-" />
                                <dx:ListEditItem Text="_" Value="_" />
                            </Items>

                        </dx:ASPxComboBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style2" style="text-align: right;">Student's ID dymanic :</td>
                    <td>
                        <dx:ASPxComboBox ID="indexDynamic" runat="server">
                            <Items>
                                <dx:ListEditItem Text="None" Value="None" />
                                <dx:ListEditItem Text="Day" Value="Day" />
                                <dx:ListEditItem Text="Month" Value="Month" />
                                <dx:ListEditItem Text="Year" Value="Year" />
                            </Items>

                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style27" style="text-align: right;">Student's ID starting No. :</td>
                    <td class="auto-style24">
                        <dx:ASPxTextBox ID="indexStartingNo" runat="server" Width="100%" MaxLength="20" NullText="eg. 101">
                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="None">
                            </ValidationSettings>
                            
                        </dx:ASPxTextBox>
                    </td>

                </tr>
                <tr>
                        <td class="table_tr_left">Attendance Recorded :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="schLocation" runat="server" Width="100%" NullText="Accra - Ghana">
                            </dx:ASPxTextBox>

                        </td>

                    </tr>
                <tr>
                    <td></td>
                    <td class="auto-style24">
                        <dx:ASPxButton ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_Click">
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


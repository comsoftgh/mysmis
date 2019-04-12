<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="settingstutor.aspx.cs" Inherits="mySmis.settingstutor" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        TEACSTAFF MANAGEMENT SETTINGS
                                    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <dx:aspxhiddenfield ID="hiddenMode" runat="server"></dx:aspxhiddenfield>

    <asp:UpdatePanel ID="upPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <table style="width: 500px;">
                <tr>

                    <td class="auto-style27" style="width: 150px; text-align: right;">Staff&#39;s ID begins with :</td>
                    <td class="auto-style24" style="width: 350px; text-align: left;">
                        <dx:ASPxTextBox ID="tutorIDString" runat="server" Width="100%" NullText="MYSMIS">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">Staff&#39;s ID sperator :</td>
                    <td>
                        
                        <dx:ASPxComboBox ID="tutorIDSeperator" runat="server">
                            <Items>
                                <dx:ListEditItem Text="None" Value="None" />
                                <dx:ListEditItem Text="/" Value="/" />
                                <dx:ListEditItem Text="-" Value="-" />
                                <dx:ListEditItem Text="_" Value="_" />
                            </Items>

                        </dx:ASPxComboBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style2" style="text-align: right;">Staff&#39;s ID dymanic :</td>
                    <td>
                        <dx:ASPxComboBox ID="tutorIDdynamic" runat="server">
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
                    <td class="auto-style27" style="text-align: right;">Staff&#39;s ID starting No. :</td>
                    <td class="auto-style24">
                        <dx:ASPxTextBox ID="tutorIDStartingNo" runat="server" Width="100%" MaxLength="20" NullText="eg. 101">
                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="None">
                            </ValidationSettings>
                            <InvalidStyle BackColor="LightPink" />
                        </dx:ASPxTextBox>
                    </td>

                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style24">
                        <dx:ASPxButton ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click">
                            <Paddings Padding="0px" />

                        </dx:ASPxButton>

                    </td>
                </tr>
            </table>


        </ContentTemplate>
    </asp:UpdatePanel>
                                </asp:Content>


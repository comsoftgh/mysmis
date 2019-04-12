<%@ Page Language="C#" Title="" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="settingsgeneral.aspx.cs" Inherits="mySmis.settingsgeneral" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        GENERAL SETTINGS
    </div>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <dx:ASPxHiddenField ID="hiddenMode" runat="server"></dx:ASPxHiddenField>

    <asp:UpdatePanel ID="upPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="appWorkspace">

                <table style="width: 500px;">
                    <tr>
                        <td class="table_tr_left" style="width: 150px;">Institution Name :</td>
                        <td class="table_tr_right" style="width: 350px;">
                            <dx:ASPxTextBox ID="schName" runat="server" Width="100%" NullText="My School Management Infomation System">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_tr_left">Location :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="schLocation" runat="server" Width="100%" NullText="Accra - Ghana">
                            </dx:ASPxTextBox>

                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Contact One :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="schTel1" runat="server" Width="100%" MaxLength="20" NullText="eg. (+233) 24 381 8669">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                </ValidationSettings>

                            </dx:ASPxTextBox>
                        </td>



                    </tr>
                    <tr>
                        <td class="table_tr_left">Contact Two :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="schTel2" runat="server" Width="100%" MaxLength="20" NullText="eg. (+233) 26 781 8669">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right">
                                </ValidationSettings>

                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Address Line One :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="schAddLine1" runat="server" Width="100%" MaxLength="20" NullText="eg. P. O. Box 2311">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right">
                                </ValidationSettings>

                            </dx:ASPxTextBox>
                        </td>

                    </tr>

                    <tr>
                        <td class="table_tr_left">Address Line Two :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="schAddLine2" runat="server" Width="100%" MaxLength="20" NullText="eg. Kaneshie - Accra">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorTextPosition="Right">
                                </ValidationSettings>

                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Address Line Three :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="schAddLine3" runat="server" Width="100%" MaxLength="20" NullText="eg. Ghana">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorTextPosition="Right">
                                </ValidationSettings>

                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Email :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="schEmail" runat="server" Width="100%" NullText=" eg. info@comsoftsolutions.com">
                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorTextPosition="Right">
                                    <RegularExpression ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Staff ID Numbers :</td>
                        <td class="table_tr_right">
                            <dx:ASPxComboBox ID="staffID" runat="server">
                                <Items>
                                    <dx:ListEditItem Text="Yes" Value="Yes" />
                                    <dx:ListEditItem Text="No" Value="No" />

                                </Items>

                            </dx:ASPxComboBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Payment Currency :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="moneyCurrency" runat="server" Width="100%" NullText="eg. GHS">
                            </dx:ASPxTextBox>

                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left">Receipt No. Starts :</td>
                        <td class="table_tr_right">
                            <dx:ASPxTextBox ID="receiptNo" runat="server" Width="100%" NullText="eg. 10000">
                            </dx:ASPxTextBox>

                        </td>

                    </tr>
                    <tr>
                        <td class="table_tr_left" style="vertical-align: top;">System Theme :</td>
                        <td class="table_tr_right" style="vertical-align: top;" runat="server" id="tdTheme">
                            <dx:ASPxComboBox ID="theme" runat="server" SelectedIndex="0" IncrementalFilteringMode="StartsWith" ShowImageInEditBox="True" ValueType="System.String">
                                <ItemImage Height="24px" Width="50px" />

                            </dx:ASPxComboBox>
                            <%--                        <dx:ASPxImage ID="themeimg" runat="server" Width="50px" Height="25px"></dx:ASPxImage>--%>
                        </td>


                    </tr>

                    <tr>
                        <td></td>
                        <td class="auto-style24">
                            <dx:ASPxButton ID="btnSaveStudent" runat="server" Text="Save" OnClick="btnSaveStudent_Click">
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



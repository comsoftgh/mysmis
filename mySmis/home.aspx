<%@ Page Title="Home - mySmis" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="mySmis.home" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        DASHBOARD
    </div>



    <%--<table style="min-width: 100%; margin-right: auto; margin-left: auto;">
        <tr>
            <td class="auto-style1" style="width: 30%; text-align: right;">SEARCH CUSTOMER</td>
            <td>
                <dx:ASPxComboBox ID="cmbSearchCustomers" runat="server" AutoPostBack="True" CallbackPageSize="10" DropDownRows="10" DropDownStyle="DropDown" EnableCallbackMode="True" FilterMinLength="2" Font-Size="10pt" Height="16px" IncrementalFilteringMode="Contains" TextFormatString="{0} - {1}" Theme="Default" ValueField="MemberId" Width="70%" OnItemRequestedByValue="cmbSearchCustomers_ItemRequestedByValue" OnItemsRequestedByFilterCondition="cmbSearchCustomers_ItemsRequestedByFilterCondition" OnValueChanged="cmbSearchCustomers_ValueChanged">
                    <Columns>
                        <dx:ListBoxColumn Caption="Member ID" FieldName="MemberId" Width="60px" />
                        <dx:ListBoxColumn Caption="Name" FieldName="Name" Width="250px" />
                        <dx:ListBoxColumn Caption="Other Info" FieldName="OtherInfo" Width="300px" />
                    </Columns>
                    <ItemStyle Font-Size="10pt">
                        <SelectedStyle BackColor="#FF9900">
                        </SelectedStyle>
                        <HoverStyle BackColor="#FF9900">
                        </HoverStyle>
                        <Paddings PaddingBottom="5px" />
                    </ItemStyle>
                </dx:ASPxComboBox>
            </td>
        </tr>
    </table>--%>

    <div class="homemenu">
        <div class="menuitem">
            <dx:ASPxButton ID="btnStudents" OnClick="btnStudents_Click" ToolTip="Restricted Access" Enabled="false" Width="100" Height="100" runat="server" CssClass="mnu_members" CssFilePath="~/styles/icons.css" EnableTheming="false">
            </dx:ASPxButton>

            <div class="label">Students</div>

        </div>
        <div class="menuitem">
            <dx:ASPxButton ID="btnNewStudent" OnClick="btnNewStudent_Click" ToolTip="Restricted Access" Width="100" Enabled="false" Height="100" runat="server" CssClass="mnu_newmember" CssFilePath="~/styles/icons.css" EnableTheming="false">
            </dx:ASPxButton>

            <div class="label">New Students</div>

        </div>
        <div class="menuitem">
            <dx:ASPxButton ID="btnPayments" OnClick="btnPayments_Click" ToolTip="Restricted Access" Width="100" Enabled="false" Height="100" runat="server" CssClass="mnu_tithe" CssFilePath="~/styles/icons.css" EnableTheming="false">
            </dx:ASPxButton>

            <div class="label">Payments</div>

        </div>
        <div class="menuitem">
            <dx:ASPxButton ID="btnPayFees" OnClick="btnPayFees_Click" ToolTip="Restricted Access" Width="100" Enabled="false" Height="100" runat="server" CssClass="mnu_tithestmt" CssFilePath="~/styles/icons.css" EnableTheming="false">
            </dx:ASPxButton>

            <div class="label">Fees Payment </div>

        </div>
        <div class="menuitem">
            <dx:ASPxButton ID="btnParentUsers" OnClick="btnParentUsers_Click" ToolTip="Restricted Access" Width="100" Enabled="false" Height="100" runat="server" CssClass="mnu_covfamily" CssFilePath="~/styles/icons.css" EnableTheming="false">
            </dx:ASPxButton>

            <div class="label">PTA</div>

        </div>
        <div class="menuitem">
            <dx:ASPxButton ID="btnBatches" OnClick="btnBatches_Click" Width="100" ToolTip="Restricted Access" Enabled="false" Height="100" runat="server" CssClass="mnu_group" CssFilePath="~/styles/icons.css" EnableTheming="false">
            </dx:ASPxButton>

            <div class="label">Batches</div>

        </div>
        <div class="menuitem">
            <dx:ASPxButton ID="btnNewUser" OnClick="btnNewUser_Click" Width="100" ToolTip="Restricted Access" Enabled="false" Height="100" runat="server" CssClass="mnu_visitor" CssFilePath="~/styles/icons.css" EnableTheming="false">
            </dx:ASPxButton>

            <div class="label">New User</div>

        </div>

        <div class="menuitem">
            <dx:ASPxButton ID="btnStaffs" AutoPostBack="true" OnClick="btnStaffs_Click" ToolTip="Restricted Access" Width="100" Enabled="false" Height="100" runat="server" CssClass="mnu_user" CssFilePath="~/styles/icons.css" EnableTheming="false">
            </dx:ASPxButton>
            <div class="label">Staff</div>
        </div>
    </div>




</asp:Content>















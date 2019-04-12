<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="feeschequeconciliation.aspx.cs" Inherits="mySmis.feeschequeconciliation" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        CHEQUE CONCILIATION
    </div>
<asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>

    <div runat="server" class="appWorkspace" visible="false" id="div_payment">
     

        <table style="width: 90%;">

            <tr>
                <td class="table_tr_left" style=" width: 120px;">Student ID :</td>
                <td class="table_tr_right">
                    <dx:ASPxTextBox ID="txtIndexNo" ReadOnly="true" runat="server" Width="300px">
                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                        
                    </dx:ASPxTextBox>
                </td>
                <td class="table_tr_left" style="width:120px;" >Student Name :</td>
                <td class="table_tr_right">
                    <dx:ASPxTextBox ID="txtStudentName" ReadOnly="true" runat="server" Width="300px">
                    </dx:ASPxTextBox>
                </td>


            </tr>
            <tr>
                <td class="table_tr_left" >Bank :</td>
                <td class="table_tr_right">
                    <dx:ASPxTextBox ID="txtBank" runat="server" Width="300px" ReadOnly="true">
                    </dx:ASPxTextBox>
                </td>
                <td class="table_tr_left">Branch :</td>
                <td style="vertical-align: top" class="table_tr_right">
                    <dx:ASPxTextBox ID="txtBranch" runat="server" Width="300px" ReadOnly="true">
                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                        
                    </dx:ASPxTextBox>
                </td>

            </tr>
            <tr>
                <td class="table_tr_left" >Cheque No. :</td>
                <td class="table_tr_right">
                    <dx:ASPxTextBox ID="txtChequeNo" runat="server" Width="300px" MaxLength="18" ReadOnly="true">
                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                        
                    </dx:ASPxTextBox>
                </td>
                <td class="table_tr_left">

                    <dx:ASPxTextBox ID="txtpayID" Visible="false" Text="0" runat="server">
                    </dx:ASPxTextBox>

                </td>
                <td class="table_tr_right">
                    <dx:ASPxTextBox ID="txtCleared" Visible="false" runat="server" Width="300px">
                    </dx:ASPxTextBox>
                </td>
               

            </tr>
            <tr>
                 <td runat="server" id="Td1" class="table_tr_left">Cashed By :
                                
                </td>

                <td class="table_tr_right">
                    <dx:ASPxTextBox ID="txtCashedBy" runat="server" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td class="table_tr_left">Cleared Date :</td>
                <td class="table_tr_right" style="width: 200px;">
                    <dx:ASPxDateEdit ID="dtPayDate" runat="server" Width="60%">
                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                        
                    </dx:ASPxDateEdit>
                </td>
                

            </tr>




            <tr>
                <td class="table_tr_left" ></td>
                <td class="table_tr_right">

                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click">
                         <Image IconID="save_save_16x16"></Image>
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="btnClear" runat="server" Text="Cancel" OnClick="btnClear_Click">
                        <Image IconID="actions_cancel_16x16"></Image>
                    </dx:ASPxButton>
                </td>
                <td class="auto-style3" style="vertical-align: top;"></td>
                <td style="vertical-align: top" class="auto-style52"></td>
            </tr>
        </table>
        <br />
    </div>



    <br />

    <dx:ASPxGridView ID="gvPayments" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnCommandButtonInitialize="gvPayments_CommandButtonInitialize" OnStartRowEditing="gvPayments_StartRowEditing" EnableCallBacks="False" Font-Names="Tahoma" Font-Size="11px">

        <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />

        <SettingsSearchPanel Visible="True" />

        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" Width="10%">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="xIndexNo" Caption="STUDENT ID" Visible="true" ReadOnly="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="xFullName" Caption="STUDENT NAME" ReadOnly="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="xBankName" Caption="BANK" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Branch" Caption="BRANCH" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ChequeNo" Caption="CHEQUE NO." VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Payvalue" Caption="AMMOUNT" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Cleared" Caption="CASHED" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DateCreated" Caption="Payment Date" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" VisibleIndex="7">
                <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy"></PropertiesTextEdit>
            </dx:GridViewDataTextColumn>

        </Columns>
        <Settings ShowFilterRow="True" />
        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" EnableCustomizationWindow="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
        <SettingsPager PageSize="25">
        </SettingsPager>
        <SettingsEditing Mode="Inline" />
        <SettingsCommandButton>
            <EditButton Text="Reconcile Cheque"></EditButton>
        </SettingsCommandButton>
        <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
    </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="gvExporter" runat="server" GridViewID="gvInventoryItems" ExportedRowType="All"></dx:ASPxGridViewExporter>

            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


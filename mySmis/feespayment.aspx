<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="feespayment.aspx.cs" Inherits="mySmis.feespayment" EnableTheming="true" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        FEES PAYMENT
    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>


            <asp:UpdatePanel ID="upFeesBatches" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div runat="server" class="appWorkspace">

                        <table style="width: 100%;">
                            
                            <tr>
                                <td class="table_tr_left" style="width:120px;">Academic Batch :</td>
                                <td class="table_tr_right" colspan="2">

                                    <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="true" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                        <Columns>

                                            <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                            <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                            <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                            <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="ClassID" Visible="false" Caption="ClassID" />
                                        </Columns>

                                        <GridViewProperties>
                                            <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                            <SettingsPager NumericButtonCount="3" />
                                            <Settings ShowFilterRow="true" />
                                        </GridViewProperties>
                                        <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" />

                                        </ValidationSettings>
                                        <ClearButton Visibility="True">
                                        </ClearButton>
                                    </dx:ASPxGridLookup>


                                </td>
                                <td></td>

                            </tr>

                        </table>
                    </div>
                    <div runat="server" class="appWorkspace" visible="false" id="div_payment">


                        <table style="width: 100%;">
                            <tr>
                                <td class="table_tr_left" style="width:120px;">Payment Date :</td>
                                <td class="table_tr_right" style="vertical-align: top; width: 200px;">


                                    <dx:ASPxDateEdit ID="dtPayDate" runat="server">
                                        <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                    </dx:ASPxDateEdit>
                                </td>
                                <td class="table_tr_right" colspan="2" style="padding-left: 10px;">
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Change date for previous payments" ForeColor="Red"></dx:ASPxLabel>

                                    <dx:ASPxTextBox ID="txtstudID" Visible="false" Text="0" runat="server">
                                    </dx:ASPxTextBox>

                                    <dx:ASPxTextBox ID="txtbatchID" runat="server" Text="0" Visible="false">
                                    </dx:ASPxTextBox>

                                    <dx:ASPxTextBox ID="txtbgroup" Visible="false" Text="0" runat="server">
                                    </dx:ASPxTextBox>
                                    <dx:ASPxTextBox ID="txtregID" Visible="false" Text="0" runat="server">
                                    </dx:ASPxTextBox>
                                    <dx:ASPxTextBox ID="txtFpid" Visible="false" Text="0" runat="server">
                                    </dx:ASPxTextBox>
                                </td>

                            </tr>
                            <tr>
                                <td class="table_tr_left" style="vertical-align: top; width:120px;">Student ID :</td>
                                <td style="vertical-align: top;width:200px;" class="table_tr_right" >
                                    <dx:ASPxTextBox ID="txtIndexNo" ReadOnly="true" runat="server" Width="300px">
                                        <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                    </dx:ASPxTextBox>
                                </td>
                                <td class="table_tr_left" style="vertical-align: top; width:120px;">Student Name :</td>
                                <td style="vertical-align: top;width:200px;" class="table_tr_right" >
                                    <dx:ASPxTextBox ID="txtStudentName" ReadOnly="true" runat="server" Width="300px">
                                    </dx:ASPxTextBox>
                                </td>


                            </tr>
                            <tr>
                                <td class="table_tr_left" >Reciept No. :</td>
                                <td class="table_tr_right">
                                    <dx:ASPxTextBox ID="txtReciept" ReadOnly="true" runat="server" Width="300px">
                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip" />

                                    </dx:ASPxTextBox>
                                </td>
                                <td class="table_tr_left" >Paid in By :</td>
                                <td class="table_tr_left">
                                    <dx:ASPxTextBox ID="txtPaidinBy" runat="server" Width="300px">
                                        <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                    </dx:ASPxTextBox>
                                </td>


                            </tr>
                            <tr>
                                <td class="table_tr_left" >Amount :</td>
                                <td  class="table_tr_right">
                                    <dx:ASPxSpinEdit ID="spntAmt" MaxValue="10000000" MinValue="0" DecimalPlaces="2" NumberType="Float" runat="server">
                                        <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                    </dx:ASPxSpinEdit>
                                </td>
                                <td class="table_tr_left" >Payment Type :</td>
                                <td class="table_tr_right">
                                    <dx:ASPxComboBox ID="cmbPayType" AutoPostBack="true" runat="server" OnValueChanged="cmbPayType_ValueChanged">
                                        <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                    </dx:ASPxComboBox>
                                </td>

                            </tr>
                            <div runat="server" visible="false" id="div_Checque">
                                <tr>
                                    <td class="table_tr_left" >Bank :</td>
                                    <td style="vertical-align: top" class="table_tr_right">
                                        <dx:ASPxComboBox ID="cmbBank" runat="server" >
                                            <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                        </dx:ASPxComboBox>
                                    </td>
                                    <td class="table_tr_left" >Branch :</td>
                                    <td  class="table_tr_right">
                                        <dx:ASPxTextBox ID="txtBranch" runat="server" Width="300px">
                                            <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                        </dx:ASPxTextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="table_tr_left" >Cheque No. :</td>
                                    <td class="table_tr_right">
                                        <dx:ASPxTextBox ID="txtChequeNo" runat="server" Width="300px" MaxLength="18">
                                            <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                        </dx:ASPxTextBox>
                                    </td>

                                    <td runat="server" id="Td1" class="table_tr_left" >
                                        <dx:ASPxTextBox ID="txtCleared" Visible="false" runat="server">
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td class="table_tr_right">
                                        <dx:ASPxTextBox ID="txtCashedBy" Visible="false" runat="server" Width="300px">
                                        </dx:ASPxTextBox>
                                    </td>

                                </tr>
                            </div>
                            <tr>
                                <td class="table_tr_left" ></td>
                                <td  class="table_tr_right">

                                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click">
                                        <Image IconID="save_save_16x16"></Image>
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="btnClear" runat="server" Text="Cancel" OnClick="btnClear_Click">
                                        <Image IconID="actions_cancel_16x16"></Image>
                                    </dx:ASPxButton>
                                </td>
                                <td class="table_tr_left" ></td>
                                <td class="table_tr_right"></td
                            </tr>
                        </table>
                        <br />

                    </div>
                    <br />

                    <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvStudents" EnableCallBacks="False" AutoGenerateColumns="False" OnStartRowEditing="gvStudents_StartRowEditing" OnRowDeleting="gvStudents_RowDeleting">
                        <SettingsDataSecurity AllowInsert="False" />
                        <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewCommandColumn Width="20%" Name="c1" VisibleIndex="0" ShowEditButton="true" ShowDeleteButton="true" />
                            <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="UserId" Caption="INDEX NO." Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="STUDENT NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="TOTAL FEES" FieldName="xFeevalue" Name="clBgroup" VisibleIndex="7" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="TOTAL PAYMENT" FieldName="xPayments" Name="clBgroup" VisibleIndex="8" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="FEES BALANCE" FieldName="xFeesLeft" Name="clBgroup" VisibleIndex="9" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Templates>
                            <DetailRow>
                                <dx:ASPxGridView ID="gvPayments" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" EnableCallBacks="False" Font-Names="Tahoma" Font-Size="11px" OnStartRowEditing="gvPayments_StartRowEditing" OnCommandButtonInitialize="gvPayments_CommandButtonInitialize" OnBeforePerformDataSelect="gvPayments_BeforePerformDataSelect" OnRowDeleting="gvPayments_RowDeleting" OnSelectionChanged="gvPayments_SelectionChanged">

                                    <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true" />

                                    <Columns>
                                        <dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowSelectButton="true" Width="10%" VisibleIndex="0" >
                                        </dx:GridViewCommandColumn>

                                        <dx:GridViewDataTextColumn FieldName="PayType" Caption="PAYMENT TYPE" VisibleIndex="3">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ReceiptNo" Caption="RECEIPT NO." VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Payvalue" Caption="AMMOUNT" VisibleIndex="2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PaidBy" Caption="PAID IN BY" VisibleIndex="4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Cleared" Caption="CASHED" VisibleIndex="5">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="DateCreated" Caption="Payment Date" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" VisibleIndex="7">
                                            <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>

                                    </Columns>

                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="Payvalue" DisplayFormat="TOTAL PAYMENTS : {0}" SummaryType="Sum" />
                                    </TotalSummary>
                                    <SettingsCommandButton>
                                        <EditButton Text="Edit"></EditButton>
                                        <DeleteButton Text="Delete"></DeleteButton>
                                        <SelectButton Text="Reciept"></SelectButton>
                                    </SettingsCommandButton>
                                    <SettingsPager PageSize="15"></SettingsPager>
                                    <Settings ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
                                    <SettingsBehavior AllowSelectByRowClick="false" ConfirmDelete="true" AllowSelectSingleRowOnly="false" EnableRowHotTrack="True" EnableCustomizationWindow="True" AllowFocusedRow="True" ProcessSelectionChangedOnServer="true" />
                                    <SettingsDataSecurity AllowInsert="False" AllowEdit="true" AllowDelete="true" />
                                    <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                </dx:ASPxGridView>
                            </DetailRow>
                        </Templates>

                        <SettingsPager PageSize="15">
                        </SettingsPager>
                        <SettingsBehavior AllowSelectByRowClick="false" ConfirmDelete="false" AllowFocusedRow="True" />

                        <SettingsCommandButton>
                            <EditButton Text="Make Payment"></EditButton>
                            <DeleteButton Text="Payment Report"></DeleteButton>
                            
                        </SettingsCommandButton>
                        <SettingsDetail ShowDetailRow="true" />
                        <Settings VerticalScrollableHeight="400" VerticalScrollBarMode="Auto" />
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="gridExp" runat="server" GridViewID="dgEvent">
                    </dx:ASPxGridViewExporter>

                </ContentTemplate>
            </asp:UpdatePanel>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


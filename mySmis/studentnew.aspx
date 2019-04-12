<%@ Page Title="" MasterPageFile="~/main.Master" Language="C#" AutoEventWireup="true" CodeBehind="studentnew.aspx.cs" Inherits="mySmis.newstudent" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        NEW STUDENT
    </div>

    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <dx:ASPxHiddenField ID="hiddenMode" runat="server"></dx:ASPxHiddenField>

            <dx:ASPxPageControl EnableHierarchyRecreation="false" ID="memberTabs" runat="server" ActiveTabIndex="0" Height="100%" Width="98%" Font-Size="11px">
                <TabPages>
                    <dx:TabPage Text="Personal Details">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl1" runat="server" SupportsDisabledAttribute="True">

                                <asp:UpdatePanel ID="upStudent" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <div id="divEdit" runat="server" visible="true" class="appWorkspace">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="vertical-align: top; width: 260px;">
                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanelProfile">
                                                            <ContentTemplate>
                                                                <div id="divMemberProfile">
                                                                    <div id="divMemberPic" runat="server" visible="true" style="width: 260px">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td style="vertical-align: top; padding-right: 15px;">
                                                                                    <dx:ASPxImage ID="imgMember" runat="server" ClientInstanceName="imgMember" Width="250px" Height="300px">
                                                                                        <EmptyImage Url="~/images/default-person.jpg">
                                                                                        </EmptyImage>
                                                                                        <Border BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" />
                                                                                    </dx:ASPxImage>
                                                                                    <br />
                                                                                    <dx:ASPxLabel ID="lblFirstname" runat="server" Style="font-size: 15pt">
                                                                                    </dx:ASPxLabel>
                                                                                    <dx:ASPxLabel ID="lblLastname" runat="server" Style="font-size: 15pt">
                                                                                    </dx:ASPxLabel>
                                                                                    <span id="spbtnChangePic" style="float: left" runat="server" visible="false">
                                                                                        <dx:ASPxButton ID="btnChangePic" runat="server" OnClick="btnChangePic_Click" Text="Upload/Change" >
                                                                                            <Image IconID="navigation_up_16x16">
                                                                                            </Image>
                                                                                        </dx:ASPxButton>
                                                                                        <dx:ASPxButton ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh" >
                                                                                            <Image IconID="actions_refresh_16x16"></Image>
                                                                                        </dx:ASPxButton>

                                                                                    </span>

                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div id="divChangePic" runat="server" style="margin-top: 5px">
                                                                        <dx:ASPxUploadControl ID="txtUpload" UploadMode="Auto" runat="server" CancelButtonHorizontalPosition="Left" ClientInstanceName="uploader" NullText="Select picture file" OnFileUploadComplete="txtUpload_FileUploadComplete" ShowProgressPanel="True" ShowUploadButton="True" Width="251px" Visible="false">
                                                                            <ClientSideEvents FileUploadComplete="function(s, e) { Uploader_OnFileUploadComplete(e); }" />
                                                                            <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe,.gif,.png" MaxFileSize="4194304">
                                                                            </ValidationSettings>
                                                                            <ProgressBarSettings DisplayMode="Position" ShowPosition="true" />

                                                                            <ProgressBarStyle Font-Size="8px" Height="10px">
                                                                            </ProgressBarStyle>
                                                                        </dx:ASPxUploadControl>
                                                                    </div>

                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td style="vertical-align: top">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="table_tr_left" style="width: 130px;">Index No. :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxTextBox ID="txtIndexNo" runat="server" Width="70%" ReadOnly="true">
                                                                    </dx:ASPxTextBox>
                                                                </td>
                                                                <td class="table_tr_left" style="width: 120px;">Title :
                                                                    <dx:ASPxTextBox ID="txtStudUserID" Visible="false" Text="0" runat="server" Width="100%" ReadOnly="true">
                                                                    </dx:ASPxTextBox>

                                                                </td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxComboBox ID="cmbTitle" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith">
                                                                        
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*" />
                                                                       
                                                                    </dx:ASPxComboBox>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="table_tr_left">First Name :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxTextBox ID="txtFName" NullText="First Name" runat="server" Width="100%">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </td>

                                                                <td class="auto-style27" style="text-align: right;">Surname :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxTextBox ID="txtSName" NullText="Surname" runat="server" Width="100%">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td class="table_tr_left" style="text-align: right;">Other Names :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxTextBox ID="txtONames" NullText="Other Name(s)" runat="server" Width="100%">
                                                                    </dx:ASPxTextBox>
                                                                </td>
                                                                <td></td>
                                                                <td></td>

                                                            </tr>
                                                            <tr>
                                                                <td class="table_tr_left">Date of Birth :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxDateEdit ID="dtDOB" runat="server" NullText="Date of Birth">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*" />
                                                                       
                                                                    </dx:ASPxDateEdit>
                                                                </td>

                                                                <td class="table_tr_left" >Gender :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxComboBox ID="cmbGender" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>
                                                                </td>




                                                            </tr>

                                                            <tr>
                                                                <td class="table_tr_left" >Marital Status :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxComboBox ID="cmbMarital" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>
                                                                </td>
                                                                <td class="table_tr_left" >Religion :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxComboBox ID="cmbReligion" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td class="table_tr_left">Admission Date :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxDateEdit ID="dtAdmission" runat="server" NullText="Choose...">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            
                                                                        </ValidationSettings>
                                                                       
                                                                    </dx:ASPxDateEdit>
                                                                </td>
                                                                <td class="table_tr_left">Nationality :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxComboBox ID="cmbNationality" NullText="Choose..." runat="server" IncrementalFilteringMode="StartsWith">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td class="table_tr_left">Mobile :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxTextBox ID="txtMobile" runat="server" Width="100%" MaxLength="14">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            <RegularExpression ValidationExpression="^\d{10,14}$" />
                                                                        </ValidationSettings>
                                                                       
                                                                    </dx:ASPxTextBox>
                                                                </td>

                                                                <td class="table_tr_left">Tel :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxTextBox ID="txtTel" runat="server" Width="100%" MaxLength="14">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            <RegularExpression ValidationExpression="^\d{10,14}$" />
                                                                        </ValidationSettings>
                                                                       
                                                                    </dx:ASPxTextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="table_tr_left">Email :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="100%">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text">
                                                                            <RegularExpression ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="table_tr_left">Residential Address :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxMemo ID="txtResAddress" runat="server" Width="100%" Height="50px">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            <%--<RegularExpression ValidationExpression="^[a-zA-Z0-9''-'\s]{2,90}$" />--%>
                                                                        </ValidationSettings>
                                                                       
                                                                    </dx:ASPxMemo>
                                                                </td>

                                                                <td class="table_tr_left">Postal Address :</td>
                                                                <td class="table_tr_right">
                                                                    <dx:ASPxMemo ID="txtPostalAddress" runat="server" Width="100%" Height="50px">
                                                                        <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" ErrorText="*">
                                                                            <%--<RegularExpression ValidationExpression="^[a-zA-Z0-9''-'\s]{2,90}$" />--%>
                                                                        </ValidationSettings>
                                                                       
                                                                    </dx:ASPxMemo>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="table_tr_left"></td>
                                                                <td class="table_tr_right" colspan="3">
                                                                    <dx:ASPxButton ID="btnSaveStudent" runat="server" EnableTheming="True" Text="Save" OnClick="btnSaveStudent_Click">
                                                                        <Image IconID="save_save_16x16"></Image> 
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnClearStudent" runat="server" EnableTheming="True" Text="Clear" OnClick="btnClearStudent_Click">
                                                                       <Image IconID="actions_cancel_16x16"></Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnNewStudent" runat="server" EnableTheming="True" Text="New" OnClick="btnNewStudent_Click">
                                                                        <Image IconID="actions_add_16x16"></Image>
                                                                    </dx:ASPxButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>


                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="Educational Details">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl2" runat="server" SupportsDisabledAttribute="True">

                                <asp:UpdatePanel ID="upEducational" runat="server" UpdateMode="Conditional">
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnEduSave" />
                                    </Triggers>
                                    <ContentTemplate>

                                        <dx:ASPxMenu ID="mMainEdu" runat="server" OnItemClick="mMainEdu_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                            <Items>
                                                <dx:MenuItem Name="mitNewEdu" Text="New">
                                                    <Image IconID="actions_add_16x16"></Image>
                                                </dx:MenuItem>
                                               
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
                                        <div runat="server" visible="false" id="div_education" class="appWorkspace">
                                            <table style="width: 100%;">


                                                <tr>
                                                    <td style="width: 120px;" class="table_tr_left">Institution :</td>
                                                    <td class="table_tr_left">
                                                        <dx:ASPxTextBox ID="txtEduInstitution" runat="server" NullText="Institution" Width="100%">
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text">
                                                                <RegularExpression ValidationExpression="^[a-zA-Z0-9''-'\s]{2,90}$" />
                                                            </ValidationSettings>
                                                            
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                    <td class="table_tr_left" style="width: 120px;">Level :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxComboBox ID="cmbEduLevel" runat="server" NullText="Choose..." SelectedIndex="0" IncrementalFilteringMode="StartsWith">
                                                            
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                                                            
                                                        </dx:ASPxComboBox>
                                                    </td>


                                                </tr>
                                                <tr>
                                                    <td class="table_tr_left" >Qualification :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtEduQuali" runat="server" NullText="Qualification" Width="100%" MaxLength="14">
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text">
                                                                <RegularExpression ValidationExpression="^[a-zA-Z0-9''-'\s]{2,90}$" />
                                                            </ValidationSettings>
                                                            
                                                        </dx:ASPxTextBox>
                                                    </td>

                                                    <td class="table_tr_left" >
                                                        Starting Date :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxDateEdit ID="dtEduSDate" runat="server" NullText="Starting Date">
                                                            <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True" />
                                                            
                                                        </dx:ASPxDateEdit>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="table_tr_left" style="vertical-align:top;">Comments :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxMemo ID="txtEduComment" runat="server" Height="50px" NullText="Comment" Width="120%">
                                                            <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="True">
                                                                <RegularExpression ValidationExpression="^[a-zA-Z0-9''-'\s]{2,90}$" />
                                                            </ValidationSettings>
                                                            
                                                        </dx:ASPxMemo>
                                                    </td>

                                                    <td class="table_tr_left" style="vertical-align:top;">Completion Date :</td>
                                                    <td class="table_tr_right" style="vertical-align:top;">
                                                        <dx:ASPxDateEdit ID="dtEduCDate" runat="server" NullText="Completion Date">
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text" />
                                                            
                                                        </dx:ASPxDateEdit>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td style="vertical-align: top;" class="table_tr_left">Document :</td>
                                                    <td style="vertical-align: top;" class="table_tr_right">
                                                        <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                                                    </td>
                                                    <td style="vertical-align: top; text-align: right;" class="auto-style2">&nbsp;</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="txtEduID" runat="server" Text="0" Visible="false">
                                                        </dx:ASPxTextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td class="table_tr_left"></td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxButton ID="btnEduSave" runat="server" EnableTheming="True" Text="Save" OnClick="btnEduSave_Click">
                                                             <Image IconID="save_save_16x16"></Image> 
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnEduClear" runat="server" EnableTheming="True" Text="Clear" OnClick="btnEduClear_Click">
                                                            <Image IconID="actions_cancel_16x16"></Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <dx:ASPxGridView KeyFieldName="Id" runat="server" Width="100%" ID="dgEducation" EnableCallBacks="false" AutoGenerateColumns="False" OnCellEditorInitialize="dgEducation_CellEditorInitialize" OnCommandButtonInitialize="dgEducation_CommandButtonInitialize" OnCustomButtonInitialize="dgEducation_CustomButtonInitialize"  OnRowDeleting="dgEducation_RowDeleting" OnStartRowEditing="dgEducation_StartRowEditing" OnSelectionChanged="dgEducation_SelectionChanged">
                                            <Columns>
                                                <dx:GridViewCommandColumn Width="15%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" ShowSelectButton="true" />
                                                <dx:GridViewDataTextColumn Name="Title" FieldName="Institution" Caption="INSTITUTION" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="USER ID" FieldName="UserId" Caption="INSTITUTION" VisibleIndex="2" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="Level" FieldName="AcademicLevel" Caption="LEVEL" VisibleIndex="3">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="Qualification" FieldName="Qualification" Caption="QUALIFICATION" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="Documment" FieldName="Documment" Caption="DOCUMENT" VisibleIndex="5">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="DateAttended" FieldName="DateAttended" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" Caption="STARTING DATE" VisibleIndex="6">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="DateCompleted" FieldName="DateCompleted" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" Caption="COMPLETION DATE" VisibleIndex="7">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="Comment" FieldName="Comment" Caption="COMMENT" Visible="false" VisibleIndex="8">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>

                                            <SettingsPager PageSize="10">
                                            </SettingsPager>
                                            <SettingsCommandButton>
                                                <EditButton Text="Edit" />
                                                <DeleteButton Text="Delete" />
                                                <SelectButton Text="Document" ButtonType="Link" />
                                            </SettingsCommandButton>
                                            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" EnableCustomizationWindow="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                            <SettingsDataSecurity AllowInsert="False" />
                                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                        </dx:ASPxGridView>
                                    </ContentTemplate>

                                </asp:UpdatePanel>

                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="Family/Guadians">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl3" runat="server" SupportsDisabledAttribute="True">

                                <asp:UpdatePanel ID="upFamily" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <dx:ASPxMenu ID="mMainFam" runat="server" OnItemClick="mMainFam_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                             <Items>
                                                <dx:MenuItem Name="mitNewFam" Text="New">
                                                    <Image IconID="actions_add_16x16"></Image>
                                                </dx:MenuItem>
                                               
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
                                        <div id="div_familySibling" runat="server" visible="false" class="appWorkspace">
                                            <table style="width: 100%;">
                                                  <tr>
                                                    <td class="table_tr_left " style="width: 120px;">Siblings On Admision :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxComboBox ID="cmbFamilySiblings" NullText="Choose..." AutoPostBack="true" runat="server" OnValueChanged="cmbFamilySiblings_ValueChanged">
                                                            <Items>
                                                                <dx:ListEditItem Text="No" Value="No" />
                                                                <dx:ListEditItem Text="Yes" Value="Yes" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="div_familyStud" runat="server" visible="false" class="appWorkspace">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="table_tr_left" style="width: 120px;">Find Sibling :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxComboBox ID="cmbSearchStudent" runat="server" AutoPostBack="True" CallbackPageSize="10" DropDownRows="10" DropDownStyle="DropDown" EnableCallbackMode="True" FilterMinLength="2" Font-Size="10pt" Height="16px" TextFormatString="{0} - {1}" ValueField="UserId" Width="60%" OnItemRequestedByValue="cmbSearchStudent_ItemRequestedByValue" OnItemsRequestedByFilterCondition="cmbSearchStudent_ItemsRequestedByFilterCondition" >
                                                            <Columns>
                                                                <dx:ListBoxColumn Caption="Student ID" FieldName="IndexNo" Width="60px" />
                                                                <dx:ListBoxColumn Caption="User ID" Visible="false" FieldName="UserId" Width="60px" />
                                                                <dx:ListBoxColumn Caption="Name" FieldName="xFullName" Width="250px" />
                                                            </Columns>
                                                            
                                                            <ClearButton Visibility="True">
                                                            </ClearButton>
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxButton ID="btnSaveSiblingRela" runat="server" EnableTheming="True" Text="Add Family/Guadian" OnClick="btnSaveSiblingRela_Click">
                                                            <Image IconID="actions_save_16x16"></Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div runat="server" visible="false" id="div_family" class="appWorkspace">
                                            <table style="width: 100%;">


                                                <tr>
                                                    <td class="table_tr_right" style="width: 120px; text-align: right;">First Name :</td>
                                                    <td class="table_tr_right" style="width:35%;">
                                                        <dx:ASPxTextBox ID="txtFamFName" runat="server" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </td>

                                                    <td class="table_tr_left" style="width: 120px; text-align: right;">Surname :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtFamSName" runat="server" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="table_tr_left" >Other Names :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtFamONames" runat="server" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                    <td class="table_tr_left" style="text-align: right;">Relation :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxComboBox ID="cmbFamRelative" runat="server" NullText="Choose..." IncrementalFilteringMode="StartsWith">
                                                            
                                                        </dx:ASPxComboBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td class="table_tr_left" style="text-align: right;">Mobile :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtFamMobile" runat="server" NullText="0267818669" Width="100%" MaxLength="14">
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text">
                                                                <RegularExpression ValidationExpression="^\d{10,14}$" />
                                                            </ValidationSettings>
                                                           
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                    <td class="table_tr_left" >Tel :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtFamTel" runat="server" NullText="0243818669" Width="100%" MaxLength="14">
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text">
                                                                <RegularExpression ValidationExpression="^\d{10,14}$" />
                                                            </ValidationSettings>
                                                           
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_tr_left" >Email :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtFamEmail" NullText="info@comsoftgh.com" runat="server" Width="100%">
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text">
                                                                <RegularExpression ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                    <td class="table_tr_left" >Next Of Kin :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxComboBox ID="cmbFamNxtKin" runat="server" NullText="Choose..." SelectedIndex="0" IncrementalFilteringMode="StartsWith">
                                                            <Items>
                                                                <dx:ListEditItem Text="No" Value="No" />
                                                                <dx:ListEditItem Text="Yes" Value="No" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top;" class="table_tr_left">Posotal Address :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxMemo ID="txtFamPostAdd" runat="server" Width="100%" Height="50px">
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="Text">
                                                                <%--<RegularExpression ValidationExpression="^[a-zA-Z0-9''-'\s]{2,90}$" />--%>
                                                            </ValidationSettings>
                                                           
                                                        </dx:ASPxMemo>
                                                    </td>

                                                    <td style="vertical-align: top;" class="table_tr_left"></td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxTextBox ID="txtFamID" Text="0" Visible="false" runat="server" Width="100%">
                                                        </dx:ASPxTextBox>

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="table_tr_right"></td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxButton ID="btnFamSave" runat="server" EnableTheming="True" Text="Save" OnClick="btnFamSave_Click">
                                                            <Image IconID="actions_add_16x16"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnFamClear" runat="server" EnableTheming="True" Text="Clear" Width="15%" OnClick="btnFamClear_Click">
                                                           <Image IconID="actions_cancel_16x16"></Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <dx:ASPxGridView KeyFieldName="Id" runat="server" Width="100%" ID="gvFamily" EnableCallBacks="False" AutoGenerateColumns="False" OnRowDeleting="gvFamily_RowDeleting" OnStartRowEditing="gvFamily_StartRowEditing">
                                            <Columns>
                                                <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" />
                                                <dx:GridViewDataTextColumn Name="FName" FieldName="FirstName" Caption="FIRST NAME" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="UserId" FieldName="UserId" Caption="INSTITUTION" VisibleIndex="1" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="LastName" FieldName="LastName" Caption="SURNAME" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="OtherName" FieldName="OtherName" Caption="OTHER NAMES" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="RelType" FieldName="RelType" Caption="RELATION" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="Mobile" FieldName="Mobile" Caption="MOBILE" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="Tel" FieldName="Tel" Visible="false" Caption="TEL" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="Email" FieldName="Email" Caption="EMAIL" Visible="false" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="NextOfKin" FieldName="NextOfKin" Caption="NEXT OF KIN" Visible="true" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Name="PostAddress" FieldName="PostAddress" Caption="POSTAL ADDRESS" Visible="false" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>


                                            <SettingsPager PageSize="10">
                                            </SettingsPager>
                                            <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" EnableRowHotTrack="True" EnableCustomizationWindow="True" ProcessSelectionChangedOnServer="True" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                                            <SettingsDataSecurity AllowInsert="False" />
                                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                        </dx:ASPxGridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>

                </TabPages>
            </dx:ASPxPageControl>

        </ContentTemplate>
    </asp:UpdatePanel>


    <script type="text/javascript">
        // <![CDATA[
        function Uploader_OnFileUploadComplete(args) {
            var imgSrc = getPreviewImageElement().src;
            if (args.isValid) {
                imgSrc = args.callbackData;
                document.getElementById("divChangePic").style.display = 'none';
            }
            getPreviewImageElement().src = imgSrc;
        }
        function getPreviewImageElement() {
            return document.getElementById("imgMember");
        }
        // ]]>
    </script>
</asp:Content>






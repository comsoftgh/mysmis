<%@ Page Language="C#" Title="" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="programregistration.aspx.cs" Inherits="mySmis.programregistration" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        PROGRAM REGISTRATION
                                    </div>
   
            <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <dx:ASPxPageControl EnableHierarchyRecreation="false" ID="memberTabs" runat="server" ActiveTabIndex="1" Height="100%" Width="100%" Font-Size="11px">
                        <TabPages>
                            <dx:TabPage Text="Student">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl1" runat="server" SupportsDisabledAttribute="True">
                                        <asp:UpdatePanel ID="UpdatePanelPerson" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table style="width: 81px;">
                                                    <tr>
                                                        <td class="auto-style23">
                                                            <dx:ASPxButton ID="tbNew" runat="server" EnableTheming="True" Text="New" Width="80px" OnClick="tbNew_Click">
                                                                <Paddings Padding="0px" />


                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td class="auto-style23">
                                                            <dx:ASPxButton ID="btnRefresh" runat="server" EnableTheming="True" Text="Refresh" Width="80px" OnClick="btnRefresh_Click">
                                                                <Paddings Padding="0px" />


                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div id="divEdit" runat="server" visible="false">
                                                    <table style="width: 600px;">
                                                        <tr>
                                                            <td class="auto-style25">STUDENT TYPE 
                                                            </td>
                                                            <td class="auto-style25">
                                                                <dx:ASPxComboBox ID="cmbStdtype" runat="server" OnValueChanged="cmbStudtype_ValueChanged" Width="200px" AutoPostBack="True">

                                                                    <Items>
                                                                        <dx:ListEditItem Text="Member" Value="0" />
                                                                        <dx:ListEditItem Text="Guest" Value="1" />
                                                                    </Items>

                                                                </dx:ASPxComboBox>
                                                                <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                                                                </dx:ASPxTextBox>
                                                                <dx:ASPxTextBox ID="txtmemID" runat="server" Text="0" Visible="False" Width="50px">
                                                                </dx:ASPxTextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style23">FIND MEMBER</td>
                                                            <td class="auto-style19" colspan="2">
                                                                <dx:ASPxComboBox ID="cmbMember" runat="server" AutoPostBack="True" CallbackPageSize="10" DropDownRows="10" DropDownStyle="DropDown" EnableCallbackMode="True" Enabled="False" FilterMinLength="2" Font-Size="10pt" Height="16px" IncrementalFilteringMode="Contains" OnItemRequestedByValue="cmbMember_ItemRequestedByValue" OnItemsRequestedByFilterCondition="cmbMember_ItemsRequestedByFilterCondition" OnValueChanged="cmbMember_ValueChanged" TextFormatString="{0} - {1}" Theme="Default" ValueField="MemberId" Width="100%">
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
                                                        <tr>
                                                            <td class="auto-style27">LAST NAME</td>
                                                            <td class="auto-style24">
                                                                <dx:ASPxTextBox ID="txtFamilyLastName" runat="server" Width="200px">
                                                                </dx:ASPxTextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style27">OTHER NAMES</td>
                                                            <td class="auto-style24">
                                                                <dx:ASPxTextBox ID="txtFamilyOtherNames" runat="server" Width="200px">
                                                                </dx:ASPxTextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style9">GENDER</td>
                                                            <td>
                                                                <dx:ASPxComboBox ID="cmbGender" runat="server" SelectedIndex="0" IncrementalFilteringMode="StartsWith">
                                                                    <Items>
                                                                        <dx:ListEditItem Selected="True" Text="Choose..." Value="-" />
                                                                        <dx:ListEditItem Text="Male" Value="Male" />
                                                                        <dx:ListEditItem Text="Female" Value="Female" />
                                                                    </Items>
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style27">TEL</td>
                                                            <td class="auto-style24">
                                                                <dx:ASPxTextBox ID="txtFamilyTel" runat="server" Width="200px">
                                                                </dx:ASPxTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style27">EMAIL</td>
                                                            <td class="auto-style24">
                                                                <dx:ASPxTextBox ID="txtemail" runat="server" Width="200px">
                                                                </dx:ASPxTextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style27">INDEX NO.</td>
                                                            <td class="auto-style24" colspan="2">
                                                                <dx:ASPxTextBox ID="txtIndexNo" runat="server" Width="200px" ReadOnly="true">
                                                                </dx:ASPxTextBox>
                                                            </td>

                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style27"></td>
                                                            <td class="auto-style24">
                                                                <dx:ASPxButton ID="btnSaveStudent" runat="server" EnableTheming="True" Text="Save" Width="80px" OnClick="btnSaveStudent_Click">
                                                                    <Paddings Padding="0px" />


                                                                </dx:ASPxButton>
                                                                <dx:ASPxButton ID="btnClearStudent" runat="server" EnableTheming="True" Text="Clear" Width="80px" OnClick="btnClearStudent_Click">
                                                                    <Paddings Padding="0px" />


                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <dx:ASPxLabel ID="lblError" runat="server" BackColor="#CC0000" ForeColor="White" Height="25px" Visible="False" Width="100%">
                                                    <Border BorderColor="#CC0000" />
                                                </dx:ASPxLabel>
                                                <br />



                                                <dx:ASPxGridView ID="gvClassLessons" KeyFieldName="Id" runat="server" Width="100%" OnCellEditorInitialize="gvClassLessons_CellEditorInitialize"
                                                    SettingsBehavior-AllowFocusedRow="true" SettingsEditing-Mode="Inline" AutoGenerateColumns="False"
                                                    OnRowUpdating="gvClassLessons_RowUpdating" SettingsBehavior-AllowSelectSingleRowOnly="true">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn Width="10%" ShowEditButton="True" VisibleIndex="0" SelectAllCheckboxMode="Page">
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn Name="c2" FieldName="IndexNo" Caption="Index No." Visible="true">
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataComboBoxColumn Caption="Other Names" Visible="true" FieldName="OtherNames" Name="clLessonID" VisibleIndex="4">
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataComboBoxColumn Caption="Last Name" Visible="true" FieldName="LastName" Name="clModID" VisibleIndex="5">
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataComboBoxColumn Caption="Contact" Visible="true" FieldName="Tel" Name="clClassID" VisibleIndex="6">
                                                        </dx:GridViewDataComboBoxColumn>



                                                    </Columns>
                                                    <SettingsPopup>
                                                        <EditForm Width="600" />
                                                    </SettingsPopup>
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                    <SettingsEditing Mode="Inline">
                                                    </SettingsEditing>
                                                    <SettingsDataSecurity AllowInsert="False" />
                                                    <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                                </dx:ASPxGridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                        &nbsp;
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="Registration">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl2" runat="server" SupportsDisabledAttribute="True">
                                        <asp:UpdatePanel ID="UpdateRegistration" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 50%">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td class="auto-style29">FIND STUDENT</td>
                                                                    <td class="auto-style23">
                                                                        <dx:ASPxComboBox ID="cmbSearchStud" runat="server" AutoPostBack="True" CallbackPageSize="10" DropDownRows="10" DropDownStyle="DropDown" EnableCallbackMode="True" Enabled="True" FilterMinLength="2" Font-Size="10pt" Height="16px" IncrementalFilteringMode="Contains" OnItemsRequestedByFilterCondition="cmbSearchStud_ItemsRequestedByFilterCondition" TextFormatString="{0} - {1} {2}" DisplayFormatString="{0} - {1} {2}" Theme="Default" ValueField="IndexNo" Width="100%" OnItemRequestedByValue="cmbSearchStud_ItemRequestedByValue" OnValueChanged="cmbSearchStud_ValueChanged">
                                                                            <Columns>
                                                                                <dx:ListBoxColumn Caption="Index ID" FieldName="IndexNo" Width="60px" />
                                                                                <dx:ListBoxColumn Caption="Name" FieldName="OtherNames" Width="250px" />
                                                                                <dx:ListBoxColumn Caption="Surname" FieldName="LastName" Width="300px" />
                                                                            </Columns>
                                                                            <ItemStyle Font-Size="10pt">
                                                                                <SelectedStyle BackColor="#FF9900">
                                                                                </SelectedStyle>
                                                                                <HoverStyle BackColor="#FF9900">
                                                                                </HoverStyle>
                                                                                <Paddings PaddingBottom="5px" />
                                                                            </ItemStyle>
                                                                        </dx:ASPxComboBox>

                                                                        &nbsp;</td>

                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style29">SELECT PROGRAM</td>
                                                                    <td>
                                                                        <dx:ASPxComboBox AutoPostBack="true" TextField="ModuleName" DisplayFormatString="{0}" TextFormatString="{0}" IncrementalFilteringMode="Contains" ValueField="ModuleID" ID="cmbProgram" runat="server" Width="100%" OnValueChanged="cmbProgram_ValueChanged">
                                                                            <Columns>
                                                                                <dx:ListBoxColumn Caption="Program" FieldName="ModuleName" Width="60px" />
                                                                            </Columns>
                                                                        </dx:ASPxComboBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">PROGRAM - CLASSES REGISTERED 
                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td colspan="2" class="auto-style23">
                                                            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="dgStudenProgram" EnableCallBacks="False" AutoGenerateColumns="False" OnRowDeleting="dgStudenProgram_RowDeleting">
                                                                <Columns>
                                                                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowDeleteButton="True" />
                                                                    <dx:GridViewDataTextColumn Name="Title" FieldName="ClassTitle" Caption="Class" VisibleIndex="1">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Name="ID" FieldName="ID" Caption="ID" Visible="false">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Name="StudID" FieldName="StudID" Caption="ID" Visible="false">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Name="ModuleID" FieldName="ModuleID" Caption="ID" Visible="false">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Name="ClassID" FieldName="ClassID" Caption="ID" Visible="false">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Name="ClassSchedule" FieldName="ClassSchedule" Caption="Schedule" VisibleIndex="1">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Name="RegStatus" FieldName="RegStatus" Caption="Status" VisibleIndex="1">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Name="DateReg" FieldName="DateReg" Caption="Registration Date" PropertiesTextEdit-DisplayFormatString="dd MM yyyy" VisibleIndex="1">
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                                <SettingsPager PageSize="25">
                                                                </SettingsPager>
                                                                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                                                <Settings ShowFilterRow="True" />
                                                                <SettingsDataSecurity AllowInsert="False" AllowEdit="False" />

                                                            </dx:ASPxGridView>
                                                            <dx:ASPxButton runat="server" ID="btnRefreshReg" Text="Refresh" Visible="false" OnClick="btnRefreshReg_Click"></dx:ASPxButton>
                                                            <br />

                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">AVAILABLE CLASSES
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxGridView ID="gvRegisterStud" KeyFieldName="ID" runat="server" Width="100%" OnCellEditorInitialize="gvRegisterStud_CellEditorInitialize"
                                                                SettingsBehavior-AllowFocusedRow="true" SettingsEditing-Mode="Inline" AutoGenerateColumns="False"
                                                                OnRowUpdating="gvRegisterStud_RowUpdating" SettingsBehavior-AllowSelectSingleRowOnly="true">
                                                                <Columns>
                                                                    <dx:GridViewCommandColumn Width="10%" ShowEditButton="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                                                                    </dx:GridViewCommandColumn>
                                                                    <dx:GridViewDataTextColumn Name="c2" FieldName="Title" Caption="Class" ReadOnly="True">
                                                                    </dx:GridViewDataTextColumn>

                                                                    <dx:GridViewDataComboBoxColumn Caption="Class ID" Visible="false" FieldName="ID" Name="classID">
                                                                    </dx:GridViewDataComboBoxColumn>
                                                                    <dx:GridViewDataComboBoxColumn Caption="ModuleID" Visible="false" FieldName="ModuleID" Name="clModID">
                                                                    </dx:GridViewDataComboBoxColumn>

                                                                    <dx:GridViewDataComboBoxColumn Caption="Class Schedule" FieldName="ClassSchudle" UnboundType="String" Name="ClassShud">
                                                                        <PropertiesComboBox TextField="Title" ValueField="ID" />
                                                                        <EditItemTemplate>
                                                                            <dx:ASPxComboBox ID="cmbClassSched" OnValidation="cmbClassSched_Validation"
                                                                                OnInit="cmbClassSched_Init" OnUnload="cmbClassSched_Unload" DropDownWidth="300px" runat="server" SelectionMode="Single" TextField="Title" ValueField="ID">
                                                                                <Columns>
                                                                                    <dx:ListBoxColumn FieldName="Title" Caption="Available Schedules" Width="300px" />
                                                                                    <dx:ListBoxColumn FieldName="ID" Visible="false" />
                                                                                </Columns>
                                                                            </dx:ASPxComboBox>
                                                                        </EditItemTemplate>

                                                                    </dx:GridViewDataComboBoxColumn>

                                                                </Columns>
                                                                <SettingsPopup>
                                                                    <EditForm Width="600" />
                                                                </SettingsPopup>
                                                                <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                                <SettingsEditing Mode="Inline">
                                                                </SettingsEditing>
                                                                <SettingsDataSecurity AllowInsert="False" />
                                                                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                                            </dx:ASPxGridView>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>

                        </TabPages>
                        <Paddings Padding="0px" />
                        <TabStyle Height="30px">
                        </TabStyle>
                        <Border BorderStyle="None" />
                    </dx:ASPxPageControl>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
   
                                </asp:Content>



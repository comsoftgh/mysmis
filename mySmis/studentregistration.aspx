<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="studentregistration.aspx.cs" Inherits="mySmis.studentregistration" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        STUDENT - BATCH REGISTRATION
    </div>

    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>

            <dx:ASPxPageControl EnableHierarchyRecreation="false" ID="memberTabs" runat="server" ActiveTabIndex="0" Height="100%" Width="98%" Font-Size="11px">
                <TabPages>
                    <dx:TabPage Text="Student Batch Registration">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl1" runat="server" SupportsDisabledAttribute="True">

                                <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                    <Items>
                                        <dx:MenuItem Name="mitNew" Text="New">
                                            <Image IconID="actions_add_16x16"></Image>
                                        </dx:MenuItem>
                                        <dx:MenuItem Name="mitCancel" Text="Cancel">
                                             <Image IconID="actions_cancel_16x16"></Image>

                                        </dx:MenuItem>

                                    </Items>
                                </dx:ASPxMenu>
                                 <br />
                                <div id="div_FeesBatch" runat="server" visible="false" class="appWorkspace">
                                   
                                    <table style="width: 100%;">
                                        <tr>

                                            <td class="table_tr_right">
                                                <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>

                                        </tr>
                                        <tr>

                                            <td class="table_tr_right">

                                                <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                                    <Columns>

                                                        <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                                    </Columns>

                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                                        <SettingsPager NumericButtonCount="3" />
                                                        <Settings ShowFilterRow="true" />
                                                    </GridViewProperties>
                                                    <ValidationSettings ErrorDisplayMode="Text" SetFocusOnError="true">
                                                        <RequiredField IsRequired="true" />
                                                        
                                                    </ValidationSettings>
                                                    <ClearButton Visibility="True">
                                                    </ClearButton>
                                                </dx:ASPxGridLookup>


                                            </td>

                                        </tr>


                                        <tr>

                                            <td class="table_tr_right">

                                                <dx:ASPxGridView KeyFieldName="UserId" runat="server" Width="100%" ID="gvStudents" EnableCallBacks="False" AutoGenerateColumns="False">
                                                    <SettingsSearchPanel Visible="True" />
                                                    <Columns>
                                                        <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" ShowClearFilterButton="True" />
                                                        <dx:GridViewDataTextColumn Name="c2" FieldName="IndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="UserId" FieldName="UserId" Name="clLessonID" Visible="false" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="GENDER" FieldName="Gender" Name="clBgroup" VisibleIndex="6">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="xAge" VisibleIndex="4" ReadOnly="True"  Caption="AGE">
                            </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="ADMISSION DATE" FieldName="Admissiondate" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" Name="clBgroup" VisibleIndex="6">
                                                            <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>

                                                    <SettingsPager PageSize="15">
                                                    </SettingsPager>
                                                    <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                                    <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False" />
                                                    
                                                </dx:ASPxGridView>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_tr_right">
                                                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click">
                                                    
                                                    <Image IconID="save_save_16x16"></Image>
                                                </dx:ASPxButton>

                                            </td>
                                        </tr>
                                    </table>
                                </div>
                               

                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>

                    <dx:TabPage Text="Batch to Batch Registration">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl2" runat="server" SupportsDisabledAttribute="True">
                                <dx:ASPxMenu ID="mMainBB" runat="server" OnItemClick="mMainBB_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                                    <Items>
                                        <dx:MenuItem Name="mitNew" Text="New">
                                            <Image IconID="actions_add_16x16"></Image>
                                        </dx:MenuItem>
                                        <dx:MenuItem Name="mitCancel" Text="Cancel">
                                            <Image IconID="actions_cancel_16x16"></Image>
                                        </dx:MenuItem>

                                    </Items>
                                </dx:ASPxMenu>
 <br />
                                <div id="div_BB" runat="server" visible="false" class="appWorkspace">
                                   
                                    <table style="width: 100%;">
                                        <tr>

                                            <td class="table_tr_right">
                                                <dx:ASPxTextBox ID="txtBB" runat="server" Visible="False" Width="50px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>

                                        </tr>
                                        <tr>

                                            <td class="table_tr_right">

                                                <dx:ASPxGridLookup ID="cmbProgramBB" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbProgramBB_ValueChanged">
                                                    <Columns>

                                                        <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="CreatedDate" Visible="false" Caption="CreatedDate" />
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassID" Visible="false" Caption="ClassID" />
                                                    </Columns>

                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                                        <SettingsPager NumericButtonCount="3" />
                                                        <Settings ShowFilterRow="true" />
                                                    </GridViewProperties>
                                                    <ValidationSettings SetFocusOnError="true" ErrorDisplayMode="Text">
                                                        <RequiredField IsRequired="true" />
                                                        
                                                    </ValidationSettings>
                                                    <ClearButton Visibility="True">
                                                    </ClearButton>
                                                </dx:ASPxGridLookup>


                                            </td>

                                        </tr>


                                        <tr>

                                            <td class="table_tr_right">

                                                <dx:ASPxGridView KeyFieldName="UserId" runat="server" Width="100%" ID="gvBatchStudents" EnableCallBacks="False" AutoGenerateColumns="False">
                                                    <SettingsSearchPanel Visible="True" />
                                                    <Columns>
                                                        <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" ShowClearFilterButton="True" />
                                                        <dx:GridViewDataTextColumn Name="c2" FieldName="IndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="UserId" FieldName="UserId" Name="clLessonID" Visible="false" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="GENDER" FieldName="Gender" Name="clBgroup" VisibleIndex="6">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="xAge" VisibleIndex="4" ReadOnly="True"  Caption="AGE">
                            </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="ADMISSION DATE" FieldName="Admissiondate" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" Name="clBgroup" VisibleIndex="6">
                                                            <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>

                                                    <SettingsPager PageSize="15">
                                                    </SettingsPager>
                                                    <Settings ShowFilterRow="True" />
                                                    <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                                    <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False" />

                                                </dx:ASPxGridView>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_tr_right">
                                                <dx:ASPxGridLookup ID="cmbProgramBBNew" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" >
                                                    <Columns>

                                                        <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                                    </Columns>

                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                                        <SettingsPager NumericButtonCount="3" />
                                                        <Settings ShowFilterRow="true" />
                                                    </GridViewProperties>
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                        <ErrorFrameStyle Border-BorderColor="LightPink">
                                                            <Border BorderColor="LightPink" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                    <ClearButton Visibility="True">
                                                    </ClearButton>
                                                </dx:ASPxGridLookup>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_tr_right">
                                                <dx:ASPxButton ID="btnSaveBB" runat="server" Text="Save" OnClick="btnSaveBB_Click">
                                                    <Image IconID="save_save_16x16"></Image>

                                                </dx:ASPxButton>

                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                </TabPages>
            </dx:ASPxPageControl>

             <br />
                                <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvRegisterdBatches" AutoGenerateColumns="False" OnRowDeleting="gvRegisterdBatches_RowDeleting">
                                    <Columns>
                                        <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowDeleteButton="True" />
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="StuduserId" Caption="INDEX NO." VisibleIndex="1" Visible="false" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="GENDER" FieldName="xGender" Name="clBgroup" VisibleIndex="6">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="xAge" VisibleIndex="4" ReadOnly="True"  Caption="AGE">
                            </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="ADMISSION DATE" FieldName="xAdmissiondate" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" Name="clBgroup" VisibleIndex="6">
                                            <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn GroupIndex="0" Caption="BATCH TITLE" FieldName="xBatchTitle" Name="clBgroup" VisibleIndex="6">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>

                                    <GroupSummary>

                                        <dx:ASPxSummaryItem FieldName="xIndexNo" DisplayFormat="NUMBER OF STUDENTS : {0}" SummaryType="Count" />
                                    </GroupSummary>

                                    <SettingsPager PageSize="15">
                                    </SettingsPager>
                                    <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" />
                                    <SettingsDataSecurity AllowInsert="False" />
                                    <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="gridExp" runat="server" GridViewID="dgEvent">
                                </dx:ASPxGridViewExporter>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


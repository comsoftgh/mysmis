<%@ Page Language="C#" Title="" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="lessonattendance.aspx.cs" Inherits="mySmis.lessonattendance" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                <div class="Separator Pagetitle" >
                                        ATTENDANCE
                                    </div>
                    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">  </asp:ScriptManager>
                            
                            <table style="width:100%;">
                                                                           
                                <tr>
                                    <td class="auto-style29">CLASS SCHEDULE</td>
                                    <td>
                                        <dx:ASPxComboBox AutoPostBack="True" OnButtonClick="cmbClassSchudle_ButtonClick" TextField="Title" DisplayFormatString="{0} - {1}" TextFormatString="{0} - {1}" ValueField="ID" ID="cmbClassSchudle" runat="server" Width="100%" >
                                            <Columns>
                                                <dx:ListBoxColumn Caption="Class Schedule" FieldName="Title" Width="60px" />
                                                <dx:ListBoxColumn Caption="Class Size" FieldName="ClassSize" Width="60px" />
                                            </Columns>
                                            <Buttons>
                                                <dx:EditButton Text="Clear">
                                                </dx:EditButton>
                                            </Buttons>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                            </table>    
                            <br />
                            <table style="width:100%;">
                                                                           
                                <tr>
                                    <td class="auto-style29">STUDENT</td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbSearchStud" OnButtonClick="cmbSearchStud_ButtonClick" runat="server" AutoPostBack="True" CallbackPageSize="10" DropDownRows="10" DropDownStyle="DropDown" EnableCallbackMode="True" FilterMinLength="2" Font-Size="10pt" Height="16px"  OnItemsRequestedByFilterCondition="cmbSearchStud_ItemsRequestedByFilterCondition" TextFormatString="{0} - {1} {2}" DisplayFormatString="{0} - {1} {2}" Theme="Default" ValueField="IndexNo" Width="100%" OnItemRequestedByValue="cmbSearchStud_ItemRequestedByValue" >
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
                                            <Buttons>
                                                <dx:EditButton Text="Clear">
                                                </dx:EditButton>
                                            </Buttons>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <dx:ASPxButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="SEARCH"  >
                                            <Paddings Padding="0px" />
                                            
                                            
                                        </dx:ASPxButton>
                                    </td>
                                    
                                </tr>
                            </table>  
                            <div runat="server" id="div_error" visible="false" class="div_error"></div>
                              <br />
                            <dx:ASPxGridView ID="gvAttendance" KeyFieldName="ID" runat="server" Width="100%" OnCellEditorInitialize="gvAttendance_CellEditorInitialize"
                                         SettingsBehavior-AllowFocusedRow="true" SettingsEditing-Mode="Batch" AutoGenerateColumns="False" 
                                         OnRowUpdating="gvAttendance_RowUpdating" OnBatchUpdate="gvAttendance_BatchUpdate"
                                        >
                                    <Columns>
                                        <%--<dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                                        </dx:GridViewCommandColumn>--%>
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="IndexNo" Caption="Index No." Width="100px" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="StudName" Caption="Name" Width="350px" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="LessonTitle" Caption="Lesson" Width="350px" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn Name="c2" FieldName="Attended" Caption="Attended" Width="100px" >
                                            <PropertiesComboBox TextField="Attended" ValueField="Attended">
                                                <Items>
                                                    <dx:ListEditItem Text="Yes" Value="Yes" />
                                                    <dx:ListEditItem  Text="No" Value="No"/>
                                                </Items>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Score"  Width="100px" FieldName="Score"  >
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Status"   Width="150px" FieldName="Completed"  >
                                            <PropertiesComboBox TextField="Completed" ValueField="Completed">
                                                <Items>
                                                    <dx:ListEditItem Text="Completed" Value="Completed" />
                                                    <dx:ListEditItem  Text="Not Completed" Value="Not Completed "/>
                                                </Items>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="ModuleID" Visible="false" Caption="Lesson" >
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="ClassID" Visible="false" Caption="Lesson" >
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="LessonID" Visible="false" Caption="Lesson" >
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="c2" FieldName="ClassSchedID" Visible="false" Caption="Lesson" >
                                        </dx:GridViewDataTextColumn>
                                        
                                        
                                     
                                    </Columns>
                                        <SettingsPopup>
                                            <EditForm Width="600" />
                                        </SettingsPopup>
                                        <SettingsPager PageSize="50"></SettingsPager>
                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                        <SettingsEditing Mode="Batch">
                                            <BatchEditSettings StartEditAction="DblClick" EditMode="Row" ShowConfirmOnLosingChanges="true"/>
                                        </SettingsEditing>
                                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                        <SettingsDataSecurity AllowInsert="False" />
                                    </dx:ASPxGridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>
        
            </asp:Content>




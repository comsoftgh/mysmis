<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="academicattendance.aspx.cs" Inherits="mySmis.academicattendance" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                    <div class="Separator Pagetitle" >
                                        STUDENT ATTENDANCE
                                    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            

                                <asp:UpdatePanel ID="upFeesBatches" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                      

                                        <div class="appWorkspace">
                                            <table style="width:100%;">
                                                
                                                <tr>
                                                    <td class="table_tr_left" style="width:120px;">Academic Batch :</td>
                                                    <td class="table_tr_right" colspan="3">

                                                        <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="True" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%"  AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                                            <Columns>

                                                                <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Academic Batch" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="ClassID" Visible="false" Caption="ClassID" />
                                                            </Columns>

                                                            <GridViewProperties>
                                                                <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                                                <SettingsPager NumericButtonCount="3" />
                                                                <Settings ShowFilterRow="true" ColumnMinWidth="300" />
                                                            </GridViewProperties>
                                                            <ValidationSettings>
                                                                <RequiredField IsRequired="true" />
                                                                <ErrorFrameStyle Border-BorderColor="LightPink">
                                                                    <Border BorderColor="LightPink" />
                                                                </ErrorFrameStyle>
                                                            </ValidationSettings>
                                                            <ClearButton Visibility="True" DisplayMode="Always">
                                                            </ClearButton>
                                                        </dx:ASPxGridLookup>
                                                        

                                                    </td>

                                                </tr>
                                              </table>
                                            <table>  

                                                <tr>
                                                    <td class="table_tr_left" style="width:120px;">Attendance Date :<br />
                                    
                                </td>
                                <td class="table_tr_right" style="vertical-align: top; width: 120px;">
                                    

                                    <dx:ASPxDateEdit ID="dtPayDate" runat="server" AutoPostBack="true" NullText="Choose Date ..." OnValueChanged="dtPayDate_ValueChanged">
                                        <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" ErrorTextPosition="Right" SetFocusOnError="true" />

                                    </dx:ASPxDateEdit>
                                </td>
                                                    <div runat="server" id="divCourse" visible="false">
                                                    <td class="table_tr_left" style="width:120px;">Course/Subject :</td>
                                                    <td class="table_tr_right">
                                                        <dx:ASPxComboBox runat="server" ID="cmbLessons" NullText="Choose Course/Subject ..." AutoPostBack="true" ValueField="ID" TextField="Title" Enabled="false" OnValueChanged="cmbLessons_ValueChanged" >
                                                            <ValidationSettings ErrorDisplayMode="Text" ErrorText="*" SetFocusOnError="true">
                                                                <RequiredField IsRequired="true" />
                                                                
                                                            </ValidationSettings>
                                                            <ClearButton Visibility="True"> </ClearButton>
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                    </div>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                       
                                       <dx:ASPxGridView KeyFieldName="StuduserId" runat="server" Width="100%" ID="gvStudents" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="gvStudents_CommandButtonInitialize">
                                                    <SettingsSearchPanel Visible="True" />
                                                    <Columns>
                                                        <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" />
                                                        <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="INDEX NO." VisibleIndex="1" Width="20%" ReadOnly="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="StuduserId" FieldName="UserId" Name="clLessonID" Visible="false" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <%--<dx:GridViewDataTextColumn Caption="GENDER" FieldName="Gender" Name="clBgroup" VisibleIndex="6">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="ADMISSION DATE" FieldName="Admissiondate" PropertiesTextEdit-DisplayFormatString="dd MMMM yyyy" Name="clBgroup" VisibleIndex="6">
                                                            <PropertiesTextEdit DisplayFormatString="dd MMMM yyyy">
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>--%>
                                                    </Columns>

                                                    <SettingsPager PageSize="15">
                                                    </SettingsPager>
                                                    <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                                    <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False" />
                                           <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                                </dx:ASPxGridView> 
                                        <dx:ASPxGridViewExporter ID="gridExp" runat="server" GridViewID="dgEvent">
                                        </dx:ASPxGridViewExporter>

                                        <br />
                                        <div class="appWorkspace">
                                        <table>
                                        <tr>
                                
                                <td class="table_tr_right" colspan="2" style="padding-left: 10px;">
                                    
                                         <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click">
                                                    <Image IconID="save_save_16x16"></Image>

                                                </dx:ASPxButton>
                                 
                                </td>

                            </tr>

                                   
                                            </table>
                                    </div>
                                            </ContentTemplate>
                                </asp:UpdatePanel>
                           
            
        </ContentTemplate>
    </asp:UpdatePanel>
                                </asp:Content>


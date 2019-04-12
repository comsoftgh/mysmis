<%@ Page Title="" Language="C#" MasterPageFile="~/tutor.Master" AutoEventWireup="true" CodeBehind="tutorsinterimassessment.aspx.cs" Inherits="mySmis.tutorsinterimassessment" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                     <div class="Separator Pagetitle" >
                                        INTERIM ASSESSMENT
                                    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            

                                <asp:UpdatePanel ID="upFeesBatches" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                      

                                        
                                            <table style="width: 100%;">
                                                
                                                <tr>

                                                    <td>

                                                        <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="true" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%"  AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                                            <Columns>

                                                                <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="BATCH" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="xLesson" Caption="SUBJECT/LESSON" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="ClassID" Visible="false" Caption="ClassID" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="xLessonId" Visible="false" Caption="xLessonId" />
                                                            </Columns>

                                                            <GridViewProperties>
                                                                <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" AllowSelectByRowClick="true" AllowFocusedRow="true" />
                                                                <SettingsPager NumericButtonCount="3" />
                                                                <Settings ShowFilterRow="true" ColumnMinWidth="300" />
                                                            </GridViewProperties>
                                                            <ValidationSettings>
                                                                <RequiredField IsRequired="true" />
                                                                <ErrorFrameStyle Border-BorderColor="LightPink"></ErrorFrameStyle>
                                                            </ValidationSettings>
                                                            <ClearButton Visibility="True">
                                                            </ClearButton>
                                                        </dx:ASPxGridLookup>
                                                        

                                                    </td>

                                                </tr>
                                            </table>
                                        <br />
                                       
                                        <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvStudents" EnableCallBacks="False" AutoGenerateColumns="False" OnBatchUpdate="gvStudents_BatchUpdate" >
                                                <SettingsSearchPanel Visible="True" />
                                                <Columns>
                                                    
                                                    <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="LESSON CODE" FieldName="xLessCode" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="LESSON/COURSE" FieldName="xLesson" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="TEST SCORE" FieldName="TestMarks" Name="clLessonID" VisibleIndex="4" >
                                                    </dx:GridViewDataTextColumn>
                                                    
                                                    
                                                </Columns>
                                            
                                                <SettingsPager PageSize="25">
                                                </SettingsPager>
                                                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                                                <SettingsDataSecurity AllowInsert="False" AllowDelete="False" />
                                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                                            <SettingsEditing Mode="Batch" />
                                            </dx:ASPxGridView>
                                        <dx:ASPxGridViewExporter ID="gridExp" runat="server" GridViewID="dgEvent">
                                        </dx:ASPxGridViewExporter>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                           
            
        </ContentTemplate>
    </asp:UpdatePanel>
                                </asp:Content>


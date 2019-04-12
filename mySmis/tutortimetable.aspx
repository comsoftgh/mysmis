<%@ Page Title="" Language="C#" MasterPageFile="~/tutor.Master" AutoEventWireup="true" CodeBehind="tutortimetable.aspx.cs" Inherits="mySmis.tutortimetable" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentHolder">
                                     <div class="Separator Pagetitle" >
                                        TIMETABLE SCHEDULE
                                    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
           
            <table style="width: 100%;">
                    <tr>

                        <td class="auto-style40">
                            <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                            </dx:ASPxTextBox>
                        </td>

                    </tr>
                    <tr>

                        <td>

                            <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="true" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%"  AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                                            <Columns>

                                                                <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="BATCH" />
                                                                <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="xLesson" Visible="false" Caption="SUBJECT/LESSON" />
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
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="1000px" ID="dgTimetable" EnableCallBacks="false" AutoGenerateColumns="False" >
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" Visible="false" />
                    <dx:GridViewDataTextColumn Name="c2" FieldName="LessDay" Caption="DAY" Visible="false" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xLessonCode" Caption="CODE" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xLessonTitle" Caption="TITLE" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="LessTime" Caption="PERIOD" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xVenueName" Caption="VENU" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="c2" FieldName="xTutorName" Visible="false" Caption="TUTOR" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn GroupIndex="0" Name="LessDay" FieldName="LessDay" Caption="DAY" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>

                </Columns>
                
                <SettingsPager PageSize="15" Visible="False">
                </SettingsPager>
                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowSelectSingleRowOnly="True" AllowFocusedRow="True" AutoExpandAllGroups="True" />
                <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False" />
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
            </dx:ASPxGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
                                </asp:Content>


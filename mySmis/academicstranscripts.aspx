<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="academicstranscripts.aspx.cs" Inherits="mySmis.academicstranscripts" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        TRANSCRIPTS 
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

                            <td class="auto-style40"></td>

                        </tr>
                        <tr>

                            <td>

                                <dx:ASPxGridLookup ID="cmbProgram" NullText="Choose Academic Batch ..." runat="server" AutoPostBack="true" GridViewProperties-EnableCallBacks="true" KeyFieldName="ID" TextFormatString="{0} - ({1})" Width="60%" AutoGenerateColumns="False" OnValueChanged="cmbProgram_ValueChanged">
                                    <Columns>

                                        <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="Class" />
                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassSize" Caption="Class Size" />
                                        <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="Bgroup" Visible="false" Caption="Bgroup" />
                                        <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="ClassID" Visible="false" Caption="ClassID" />
                                        <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="BgsId" Visible="false" Caption="BgsId" />
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
                    </div>
                        <br />

                    <dx:ASPxGridView Visible="true" KeyFieldName="ID" runat="server" Width="100%" ID="gvTranscriptTertiary" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="gvTranscriptTertiary_CommandButtonInitialize">
                        <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewCommandColumn Width="15%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowSelectButton="True" />
                            <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn Name="c2" FieldName="StuduserId" Caption="USER ID" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="BatchId" Caption="BatchId" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="xGsId" Caption="xGsId" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="LEVEL" FieldName="xBatchTitle" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Templates>
                            <DetailRow>
                                <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvTranscriptTertiaryDetails" OnBeforePerformDataSelect="gvTranscriptTertiaryDetails_BeforePerformDataSelect" EnableCallBacks="False" AutoGenerateColumns="False">

                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="LESSON CODE" FieldName="xLessCode" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="LESSON/COURSE" FieldName="xLesson" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="TEST SCORE" FieldName="TestMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="EXAMS SCORE" FieldName="ExamsMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="TOTAL SCORE" FieldName="xTotalMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="GRADE" FieldName="xGrade" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="GRADE PT." FieldName="xGradepiont" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="INTERPRETATION" FieldName="xGradeDesc" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Settings ShowFooter="True" />
                                    
                                    <SettingsEditing Mode="Inline" />
                                    
                                </dx:ASPxGridView>
                            </DetailRow>
                        </Templates>

                        <GroupSummary>
                            <dx:ASPxSummaryItem FieldName="xFullName" Visible="true" SummaryType="None" />
                        </GroupSummary>
                        <SettingsPager PageSize="15">
                        </SettingsPager>
                        <SettingsDetail ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="true" />
                        <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                        <SettingsDataSecurity AllowInsert="False" AllowDelete="False" />
                        <SettingsCommandButton>
                            <EditButton Text="Results"></EditButton>
                            <SelectButton Text="Transcript"></SelectButton>
                        </SettingsCommandButton>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="gridExp" runat="server" GridViewID="dgEvent">
                    </dx:ASPxGridViewExporter>

                    <dx:ASPxGridView Visible="false" KeyFieldName="ID" runat="server" Width="100%" ID="gvTranscriptSecondCycle" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="gvTranscriptSecondCycle_CommandButtonInitialize">
                        <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewCommandColumn Width="15%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowSelectButton="True" />
                            <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn Name="c2" FieldName="StuduserId" Caption="USER ID" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="BatchId" Caption="BatchId" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="xGsId" Caption="xGsId" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="LEVEL" FieldName="xBatchTitle" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Templates>
                            <DetailRow>
                                <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvTranscriptSecondCycleDetails" OnBeforePerformDataSelect="gvTranscriptSecondCycleDetails_BeforePerformDataSelect" EnableCallBacks="False" AutoGenerateColumns="False">

                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="LESSON CODE" FieldName="xLessCode" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="LESSON/COURSE" FieldName="xLesson" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="TEST SCORE" FieldName="TestMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="EXAMS SCORE" FieldName="ExamsMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="TOTAL SCORE" FieldName="xTotalMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="GRADE" FieldName="xGrade" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="GRADE PT." FieldName="xGradepiont" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="INTERPRETATION" FieldName="xGradeDesc" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Settings ShowFooter="True" />
                                    
                                    <SettingsEditing Mode="Inline" />
                                    
                                </dx:ASPxGridView>
                            </DetailRow>
                        </Templates>

                        <GroupSummary>
                            <dx:ASPxSummaryItem FieldName="xFullName" Visible="true" SummaryType="None" />
                        </GroupSummary>
                        <SettingsPager PageSize="15">
                        </SettingsPager>
                        <SettingsDetail ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="true" />
                        <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                        <SettingsDataSecurity AllowInsert="False" AllowDelete="False" />
                        <SettingsCommandButton>
                            <EditButton Text="Results"></EditButton>
                            <SelectButton Text="Transcript"></SelectButton>
                        </SettingsCommandButton>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="dgEvent">
                    </dx:ASPxGridViewExporter>

                    <dx:ASPxGridView Visible="false" KeyFieldName="ID" runat="server" Width="100%" ID="gvTranscriptBasic" EnableCallBacks="False" AutoGenerateColumns="False" OnCommandButtonInitialize="gvTranscriptBasic_CommandButtonInitialize">
                        <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewCommandColumn Width="15%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowSelectButton="True" />
                            <dx:GridViewDataTextColumn Name="c2" FieldName="xIndexNo" Caption="INDEX NO." VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn Name="c2" FieldName="StuduserId" Caption="USER ID" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="BatchId" Caption="BatchId" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="c2" FieldName="xGsId" Caption="xGsId" Visible="false" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="NAME" FieldName="xFullName" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="LEVEL" FieldName="xBatchTitle" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Templates>
                            <DetailRow>
                                <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="gvTranscriptBasicDetails" OnBeforePerformDataSelect="gvTranscriptBasicDetails_BeforePerformDataSelect" EnableCallBacks="False" AutoGenerateColumns="False">

                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="LESSON CODE" FieldName="xLessCode" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="LESSON/COURSE" FieldName="xLesson" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="TEST SCORE" FieldName="TestMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="EXAMS SCORE" FieldName="ExamsMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="TOTAL SCORE" FieldName="xTotalMarks" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="GRADE" FieldName="xGrade" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="GRADE PT." FieldName="xGradepiont" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="INTERPRETATION" FieldName="xGradeDesc" Name="clLessonID" VisibleIndex="4" ReadOnly="True">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Settings ShowFooter="True" />
                                    
                                    <SettingsEditing Mode="Inline" />
                                    
                                </dx:ASPxGridView>
                            </DetailRow>
                        </Templates>

                        <GroupSummary>
                            <dx:ASPxSummaryItem FieldName="xFullName" Visible="true" SummaryType="None" />
                        </GroupSummary>
                        <SettingsPager PageSize="15">
                        </SettingsPager>
                        <SettingsDetail ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="true" />
                        <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="true" AllowFocusedRow="True" />
                        <SettingsDataSecurity AllowInsert="False" AllowDelete="False" />
                        <SettingsCommandButton>
                            <EditButton Text="Results"></EditButton>
                            <SelectButton Text="Transcript"></SelectButton>
                        </SettingsCommandButton>
                        <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="dgEvent">
                    </dx:ASPxGridViewExporter>

                </ContentTemplate>
            </asp:UpdatePanel>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


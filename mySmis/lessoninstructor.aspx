<%@ Page Language="C#" Title="" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="lessoninstructor.aspx.cs" Inherits="mySmis.lessoninstructor" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        LESSON - TUTOR 
    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <dx:ASPxMenu ID="mMain" runat="server" OnItemClick="mMain_ItemClick" AllowSelectItem="True" AutoPostBack="true" ShowPopOutImages="True">
                <Items>
                    <dx:MenuItem Name="mitNew" Enabled="false" Text="New">
                        <Image IconID="actions_add_16x16">
                        </Image>
                    </dx:MenuItem>
                    <dx:MenuItem Name="mitCancel" Enabled="false" Text="Cancel">
                        <Image IconID="actions_cancel_16x16">
                        </Image>
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
            <div id="divLessons" runat="server" visible="false" class="appWorkspace">
                <table style="width:100%;">
                    <tr>
                        <td colspan="2">
                <dx:ASPxTextBox ID="txtId" runat="server" Visible="False" Width="50px" Text="0">
                </dx:ASPxTextBox>
                            </td>
</tr>
<tr>
    <td >
                <dx:ASPxGridLookup ID="cmbLessons" NullText="Choose Course/Subject ..." runat="server" KeyFieldName="ID" SelectionMode="Single" AutoPostBack="true" TextFormatString="{0} - ({1})" Width="100%" IncrementalFilteringMode="Contains"  OnValueChanged="cmbLessons_ValueChanged">
                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="Title" Caption="COURSE/SUBJECT" Width="200px" />
                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ClassName" Caption="PROGRAM/LEVEL" Width="200px" />

                    </Columns>

                    <GridViewProperties>
                        <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" />
                        <SettingsPager NumericButtonCount="3" />
                        <Settings ShowFilterRow="true" />
                    </GridViewProperties>
                </dx:ASPxGridLookup>
        </td>
    <td></td>
            </tr>
                    <tr>
                        <td style="vertical-align:top;width:50%;">
                            <dx:ASPxGridView KeyFieldName="UserId" runat="server" Width="100%" ID="gvAllInstructors" OnCommandButtonInitialize="gvAllInstructors_CommandButtonInitialize" EnableCallBacks="false" OnStartRowEditing="gvAllInstructors_StartRowEditing" AutoGenerateColumns="False">
                    <Columns>
                        <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" />
                        <dx:GridViewDataTextColumn Name="c2" FieldName="xFullName" Caption="All TEACHING STAFF" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>

                    </Columns>
                    <SettingsPager PageSize="5">
                    </SettingsPager>
                    <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                    <Settings ShowFilterRow="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />

                    <SettingsCommandButton>
                        <EditButton Text="Assign" />
                    </SettingsCommandButton>
                </dx:ASPxGridView>
               
</td>
                        <td style="vertical-align:top;width:50%;">
                 <dx:ASPxGridView KeyFieldName="ID" OnRowDeleting="gvLessonInstructors_RowDeleting" runat="server" EnableCallBacks="false" OnCommandButtonInitialize="gvLessonInstructors_CommandButtonInitialize" Width="100%" ID="gvLessonInstructors" AutoGenerateColumns="False">
                    <Columns>
                        <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowDeleteButton="True" />
                        <dx:GridViewDataTextColumn Name="c2" FieldName="TutorName" Caption="COURSE/SUBJECT - TEACHING STAFF" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>

                    </Columns>
                    <SettingsPager PageSize="5">
                    </SettingsPager>
                    <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                    <Settings ShowFilterRow="True" />
                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" />

                </dx:ASPxGridView>
                            </td>
                        </tr>
</table>
            </div>
            <div id="div_error" runat="server" class="div_error" visible="false"></div>
            <br />

            <dx:ASPxGridView KeyFieldName="LessonID" runat="server" Width="100%" ID="dgLessonsTutors" EnableCallBacks="False" AutoGenerateColumns="False" OnStartRowEditing="dgLessonsTutors_StartRowEditing" OnCommandButtonInitialize="dgLessonsTutors_CommandButtonInitialize" OnRowDeleting="dgLessonsTutors_RowDeleting">
                <Columns>
                    <dx:GridViewCommandColumn Width="10%" Name="c1" VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" />
                    <dx:GridViewDataTextColumn Name="Title" FieldName="LessonTitle" Caption="COURSE/SUBJECT" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="Code" FieldName="Code" Caption="CODE" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="ID" FieldName="ID" Caption="ID" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="Type" FieldName="Type" Caption="TYPE">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Name="Description" Visible="false" FieldName="LessonDescription" Caption="Description" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn GroupIndex="0" Name="TutorName" FieldName="TutorName" Caption="TEACHING STAFF" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsPager PageSize="30">
                </SettingsPager>
                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                <Settings ShowFilterRow="True" VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                <SettingsDataSecurity AllowInsert="False" />

            </dx:ASPxGridView>


        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgLessonsTutors">
    </dx:ASPxGridViewExporter>

</asp:Content>




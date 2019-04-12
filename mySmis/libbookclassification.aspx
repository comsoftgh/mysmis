<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="libbookclassification.aspx.cs" Inherits="mySmis.libbookclassification" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentHolder">
    <div class="Separator Pagetitle">
        STANDARD LIBRARY BOOKS CLASSIFICATION 
    </div>
    <asp:UpdatePanel runat="server" ID="uPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <dx:ASPxMenu ID="mMenu" runat="server" OnItemClick="mMenu_ItemClick" AllowSelectItem="True" AutoPostBack="True" ShowPopOutImages="True">
                <Items>
                    
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
            
            <dx:ASPxGridView KeyFieldName="ID" runat="server" Width="100%" ID="dgLibClassification" EnableCallBacks="false" AutoGenerateColumns="False" >
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewDataTextColumn GroupIndex="0"  Name="c2" FieldName="TitleBlock" Caption="BLOCK" VisibleIndex="1" />
                    <dx:GridViewDataTextColumn Name="c2" GroupIndex="1" FieldName="TitleShelve" Caption="SHELVE" VisibleIndex="1" />
                    <dx:GridViewDataTextColumn Name="c2" Width="10%" FieldName="CodeStack" Caption="STACK NUMBER" VisibleIndex="1" />
                    <dx:GridViewDataTextColumn Name="c2" FieldName="TitleStack" Caption="STACK CATEGORY" VisibleIndex="1" />                      
                </Columns>
                <SettingsPager PageSize="25"></SettingsPager>
                <SettingsDetail ExportMode="All" />
                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="true" AllowFocusedRow="True" />
                <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False" />
                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400"  />
            </dx:ASPxGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:ASPxGridViewExporter ID="dataExporter" runat="server" GridViewID="dgLibClassification" FileName="Standard Library Books Classification"></dx:ASPxGridViewExporter>

</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="mySmis.upload" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>FileUpload.SaveAs Method Example</title>

</head>
<body>

    <h3>FileUpload.SaveAs Method Example</h3>

    <form id="Form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <dx:ASPxHiddenField ID="hiddenMode" runat="server"></dx:ASPxHiddenField>
        <asp:UpdatePanel ID="upEducational" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
        <h4>Select a file to upload:</h4>

        <asp:FileUpload id="FileUpload1"                 
            runat="server">
            
        </asp:FileUpload>

        <br /><br />

        <asp:Button id="UploadButton" 
            Text="Upload file"
            OnClick="UploadButton_Click"
            runat="server">
        </asp:Button>      

        <hr />

        <asp:Label id="UploadStatusLabel"
            runat="server">
        </asp:Label>   

  </ContentTemplate>
            <Triggers>
       <asp:PostBackTrigger ControlID="UploadButton"  />
   </Triggers>
                        </asp:UpdatePanel>
    </form>

</body>
</html>

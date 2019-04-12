<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="mySmis.login" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>mySmis - login</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="A highly customized School Management Information System to manage both academia and non-academia institutions of various levels. It is a carefully thought, planned and engineered software with top level reports and statically dashboards." name="description" />
    <meta content="Comsoft Solutions :: www.comsoftsolutions.com" name="author" />
    <link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/metro.css" rel="stylesheet" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/style_responsive.css" rel="stylesheet" />
    <link href="assets/css/style_default.css" rel="stylesheet" id="style_color" />
    <link rel="stylesheet" type="text/css" href="assets/uniform/css/uniform.default.css" />
    <link rel="shortcut icon" href="favicon.ico" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="login">
    <!-- BEGIN LOGO -->
    <div class="logo">
        
        <img src="images/mySmis.png" alt="" />  
    </div>
    <!-- END LOGO -->
    <!-- BEGIN LOGIN -->
    <form class="form-vertical login-form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!--<asp:UpdatePanel ID="UpdatePanelLogin" runat="server" UpdateMode="Conditional">
        <ContentTemplate> -->
            <div class="content">
                <!-- BEGIN LOGIN FORM -->
                
                    <h4 runat="server" id="div_name" style="font-weight:bold;text-align:center;" class="form-title"></h4>
                    <h4 class="form-title">Login </h4>
                    <div class="control-group">
                        <div class="controls">
                            <div class="input-icon left">
                                <i class="icon-user"></i>
                                <input class="m-wrap" type="text" runat="server" id="txtUsername" placeholder="Username" />
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <div class="input-icon left">
                                <i class="icon-lock"></i>
                                <input class="m-wrap" type="password" runat="server" id="txtPassword" style="" placeholder="Password" />
                            </div>
                        </div>
                    </div>
                    <div class="form-actions">
                        <dx:ASPxButton ID="btnLogin" CssClass="pull-right" runat="server" Text="Login" OnClick="btnLogin_Click">
                            <Image IconID="businessobjects_bouser_16x16">
                            </Image>
                        </dx:ASPxButton>
                        
                    </div>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelLogin">
                        <ProgressTemplate>
                            Please wait...
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                
                    <div class="forget-password">
                        <h5>Forgot your password ?</h5>
                        <p>
                            Contact your <a href="#" class="" id="forget-password">Administrator</a> to reset it for you.
                        </p>
                    </div>
                
                <!-- END LOGIN FORM -->
                <!-- BEGIN FORGOT PASSWORD FORM -->

                <!-- END FORGOT PASSWORD FORM -->
            </div>
  <!--  </ContentTemplate>
    </asp:UpdatePanel> -->
        </form>
    <!-- END LOGIN -->
    <!-- BEGIN COPYRIGHT -->
    <div class="copyright">
        2015 &copy; Powered by <a href="http://www.comsoftgh.com" target="_blank" style="text-decoration: none;">Comsoft Solutions</a>
    </div>
    <!-- END COPYRIGHT -->
    <!-- BEGIN JAVASCRIPTS -->
    <script src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/uniform/jquery.uniform.min.js"></script>
    <script src="assets/js/jquery.blockui.js"></script>
    <script src="assets/js/app.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.initLogin();
        });
    </script>

    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>

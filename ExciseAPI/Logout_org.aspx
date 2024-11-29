<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logout_org.aspx.cs" Inherits="Logout_org" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Excise</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui" />
    <link href="Assets/CSS/Fontcss.css" rel="stylesheet" />
    <link href="Assets/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/Fonts/css/iconfont.css" rel="stylesheet" type="text/css" />
    <link href="Assets/CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/jquery.min.js"></script>
    <link href="Assets/CSS/TopMenu.css" rel="stylesheet" type="text/css" />
    <script src="Assets/Scripts/shaa256.js" type="text/javascript"></script>
    <script type="text/javascript">
        history.pushState(null, null, 'Logout.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'Logout.aspx');
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="theme-loader">
        <div class="ball-scale">
            <div class='contain'>
                <div>
                    <div class="frame">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="pcoded" class="pcoded load-height">
        <div class="pcoded-inner-content" style="background-color: #01444e; margin-top: 2px">
            <div class="row align-items-end">
                <div class="col-lg-2">
                    <div class="page-header-title">
                        <div class="d-inline">
                            <img src="Assets/images/tg.png" alt="Telangana-Logo" />
                        </div>
                    </div>
                </div>
               <div class="col-lg-8" style="padding-top: -3px; color: White;">
                <h1 style="margin-top: -20px">
                        <font size="6px">Government of Telangana</font></h1>
                    <h1>
                        <font size="6px">Prohibition & Excise Department</font>
                    </h1>
                     <h1>
                        <font size="3px">Excise Revenue Collection System</font>
                    </h1>
                    
                </div>
                <div class="col-lg-2">
                    <div class="page-header-breadcrumb">
                        <div class="d-inline">
                            <img src="Assets/images/digital.png" alt="digitalindia-Logo" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
    </div>
   
    <div class="container-fluid">
        <div class="card">
            <div class="card-body">
                <div class="col-md-12" align="center">
                    <h3 class="form-signin-heading">
                       <%-- <asp:Image ID="Image1" ImageUrl="~/Assests/images/Logged_Out.jpg" CssClass="img-fluid"
                            runat="server" />--%></h3>
                    <div class="login">
                        <h1>
                            &nbsp;
                        </h1>
                        <div class="col-md-12 h6">
                            Click Here to <a href="Login.aspx" class="h4">Login</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
   <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/jquery-ui.min.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/popper.min.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/bootstrap.min.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/jquery.slimscroll.js"></script>
    <!-- data-table js -->
    <script src="Assets/Scripts/jquery.dataTables.min.js" type="9b4f5222b3507669ee2c1f74-text/javascript"></script>
    <script src="Assets/Scripts/dataTables.buttons.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/dataTables.responsive.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/dataTables.bootstrap4.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/jszip.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/pdfmake.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/vfs_fonts.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/buttons.print.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/buttons.html5.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/responsive.bootstrap4.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script src="Assets/Scripts/data-table-custom.js" type="cfcdfdafe9b0c09b20e4039c-text/javascript"></script>
    <!-- data-table js -->
    <script src="Assets/Scripts/jquery.mCustomScrollbar.concat.min.js" type="f1fb9abf53ce300d75205352-text/javascript"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/SmoothScroll.js"></script>
    <script src="Assets/Scripts/pcoded.min.js" type="f1fb9abf53ce300d75205352-text/javascript"></script>
    <!-- custom js -->
    <script src="Assets/Scripts/vartical-layout.min.js" type="f1fb9abf53ce300d75205352-text/javascript"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/custom-dashboard.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/script.min.js"></script>
     <script src="https://ajax.cloudflare.com/cdn-cgi/scripts/a2bd7673/cloudflare-static/rocket-loader.min.js"
        data-cf-settings="f1fb9abf53ce300d75205352-|49" defer=""></script>
    </form>
   
   <%-- <Footer:footer ID="footer" runat="server"></Footer:footer>--%>
</body>
</html>

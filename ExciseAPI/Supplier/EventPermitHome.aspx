<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventPermitHome.aspx.cs" Inherits="Supplier_EventPermitHome" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport">

  <title>Excise</title>
  <meta content="" name="description">
  <meta content="" name="keywords">

  <!-- Favicons -->
  <link href="assets/img/favicon.png" rel="icon">
  <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">

  <!-- Google Fonts -->
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Raleway:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">

  <!-- Vendor CSS Files -->
  
    <link href="../style/css/style.css" rel="stylesheet" />
    <link href="../style/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../style/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="../style/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="../style/vendor/glightbox/css/glightbox.min.css" rel="stylesheet" />
    <link href="../style/vendor/swiper/swiper-bundle.min.css" rel="stylesheet" />
  <%--<link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
  <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
  <link href="assets/vendor/glightbox/css/glightbox.min.css" rel="stylesheet">
  <link href="assets/vendor/swiper/swiper-bundle.min.css" rel="stylesheet">--%>
    
  <!-- Template Main CSS File -->
  <%--<link href="assets/css/style.css" rel="stylesheet">--%>

  <!-- =======================================================
  * Template Name: Flexor
  * Updated: Mar 10 2023 with Bootstrap v5.2.3
  * Template URL: https://bootstrapmade.com/flexor-free-multipurpose-bootstrap-template/
  * Author: BootstrapMade.com
  * License: https://bootstrapmade.com/license/
  ======================================================== -->
</head>

<body>
    <form runat="server">
  <!-- ======= Header ======= -->

        <div id="pcoded" class="pcoded load-height" style="background-color:#71d5e4;">
       <%-- <div class="pcoded-inner-content" style="background-color:#71d5e4; margin-top: 2px;
            padding-left: 130px;">--%>
           <div class="container d-flex align-items-center justify-content-between" style="margin-top: 2px;">
                <div class="col-lg-2">
                    <div class="page-header-title">
                        <div class="d-inline">
                            <img src="Assets/images/tg.png" alt="Telangana-Logo" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-8" style="padding-top: -2px; color: White;text-align:center;">
                    <h1 style="margin-top: -10px">
                        <font size="5px">Government of Telangana</font></h1>
                    <h1>
                        <font size="5px">Prohibition & Excise Department</font>
                    </h1>
                    <h1>
                        <font size="6px">EVENT PERMIT</font>
                    </h1>
                </div>
                <div class="col-lg-2">
                    <div class="page-header-breadcrumb">
                        <div class="d-inline">
                            <img src="Assets/images/deptlogo.png" alt="digitalindia-Logo" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
   
  <header id="header" class="d-flex align-items-center">
    <div class="container d-flex align-items-center justify-content-between">
        <nav id="navbar" class="navbar">
        <ul>
          <li><a class="nav-link scrollto active" href="../Event_Default.aspx">Home</a></li>
          <li><a class="nav-link scrollto" href="../EventSelection.aspx">Apply for Event Permit</a></li>
          <li><a class="nav-link scrollto" href="../ApplicationStatus.aspx">Application Status</a></li>
          <li><a class="nav-link scrollto" href="../DownloadPermission.aspx">Download Permit</a></li>
          <li><a class="nav-link scrollto" href="../Ack_EventReg.aspx">Acknowledgement</a></li>
          <li><a class="nav-link scrollto" href="../EoDBDashboard.aspx">Dashboard</a></li>
          <li><a class="nav-link scrollto" href="../G.O_PermitRegistration.pdf">G.O</a></li>
          <li><a class="nav-link scrollto" href="../Verify_permit.aspx">Third Party Verification</a></li>
          <li><a class="nav-link scrollto" href="../AdditionalPayment.aspx">Balance Amount Payment</a></li>
          <li><a class="nav-link scrollto" href="../login.aspx">Dept Login</a></li>
</ul>
        <i class="bi bi-list mobile-nav-toggle"></i>
      </nav><!-- .navbar -->
     <%-- <div class="logo">
        <h1><a href="index.html">Flexor</a></h1>
        <!-- Uncomment below if you prefer to use an image logo -->
        <!-- <a href="index.html"><img src="assets/img/logo.png" alt="" class="img-fluid"></a>-->
      </div>--%>

      

    </div>
  </header><!-- End Header -->

  <!-- ======= Hero Section ======= -->
  

  <main id="main">

    <!-- ======= Why Us Section ======= -->
 
    <section id="services" class="services section-bg">
      <div class="container">        
        <div class="row">
          <div class="col-lg-3 col-md-6" data-aos="fade-up">
            <div class="icon-box">
              <div class="icon"><i class="bi bi-briefcase"></i></div>
              <h4 class="title">Applications Recieved</h4>
              <p class="card-text">
                                                                <asp:Label ID="lblReceived" runat="server"></asp:Label>
                                                            </p>
                                                            <b>Day&nbsp;&nbsp;&nbsp:</b>
                                                            <asp:Label ID="lblDayCount" runat="server"></asp:Label>
                                                            <br />
                                                            <b>Month&nbsp;&nbsp;&nbsp:</b>
                                                            <asp:Label ID="lblMonthCount" runat="server"></asp:Label>
                                                            <br />
                                                            <b>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblYearCount" runat="server"></asp:Label>
              
                
                                                          <div><asp:LinkButton runat="server" ID="lnkInfo">More Info</asp:LinkButton></div>
                                                   
            </div>
          </div>
          <div class="col-lg-3 col-md-6" data-aos="fade-up" data-aos-delay="100">
            <div class="icon-box">
              <div class="icon"><i class="bi bi-card-checklist"></i></div>
              <h4 class="title">No.Of Permits Issued</h4>
                <p class="card-text">
                                                                <asp:Label ID="lblNoofPermitIssued" runat="server"></asp:Label>
                                                            </p>
                                                            <b>Day &nbsp;&nbsp;&nbsp:</b>
                                                            <asp:Label ID="lblDayIssued" runat="server"></asp:Label>
                                                            <br />
                                                            <b>Month&nbsp;&nbsp;&nbsp:</b>
                                                            <asp:Label ID="lblMonthIssued" runat="server"></asp:Label>
                                                            <br />
                                                            <b>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblYearIssued" runat="server"></asp:Label>
                                                        <div>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" >More Info</asp:LinkButton>
                                                        </div>
            </div>
          </div>
          <div class="col-lg-3 col-md-6" data-aos="fade-up" data-aos-delay="200">
            <div class="icon-box">
              <div class="icon"><i class="bi bi-bar-chart"></i></div>
              <h4 class="title">No Of Under Process</h4>
             <p class="card-text">
                                                                <asp:Label ID="lblNoofUnderProcess" runat="server"></asp:Label>
                                                            </p>
                                                            <b>Day&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblDayProcess" runat="server"></asp:Label>
                                                            <br />
                                                            <b>Month&nbsp;&nbsp;&nbsp:</b>
                                                            <asp:Label ID="lblMonthProcess" runat="server"></asp:Label>
                                                            <br />
                                                            <b>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblYearProcess" runat="server"></asp:Label>
                                                        <div><asp:LinkButton ID="LinkButton2" runat="server" >More Info</asp:LinkButton></div>
            </div>
          </div>
          <div class="col-lg-3 col-md-6" data-aos="fade-up" data-aos-delay="300">
            <div class="icon-box">
              <div class="icon"><i class="bi bi-binoculars"></i></div>
              <h4 class="title">No Of Rejected</h4>
             <p class="card-text">
                                                                <asp:Label ID="lblNoofRejected" runat="server"></asp:Label>
                                                            </p>
                                                            <b>Day&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblDayRejected" runat="server"></asp:Label>
                                                            <br />
                                                            <b>Month&nbsp;&nbsp;&nbsp:</b>
                                                            <asp:Label ID="lblMonthRejected" runat="server"></asp:Label>
                                                            <br />
                                                            <b>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblYearRejected" runat="server"></asp:Label>
                <div><asp:LinkButton ID="LinkButton3" runat="server" >More Info</asp:LinkButton></div>
            </div>
          </div>


             <table id="Table1" runat="server" visible="false">
                                                        <%--   <tr>
                                            <td colspan="4">
                                                <b></b>
                                                <br />
                                                (Data to be updated strating from <b><i>1<sup>st</sup> November 2020</i></b>)
                                                <br />
                                                <b><i>Details to be published for separately for each registration/Retention granted
                                                    by the department covered under BRAP</i></b>
                                            </td>
                                        </tr>--%>
                                                        <tr>
                                                            <th colspan="2" style="background-color: Gray; color: White; border: 1px Solid Black;
                                                                text-align: center;" align="Center" class="style1">
                                                                Particulars
                                                            </th>
                                                            <th colspan="2" style="background-color: Gray; color: White; border: 1px Solid Black;
                                                                text-align: center;" align="Center" class="style1">
                                                                Details
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                Time Limit prescribed as per the Service Guarantee Act
                                                            </td>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                <%--2--%>
                                                                <asp:Label ID="lblTimeLimit" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                Total Number of Applications Received
                                                            </td>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                <%--718--%>
                                                                <asp:Label ID="lblTotalAppReceived" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                Total Number of Applications Approved
                                                            </td>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                <%-- 717--%>
                                                                <asp:Label ID="lblTotalAppApproved" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                Average time taken to obtain Permits
                                                            </td>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                <%--1.1--%>
                                                                <asp:Label ID="lblAvgTime" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                Median time taken to obtain Permits
                                                            </td>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                <%-- 1--%>
                                                                <asp:Label ID="lblMedianTime" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                Minimum time taken to obtain Permits
                                                            </td>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                <%-- 1--%>
                                                                <asp:Label ID="lblMinimum" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                Maximum time taken to obtain Permits
                                                            </td>
                                                            <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                                <%-- 2--%>
                                                                <asp:Label ID="lblMaximum" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>



          <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="400">
            <div class="icon-box">
              <div class="icon"><i class="bi bi-brightness-high"></i></div>
              <h4 class="title">Check Lists For Event Permits</h4>
                <center>
                  <table>
                                                    
                                                    <tr>
                                                        <th colspan="4" style="background-color: Gray; color: White; border: 1px Solid Black;
                                                            text-align: center;">
                                                            List of documents required for event permit
                                                        </th>
                                                        <%--<th colspan="2" style="background-color: Gray; color: White; border: 1px Solid Black;"
                                                            align="Center">
                                                            
                                                        </th>--%>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                            1
                                                        </td>
                                                        <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                            Address proof the applicant
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                            2
                                                        </td>
                                                        <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                            Identity proof of the applicant
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                            3
                                                        </td>
                                                        <td colspan="2" align="Center" style="border: 1px Solid Black;">
                                                            Event related document (if available)
                                                        </td>
                                                    </tr>
                                                </table>
                    </center>
            </div>
          </div>
          <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="500">
            <div class="icon-box">
              <div class="icon"><i class="bi bi-calendar4-week"></i></div>
               <center>
                                                <b style="color: Red; font-size: 22px;">Helpdesk Numbers</b>
                                                <table>
                                                   <tr>
                                                        <th colspan="4" style="background-color: Gray; color: White; border: 1px Solid Black;
                                                            text-align: center;">
                                                            Contact Details
                                                        </th>
                                                        <%--<th colspan="2" style="background-color: Gray; color: White; border: 1px Solid Black;"
                                                            align="Center">
                                                            
                                                        </th>--%>
                                                    </tr>
                                                    <%--<tr>
                                                        <td colspan="4" align="Center" style="border: 1px Solid Black;">
                                                            T.Praveen Singh :9515744990
                                                        </td>
                                                       
                                                    </tr>--%>
                                                    <tr>
                                                        
                                                        <td colspan="4" align="Center" style="border: 1px Solid Black;">
                                                            Vinay :9701317337
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
            </div>
          </div>
        </div>

      </div>
    </section><!-- End Services Section -->
       <div class="footer bg-inverse" style="background-color:black;color:white;">
        <p class="text-center">
            Site designed , developed and hosted by National Informatics Centre,Telangana ,Hyderabad.
            Content Owned and updated by Prohibition and Excise Department Govt of Telangana
            Hyderabad.
        </p>
    </div>

    <!-- ======= Values Section ======= -->
   </form>
  <script src="assets/js/main.js"></script>

</body>

</html>

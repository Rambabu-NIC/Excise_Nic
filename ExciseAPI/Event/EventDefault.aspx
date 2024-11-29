<%@ Page Title="" Language="C#" MasterPageFile="~/Event/Events.Master" AutoEventWireup="true" CodeBehind="EventDefault.aspx.cs" Inherits="ExciseAPI.Event.EventDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
       <div class="pcoded-content">
        <div class="pcoded-inner-content">
            <div class="main-body">
                <div class="page-wrapper">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm-12">
                                <br>
                                <div class="card">
                                    <div class="card-block">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <center>
                                                    
                                                    <div class="card user-widget-card bg-c-yellow">
                                                        <div class="card-body">
                                                            <h5 class="card-title font">
                                                                <strong>Applications Received</strong></h5>
                                                            <p class="card-text">
                                                               <asp:Label ID="lblReceived" runat="server"></asp:Label>
                                                            </p>
                                                            <b>Day&nbsp;&nbsp;&nbsp;:</b>
                                                              <asp:Label ID="lblDayCount" runat="server"></asp:Label>
                                                            <br>
                                                            <b>Month&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblMonthCount" runat="server"></asp:Label>
                                                            <br>
                                                            <b>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                             <asp:Label ID="lblYearCount" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="card-footer border border-warning">
                                                            <center>
                                                                <asp:LinkButton runat="server" ID="lnkInfo" OnClick="lnkMore_OnClink">More Info</asp:LinkButton>
                                                            </center>
                                                        </div>
                                                    </div>
                                                    
                                                </center>
                                            </div>
                                            <div class="col-md-3">
                                                <center>
                                                    <div class="card user-widget-card bg-c-blue">
                                                        <div class="card-body">
                                                            <h5 class="card-title">
                                                                <strong>No.of Permits Issued</strong></h5>
                                                            <p class="card-text">
                                                                 <asp:Label ID="lblNoofPermitIssued" runat="server"></asp:Label>
                                                            </p>
                                                            <b>Day &nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblDayIssued" runat="server"></asp:Label>
                                                            <br>
                                                            <b>Month&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblMonthIssued" runat="server"></asp:Label>
                                                            <br>
                                                            <b>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                           <asp:Label ID="lblYearIssued" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="card-footer border border-primary">
                                                            <center>
                                                                <asp:LinkButton ID="LinkButton1" OnClick="lnkIssuedMore_OnClink" runat="server" >More Info</asp:LinkButton>
                                                            </center>
                                                        </div>
                                                    </div>
                                                </center>
                                            </div>
                                            <div class="col-md-3">
                                                <center>
                                                    <div class="card user-widget-card bg-c-green">
                                                        <div class="card-body">
                                                            <h5 class="card-title">
                                                                <strong>No.of Under Process</strong></h5>
                                                            <p class="card-text">
                                                                 <asp:Label ID="lblNoofUnderProcess" runat="server"></asp:Label>
                                                            </p>
                                                            <b>Day&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                           <asp:Label ID="lblDayProcess" runat="server"></asp:Label>
                                                            <br>
                                                            <b>Month&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblMonthProcess" runat="server"></asp:Label>
                                                            <br>
                                                            <b>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblYearProcess" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="card-footer border border-success">
                                                            <center>
                                                                <asp:LinkButton ID="LinkButton2" OnClick="lnkProcessMore_OnClink" runat="server" >More Info</asp:LinkButton>
                                                            </center>
                                                        </div>
                                                    </div>
                                                </center>
                                            </div>
                                            <div class="col-md-3">
                                                <center>
                                                    <div class="card user-widget-card bg-c-pink">
                                                        <div class="card-body">
                                                            <h5 class="card-title">
                                                                <strong>No.of Rejected</strong></h5>
                                                            <p class="card-text">
                                                                <asp:Label ID="lblNoofRejected" runat="server"></asp:Label>
                                                            </p>
                                                            <b>Day&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                             <asp:Label ID="lblDayRejected" runat="server"></asp:Label>
                                                            <br>
                                                            <b>Month&nbsp;&nbsp;&nbsp;:</b>
                                                           <asp:Label ID="lblMonthRejected" runat="server"></asp:Label>
                                                            <br>
                                                            <b>Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>
                                                            <asp:Label ID="lblYearRejected" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="card-footer border border-danger">
                                                            <center>
                                                               <asp:LinkButton ID="LinkButton3" OnClick="lnkRejectedMore_OnClink"  runat="server" >More Info</asp:LinkButton>
                                                            </center>
                                                        </div>
                                                    </div>
                                                </center>
                                            </div>
                                        </div>
                                    </div>
                                    <br>
                                    <br>
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
                                    <div class="form-group row">
                                        <div class="col-md-6">
                                            <center>
                                                <b style="color: Red; font-size: 22px;">Checklist for Event permits </b>
                                                <table style="width: 100px">
                                                    
                                                    <tbody><tr>
                                                        <th colspan="4" style="background-color: Gray; color: White; border: 1px Solid Black;
                                                            text-align: center;">
                                                            List of documents required for event permit
                                                        </th>
                                                        
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
                                                </tbody></table>
                                            </center>
                                        </div>
                                        <div class="col-md-6">
                                            <center>
                                                <b style="color: Red; font-size: 22px;">Helpdesk Numbers</b>
                                                <table style="width: 100px">
                                                   <tbody><tr>
                                                        <th colspan="4" style="background-color: Gray; color: White; border: 1px Solid Black;
                                                            text-align: center;">
                                                            Contact Details
                                                        </th>
                                                        
                                                    </tr>
                                                    
                                                    <tr>
                                                        
                                                        <td colspan="4" align="Center" style="border: 1px Solid Black;">
                                                            Vinay :9701317337
                                                        </td>
                                                    </tr>
                                                </tbody></table>
                                            </center>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="col-sm-12">
                                </div>
                                <div id="hit" style="text-align: center">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

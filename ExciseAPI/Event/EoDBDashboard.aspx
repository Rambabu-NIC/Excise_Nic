<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="EoDBDashboard.aspx.cs" Inherits="ExciseAPI.Event.EoDBDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .eventlinkbtn {
            padding: 5px 10px;
            font-size: 14px;
            line-height: 2;
            border-radius: 5px;
            height: 40px;
        }
    </style>
    <script type="text/javascript">
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
    <style type="text/css">
        .row {
            margin-left: 0px;
            margin-right: 0px;
        }

        .style3 {
            font-size: large;
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Dashboard</div>
            <div class="content">
                <div class="card">
                    <div class="card-block">
                        <div class="row">

                            <div class="col-md-12">
                                <br />
                                <div class="form-group row">
                                    <label class="col-md-3 col-form-label text-right" style="text-align: right">
                                        From Date<span style="color: Red"> *</span></label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtfrm" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Width="250px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                    </div>
                                    <label class="col-md-1 col-form-label text-right">
                                        To Date<span style="color: Red"> *</span></label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtto" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Width="250px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="content" align="center">

                                <div class="col-xs-12 col-sm-12 txt-cnt">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    <asp:Image ID="Image2" runat="server" />
                                    <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                        OnClick="btnImgRefresh_Click" />
                                    <span class="form-bar"></span>

                                    <div class="container-fluid" align="center">
                                        <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha" AutoCompleteType="Disabled" MaxLength="6"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="captch_FilteredTextBoxExtender1" runat="server"
                                            BehaviorID="captch_FilteredTextBoxExtender" FilterType="numbers"
                                            TargetControlID="captch"></ajaxToolkit:FilteredTextBoxExtender>
                                        <span class="form-bar"></span>
                                    </div>
                                </div>


                            </div>
                            <asp:HiddenField ID="hf" runat="server" />

                            <div class="form-group row">
                                <div class="col-md-12 text-center">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click"
                                        CssClass=" btn btn-secondary" />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-6">
                                <%--<b style="color: Red; font-size: 25px;">Dashboard</b>--%>
                                <table runat="server" visible="true">
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            (Data to be updated strating from <b><i>1<sup>st</sup> November 2020</i></b>)
                                                            <br />
                                            <b><i>Details to be published for separately for each registration/Retention granted
                                                                by the department covered under BRAP</i></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="background-color: Gray; color: White; border: 1px Solid Black; text-align: center;"
                                            class="style1">Particulars
                                        </th>
                                        <th style="background-color: Gray; color: White; border: 1px Solid Black; text-align: center;"
                                            class="style1">Details
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Time Limit prescribed as per the Service Guarantee Act
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%--2--%>
                                            <asp:Label ID="lblTimeLimit" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Total Number of Applications Received
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%--718--%>
                                            <asp:Label ID="lblTotalAppReceived" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Total Number of Applications Approved
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%-- 717--%>
                                            <asp:Label ID="lblTotalAppApproved" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Total Number of Applications Pending
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%-- 717--%>
                                            <asp:Label ID="lblTotalAppPending" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Total Number of Applications Rejected
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%-- 717--%>
                                            <asp:Label ID="lblTotalAppRejected" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Average time taken to obtain Permits
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%--1.1--%>
                                            <asp:Label ID="lblAvgTime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Median time taken to obtain Permits
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%-- 1--%>
                                            <asp:Label ID="lblMedianTime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Minimum time taken to obtain Permits
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%-- 1--%>
                                            <asp:Label ID="lblMinimum" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px Solid Black;">Maximum time taken to obtain Permits
                                        </td>
                                        <td style="border: 1px Solid Black;">
                                            <%-- 2--%>
                                            <asp:Label ID="lblMaximum" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-4 offset-4">
                                <center>
                                                    <%-- <b style="color: Red; font-size: 25px;">Checklist for Event permits </b>--%>
                                                    <table style="" runat="server" visible="false">
                                                        <tr>
                                                            <th colspan="4" style="background-color: Gray; color: White; border: 1px Solid Black;
                                                                text-align: center;">
                                                                List of documents required for event permit
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="border: 1px Solid Black;">
                                                                1
                                                            </td>
                                                            <td colspan="2" style="border: 1px Solid Black;">
                                                                Address proof the applicant
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="border: 1px Solid Black;">
                                                                2
                                                            </td>
                                                            <td colspan="2" style="border: 1px Solid Black;">
                                                                Identity proof of the applicant
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="border: 1px Solid Black;">
                                                                3
                                                            </td>
                                                            <td colspan="2" style="border: 1px Solid Black;">
                                                                Event related document (if available)
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("#txtEvnDate").datepicker({
                    dateFormat: 'dd-mm-yy',
                    changeMonth: true,
                    changeYear: true,
                    minDate: 0
                });
            });
        });
    </script>
</asp:Content>


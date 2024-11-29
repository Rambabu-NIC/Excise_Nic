<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="MicroBrewery.aspx.cs" Inherits="ExciseAPI.MicroBrewery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Micro Brewery</div>
            <div class="content">
                <div class="text-center">
                    <div class="row">
                        <div class="col-md-5 col-sm-5" style="text-align: end;">
                            <label class="custom-label">Micro Brewery Service :</label>
                        </div>

                        <div class="col-md-4 col-sm-6">
                            <asp:DropDownList ID="ddl_microbrewery" class="form-control" runat="server" OnSelectedIndexChanged="ddl_microbrewery_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Application for Prior Clearance for grant of license </asp:ListItem>
                                <asp:ListItem Value="2">Application for grant of License</asp:ListItem>
                                <asp:ListItem Value="3">Renewal forms </asp:ListItem>

                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="block black bg-white" id="grantofpriorclearance" runat="server" visible="false">
        <div class="content">
            <!-- Firm registration -->
            <div class="col-md-12 col-lg-12">
                <div class="content">
                    <table class="excise-table">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th style="text-align: left;">SERVICE NAME</th>
                                <td colspan="2">Grant of Prior clearance for establishment of Micobrewery</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">-</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">USER CHARGES</th>
                                <td colspan="2">Rs.1 lakhs</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">STAGES</th>
                                <td>2</td>
                               
                            </tr>
                            <tr>

                                <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                <td>Stage 1 -- DC<br />Stage 2 -- CPE  </td>
                               
                            </tr>
                            <tr>
                                <th style="text-align: left;">TIME LINES</th>
                                <td>No Time Lines Policy matter</td>
                               
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-md-12 col-lg-12">
                <h4>PROCEDURE:-</h4>

                After receipt of application in prescribed format. Commissioner after causing such enquiry from concerned Deputy Commissioners /DPEO and on fulfillment of required documents and taxes, he may grant prior clearance. 
  
                          <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                <p class="excise-para">Documents required for grant of prior clearance:</p>
                <ol>
                    <li>Form MB-1A</li>
                    <li>Payment of Fee</li>
                    <li>Provisional trade licence issued by local Authority to serve food such as Hotel or a Restaurant or having 2B/TD1/TD2 licenses.</li>
                    <li>Land Documents.</li>
                </ol>
            </div>

        </div>
    </div>

    <div class="block black bg-white" id="grantoflicence" runat="server" visible="false">
        <div class="content">
            <!-- Firm registration -->
            <div id="eodb_firm_1" style="display: block;">
                <div class="content">
                    <table class="excise-table">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th style="text-align: left;">SERVICE NAME</th>
                                <td colspan="2">Grant of licence for manufacture of draught beer</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">Rs.5 lakhs</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">USER CHARGES</th>
                                <td colspan="2">-</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">STAGES</th>
                                <td>2</td>
                                
                            </tr>
                            <tr>
                                <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                <td>Stage 1 -- DC<br />Stage 2 -- CPE</td>
                               
                            </tr>
                            <tr>
                                <th style="text-align: left;">TIME LINES</th>
                                <td>120 Days</td>
                               
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div style="padding-top: 0;">
                    <h4>PROCEDURE:-</h4>

                    After receipt of application. Commissioner after causing such enquiry from concerned Deputy Commissioners /DPEO and on fulfillment of required documents and taxes, he may grant licence.  
  
                          <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                    <p class="excise-para">Documents required for grant of Licence:</p>
                    <ol>
                        <li>Application</li>
                        <li>Payment of Microbrewery Excise Tax.</li>
                        <li>Security Deposit (Bank Guarantee / FDR)</li>
                        <li>Legal Metrology certification regarding fermentation tanks capacity</li>
                        <li>Copy of the prior clearance.</li>
                        <li>Provisional trade licence issued by local Authority to serve food such as Hotel or a Restaurant or having 2B/TD1/TD2 licenses.</li>
                        <li>Proposed Microbrewery Maps / Plans.</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

    <div class="block black bg-white" id="renewaloflicence" runat="server" visible="false">
        <div class="content">
            <div class="col-md-12 col-lg-12">
                <!-- Firm registration -->
                <div class="content">
                    <table class="excise-table">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th style="text-align: left;">SERVICE NAME</th>
                                <td colspan="2">Renewals of form 2MB</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">MBET-Rs.5 lakhs and Renewal application fee Rs.1.50 lakhs </td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">USER CHARGES</th>
                                <td colspan="2">0/-</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">STAGES</th>
                                <td>2</td>
                                
                            </tr>
                            <tr>
                                <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                <td>Stage 1 -- DC<br />Stage 2 -- CPE</td>
                                
                            </tr>
                            <tr>
                                <th style="text-align: left;">TIME LINES</th>
                                <td>15 Days</td>
                                
                            </tr>
                        </tbody>
                    </table>

                    <div style="padding-top: 0;">
                        <h4>PROCEDURE:-</h4>

                        After receipt of application. Commissioner after causing such enquiry from concerned Deputy Commissioners /DPEO and on fulfillment of required documents and taxes, he may grant Renewal of licence.   
  
                          <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                        <p class="excise-para">Documents required for Renewal of Licence:</p>
                        <ol>
                            <li>Renewal application fee</li>
                            <li>Microbrewery Excise Tax (MBET)</li>
                            <li>No due certificate issued by concerned authority.</li>
                            <li>Security Deposit </li>
                            <li>Payment of 50% of Excise Duty and VAT in Advance.</li>
                            <li>Previous renewal licence copy.</li>

                        </ol>
                    </div>
                </div>

            </div>
        </div>
    </div>


    <div class="block black bg-white" id="brandlabelapproval" runat="server" visible="false">
        <div class="content">
            <div class="col-md-12 col-lg-12">
                <!-- Firm registration -->

                <div class="content">
                    <table class="excise-table">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th style="text-align: left;">SERVICE NAME</th>
                                <td colspan="2">Brand Label Approval </td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">10,000/-</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">USER CHARGES</th>
                                <td colspan="2">0/-</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">STAGES</th>
                                <td>-</td>
                                <td></td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                <td>-</td>
                                <td>-</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">TIME LINES</th>
                                <td></td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>

                    <div style="padding-top: 0;">
                        <h4>PROCEDURE:-</h4>

                        After receipt of application to the Commissioner, Prohibition & Excise through Distillery Officer I/c of the unit and Concerned Assistant Commissioner (Distilleries). and on fulfillment of required documents and taxes, he may approve the label.    
  
                          <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                        <p class="excise-para">Documents required for approval of brand label :</p>
                        <ol>
                            <li>Application in prescribed format.</li>
                            <li>Affixing of court fee stamp of requisite value.</li>
                            <li>Payment of label fee.</li>
                            <li>Basic Price and MRP issued by MD TGBCL (in case of bottled Liquor).</li>
                            <li>(10) Sets of Brand labels </li>
                            <li>Previous year approved copy in case of re-approval.</li>

                        </ol>
                    </div>
                </div>

            </div>
        </div>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="F_Section.aspx.cs" Inherits="ExciseAPI.F_Section" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">F-Section</div>
           
             <div class="content">
                <div class="text-center">
                <div class="row">
                     <div class="col-md-5 col-sm-5" style="text-align: end;">
                            <label class="custom-label">Select Service :</label>
                        </div>
                        <div class="col-md-4 col-sm-6">
                            <asp:DropDownList ID="ddlA4_Shops" class="form-control" runat="server" OnSelectedIndexChanged="ddlA4_Shops_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">A4 Shops</asp:ListItem>
                                <asp:ListItem Value="2">2B Bars</asp:ListItem>
                                <asp:ListItem Value="3">Clubs</asp:ListItem>
                                <asp:ListItem Value="4">Tourism</asp:ListItem>
                                <asp:ListItem Value="5">Toddy Shops</asp:ListItem>
                                <asp:ListItem Value="6">CS-1</asp:ListItem>
                                <asp:ListItem Value="7">CS-2</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
            </div>
            </div>
        </div>
            <div class="block black bg-white" id="A4Shops" runat="server" visible="false">
                <div class="content">
                    <!-- Firm registration -->
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">A4 SHOP LICENSE </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">- </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>-</td>
                                    <td>0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">
                            <%--  <h4>PROCEDURE:-</h4>--%>
                            <div class="content">
                                <h5>i.Application form comprising details of :</h5>
                                <ol class="excise-para" type="i">
                                    <ul>
                                        <li>Applicant name/ company name and details</li>
                                        <li>Contact number</li>

                                        <li>G.Sl. No. </li>
                                        <li>Proposed shop </li>
                                        <li>Photographs</li>

                                    </ul>
                                    <li>Copy of I.D. proof</li>
                                    <li>Copy of Pan card </li>
                                    <li>Non refundable tax (application tax) @ Rs. 2.00 lakhs</li>
                                </ol>

                                <h4 style="margin-bottom: 0;">WHETHER ANY COMPLAINTS:-</h4>

                                <ol class="excise-para" type="i">

                                    <li>Disposal report of complaint </li>
                                </ol>


                                <h4 style="margin-bottom: 0;">LICENSE ISSUING PROCEDURE:</h4>
                                <ol>
                                    i.	Station Enquiry Report comprising of
                            <ul>
                                <li>Selected applicant/ company particulars</li>
                                <li>Inspection date</li>
                                <li>Along with documents submitted by successful applicant</li>
                            </ul>
                                </ol>
                                <h4>A4-shop</h4>
                                <ol class="excise-para">
                                    <ul>
                                        <li>Inspection of proposed premises (A4)</li>
                                        <li>In-conformity of Rule 25</li>
                                        <li>Boundaries</li>
                                        <li>Plinth area of wine shop  (in Sq. Mtrs)</li>
                                    </ul>
                                </ol>
                                <h4>Permit Room</h4>
                                <ol class="excise-para">
                                    <ul>
                                        <li>Inspection of proposed permit room premises</li>
                                        <li>In-conformity of Rule 25</li>
                                        <li>Boundaries (whether it is adjacent to the said wine shop or not)</li>
                                        <li>Plinth area of the permit room (not exceeding 100 Sq. Mtrs)</li>
                                    </ul>
                                </ol>
                                <h4>Walk-in store:</h4>
                                <ol class="excise-para">
                                    <ul>
                                        <li>Inspection of proposed walk-in store premises</li>
                                        <li>In-conformity of Rule 25</li>
                                        <li>Boundaries (whether it is adjacent to the said wine shop or not)</li>
                                        <li>Subject to payment of Rs. 5 Lakhs per annum in addition to RSET </li>
                                    </ul>
                                </ol>


                                <h4>Documents to be provided :</h4>
                                <ol class="excise-para">
                                    <ul>
                                        <li>1st installment of Retail Shop Excise Tax</li>
                                        <li>Approved map</li>
                                        <li>Copy of Aadhar and PAN</li>
                                        <li>Consent/ Lease Deed issued by the Owner of premises for establishment of proposed wine shop </li>
                                        <li>Undertaking to provide CC camera, parking, HPFS </li>
                                        <li>Affidavit per rule 8 </li>
                                        <li>Copy of registered partnership deed for Firm/ company </li>
                                        <li>Declaration in Form - A1, Form - A2, Form - A3 as pe rule - 6</li>
                                        <li>Declaration in Form - A2(S) as pe rule - 16</li>
                                        <li>Bank Guarantee in Form - A5 (BG) as per rule - 16</li>
                                        <li>Counterpart agreement in Form- A6 as per rule - 19</li>
                                        <li>Along with Nowkarnama proposals as per rule 44 in Form N1 (enclosed with Challa for Rs. 5000, Adhaar and photos of each applicant)</li>


                                    </ul>
                                </ol>


                                <br>
                                <h4>ES Office verification:</h4>
                                <ol class="excise-para" type="i">

                                    <li>Verification of documents </li>
                                    <li>Reconciliation of remittance particulars with IFMIS (treasury)</li>
                                    <li>Issue of license in FORM-A4/permit room license- Form A(B) / Walk- in store license</li>
                                    <li>Entry of retailer details in TSBCL portal for lifting of stocks</li>

                                </ol>

                            </div>

                            <!-- <h5>Firm registration</h5>
                          <ol>
                              <li>Any person who is a producer of molasses and desires to posses and sell molasses shall make an application to the Commissioner for a license in that behalf. The application shall be accompanied by a challan evidencing payment of a fee of Rs.100/- for such application. The application shall contain the details prescribed in Rule 3 of Telangana Excise (Possession, Import, Export, Transport of Molasses Conditions of License and Permits) Rules, 2008. </li>
                              <li>On receipt of an application, the Commissioner may make such inquiries as he deems necessary and if he is satisfied that there is no objection to grant the license applied for, he may, grant the license, on payment of a fee as per the scale prescribed in the Rules. </li>

                          </ol>
   -->


                            <%--  <h4 style="margin-bottom: 0;"><strong>CHECK LIST :-</strong></h4>--%>
                        </div>
                    </div>
                </div>
            </div>


            <div class="block black bg-white" id="Bars" runat="server" visible="false">
                <div class="content">
                    <!-- Firm registration -->

                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Renewal of 2B bar duly affixed with 2/- Court fee stamp</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">- </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>-</td>
                                    <td>0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">
                            <%--<h4>PROCEDURE:-</h4>--%>
                            <div class="content">
                                <h4>Application for renewal of 2B bar duly affixed with 2/- Court fee stamp along with</h4>
                                <ul>
                                    <li>Renewal/ Registration tax of Rs. 1,00,000/-</li>
                                    <li>1st installment of BET as per rule-10</li>
                                    <li>Remittance particulars of Green fund</li>
                                    <li>Copy of Trade license as rule(4)</li>
                                    <li>Copy of Registered lease deed</li>
                                    <li>Counter part agreement-Form-4B as per rule-5</li>
                                    <li>Photographs Of Licensee</li>
                                </ul>
                                <h4 style="margin-bottom: 0;">RENEWAL PROCEDURE:-</h4>

                                <ol class="excise-para" type="i">
                                    <li>Station Enquiry Report along with recommendations and</li>

                                    <h4><b>Documents to be provided</b></h4>
                                    <ul>
                                        <li>Renewal/ Registration tax of Rs. 1,00,000/-</li>

                                        <li>1st installment of BET</li>
                                        <li>Copy of Trade license (Annexure-I)</li>
                                        <li>Copy of Registered lease deed (Annexure-II)</li>
                                        <li>Counter part agreement (Annexure-III)-Form-4B as per rule-5</li>
                                        <li>Bank Guarantee as per rule-10</li>
                                        <li>Audit undertaking (Annexure-IV)</li>
                                        <li>Plinth area self-certification (Annexure-V)</li>
                                        <li>Plinth area survey or certification (Annexure-VI)</li>
                                        <li>Affidavit U/r 7(Annexure-VII)</li>
                                        <li>Along with Nowkarnama proposals as per rule 44 in Form N1 (enclosed with Challa for Rs. 5000, Adhaar and photos of each applicant)</li>
                                        <li>Undertaking to provide CC camera, HPFS</li>
                                    </ul>


                                </ol>
                                <br/>
                                <h4><b>ES office verification:</b></h4>
                                <ol class="excise-para" type="i">

                                    <li>Verification of documents </li>
                                    <li>Reconciliation of remittance particulars with IFMIS (treasury)</li>
                                    <li>Issue of renewal license</li>
                                    <li>Submission of report to DC for onward entry in TSBCL portal for lifting of stocks</li>

                                </ol>
                            </div>
                        </div>
                    </div>
                </div>

            </div>




            <div class="block black bg-white" id="clubs" runat="server" visible="false">
                <div class="content">
                    <!-- Firm registration -->
                    <div id="eodb_firm_1" style="display: block;">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">1HA-2 for grant of Club license in Form C-1 </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">- </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>-</td>
                                    <td>0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">
                            <%--   <h4>PROCEDURE:-</h4>--%>

                            <!-- <h5>Firm registration</h5>
                          <ol>
                              <li>Any person who is a producer of molasses and desires to posses and sell molasses shall make an application to the Commissioner for a license in that behalf. The application shall be accompanied by a challan evidencing payment of a fee of Rs.100/- for such application. The application shall contain the details prescribed in Rule 3 of Telangana Excise (Possession, Import, Export, Transport of Molasses Conditions of License and Permits) Rules, 2008. </li>
                              <li>On receipt of an application, the Commissioner may make such inquiries as he deems necessary and if he is satisfied that there is no objection to grant the license applied for, he may, grant the license, on payment of a fee as per the scale prescribed in the Rules. </li>
  
                          </ol>
   -->


                            <%-- <h4 style="margin-bottom: 0;"><strong>CHECK LIST :-</strong></h4>--%>

                            <h4>I. APPLICATION :</h4>
                            <ol class="excise-para" type="i">
                                <li>Application in form 1HA-2for grant of Club license in Form C-1  </li>
                                <br/>
                                <li>Station Enquiry Report along with recommendations and  </li>
                                <p><b>Documents to be provided</b></p>
                                <ul style="list-style: disc;">
                                    <li>Inspection of premises </li>
                                    <li>Copy of society registration as per Societies Registration Act, 1860 along with members details.</li>
                                    <li>Copy Adhaar of society president</li>
                                    <li>Copy of Pan card</li>
                                    <li>Applicable excise tax </li>
                                    <li>Copy of Trade license</li>
                                    <li>Copy of Sale deed / Registered lease deed</li>
                                    <li>Details of club facility (Indoor Games) for not less than three items</li>
                                    <li>Counter part agreement in Form CG-1</li>
                                    <li>Affidavit U/r 6  </li>
                                    <li>Along with Nowkarnama proposals as per rule 44 in Form N1 (enclosed with Challa for Rs. 5000, Adhaar and photos of each applicant)</li>
                                    <li>Undertaking to provide CC camera, HPFS</li>
                                    <li>Maps</li>
                                </ul>
                                <br/>
                                <li><b>ES office verification:</b></li>
                                <ul style="list-style: disc;">
                                    <li>Verification of documents </li>
                                    <li>Reconciliation of remittance particulars with IFMIS (treasury)</li>
                                    <li>Submission of proposals to CPE through DC for issue of orders.</li>
                                </ul>
                            </ol>



                        </div>
                    </div>
                </div>

            </div>



            <div class="block black bg-white" id="Tourism" runat="server" visible="false">
                <div class="content">
                    <!-- Firm registration -->
                    <div class="col-md-12 col-lg-12">

                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">1HA-1 for license to Sell Indian Made Foreign Liquor and Foreign Liquor by In-house</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">- </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>-</td>
                                    <td>0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">
                            <%-- <h4>PROCEDURE:-</h4>--%>

                            <!-- <h5>Firm registration</h5>
                          <ol>
                              <li>Any person who is a producer of molasses and desires to posses and sell molasses shall make an application to the Commissioner for a license in that behalf. The application shall be accompanied by a challan evidencing payment of a fee of Rs.100/- for such application. The application shall contain the details prescribed in Rule 3 of Telangana Excise (Possession, Import, Export, Transport of Molasses Conditions of License and Permits) Rules, 2008. </li>
                              <li>On receipt of an application, the Commissioner may make such inquiries as he deems necessary and if he is satisfied that there is no objection to grant the license applied for, he may, grant the license, on payment of a fee as per the scale prescribed in the Rules. </li>
  
                          </ol>
   -->


                            <%--  <h4 style="margin-bottom: 0;"><strong>CHECK LIST :-</strong></h4>--%>

                            <h4>I. APPLICATION :</h4>
                            <ol class="excise-para" type="i">
                                <li>Application in form 1HA-1 for license to Sell Indian Made Foreign Liquor and Foreign Liquor by In-house</li>
                                <br/>
                                <li>Station Enquiry Report along with recommendations and</li>
                                <p class="excise-para"><b>Documents to be provided</b></p>
                                <ul style="list-style: disc;">
                                    <li>Inspection of premises </li>
                                    <li>Applicable excise tax </li>
                                    <li>Copy of orders issued by Tourism Department </li>
                                    <li>Copy of Trade license</li>
                                    <li>Copy of Sale deed / Registered lease deed</li>
                                    <li>Counterpart agreement in Form CG-1</li>
                                    <li>Affidavit U/r 6</li>
                                    <li>Undertaking to provide CC camera, HPFS</li>
                                    <li>Maps</li>
                                    <li>Along with Nowkarnama proposals as per rule 44 in Form N1 (enclosed with Challa for Rs. 5000, Adhaar and photos of each applicant)</li>
                                   
                                </ul>
                                <br/>
                                <li><b>ES office verification:</b></li>
                                <ul style="list-style: disc;">
                                    <li>Verification of documents </li>
                                    <li>Reconciliation of remittance particulars with IFMIS (treasury)</li>
                                    <li>Submission of report to CPE through DC for further necessary action.</li>
                                </ul>
                            </ol>



                        </div>
                    </div>
                </div>
            </div>

            <div class="block black bg-white" id="TODDYSHOPLICENSE" runat="server" visible="false">
                <div class="content">
                    <!-- Firm registration -->
                    <div class="col-md-12 col-lg-12">
                        <!-- Firm registration -->
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">TODDY SHOP LICENSE</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">- </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>-</td>
                                    <td>0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">
                            <h4>PROCEDURE:-</h4>

                            <h4>I. Toddy shop licences are of two types: </h4>
                            <ol class="excise-para" type="I">
                                <li>Tree For Tapper (TFT licence) – </li>
                                <ul style="list-style: disc;">
                                    <li>Individual type </li>
                                    <li>Not below 30 ration in terms of sendhi</li>
                                    <li>If number of eligible tappers available in the village and not adequate trees, the available tree are divided among
                                     the eligible tappers.then Addl. Counters may be issued subject to availability of ration. </li>
                                </ul>
                                <br/>
                                <li>Toddy Cooperative Society (TCS) – </li>
                                <ul style="list-style: disc;">
                                    <li>TCS means a society formed as per the provisions of the Telangana Co-Operative Societies Act, 1964 consisting of not less than 80% of the tappers as defined in clause (xiv) above, and not exceeding 
                            15% of the persons incidental to tapping and sale of toddy and not exceeding 5% of; </li>
                                    <ol type="a">
                                        <li>Disabled tappers,</li>
                                        <li>professional tappers who are above 65 year of age and </li>
                                        <li>Widows of tappers who died while engaged in tapping.</li>
                                    </ol>
                                    <li>Ration may be allotted from local/nearest village/ mandal/ District.</li>
                                </ul>
                                <br/>
                            </ol>
                            <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                            <h4>i.Application form comprising details of (TCS Membership / Addl TFT Counter) :</h4>
                            <ul style="list-style: disc;">
                                <li>Name and address </li>
                                <li>Proof of residence</li>
                                <li>Community certificate</li>
                                <li>Ration card / Income certificate</li>
                                <li>Voter id/ Aadhar proofs</li>
                                <li>The name and locality of the shop or group of shops which sell toddy in the area.</li>
                                <li>Name of the tope and number of trees to be allotted.</li>
                                <li>Photographs.</li>
                                <li>Affidavit of non-employment</li>
                            </ul>
                            <ul style="list-style-type: none;">
                                <li><b>II. License issuing procedure:</b></li>
                                <h5>Toddy shop:</h5>
                                <ol class="excise-para" type="i">
                                    <li>Station Enquiry Report comprising of</li>
                                    <ul style="list-style: disc;">
                                        <li>Application from applicant/TCS President </li>
                                        <li>Notice to applicant/member for Tapping demonstration</li>
                                        <li>Tapping test demonstration sheet.</li>
                                        <li>Tapping test Photographs and video</li>
                                        <li>Check memo </li>
                                        <li>Enquiry report </li>
                                        <li>Specific remarks/ recommendation</li>
                                        <li>In case of TFTs, toddy shop must be proposed in rural areas.</li>
                                        <li>New Toddy shop must be proposed at a distance of 2 Kms to the nearest toddy shop</li>
                                        <li>In case of TCS, Cooperative Sr. Inspector report shall be submitted as per the provisions of the Telangana Co-Operative Societies Act, 1964 consisting of not less than 80% of the tappers as defined in clause (xiv) above, and not exceeding 15% of the persons incidental to tapping and sale of toddy and not exceeding 5% of;</li>
                                        <ol type="a">
                                            <li>Disabled tappers,</li>
                                            <li>professional tappers who are above 65 year of age and </li>
                                            <li>Widows of tappers who died while engaged in tapping.</li>
                                        </ol>
                                    </ul>

                                    <h4>B-shop(Rule- 5(4(vi)))</h4>
                                    <ul style="list-style: disc;">
                                        <li>B shop is satellite shop to the existing shop subject to condition that the B shop shall be within 2 Kms from the main shop and it shall be 2Kms away from other neighboring toddy shop. </li>
                                        <li>Resolution of the society </li>
                                        <li>Inspection of proposed B shop premises</li>
                                        <li>Premises in-conformity of Rule 8</li>
                                        <li>Rental agreement on NJS paper</li>
                                        <li>Boundaries </li>
                                    </ul>
                                    <h4>Toddy Depot: (Rule 45(ii))</h4>
                                    <ul style="list-style: disc;">
                                        <li>Inspection of proposed Toddy Depot premises</li>
                                        <li>Premises in-conformity of Rule 8</li>
                                        <li>Boundaries</li>
                                        <li>Rental agreement on NJS paper</li>
                                    </ul>
                                    <h4>Shifting of Toddy shop / Depot: (Rule 42)</h4>
                                    <ul style="list-style: disc;">
                                        <li>Inspection of proposed premises</li>
                                        <li>Premises in-conformity of Rule 8</li>
                                        <li>Boundaries</li>
                                        <li>Rental agreement on NJS paper</li>
                                        <li>Resolution of the society (for granting B-shop/Toddy Depot and Shifting of Toddy Shop/Depot of TCS)</li>
                                        <li>NOC from local body</li>
                                    </ul>
                                    <h4>Documents to be provided:</h4>
                                    <ul style="list-style: disc;">
                                        <li>Application</li>
                                        <li>Tapping test report along with tapping test photographs/ video graph. </li>
                                        <li>Boundaries</li>
                                        <li>Copy of Aadhar, Voter Id, Ration Card, Community,Residence certificate.</li>
                                        <li>Counterpart agreement on NJS paper</li>
                                        <li>Rental agreement on NJS papery</li>
                                        <li>Resolution of the society (for granting B-shop/Toddy Depot and Shifting of Toddy Shop/Depot of TCS).</li>
                                        <li>NOC from local body (Shifting)</li>
                                    </ul>
                                    <br/>
                                    <li>ES office verification:</li>
                                    <ul style="list-style: disc;">
                                        <li>Verification of documents</li>
                                        <li>In case of New toddy shop, proposals shall be submitted to District Collector through Deputy Commissioner for approval</li>
                                        <li>All new toddy shops shall be granted by the Commissioner after receipt of the proposals from the District Collector concerned.</li>
                                        <li>Issue of licence/B-shop/Toddy Depot.</li>
                                    </ul>
                                </ol>
                            </ul>

                        </div>
                    </div>
                </div>
            </div>
            <div class="block black bg-white" id="DivCS2" runat="server" visible="false">
                <div class="content">
                    <!-- Firm registration -->
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">CS-2</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">- </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>-</td>
                                    <td>0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>
                        <div style="padding-top: 0;">


                            <h5>Application for Licence to Sell Indian Made Foreign Liquor and Foreign Liquor by In-house CS-2</h5>

                            <ul class="excise-para">
                                <li>Name of the applicant:</li>
                                <li>Full Residential Address:</li>
                                <li>Details of the organization or Partnership firm with registration particulars:</li>
                                <li>Details of Premises to be Licensed:</li>
                                <li>Details of any other licenses held by him:</li>
                                <li>Date on which he can commence business:</li>
                                <li>In case of EP-1 the approximate quantity of IMFL required and the date/dates of event:</li>

                            </ul>

                        </div>
                    </div>
                </div>
            </div>
            <div class="block black bg-white" id="DivCS1" runat="server" visible="false">
                <div class="content">
                    <!-- Firm registration -->
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">CS-1</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">- </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>-</td>
                                    <td>0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>
                        <div style="padding-top: 0;">


                            <h5>Application for Licence to Sell Indian Made Foreign Liquor and Foreign Liquor by In-house CS-1</h5>

                            <ul class="excise-para">
                                <li>Name of the applicant:</li>
                                <li>Full Residential Address:</li>
                                <li>Details of the organization or Partnership firm with registration particulars:</li>
                                <li>Details of Premises to be Licensed:</li>
                                <li>Details of any other licenses held by him:</li>
                                <li>Date on which he can commence business:</li>
                                <li>In case of EP-1 the approximate quantity of IMFL required and the date/dates of event:</li>

                            </ul>

                        </div>
                    </div>
                </div>
            </div>
       

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

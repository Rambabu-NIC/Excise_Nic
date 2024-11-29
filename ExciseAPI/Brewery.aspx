<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Brewery.aspx.cs" Inherits="ExciseAPI.Brewery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="card block black bg-white">
            <div class="head">Brewery</div>
             <div class="content">
                <div class="text-center">
                <div class="row">
                     <div class="col-md-5 col-sm-5" style="text-align: end;">
                            <label class="custom-label">Brewery :</label>
                        </div>
                    <div class="col-md-4 col-sm-6">
                        <asp:DropDownList ID="ddl_brewery" class="form-control" runat="server" OnSelectedIndexChanged="ddl_brewery_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Application for LOI (Brewery in Form-B1)</asp:ListItem>
                            <asp:ListItem Value="2">Application for Licence (Brewery)</asp:ListItem>
                           <asp:ListItem Value="3">Renewal forms</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
            </div>
                 </div>
            </div>
        </div>
            <div class="block black bg-white" id="Grantofloi" runat="server" visible="false">
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
                                    <td colspan="2">Grant of Letter of Intent for establishment of any new Brewery</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Capacity<br />Upto 200 Lakh BLs<br />Above 200 Lakh BLs  </td>
                                    <td>NR & NA fee<br />Rs.1.00 crores<br />Rs. 1.5 crores  </td>
                                    <td>Spl fee<br />Rs.1.00 crores<br />    Rs. 1.5 crore</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>3</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>Stage 1 -- AC(D)H<br />Stage 2 -- CPE<br />Stage 3 - Govt.</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>No Time Lines Policy matte</td>
                                   
                                </tr>
                            </tbody>
                        </table>
                            </div>
                        <div style="padding-top: 0;">
                            <div class="content">
                                 <p class="excise-para">
                                    (1) No establishment of any new Brewery or expansion of the production capacity of an existing Brewery shall be issued without previous notification issued by the Government expressing the intention to grant the same from time to time.
                                </p>
                                 <p class="excise-para">
                                    (2) A notification shall be issued by the Government separately from time to time for grant of Letter of Intent for the establishment of a new Brewery or expansion of the production capacity of an existing Brewery.
                                </p>
                                 <p class="excise-para">
                                    (3) Govemment may, by notification issued from time to time, withdraw their intention of granting Letter of Intent for establishment of new Brewery
                                        expansion of the production capacity of the existing Brewery for any of the 
                                        purposes separately
                                </p>

                            </div>
                            <div class="content">
                                <h4>Comment</h4>
                                 <p class="excise-para">
                                    The Government in their G.O.Ms.No.749, Revenue (Ex.IIlI) Dept.
                                    dt. 04.06.2007 issued the notification as required under Rule 3 (2) above.
                                    Cony of the GO. is appended at the end of these Rules
                                </p>
                                 <p class="excise-para">
                                    (1) No licence for Brewery shall be granted unless the same
notified and sanctioned under Sub-rules (1) and (2) of Rule 3 and
sanctioned under Rule 4(2)\c) of these rules.
                                </p>
                                 <p class="excise-para">
                                    (2) Procedure for obtaining sanction of the Government:
                                    <ul class="excise-para">
                                        <li>On notification by the Government under Rule 3(1) and (2), any
att: to PerSOn intending to construct and work such a Brewery or expand ntthe production capacity of the existing B()) along with his scheme to the Brewery may apply in Form- 0 an Commissioner:.</li>
                                        <li>(i) No application mentioned in Clause (a) above shall be olut ao ius nlepsasid ai nntoon -rGefouvnedrnambleen at ntdr enaosunr-yad juansdta btlhee feceh allaas ns pienc ifeinctder tabienleodw support of payment is produced along with the application.

                                            <table class="excise-table">
                                                <thead>
                                                     <tr>
                                                     <th>Annual Production capacity of the proposed Brewery</th>
                                                     <th>Non-refundable and non-adjustable fee</th>
                                                         </tr>
                                                </thead>
                                                <tr>
                                                   
                                                    <td>Up to 200 Lakh Bulk Litres.</td>
                                                    <td>Rupees One Crores.</td>
                                                </tr>
                                                <tr>
                                                   
                                                    <td>Above 200 Lakh Bulk Litres,</td>
                                                    <td>Rupees One Crores Twenty Five Lakhs.</td>
                                                </tr>
                                            </table>

                                            

                                        </li>
                                        <li>
                                            (ii) A special fee as specified below shall also be paid into treasury and the challan in original in support of payment is produced along with the application.

                                            <table class="excise-table">
                                                <thead>
                                                     <tr>
                                                     <th>Annual Production capacity of the proposed Brewery</th>
                                                     <th>Special Fee</th>
                                                         </tr>
                                                </thead>
                                                <tr>
                                                   
                                                    <td>Up to 200 Lakh Bulk Litres.</td>
                                                    <td>Rupees One Crores.</td>
                                                </tr>
                                                <tr>
                                                   
                                                    <td>Above 200 Lakh Bulk Litres,</td>
                                                    <td>Rupees One Crores Twenty Five Lakhs.</td>
                                                </tr>
                                            </table>

                                        </li>
                                        <li>
                                            The special fee remitted under clause (ii) above shall be adjusted towards future licence fee or Excise Duty or both on commencement
                                            of production.
                                        </li>

                                    </ul>
                                </p>
                            </div>
                        </div>
                    
                        </div>
                    
                </div>
            </div>

            <div class="block black bg-white" id="GrantofLicence" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                       <div class="content">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Grant of new License in form B1</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Capacity<br />Upto 200LBLs<br />Every Addl. 10 LBLs</td>
                                    <td>NR & NA fee<br />Rs.1.00 crores<br />Rs.50.00 Lakhs</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>2</td>
                                    
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>Stage 1 -- AC(B)<br />Stage 2 - CPE</td>
                                    
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>No Time Lines</td>
                                   
                                </tr>
                            </tbody>
                        </table>
                           </div>

                        <div style="padding-top: 0;">
                            <p class="excise-para">1.	The holder of a letter of intent shall obtain a license from the Commissioner within six months from the date of sanction by the Government in the form of a Letter of Intent referred to in Rule 4 2(c).</p>
                            <p class="excise-para">2.	The holder of the letter of intent shall apply in Form-B (1) (A) and the application shall be accompanied by:</p>
                            <ul class="excise-para">
                                <li>Copy of the sanction (Letter of Intent) accorded by the Government.</li>
                                <li>Description and plans for the construction of the proposed manufactory.</li>
                                <li>Statement of plant and machinery proposed to be erected.</li>
                                <li>No objection certificate' from the local body competent to issue.</li>
                                <li>No objection certificate' from the competent authority under the Factories Act, 1948.</li>
                                <li>Clearance certificate from the Andhra Pradesh Pollution Control Board.</li>
                                <li>An undertaking in the prescribed form on a non-judicial stamp paper of the requisite value as per the Indian Stamp Act binding himself that he shall erect the plant and machinery as per the standards, as may be prescribed by the Commissioner from time to time for maintaining the specifications and quality of products.</li>

                                <li>Counterpart agreement in Form-B (1) (C).</li>


                            </ul>
                            <p class="excise-para">3.	No license shall be granted unless the applicant deposits ₹5,00,000/- (Rupees Five Lakhs only) in the shape of a cash fixed deposit receipt or Bank Guarantee from any Scheduled Bank situated in Andhra Pradesh as a security for fulfillment of all the conditions and enters into a counterpart agreement in Form-B (1) (C).</p>
                            <p class="excise-para">4.	(a) Where the Commissioner is satisfied that the applicant has fulfilled the conditions specified in sub-rules (1) to (3), he may grant a license to the applicant in Form B-2.</p>
                            <ul class="excise-para">

                                <li>(b )The license fee for a new Brewery shall be ₹1,00,000/- (Rupees One Lakh only) per annum till the commencement of production or expiry of two and a half years period from the issue of the letter of intent, whichever is earlier.</li>
                                <li>(c) Where the Commissioner is satisfied that the applicant for expansion of production capacity of an existing Brewery has fulfilled the conditions specified in sub-rules (1) to (3), he may endorse the sanction of expansion on the existing license.</li>

                            </ul>
                            <p class="excise-para">5. The licensee shall, before the expiry of two and a half years from the date of grant of the letter of intent, report to the Commissioner the date on which the construction or expansion of the brewery is completed and the date from which its working is commenced.</p>
                           <p class="excise-para">6. In case the licensee fails to construct or expand and work the brewery before the expiry of two and a half years from the date of the grant of the letter of intent, the new license or the expansion sanctioned under sub-rule (4)(a) or (4)(c), as the case may be, shall be liable for cancellation without compensation for any damage or loss .</p>

                        </div>
                    </div>
                </div>
            </div>


    <div class="block black bg-white" id="DivRenewal" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                       <div class="content">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Renewal of B1 license</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Capacity<br />Upto 200LBLs<br />Every Addl. 10 LBLs</td>
                                    <td>NR & NA fee<br />Rs.1.00 crores<br />Rs.50.00 Lakhs</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>2</td>
                                    
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>Stage 1 -- AC(B)<br />Stage 2 - CPE</td>
                                    
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>No Time Lines</td>
                                   
                                </tr>
                            </tbody>
                        </table>
                           </div>

                        <div style="padding-top: 0;">
                            <p class="excise-para">1.	The holder of a letter of intent shall obtain a license from the Commissioner within six months from the date of sanction by the Government in the form of a Letter of Intent referred to in Rule 4 2(c).</p>
                            <p class="excise-para">2.	The holder of the letter of intent shall apply in Form-B (1) (A) and the application shall be accompanied by:</p>
                            <ul class="excise-para">
                                <li>Copy of the sanction (Letter of Intent) accorded by the Government.</li>
                                <li>Description and plans for the construction of the proposed manufactory.</li>
                                <li>Statement of plant and machinery proposed to be erected.</li>
                                <li>No objection certificate' from the local body competent to issue.</li>
                                <li>No objection certificate' from the competent authority under the Factories Act, 1948.</li>
                                <li>Clearance certificate from the Andhra Pradesh Pollution Control Board.</li>
                                <li>An undertaking in the prescribed form on a non-judicial stamp paper of the requisite value as per the Indian Stamp Act binding himself that he shall erect the plant and machinery as per the standards, as may be prescribed by the Commissioner from time to time for maintaining the specifications and quality of products.</li>

                                <li>Counterpart agreement in Form-B (1) (C).</li>


                            </ul>
                            <p class="excise-para">3.	No license shall be granted unless the applicant deposits ₹5,00,000/- (Rupees Five Lakhs only) in the shape of a cash fixed deposit receipt or Bank Guarantee from any Scheduled Bank situated in Andhra Pradesh as a security for fulfillment of all the conditions and enters into a counterpart agreement in Form-B (1) (C).</p>
                            <p class="excise-para">4.	(a) Where the Commissioner is satisfied that the applicant has fulfilled the conditions specified in sub-rules (1) to (3), he may grant a license to the applicant in Form B-2.</p>
                            <ul class="excise-para">

                                <li>(b )The license fee for a new Brewery shall be ₹1,00,000/- (Rupees One Lakh only) per annum till the commencement of production or expiry of two and a half years period from the issue of the letter of intent, whichever is earlier.</li>
                                <li>(c) Where the Commissioner is satisfied that the applicant for expansion of production capacity of an existing Brewery has fulfilled the conditions specified in sub-rules (1) to (3), he may endorse the sanction of expansion on the existing license.</li>

                            </ul>
                            <p class="excise-para">5. The licensee shall, before the expiry of two and a half years from the date of grant of the letter of intent, report to the Commissioner the date on which the construction or expansion of the brewery is completed and the date from which its working is commenced.</p>
                           <p class="excise-para">6. In case the licensee fails to construct or expand and work the brewery before the expiry of two and a half years from the date of the grant of the letter of intent, the new license or the expansion sanctioned under sub-rule (4)(a) or (4)(c), as the case may be, shall be liable for cancellation without compensation for any damage or loss .</p>

                        </div>
                    </div>
                </div>
            </div>
      
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Secondary_Distillery.aspx.cs" Inherits="ExciseAPI.Secondary_Distillery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card w-100 fl container-fluid">
        <div class="card block black bg-white">
            <div class="head">Secondary Distillery</div>
            <div class="content">
                <div class="text-center">
                    <div class="row">
                        <div class="col-md-5 col-sm-5" style="text-align: end;">
                            <label class="custom-label">Secondary Distillery Service :</label>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddl_secondary_dist" class="form-control" runat="server" OnSelectedIndexChanged="ddl_secondary_dist_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Application for LOI (IMFL) in DM(1) nForm</asp:ListItem>
                                <asp:ListItem Value="2">Application for Licence (IMFL)</asp:ListItem>
                                <asp:ListItem Value="3">Renewal forms</asp:ListItem>
                            </asp:DropDownList>
                        </div>
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
                                <td colspan="2">Grant of Letter of Intent for establishment of any new manufactory</td>
                               
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">Capacity <br />Upto 10 Lakh PLs<br />10 Lakh PLs upto 50 Lakh PLs<br />50 Lakh PLs upto 100 Lakh PLs<br />Above 100 Lakh PLs  </td>
                                <td colspan="2">NR & NA fee<br />Rs. 7 crores<br />Rs. 7 crores<br /> Rs. 10 crores<br />Rs. 10 crores + Rs. 2 Cr addl   50 Lakh PLs  or part<br />  thereof</td>
                                <td colspan="2">Spl fee<br />Rs. 3 crores<br />Rs. 3 crores<br />Rs. 5 crores<br />Rs. 5 crores + Rs. 1Craddl   50 Lakh PLs  or part <br /> thereof</td>
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
                                <td>No Time Lines Policy matter</td>
                               
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="padding-top: 0;">
                    <p class="excise-para">
                        (1) The holder of a letter of intent shall obtain a license from the Commissioner within six months from the date of sanction by the Government in the form of a Letter of Intent referred to in rule 5(c).
                    </p>
                    <p class="excise-para">
                        (2) The holder of the letter of intent shall apply in Form-DM (1) (A) and the application shall be accompanied by:
                                <ul class="excise-para">
                                    <li>(a) Copy of the sanction (Letter of Intent) accorded by the Government.</li>
                                    <li>(b) Description and plans for the construction of the proposed manufactory.</li>
                                    <li>(c) Statement of plant and machinery proposed to be erected.</li>
                                    <li>(d) 'No objection certificate' from the local body competent to issue.</li>
                                    <li>(e) 'No objection certificate' from the competent authority under the Factories Act, 1948.</li>
                                    <li>(f) Clearance certificate from the A.P. Pollution Control Board.</li>
                                    <li>(g) An undertaking in the prescribed form on a non-judicial stamp paper of the requisite value as per the Indian Stamp Act binding himself that he shall erect the plant and machinery as per the standards, as may be prescribed by the Commissioner from time to time for maintaining the specifications and quality of products.</li>
                                    <li>(h) Counterpart Agreement in Form-DM (1) (C).</li>
                                </ul>
                    </p>
                    <p class="excise-para">
                        (3) No license shall be granted unless the applicant deposits Rs. 10 Lakhs in the shape of a cash deposit or fixed deposit receipt or Bank Guarantee from any scheduled bank situated in Telangana as a security for fulfillment of all the conditions of the license and enters into a counterpart agreement in Form-DM (1) (C).
                    </p>
                    <p class="excise-para">
                        Provided that in the case of a license for a new manufactory, the licensee shall furnish a bank guarantee valid for four (4) years from the date of the grant of the Letter of Intent from any Scheduled Bank situated in Telangana as security for a sum equal to the remaining 11 four-monthly installments of the non-refundable and non-adjustable fee as well as the special fee.
[Two provisos inserted by GOMs.No. 1051, Rev. (Ex.II) Dept. dated 21.8.2008 and further substituted by GO. Ms.No. 881 Revenue (Ex. III) Dept. dated 23.8.2010 into a single proviso]
                    </p>
                    <p class="excise-para">
                        (4) 
                                <ul class="excise-para">
                                    <li>(a) Where the Commissioner is satisfied that a new manufactory has fulfilled the conditions specified in sub-rules (1) to (3) above, he may grant a license to the applicant in Form DM-2(M)/DM-2(G)/DM-2(MGO) as the case may be.</li>
                                    <li>(b) The license fee for a new manufactory shall be Rs. 20,000/- (Rupees twenty thousand only) per annum till the commencement of production or expiry of two years period from the issue of the letter of intent, whichever is earlier.
                                    </li>
                                    <li>(c) Where the Commissioner is satisfied that the applicant for the expansion of production capacity of an existing manufactory has fulfilled the conditions specified in sub-rules (1) to (3) above, he may endorse the sanction of expansion on the existing license by permitting the licensee to go for the expansion in a phased manner as required by the licensee within the validity period of the Letter of Intent.
[Clause (c) substituted by GO.Ms.No. 1051, Rev. (Ex.II) Dept. dated 21.8.2008]
                                    </li>
                                </ul>
                    </p>
                    <p class="excise-para">
                        (5) The licensee shall, before the expiry of two years from the date of grant of the letter of intent, report to the Commissioner the date on which the construction or expansion of the manufactory is completed and the date from which its working is commenced.
                    </p>
                    <p class="excise-para">
                        (6) In case the licensee fails to construct or expand and work the manufactory before the expiry of two years from the date of grant of the letter of intent, the new license or the expansion sanctioned under sub-rule (4)(a) or (4)(c), as the case may be, shall be liable for cancellation without compensation for any damage or loss.
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="block black bg-white" id="RenewalofLicence" runat="server" visible="false">
        <div class="content">
            <div class="col-md-12 col-lg-12">
                <div class="content">
                    <table class="excise-table">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th style="text-align: left;">SERVICE NAME</th>
                                <td colspan="2">Grant of new License in form DM2(MGO) </td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">Capacity<br />Upto 20LPLs  <br />Every Addl. One LPLs</td>
                                <td>NR & NA fee<br />Rs.40.00 Lakhs.<br />Rs.2.00 Lakhs</td>
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
                                <td>Stage 1 -- AC(D)H<br />Stage 2 -- CPE   </td>
                               
                            </tr>
                            <tr>
                                <th style="text-align: left;">TIME LINES</th>
                                <td>No Time Lines </td>
                               
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="padding-top: 0;">
                    <p class="excise-para">
                        (1) Licence, granted under these rules, shall come
into effect from such date as specified therein.
                    </p>
                    <p class="excise-para">
                        (2) Licence shall ordinarily be for a period of one year.
                    </p>
                    <p class="excise-para">
                        (3) The licensee shall get his licence renewed before the commencement of the Licence year, by paying the licence fee as prescribed in Rule 8,
                                other wise he is neither eligible to go into production nor permitted to transact any business
                    </p>
                    <p class="excise-para">
                        (4) If the licensee fails to apply for renewal by paying the specified fee before the commencement of the licence year, he shall pay the licence
fee along with late fee specified below for renewal of his licence.

                               
                        <table class="excise-table">
                            <thead>
                                <tr>
                                    <th>Period</th>
                                    <th>Late Fee</th>
                                </tr>
                            </thead>
                            <tr>

                                <td>1.
                                                Within six months from the date of
                                                Commencement of licence year</td>
                                <td>5% of the Annual Licence Fee.</td>
                            </tr>
                            <tr>

                                <td>2. After six months from the date of Commencement of Licence year.</td>
                                <td>10% of the Annual Licence Fee.</td>
                            </tr>
                        </table>

                    </p>
                    <p class="excise-para">
                        Provided, if the licensee does not apply for renewal of licence within he licence year, he shall pay the annual licence fee for the entire period
for which he docs not have his licence renewed along with the late fee
as specified above, subject to the condition laid down in sub-rule (7) of this Rule.

                    </p>
                    <p class="excise-para">
                        (5) Every application for renewal of licence under these rules shall
bear a court fee stamp of requisite value as specified in the Indian Stamp
Act and shall be addressed to the Commissioner.

                    </p>
                    <p class="excise-para">
                        (6) Where the Commissioner is satisfied that the licensee has fulfilled
the conditions specified for renewal and that the manufacturing facilities
on ground are not modified in any manner in deviation of the provisions
Of previous licence, he may renew the licence.

                    </p>
                    <p class="excise-para">
                        (7) The right of the licensee to get his licence renewed stands forfeited
if the licence is not renewed continuously for a period of 3 years.

                    </p>
                </div>
            </div>
        </div>
    </div>

    <div class="block black bg-white" id="TransferofLicence" runat="server" visible="false">
        <div class="content">
            <div class="col-md-12 col-lg-12">
                <div class="content">
                    <table class="excise-table">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th style="text-align: left;">SERVICE NAME</th>
                                <td colspan="2">Renewal of DM2(MGO) license</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">Capacity<br />Upto 20LPLs<br />Every Addl. One LPLs</td>
                                <td>NR & NA fee<br />Rs.40.00 Lakhs.<br />Rs.2.00 Lakhs</td>
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
                                <td>Stage 1 -- AC(D)H<br />Stage 2 -- CPE   </td>
                                
                            </tr>
                            <tr>
                                <th style="text-align: left;">TIME LINES</th>
                                <td>No Time Lines</td>
                                
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="padding-top: 0;">
                    <h4>(1) Transfer of Licence:</h4>
                    <p class="excise-para">
                        (i) No licensee shall except with the sanction of the Commissioner transfer his license to any other person. The Commissioner may allow such transfer of license on payment of prescribed fee and on production of certificate to the effect that no cases involving contravention of Excise Act and Rules framed there under are pending against him and also on production of Sales Tax and Income Tax clearance certificates.

Common Provisions relating to Renewal, Sub-leasing,
When there are only two partners in the firm holding the licence and one of them withdraws or expires, the entity of firm changes from partnership to proprietary and it amounts to transfer of licence.

Conversion of a proprietary concern into a firm or a company or a firm into a company and vice versa shall amount to transfer of licence.

The Commissioner, on payment of a fee of Rupees Two lakhs and on obtaining such undertaking or Bond and such other material documents to protect the interest of the Government as he may deem fit, may grant such permission for the transfer of the licence in the cases referred in clauses (ii) and (iii) above.
                    </p>
                    <p class="excise-para">
                        (v) Where there is a change of 50% or more partners, it shall be construed as a complete change in the ownership, and a fee amounting to 10% of the licence fee shall be paid.
                    </p>
                    <p class="excise-para">
                        (2) Inclusion or exclusion of partners: No licensee shall except with prior permission of the Commissioner get any person included as a partner to his business or get an existing partner excluded.
                    </p>
                    <p class="excise-para">
                        (3) Death of licensee or incapability of the licensee: A licence, issued under these rules, shall be only to the person named therein and on his death the legal heirs may apply for continuance of the licence in their name to the Commissioner within thirty days of the death of the licensee. If the Commissioner is satisfied, he may permit the legal heirs to continue the licence in the name of such legal heirs.
                    </p>
                    <p class="excise-para">
                        (4) Merger of licence:
                                <ul class="excise-para">
                                    <li>(i) When licensees of two or more existing manufactories subject to provisions of Rule 13(1) desire to merge into one manufactory, they may apply to the Commissioner in Form-DM3 (M) along with a challan for Rupees Two lakhs.</li>
                                    <li>(ii) On receipt of such an application the Commissioner if satisfied, may obtain such undertaking or Bond and such other material documents to protect the interest of the Government as he may deem fit, and may grant such permission after obtaining the orders from the Government for the merger of the manufactories.</li>
                                </ul>
                    </p>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

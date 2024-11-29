<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Primary_Distillery.aspx.cs" Inherits="ExciseAPI.Primary_Distillery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Primary Distillery</div>
            <div class="content">
                <div class="text-center">
                    <div class="row">
                        <div class="col-md-5 col-sm-5" style="text-align: end;">
                            <label class="custom-label">Primary Distillery Service :</label>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="ddl_Primary" class="form-control" runat="server" OnSelectedIndexChanged="ddl_Primary_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Application for LOI of D1P(Potable)</asp:ListItem>
                                <asp:ListItem Value="2">Application for LOI of D1R(Industrial Fully)</asp:ListItem>
                                <asp:ListItem Value="3">Application for LOI of D1R(Industrial Partial)</asp:ListItem>
                                <asp:ListItem Value="4">Application for Grant of Licence of D1P(Potable)</asp:ListItem>
                                <asp:ListItem Value="5">Application for Grant of Licence of D1R(Industrial Fully)</asp:ListItem>
                                <asp:ListItem Value="6">Application for Grant of Licence of D1R(Industrial Partial)</asp:ListItem>
                                <asp:ListItem Value="7"> Renewal forms</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="block black bg-white" id="DivLOID1P" runat="server" visible="false">
            <div class="content">
                <div class="col-md-12 col-lg-12">
                    <div class="content">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Grant of Letter of Intent for establishment of Spirit & Malt Spirit Producing Distillery</td>
                                   
                                </tr>
                                <tr>
                                    <th>SERVICE FEE</th>
                                    <td colspan="2">Rs.20 Lakhs</td>
                                   
                                </tr>
                                <tr>
                                    <th>USER CHARGES</th>
                                    <td colspan="2">0</td>
                                   
                                </tr>
                                <tr>
                                    <th>STAGES</th>
                                     <td>3</td>
                                    
                                </tr>
                                <tr>
                                                                                                                       
                                    <th>ALLOTED OFFICIALS</th>
                                    <td>Stage 1 -- AC(D)H <br />Stage 2 -- CPE<br /> Stage 3 - Govt.</td>
                                </tr>
                                <tr>
                                    <th>TIME LINES</th>
                                    <td>No Time Lines Policy matter</td>
                                    
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="content">


                        <h4>LICENCE FOR POSSESSION AND USE OF DENATURED SPIRIT IN
                        MANUFACTURE OF SURGICAL SPIRIT AND HYDROZEN PEROXIDE FOR
                        INDUSTRIAL PURPOSE AS RE-AGENTS OR SOLVENT ETC. </h4>
                        <p class="excise-para">
                            (1) The quantity permitted for manufacture per annum shall be B.Ls of Rectified spirit/Extra Neutral Alcohol/Malt spirit.

                        </p>

                        <p class="excise-para">(2) This sanction is accorded without any commitment for allowing import of any machinery or supply of raw materials,</p>
                        <p class="excise-para">
                            (3) This letter of Intent is valid for a period of two years from the date of issue, subject to the condition that the holder shail

                        obtain a licence by the Commissioner of Prohibition and Excise within six months duly paying the initial licence fee and the security, deposits as required under Telangana Distillery (Manufacture of spirits) Rules, 2006.
                        </p>

                        <p class="excise-para">(4) The holder of this Letter of Intent shall fulfil the formalities laid down in the Telangana Distillery (Manufacture of Spirits) Rules, 2006.</p>
                        <p class="excise-para">
                            (5) This Letter of Intent shall not, however confer any right or privilege for the grant of a licence and it is liable to be cancelled at any time and in such an event, no compensation or damages whatever shall be payable for such cancellation.
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="block black bg-white" id="LOID1RFully" runat="server" visible="false">
            <div class="content">
                <div class="col-md-12 col-lg-12">
                    <div class="content">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td>Grant of Letter of Intent for establishment of Spirit Producing Distillery exclusively industrial purpose</td>
                                    
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td>Rs.5 Lakhs</td>
                                    
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td>0</td>

                                    
                                </tr>
                                <tr>
                                                                                                                    
                                    <th style="text-align: left;">STAGES</th>
                                   <td>3</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                     <td>Stage 1 -- AC(D)H <br />Stage 2 -- CPE<br />Stage 3 - Govt.</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>No Time Lines Policy matter</td>
                                   
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="padding-top: 0;">
                        <div class="content">
                            <h4>PROCEDURE:-</h4>
                            <p class="excise-para">After receipt of application in prescribed format. Commissioner after causing such enquiry from concerned Assistant Commissioners Distilleries and on fulfillment of required documents and taxes, he may grant licences. </p>
                        </div>
                        <div class="content">
                            <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                            <p class="excise-para">Documents required for grant of Licence:</p>

                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th style="text-align: left;">Sl.No.</th>
                                        <td colspan="2" style="text-align: center;"><b>Description</b></td>
                                        <td colspan="3"><b>Rule</b></td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">1</th>
                                        <td colspan="2">Copy of the sanction (Letter of Intent) accorded by the Government</td>
                                        <td colspan="2">9(2)(a)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">2</th>
                                        <td colspan="2">Description and plans for the construction of the proposed distillery.</td>
                                        <td colspan="2">9(2)(b)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">3</th>
                                        <td colspan="2">Statement of plant and machinery proposed to be erected.</td>
                                        <td colspan="2">9(2)(c)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">4</th>
                                        <td colspan="2">No Objection Certificate from the local body competent to grant the same.</td>
                                        <td colspan="2">9(2)(d)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">5</th>
                                        <td colspan="2">'No Objection Certificate' from the competent authority under Factories Act, 1948.</td>
                                        <td colspan="2">9(2)(e)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">6</th>
                                        <td colspan="2">Clearance Certificate from the Telangana Pollution control Board.</td>
                                        <td colspan="2">9(2)(f)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">7</th>
                                        <td colspan="2">An Under Taking in the prescribed form on a non-judicial stamp paper of the requisite 
                                        <br />
                                            value as specified in Indian Stamp Act binding himself that he shall erect the plant and machinery 
                                        <br />
                                            as per the standards as may be prescribed by the Commissioner from time to time for maintaining the specifications and 
                                        quality of products</td>
                                        <td colspan="2">9(2)(g)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">8</th>
                                        <td colspan="2">Counterpart agreement in Form D1 (C) as required under subrule (3).</td>
                                        <td colspan="2">9(2)(h)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">9</th>
                                        <td colspan="2">Security Deposit for ₹50,000/-</td>
                                        <td colspan="2">9(3)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">10</th>
                                        <td colspan="2">Initial Distillery Excise Tax ₹20,000/-</td>
                                        <td colspan="2">9(4)(b)</td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: left;">11</th>
                                        <td colspan="2">Land Particulars</td>
                                        <td colspan="2">9(2)</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>


                        <!-- <p>Citizen must submit papers either by courier/RPAD or handover in person in the concerned District 
                            Registrar Office quoting online application reference number.</p>
   -->

                    </div>
                </div>

            </div>
        </div>

        <div class="block black bg-white" id="DivLOID1RPartial" runat="server" visible="false">
            <div class="content">
                <div class="col-md-12 col-lg-12">
                    <div class="content">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>SERVICE NAME</th>
                                    <td colspan="2">Grant of Letter of Intent for establishment of Spirit Producing Distillery industrial purpose wholly or partly</td>
                                    
                                </tr>
                                <tr>
                                    <th>SERVICE FEE</th>
                                    <td colspan="2">Rs.20 Lakhs</td>
                                    
                                </tr>
                                <tr>
                                    <th>USER CHARGES</th>
                                    <td colspan="2">0</td>
                                    
                                </tr>
                                <tr>
                                    <th>STAGES</th>
                                     <td>3</td>
                                   
                                </tr>
                                <tr>
                                                                                                                       
                                    <th>ALLOTED OFFICIALS</th>
                                    <td>Stage 1 -- AC(D)H<br />Stage 2 -- CPE<br />Stage 3 - Govt. </td>
                                    
                                </tr>
                                <tr>
                                    <th>TIME LINES</th>
                                    <td>No Time Lines Policy matter</td>
                                    
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="content">


                        <h4>LICENCE FOR POSSESSION AND USE OF DENATURED SPIRIT IN
                        MANUFACTURE OF SURGICAL SPIRIT AND HYDROZEN PEROXIDE FOR
                        INDUSTRIAL PURPOSE AS RE-AGENTS OR SOLVENT ETC. </h4>
                        <p class="excise-para">
                            (1) The quantity permitted for manufacture per annum shall be B.Ls of Rectified spirit/Extra Neutral Alcohol/Malt spirit.

                        </p>

                        <p class="excise-para">(2) This sanction is accorded without any commitment for allowing import of any machinery or supply of raw materials,</p>
                        <p class="excise-para">
                            (3) This letter of Intent is valid for a period of two years from the date of issue, subject to the condition that the holder shail

                        obtain a licence by the Commissioner of Prohibition and Excise within six months duly paying the initial licence fee and the security, deposits as required under Telangana Distillery (Manufacture of spirits) Rules, 2006.
                        </p>

                        <p class="excise-para">(4) The holder of this Letter of Intent shall fulfil the formalities laid down in the Telangana Distillery (Manufacture of Spirits) Rules, 2006.</p>
                        <p class="excise-para">
                            (5) This Letter of Intent shall not, however confer any right or privilege for the grant of a licence and it is liable to be cancelled at any time and in such an event, no compensation or damages whatever shall be payable for such cancellation.
                        </p>
                    </div>
                </div>
            </div>
        </div>


        <div class="block black bg-white" id="DivGrantLicenceD1P" runat="server" visible="false">
            <div class="content">
                <div class="col-md-12 col-lg-12">
                    <div class="content">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>SERVICE NAME</th>
                                    <td colspan="2">Grant of Licence for Manufacture of Spirit & Malt Spirit for potable purpose</td>
                                    
                                </tr>
                                <tr>
                                    <th>SERVICE FEE</th>
                                    <td colspan="2">upto 20 LBLs -Rs.8 lakhs<br />for every additional 10 LBLs -- Rs.2 Lakhs</td>
                                    
                                </tr>
                                <tr>
                                    <th>USER CHARGES</th>
                                    <td colspan="2">0</td>
                                    
                                </tr>
                                <tr>
                                    <th>STAGES</th>
                                     <td>2</td>
                                   
                                </tr>
                                <tr>
                                                                                                                                                                   
                                    <th>ALLOTED OFFICIALS</th>
                                    <td> Stage 1 -- AC(D)H<br />Stage 2 -- CPE </td>
                                   
                                   
                                </tr>
                                <tr>
                                    <th>TIME LINES</th>
                                    <td>(15) days</td>
                                    
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="content">


                        <h4>LICENCE FOR POSSESSION AND USE OF DENATURED SPIRIT IN
                        MANUFACTURE OF SURGICAL SPIRIT AND HYDROZEN PEROXIDE FOR
                        INDUSTRIAL PURPOSE AS RE-AGENTS OR SOLVENT ETC. </h4>
                        <p class="excise-para">
                            (1) The quantity permitted for manufacture per annum shall be B.Ls of Rectified spirit/Extra Neutral Alcohol/Malt spirit.

                        </p>

                        <p class="excise-para">(2) This sanction is accorded without any commitment for allowing import of any machinery or supply of raw materials,</p>
                        <p class="excise-para">
                            (3) This letter of Intent is valid for a period of two years from the date of issue, subject to the condition that the holder shail

                        obtain a licence by the Commissioner of Prohibition and Excise within six months duly paying the initial licence fee and the security, deposits as required under Telangana Distillery (Manufacture of spirits) Rules, 2006.
                        </p>

                        <p class="excise-para">(4) The holder of this Letter of Intent shall fulfil the formalities laid down in the Telangana Distillery (Manufacture of Spirits) Rules, 2006.</p>
                        <p class="excise-para">
                            (5) This Letter of Intent shall not, however confer any right or privilege for the grant of a licence and it is liable to be cancelled at any time and in such an event, no compensation or damages whatever shall be payable for such cancellation.
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <div class="block black bg-white" id="DivGrantD1RFully" runat="server" visible="false">
            <div class="content">
                <div class="col-md-12 col-lg-12">
                    <div class="content">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>SERVICE NAME</th>
                                    <td colspan="2">Grant of Licence for Manufacture of Spirit exculisvely for industrial purpose</td>
                                    
                                </tr>
                                <tr>
                                    <th>SERVICE FEE</th>
                                    <td colspan="2">upto 20 LBLs -Rs.8 lakhs<br />for every additional 10 LBLs -- Rs.2 Lakhs</td>
                                    
                                </tr>
                                <tr>
                                    <th>USER CHARGES</th>
                                    <td colspan="2">0</td>
                                    
                                </tr>
                                <tr>
                                    <th>STAGES</th>
                                     <td>2</td>
                                   
                                </tr>
                                <tr>
                                                                                                                                                                   
                                    <th>ALLOTED OFFICIALS</th>
                                    <td>Stage 1 -- AC(D)H<br />Stage 2 -- CPE </td>
                                   
                                   
                                </tr>
                                <tr>
                                    <th>TIME LINES</th>
                                    <td>(15) days</td>
                                    
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="content">


                        <h4>LICENCE FOR POSSESSION AND USE OF DENATURED SPIRIT IN
                        MANUFACTURE OF SURGICAL SPIRIT AND HYDROZEN PEROXIDE FOR
                        INDUSTRIAL PURPOSE AS RE-AGENTS OR SOLVENT ETC. </h4>
                        <p class="excise-para">
                            (1) The quantity permitted for manufacture per annum shall be B.Ls of Rectified spirit/Extra Neutral Alcohol/Malt spirit.

                        </p>

                        <p class="excise-para">(2) This sanction is accorded without any commitment for allowing import of any machinery or supply of raw materials,</p>
                        <p class="excise-para">
                            (3) This letter of Intent is valid for a period of two years from the date of issue, subject to the condition that the holder shail

                        obtain a licence by the Commissioner of Prohibition and Excise within six months duly paying the initial licence fee and the security, deposits as required under Telangana Distillery (Manufacture of spirits) Rules, 2006.
                        </p>

                        <p class="excise-para">(4) The holder of this Letter of Intent shall fulfil the formalities laid down in the Telangana Distillery (Manufacture of Spirits) Rules, 2006.</p>
                        <p class="excise-para">
                            (5) This Letter of Intent shall not, however confer any right or privilege for the grant of a licence and it is liable to be cancelled at any time and in such an event, no compensation or damages whatever shall be payable for such cancellation.
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <div class="block black bg-white" id="DivGrantD1RPartial" runat="server" visible="false">
            <div class="content">
                <div class="col-md-12 col-lg-12">
                    <div class="content">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>SERVICE NAME</th>
                                    <td colspan="2">Grant of Licence for Manufacture of Spirit  for industrial purpose wholly or partly</td>
                                   
                                </tr>
                                <tr>
                                    <th>SERVICE FEE</th>
                                    <td colspan="2">upto 20 LBLs -Rs.8 lakhs<br />for every additional 10 LBLs -- Rs.2 Lakhs</td>
                                   
                                </tr>
                                <tr>
                                    <th>USER CHARGES</th>
                                    <td colspan="2">0</td>
                                    
                                </tr>
                                <tr>
                                    <th>STAGES</th>
                                     <td>2</td>
                                    
                                </tr>
                                <tr>
                                                                                                                                                                   
                                    <th>ALLOTED OFFICIALS</th>
                                    <td> Stage 1 -- AC(D)H<br />Stage 2 -- CPE  </td>
                                    
                                   
                                </tr>
                                <tr>
                                    <th>TIME LINES</th>
                                    <td>(15) days</td>
                                    
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="content">


                        <h4>LICENCE FOR POSSESSION AND USE OF DENATURED SPIRIT IN
                        MANUFACTURE OF SURGICAL SPIRIT AND HYDROZEN PEROXIDE FOR
                        INDUSTRIAL PURPOSE AS RE-AGENTS OR SOLVENT ETC. </h4>
                        <p class="excise-para">
                            (1) The quantity permitted for manufacture per annum shall be B.Ls of Rectified spirit/Extra Neutral Alcohol/Malt spirit.

                        </p>

                        <p class="excise-para">(2) This sanction is accorded without any commitment for allowing import of any machinery or supply of raw materials,</p>
                        <p class="excise-para">
                            (3) This letter of Intent is valid for a period of two years from the date of issue, subject to the condition that the holder shail

                        obtain a licence by the Commissioner of Prohibition and Excise within six months duly paying the initial licence fee and the security, deposits as required under Telangana Distillery (Manufacture of spirits) Rules, 2006.
                        </p>

                        <p class="excise-para">(4) The holder of this Letter of Intent shall fulfil the formalities laid down in the Telangana Distillery (Manufacture of Spirits) Rules, 2006.</p>
                        <p class="excise-para">
                            (5) This Letter of Intent shall not, however confer any right or privilege for the grant of a licence and it is liable to be cancelled at any time and in such an event, no compensation or damages whatever shall be payable for such cancellation.
                        </p>
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
                                    <th>SERVICE NAME</th>
                                    <td colspan="2">Renewals of form D1(P) & D1(R)</td>
                                   
                                </tr>
                                <tr>
                                    <th>SERVICE FEE</th>
                                    <td colspan="2">upto 20 LBLs -Rs.8 lakhs<br />for every additional 10 LBLs -- Rs.2 Lakhs</td>
                                   
                                </tr>
                                <tr>
                                    <th>USER CHARGES</th>
                                    <td colspan="2">0</td>
                                   
                                </tr>
                                <tr>
                                    <th>STAGES</th>
                                     <td>2</td>
                                   
                                </tr>
                                <tr>
                                                                                                                                                                   
                                    <th>ALLOTED OFFICIALS</th>
                                    <td> Stage 1 -- AC(D)H<br />Stage 2 -- CPE </td>
                                   
                                   
                                </tr>
                                <tr>
                                    <th>TIME LINES</th>
                                    <td>(15) days</td>
                                    
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="content">


                        <h4>LICENCE FOR POSSESSION AND USE OF DENATURED SPIRIT IN
                        MANUFACTURE OF SURGICAL SPIRIT AND HYDROZEN PEROXIDE FOR
                        INDUSTRIAL PURPOSE AS RE-AGENTS OR SOLVENT ETC. </h4>
                        <p class="excise-para">
                            (1) The quantity permitted for manufacture per annum shall be B.Ls of Rectified spirit/Extra Neutral Alcohol/Malt spirit.

                        </p>

                        <p class="excise-para">(2) This sanction is accorded without any commitment for allowing import of any machinery or supply of raw materials,</p>
                        <p class="excise-para">
                            (3) This letter of Intent is valid for a period of two years from the date of issue, subject to the condition that the holder shail

                        obtain a licence by the Commissioner of Prohibition and Excise within six months duly paying the initial licence fee and the security, deposits as required under Telangana Distillery (Manufacture of spirits) Rules, 2006.
                        </p>

                        <p class="excise-para">(4) The holder of this Letter of Intent shall fulfil the formalities laid down in the Telangana Distillery (Manufacture of Spirits) Rules, 2006.</p>
                        <p class="excise-para">
                            (5) This Letter of Intent shall not, however confer any right or privilege for the grant of a licence and it is liable to be cancelled at any time and in such an event, no compensation or damages whatever shall be payable for such cancellation.
                        </p>
                    </div>
                </div>
            </div>
        </div>



    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

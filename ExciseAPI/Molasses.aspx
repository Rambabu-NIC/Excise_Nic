<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Molasses.aspx.cs" Inherits="ExciseAPI.Molasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card w-100 fl container-fluid">
        <div class="block black bg-white">
             <div class="head">Molasses</div>
             <div class="content">
                <div class="text-center">
                <div class="row">
                     <div class="col-md-5 col-sm-5" style="text-align: end;">
                            <label class="custom-label">Molasses Service :</label>
                        </div>
                        <div class="col-md-4 col-sm-6">
                            <asp:DropDownList ID="ddl_Molasses" class="form-control" runat="server" OnSelectedIndexChanged="ddl_Molasses_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Application for grant / renewal of M-I license</asp:ListItem>
                                <asp:ListItem Value="2">Application for grant / renewal of M-II license</asp:ListItem>
                                <asp:ListItem Value="3">Application for grant / renewal of M-IV license</asp:ListItem>
                                <asp:ListItem Value="4">Application for grant / renewal of M-V license</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
            </div>
            </div>
        </div>
            <div class="block black bg-white" id="GrantofM1Licence" runat="server" visible="false">
                <div class="content">
                    <!-- Firm registration -->
                    <div class="col-md-12 col-lg-12">
                         <div class="content">
                        <table  class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Molasses production license</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Application fee - Rs.100/- and license fee is as follows: for base quota upto 5000 MTs - Rs.2,000/- ; from 5000 MTs to 10,000 MTs is Rs.5,000/-; from 10,000 MTs to 15,000 MTs is Rs.7500/-;<br />  from 15,000 MTs to 20,000 MTs is Rs.10,000/-; and if base quota exceeds 20,000 MTs it is Rs.5,000/- for every 10,000 MTs.  </td>
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
                                    <td>Stage 1 -- Concerned DPEO / AC(D) Hyd <br /> Stage 2 -- CPE </td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(20) days</td>
                                    
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">
                            <h4>PROCEDURE:-</h4>

                            <h5>Firm registration</h5>
                            <ol class="excise-para">
                                <li>Any person who is a producer of molasses and desires to posses and sell molasses shall make an application to the Commissioner for a license in that behalf. The application shall be accompanied by a challan evidencing payment of a fee of Rs.100/- for such application. The application shall contain the details prescribed in Rule 3 of Telangana Excise (Possession, Import, Export, Transport of Molasses Conditions of License and Permits) Rules, 2008. </li>
                                <li>On receipt of an application, the Commissioner may make such inquiries as he deems necessary and if he is satisfied that there is no objection to grant the license applied for, he may, grant the license, on payment of a fee as per the scale prescribed in the Rules. </li>

                            </ol>



                            <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                            <p class="excise-para">Documents required for grant of License: Proposal from concerned DC / DPEO / AC (Distilleries) while enclosing </p>
                            <ol>
                                <li>Report of concerned DO / P&EI </li>
                                <li>Representation of the applicant with affixing Rs.5 court fee stamp</li>
                                <li>Challan original for application fee and license fee</li>
                                <li>Check Memo</li>
                                <li>Declaration / Undertaking on Rs.100 NJS Paper</li>
                                <li>Last year license renewed copy</li>
                                <li>Stock particulars / Production / utilization details of the unit</li>

                            </ol>



                        </div>
                    </div>
                        </div>
                </div>
            </div>


            <div class="block black bg-white" id="GrantofM2Licence" runat="server" visible="false">

                <div class="content">
                    <!-- Firm registration -->
                    <div class="col-md-12 col-lg-12">
                        <table  class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Molasses utilisation license</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Application fee - Rs.100/- and license fee is as follows:  1) License fee is Rs.100/- for Govt. purpose, Educational, Scientific, Medicinal, sample purpose, <br />Agricultural purpose, cattle feed.  2) For other purposes: Rs.2,000/- for base quota upto 1000 MTs, Rs.4,000/- for base <br />quota from 1,000 MTs to 5,000 MTs, Rs.6,000/- for <br />base quota from 5,000 MTs to 10,000 MTs, Rs.8,000 for base quota from 10,000 MTs to 15,000 MTs, <br />Rs.10,000/- for base quota from 15,000 MTs to 20,000 MTs, For base quotas above 20,000 MTs, it is Rs.5,000/- for every 10,000 MTs or part thereof. </td>
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
                                      <td>Stage 1 -- Concerned DPEO / AC(D) Hyd <br /> Stage 2 -- CPE </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>20 Days</td>
                                  
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">
                            <h4>PROCEDURE:-</h4>

                            <h5>Firm registration</h5>
                            <ol class="excise-para">
                                <li>Any person other than a producer of molasses and desiring to posses and use molasses shall make an application to the Commissioner for a license in that behalf. The application shall be accompanied by a challan evidencing payment of a fee of Rs.100/- for such application. The application shall contain the details prescribed in Rule 4(1) of Telangana Excise (Possession, Import, Export, Transport of Molasses Conditions of License and Permits) Rules, 2008. </li>
                                <li>On receipt of an application, the Commissioner may make such enquiries as he deems necessary and if he is satisfied that there is no objection to grant the license applied for, he may, grant the license, on payment of a fee as prescribed in the Rules. </li>

                            </ol>



                            <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                            <p class="excise-para">Documents required for grant of License:Proposal from concerned DC / DPEO / AC (Distilleries) while enclosing </p>
                            <ol>
                                <li>Report of concerned DO / P&EI </li>
                                <li>Representation of the applicant with affixing Rs.5 court fee stamp</li>
                                <li>Challan original for application fee and license fee</li>
                                <li>Check Memo</li>
                                <li>Declaration / Undertaking on Rs.100 NJS Paper</li>
                                <li>Last year license renewed copy</li>
                                <li>Stock particulars / Production / utilization details of the unit</li>

                            </ol>



                        </div>
                    </div>

                    </div>
                </div>
            








            <div class="block black bg-white" id="GrantofM4Licence" runat="server" visible="false">
                <div class="content">
  <!-- Firm registration -->
                <div class="col-md-12 col-lg-12">
                    <table  class="excise-table">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th style="text-align: left;">SERVICE NAME</th>
                                <td colspan="2">Molasses Import License</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">License fee is Rs.100/- </td>
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
                                 <td>Stage 1 -- Concerned DPEO / AC(D) Hyd <br /> Stage 2 -- CPE </td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">TIME LINES</th>
                                <td>20 Days</td>
                              
                            </tr>
                        </tbody>
                    </table>

                    <div style="padding-top: 0;">
                        <h4>PROCEDURE:-</h4>

                        <h5>Firm registration</h5>
                        <ol class="excise-para">
                            <li>A holder of license in Forms M-I / M-II desiring to import molasses shall make an application to the Commissioner for a license in that behalf. The application shall contain the details prescribed in Rule 12 of Telangana Excise (Possession, Import, Export, Transport of Molasses Conditions of License and Permits) Rules, 2008.</li>
                            <li>On receipt of an application, the Commissioner may make such enquiries as he deems necessary and if he is satisfied that there is no objection to grant the license applied for, he may, grant the license, on payment of a fee of Rs.100/-.</li>

                        </ol>



                        <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                        <p>Proposal from concerned DC / DPEO / AC (Distilleries) while enclosing </p>
                        <ol>
                            <li>Report of concerned DO / P&EI </li>
                            <li>Representation of the applicant with affixing Rs.5 court fee stamp</li>
                            <li>Challan original for application fee and license fee</li>
							<li>Last year license renewed copy</li>
							<li>Stock particulars of the unit</li>
							

                        </ol>



                    </div>
                </div>	
                    </div>
                </div>



            <div class="block black bg-white" id="GrantofM5Licence" runat="server" visible="false">
    <div class="content" >
  <!-- Firm registration -->
                <div class="col-md-12 col-lg-12">
                    <table  class="excise-table">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <th style="text-align: left;">SERVICE NAME</th>
                                <td colspan="2">Molasses Export License</td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">SERVICE FEE</th>
                                <td colspan="2">License fee is Rs.1,00,000/- </td>
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
                               <td>Stage 1 -- Concerned DPEO / AC(D) Hyd <br /> Stage 2 -- CPE </td>
                            </tr>
                            <tr>
                                <th style="text-align: left;">TIME LINES</th>
                                <td>20 days</td>
                               
                            </tr>
                        </tbody>
                    </table>

                    <div style="padding-top: 0;">
                        <h4>PROCEDURE:-</h4>

                        <h5>Firm registration</h5>
                        <ol class="excise-para">
                            <li>Any person holding a license in Form M-I or any person who is bonafide user any where in India, desiring to export molasses shall make an application to the Commissioner for a license in that behalf. The application shall contain the details prescribed in Rule 14 of Telangana Excise (Possession, Import, Export, Transport of Molasses Conditions of License and Permits) Rules, 2008. </li>
                            <li>On receipt of an application, the Commissioner may make such inquiries as he deems necessary and if he is satisfied that there is no objection to grant the license applied for, he may, grant the license, on payment of a fee of Rs.1,00,000/- per annum. </li>

                        </ol>



                        <h4 style="margin-bottom: 0;">CHECK LIST :-</h4>

                        <p>Proposal from concerned DC / DPEO / AC (Distilleries) while enclosing </p>
                        <ol>
                            <li>Report of concerned DO / P&EI </li>
                            <li>Representation of the applicant with affixing Rs.5 court fee stamp</li>
                            <li>Challan original for application fee and license fee</li>
							<li>Last year license renewed copy</li>
							<li>Stock particulars of the unit</li>
							

                        </ol>



                    </div>
                </div>	
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				</div>
                </div>
            
				
				
				
				
				
				
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

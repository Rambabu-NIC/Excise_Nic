<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="RSandDs.aspx.cs" Inherits="ExciseAPI.RSandDs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">RS And DS Licenses</div>
             <div class="content">
                <div class="text-center">
                <div class="row">
                     <div class="col-md-5 col-sm-5" style="text-align: end;">
                            <label class="custom-label">Select Service :</label>
                        </div>
                        <div class="col-md-4 col-sm-6">
                            <asp:DropDownList ID="ddlRSDS" class="form-control" runat="server" OnSelectedIndexChanged="ddlRSDS_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Application for grant of License of ARS-III (Industrial Purpose)</asp:ListItem>
                                <asp:ListItem Value="2">Renewal of form RS-III Licence</asp:ListItem>
                                <asp:ListItem Value="3">Application for grant of License of ARS-II(B) (R&D)</asp:ListItem>
                                <asp:ListItem Value="4">Renewal of form RS-II(B) Licence</asp:ListItem>
                                <asp:ListItem Value="5">Application for grant of License of DS-XI (Industrial Purpose)</asp:ListItem>
                                <asp:ListItem Value="6">Renewal of form DS-XI Licence</asp:ListItem>
                                <asp:ListItem Value="7">Application for grant of License of DS-XI-A (OMC Purpose)</asp:ListItem>
                                <asp:ListItem Value="8">Renewal of form DS-XIA Licence</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
            </div>
            </div>
        </div>
            <div class="block black bg-white" id="divARsIII" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Possession and use of Absolute Alcohol/RS in the manufacture of industrial preparations</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Rs.5000/- (Rupees Five Thousand only)for base quota up to 1,00,000 BLs, thereafter Rs.5000/- (Rupees Five Thousand only) for every 1,00,000 BLs and<br /> Rs.5000/- (Rupees Five Thousand only) for every additional quota over and above the base quota in multiples of 1,00,000 BLs or part thereof</td>
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
                                    <td>Stage 1- EO (I)<br />Stage 2- ACDH<br />Stage -  CPE</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(20) days</td>
                                    
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">


                            <h5>LICENCE FOR POSSESSION AND USE OF RS by Medical, Scientific, Educational and
Research Institutions and Laboratories</h5>
                            <ul class="excise-para">
                                <li>The licensee shall be bound by the provisions of the Excise Act 1968.Rectified Spirit Rules 1971, the regulations and orders made there under and the Conditions of the licence.</li>
                                <li>The licensee shall not use RS for any purpose except for bona-fide medical, scientific, educational,research and laboratory purpose</li>
                                <li>The licensee shall obtain the supply of RS from the sources allotted by the Commissioner</li>
                                <li>The licensee shall not sell rectified spirit </li>
                                <li>The receptacles containing RS shall bear necessary labels showing the contents of RS with particulars of place of manufacture</li>
                                <li>Licensee shall keep the Rectified Spirit received by him in the licensed premises</li>
                                <li>Every consignment of Rectified Spirit received shall be opened in the presence of an Excise Officer not below the rank of a Sub Inspector</li>
                                <li>The licensee shall be bound to keep the daily accounts of the receipts and expenditure of Rectified Spirit in the form mentioned below which shall be produced whenever called for by any Excise Officer not below the rank of a Sub Inspector of Excise</li>
                            </ul>

                            <h5>Account of Ethanol received and used at the licensed premises situated at M/s Auro Vaccines
Pvt.Ltd., Sy.No.69/A, 70/AA2, 70/AA5, 70/AA6, 70/AA7, 71/A5, 72/A6, 72, Indrakaran (V), Sangareddy
(M&D), Telangana (8000 B.Ls of Rectified SpiritUEthanol/Absolute Alcohol per annum). </h5>
                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>Date</th>
                                        <th>Opening Balance</th>
                                        <th>Quantity received</th>
                                        <th>Source of supply number and date of quantity the letter of advice in<br />
                                            hand and route by which supply received.</th>
                                        <th>Total Quantity in Hand</th>
                                        <th>Quantity Used</th>
                                        <th>Purpose For Which Used</th>
                                        <th>Closing Balance</th>
                                        <th>Remarks</th>
                                    </tr>
                                    <tr>

                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>4</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>7</td>
                                        <td>8</td>
                                        <td>9</td>
                                    </tr>


                                </tbody>
                            </table>
                            <ul class="excise-para">
                                <li>The licensee shall pay annual licence fee as may be fixed by the Government from time to time for
grant of renewal of licence. </li>
                                <li>Any breach of the above conditions or such other conditions applicable to the license as laid down
the rules will render the licence liable to the penalties and criminal action under 
Excise Act 1968, as well as to the forfeiture of licence. </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="block black bg-white" id="divRSIII" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Renewal of form RS-III Licence</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Rs.5000/- (Rupees Five Thousand only) for base quota up to 1,00,000 BLs, thereafter Rs.5000/- (Rupees Five Thousand only) <br />for every 1,00,000 BLs and Rs.5000/- (Rupees Five Thousand only) for every additional quota over and above the base quota in multiples of 1,00,000 BLs or part thereof</td>
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
                                     <td>Stage 1- EO (I)<br />Stage 2- ACDH<br />Stage -  CPE</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(20)Days</td>
                                   
                                </tr>
                            </tbody>
                        </table>
                        <div id="RS" style="display: block;">
                            <table class="excise-table">
                                <tr>
                                    <th>Sl. No.</th>
                                    <th>Name of the preparation permitted to be manufactured</th>
                                    <th>Kind of alcohol permitted to be used in the
                                        <br />
                                        manufacture of commodity mentioned in column (2)</th>
                                    <th>REMARKS.</th>
                                </tr>
                                <tr>
                                    <td>1.</td>
                                    <td>2</td>
                                    <td>3</td>
                                    <td>4</td>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>Itraconazole Pellets Drug</td>
                                    <td>Ethanol/Absolute Alcohol</td>
                                    <td>64,050 B.Ls per annum on adhoc basis</td>
                                </tr>
                            </table>
                        </div>
                        <div class="clearfix"></div>
                        <div style="padding-top: 0;">
                            <ol class="excise-para" type="1">
                                <li>The licensee shall be bound by the provisions of Telangana State Excise Act, 1968, the Telangana State RS. Rules, 1971 and other regulations and orders made there under and conditions to this license
                                </li>
                                <li>The Privilege conferred by the license extends to the possession and use of Alcohol in the manufacture of preparation of the commodities specified above. The licensee is prohibited from selling Alcohol obtained under the license. No commodity other than those specified in the license shall be manufactured without the approval of the licensing authority and before name of the commodity is included in the license. Nor shall the spirit put to any use other than that indicated in

                                    the licence
                                </li>
                                <li>The licensee shall pay license fee as fixed by the Government from time to time</li>
                                <li>The licensee shall obtain his supply of Rectified Spirit from any of the following sources:
                                        <ol type="a">
                                            <li>Distillery in the State, or</li>
                                            <li>sources outside the State by import, or</li>
                                            <li>Such other sources as the Commissioner may in special cases determine or approve subject to such terms and conditions as he may impose in that regard. The supplies shall be obtained duly in accordance with the provisions of these rules.</li>
                                        </ol>
                                </li>
                                <li>The quantity of Alcohol possessed at any one time and that used and consumed under the license in a month and during the year or period for which the license is current shall not exceed the quantities enter below-

                                </li>
                                <table class="excise-table">
                                    <tr>
                                        <th>Kind of Spirit</th>
                                        <th>Quantity that may be possessed at any one time (in Bulk liters)</th>
                                        <th>Quantity that may be used in a month for<br />
                                            manufacturing purpose (in bulk liters)</th>
                                        <th>In a year or the period of current year of licence for manufacturing
                                            <br />
                                            purpose in Bulk Liters</th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>4</td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Ethanol/AA/RS</td>
                                        <td>21,350 B.Ls per month</td>
                                        <td>21,350 B.LS per month</td>
                                        <td>64,050 B.Ls per annum on adhoc basis</td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>

                                <li class="excise-para">(a)(A) "The licensee shall use the Alcohol in the manufacture or preparation of the commodities specified above as per the norms prescribed by the following authority.

                                        <br>
                                    Any excess quantity of Alcohol used in the said manufacture or preparation of the commodities over and above the norms fixed by the licensing authority shall be indemnified in full by payment up-to five (5) times of the cost of the spint and with such other penalty as the Commissioner of Prohibition and
                                        
                                        Excise may decide for all categories of licenses to which the spirits are used"
                                </li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="block black bg-white" id="divARSIIB" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Possession and use of RS for Research & Development purposes</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">- </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">Rs.2000/-</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>3</td>
                                    
                                </tr>
                                <tr>
                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>Stage 1- EO (I)<br />Stage 2- ACDH<br />Stage -  CPE</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(20)Days</td>
                                    
                                </tr>
                            </tbody>
                        </table>
                        <div style="padding-top: 0;">
                            <h5>LICENCE FOR POSSESSION AND USE OF DENATURED SPIRIT IN
MANUFACTURE OF SURGICAL SPIRIT AND HYDROZEN PEROXIDE FOR
INDUSTRIAL PURPOSE AS RE-AGENTS OR SOLVENT ETC. </h5>



                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>SI.No</th>
                                        <th>Name of the Commodity permitted to be manufactured</th>
                                        <th>Kind of Denatured Spirit / Methylated Spirit/Methyl Alcohol<br />
                                            permitted to be to be used in the manufacture of commodity mentioned in col. No.2 and the name of the Denaturant</th>
                                        <th>Remarks</th>
                                    </tr>
                                    <tr>

                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>4</td>
                                    </tr>
                                    <tr>

                                        <td>1</td>
                                        <td>GCLE (7-(phenylacetamido-3 )(Chloromethyl )(Cephalosporanic Acid )<br />
                                            (methoxybenzylester)</td>
                                        <td>Denatured Spirit with admixture of 1% Benzene </td>
                                        <td></td>
                                    </tr>

                                </tbody>
                            </table>

                            <h5>1. The License shall be bound by the provisions of the Andhra Pradesh Excise Act, 1968,
The Andhra Pradesh Denatured Spirit and Denatured Spirituous Preparations Rules,
1971 and other regulations and other made there under and the conditions of this
license. </h5>

                            <h5>2. The privilege confered by this license extends to the possession use of the Denatured
Spirit/Methylated Spirit/Methyl alcohol in the manufacture of preparation of the
Commodities specified above. The Licensee is prohibited from selling denatured Spirit/
Methylated Spirit/Methyl Alcohol obtained under the Licence. No commodity of the
licensing authority and before the name of the commodity is included in the licence. No
shall the spirit put to any other use other than those indicated in the licence. </h5>

                            <h5>3. The licensee shall obtain his supply of denatured spirit/methylated spirit/methyl alcohol
from any of the following sources: </h5>
                            <ul class="excise-para">
                                <li>(a)A distillery in the State : </li>
                                <li>(b)From the holder of a licence Form D.S-VI :or</li>
                                <li>(C)Source outside the State by import: or</li>
                                <li>Such others sources as the Commissioner may in special cases appoint or
approve subject to such terms and conditions as he may impose in that regard.
The supplied shall be obtained only in accordance with the provisions of the
rules. </li>
                            </ul>
                            <h5>4.The quantity of the denatured spirit/methylated spirit/methyl alcohol possed at any one
time and that used and consumed under the licence shall not exceed 25% of the
quantity allowed for the year</h5>



                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>Kind of spirit </th>
                                        <th>Quantity that may be used a year of the period of Currency of licence for manufacturing purpose</th>

                                    </tr>
                                    <tr>

                                        <td>1</td>
                                        <td>2</td>

                                    </tr>
                                    <tr>

                                        <td>Denatured Spirit,Methylated Spirit,Methly Alcohol</td>
                                        <td>Denatured Spirit with admixture of 1% Benzene 5,43,300 B.Ls per annum on adhoc basis. </td>

                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="block black bg-white" id="divRSIIB" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Renewal of form RS-II(B) Licence</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Rs.2000/-</td>
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
                                    <td>Stage 1- EO (I)<br />Stage 2- ACDH<br />Stage -  CPE</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(20)Days</td>
                                   
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">

                            <p class="excise-para">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Prohibition & Excise Department - T.S. Denatured Spirit & Denature Spirituous Preparations Rules 1971-DSXI-A 
                            Licence of M/s Indian Oil Corporation Limited, Sy.No:120, Malkapur Village, Chouttuppal Mandal, Yadadri Bhuvanagiri
                             District, Telangana State - 508252, for the year -06- 2024-Το 31-03-2027-Reg
                            </p>

                            <p class="excise-para">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.Representatiol M/s Indian Oll Corporation Limited, Sy.No:120, Malkapur Village, Chouttuppal&nbsp;Mandal, 
                                Yadadri Bhuvanagiri District, Telangana State - 508252 Lr.dt. 22.05.2024
                            </p>

                            <p class="excise-para">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2.G.O.Rt. No. 207, Rev(Ex.II) Dept., dt. 15-07-2019 </p>

                            <p class="excise-para">
                                <center><u>DSXI-A LICENSE FOR THREE YEARS FROM 04-06-2024 TO 31-03-2027</u></center>
                            </p>

                            <p class="excise-para">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The DSXI-A Licence held by M/s Indian Oil Corporation Limited, Sy.No:120, Malkapur Village, Chouttuppal Mandal, Yadadri Bhuvanagiri District, 
                                Telangana State - 508252, is hereby for (3) years 2024-2025, 2025-2026, and 2026-2027 ie, from 04-06-2024 To 31-03-2027.
                            </p>


                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th style="text-align: left;">Sl.No</th>
                                        <th colspan="2">Name of Terminal and Address</th>
                                        <th>Annual quota of Ethanol</th>
                                        <th>Base quota for three years</th>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td colspan="2">M/s Indian Oil Corporation Limited, Sy.No:120, Malkapur Village,
                                                 Chouttuppal Mandal, Yadadri Bhuvanagiri District, Telangana State - 508252
                                        </td>
                                        <td colspan="">1,44,000 KL</td>
                                        <td colspan="">4,32,000 KL</td>
                                    </tr>

                                </tbody>
                            </table>


                        </div>

                    </div>
                </div>
            </div>

    <div class="block black bg-white" id="divDSXI" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Possession and use of Denatured Spirit in manufacture of surgical spirit and hydrozen peroxide for industrial purpose as re-agents or solvent etc</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Rs.5000/- (Rupees Five Thousand only)
for base quota up to 1,00,000 BLs, thereafter Rs.5000/- (Rupees Five Thousand only) <br />for every 1,00,000 BLs and Rs.5000/- (Rupees Five Thousand only) for every additional quota over and above the base quota in multiples of 1,00,000 BLs or part thereof</td>
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
                                    <td>Stage 1- EO (I)<br />Stage 2- ACDH<br />Stage -  CPE</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(20) days</td>
                                    
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">


                            <h5>LICENCE FOR POSSESSION AND USE OF RS by Medical, Scientific, Educational and
Research Institutions and Laboratories</h5>
                            <ul class="excise-para">
                                <li>The licensee shall be bound by the provisions of the Excise Act 1968.Rectified Spirit Rules 1971, the regulations and orders made there under and the Conditions of the licence.</li>
                                <li>The licensee shall not use RS for any purpose except for bona-fide medical, scientific, educational,research and laboratory purpose</li>
                                <li>The licensee shall obtain the supply of RS from the sources allotted by the Commissioner</li>
                                <li>The licensee shall not sell rectified spirit </li>
                                <li>The receptacles containing RS shall bear necessary labels showing the contents of RS with particulars of place of manufacture</li>
                                <li>Licensee shall keep the Rectified Spirit received by him in the licensed premises</li>
                                <li>Every consignment of Rectified Spirit received shall be opened in the presence of an Excise Officer not below the rank of a Sub Inspector</li>
                                <li>The licensee shall be bound to keep the daily accounts of the receipts and expenditure of Rectified Spirit in the form mentioned below which shall be produced whenever called for by any Excise Officer not below the rank of a Sub Inspector of Excise</li>
                            </ul>

                            <h5>Account of Ethanol received and used at the licensed premises situated at M/s Auro Vaccines
Pvt.Ltd., Sy.No.69/A, 70/AA2, 70/AA5, 70/AA6, 70/AA7, 71/A5, 72/A6, 72, Indrakaran (V), Sangareddy
(M&D), Telangana (8000 B.Ls of Rectified SpiritUEthanol/Absolute Alcohol per annum). </h5>
                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>Date</th>
                                        <th>Opening Balance</th>
                                        <th>Quantity received</th>
                                        <th>Source of supply number and date of quantity the letter of advice in<br />
                                            hand and route by which supply received.</th>
                                        <th>Total Quantity in Hand</th>
                                        <th>Quantity Used</th>
                                        <th>Purpose For Which Used</th>
                                        <th>Closing Balance</th>
                                        <th>Remarks</th>
                                    </tr>
                                    <tr>

                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>4</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>7</td>
                                        <td>8</td>
                                        <td>9</td>
                                    </tr>


                                </tbody>
                            </table>
                            <ul class="excise-para">
                                <li>The licensee shall pay annual licence fee as may be fixed by the Government from time to time for
grant of renewal of licence. </li>
                                <li>Any breach of the above conditions or such other conditions applicable to the license as laid down
the rules will render the licence liable to the penalties and criminal action under 
Excise Act 1968, as well as to the forfeiture of licence. </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>


    <div class="block black bg-white" id="divDSXILicence" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Renewal of form DS-XI Licence</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">Rs.5000/- (Rupees Five Thousand only) 
for base quota up to 1,00,000 BLs, thereafter Rs.5000/- (Rupees Five Thousand only) <br />for every 1,00,000 BLs and Rs.5000/- (Rupees Five Thousand only) for every additional quota over and above the base quota in multiples of 1,00,000 BLs or part thereof</td>
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
                                    <td>Stage 1- EO (I)<br />Stage 2- ACDH<br />Stage -  CPE</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(20) days</td>
                                    
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">


                            <h5>LICENCE FOR POSSESSION AND USE OF RS by Medical, Scientific, Educational and
Research Institutions and Laboratories</h5>
                            <ul class="excise-para">
                                <li>The licensee shall be bound by the provisions of the Excise Act 1968.Rectified Spirit Rules 1971, the regulations and orders made there under and the Conditions of the licence.</li>
                                <li>The licensee shall not use RS for any purpose except for bona-fide medical, scientific, educational,research and laboratory purpose</li>
                                <li>The licensee shall obtain the supply of RS from the sources allotted by the Commissioner</li>
                                <li>The licensee shall not sell rectified spirit </li>
                                <li>The receptacles containing RS shall bear necessary labels showing the contents of RS with particulars of place of manufacture</li>
                                <li>Licensee shall keep the Rectified Spirit received by him in the licensed premises</li>
                                <li>Every consignment of Rectified Spirit received shall be opened in the presence of an Excise Officer not below the rank of a Sub Inspector</li>
                                <li>The licensee shall be bound to keep the daily accounts of the receipts and expenditure of Rectified Spirit in the form mentioned below which shall be produced whenever called for by any Excise Officer not below the rank of a Sub Inspector of Excise</li>
                            </ul>

                            <h5>Account of Ethanol received and used at the licensed premises situated at M/s Auro Vaccines
Pvt.Ltd., Sy.No.69/A, 70/AA2, 70/AA5, 70/AA6, 70/AA7, 71/A5, 72/A6, 72, Indrakaran (V), Sangareddy
(M&D), Telangana (8000 B.Ls of Rectified SpiritUEthanol/Absolute Alcohol per annum). </h5>
                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>Date</th>
                                        <th>Opening Balance</th>
                                        <th>Quantity received</th>
                                        <th>Source of supply number and date of quantity the letter of advice in<br />
                                            hand and route by which supply received.</th>
                                        <th>Total Quantity in Hand</th>
                                        <th>Quantity Used</th>
                                        <th>Purpose For Which Used</th>
                                        <th>Closing Balance</th>
                                        <th>Remarks</th>
                                    </tr>
                                    <tr>

                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>4</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>7</td>
                                        <td>8</td>
                                        <td>9</td>
                                    </tr>


                                </tbody>
                            </table>
                            <ul class="excise-para">
                                <li>The licensee shall pay annual licence fee as may be fixed by the Government from time to time for
grant of renewal of licence. </li>
                                <li>Any breach of the above conditions or such other conditions applicable to the license as laid down
the rules will render the licence liable to the penalties and criminal action under 
Excise Act 1968, as well as to the forfeiture of licence. </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

    <div class="block black bg-white" id="div1" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Possession and use of denatured Ethanol for doing with petrol by the oil Companies in respect of one terminal </td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">D.S.XI-A license for a period of 3 years on payment of proportionate licence fee @ the present rate i.e., Rs.45,000/- for each terminal</tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>1</td>
                                    
                                </tr>
                                <tr>
                                   


                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>Stage-1 CPE</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(07) Days</td>
                                    
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">


                            <h5>LICENCE FOR POSSESSION AND USE OF RS by Medical, Scientific, Educational and
Research Institutions and Laboratories</h5>
                            <ul class="excise-para">
                                <li>The licensee shall be bound by the provisions of the Excise Act 1968.Rectified Spirit Rules 1971, the regulations and orders made there under and the Conditions of the licence.</li>
                                <li>The licensee shall not use RS for any purpose except for bona-fide medical, scientific, educational,research and laboratory purpose</li>
                                <li>The licensee shall obtain the supply of RS from the sources allotted by the Commissioner</li>
                                <li>The licensee shall not sell rectified spirit </li>
                                <li>The receptacles containing RS shall bear necessary labels showing the contents of RS with particulars of place of manufacture</li>
                                <li>Licensee shall keep the Rectified Spirit received by him in the licensed premises</li>
                                <li>Every consignment of Rectified Spirit received shall be opened in the presence of an Excise Officer not below the rank of a Sub Inspector</li>
                                <li>The licensee shall be bound to keep the daily accounts of the receipts and expenditure of Rectified Spirit in the form mentioned below which shall be produced whenever called for by any Excise Officer not below the rank of a Sub Inspector of Excise</li>
                            </ul>

                            <h5>Account of Ethanol received and used at the licensed premises situated at M/s Auro Vaccines
Pvt.Ltd., Sy.No.69/A, 70/AA2, 70/AA5, 70/AA6, 70/AA7, 71/A5, 72/A6, 72, Indrakaran (V), Sangareddy
(M&D), Telangana (8000 B.Ls of Rectified SpiritUEthanol/Absolute Alcohol per annum). </h5>
                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>Date</th>
                                        <th>Opening Balance</th>
                                        <th>Quantity received</th>
                                        <th>Source of supply number and date of quantity the letter of advice in<br />
                                            hand and route by which supply received.</th>
                                        <th>Total Quantity in Hand</th>
                                        <th>Quantity Used</th>
                                        <th>Purpose For Which Used</th>
                                        <th>Closing Balance</th>
                                        <th>Remarks</th>
                                    </tr>
                                    <tr>

                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>4</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>7</td>
                                        <td>8</td>
                                        <td>9</td>
                                    </tr>


                                </tbody>
                            </table>
                            <ul class="excise-para">
                                <li>The licensee shall pay annual licence fee as may be fixed by the Government from time to time for
grant of renewal of licence. </li>
                                <li>Any breach of the above conditions or such other conditions applicable to the license as laid down
the rules will render the licence liable to the penalties and criminal action under 
Excise Act 1968, as well as to the forfeiture of licence. </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

    <div class="block black bg-white" id="divDSXIALicence" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <th style="text-align: left;">SERVICE NAME</th>
                                    <td colspan="2">Renewal of form DS-XIA Licence</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SERVICE FEE</th>
                                    <td colspan="2">D.S.XI-A license for a period of 3 years on payment of proportionate licence fee @ the present rate i.e., Rs.45,000/- for each terminal</tr>
                                <tr>
                                    <th style="text-align: left;">USER CHARGES</th>
                                    <td colspan="2">0</td>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">STAGES</th>
                                    <td>1</td>
                                    
                                </tr>
                                <tr>
                                   


                                    <th style="text-align: left;">ALLOTED OFFICIALS</th>
                                    <td>Stage-1 CPE</td>
                                   
                                </tr>
                                <tr>
                                    <th style="text-align: left;">TIME LINES</th>
                                    <td>(07) Days</td>
                                    
                                </tr>
                            </tbody>
                        </table>

                        <div style="padding-top: 0;">


                            <h5>LICENCE FOR POSSESSION AND USE OF RS by Medical, Scientific, Educational and
Research Institutions and Laboratories</h5>
                            <ul class="excise-para">
                                <li>The licensee shall be bound by the provisions of the Excise Act 1968.Rectified Spirit Rules 1971, the regulations and orders made there under and the Conditions of the licence.</li>
                                <li>The licensee shall not use RS for any purpose except for bona-fide medical, scientific, educational,research and laboratory purpose</li>
                                <li>The licensee shall obtain the supply of RS from the sources allotted by the Commissioner</li>
                                <li>The licensee shall not sell rectified spirit </li>
                                <li>The receptacles containing RS shall bear necessary labels showing the contents of RS with particulars of place of manufacture</li>
                                <li>Licensee shall keep the Rectified Spirit received by him in the licensed premises</li>
                                <li>Every consignment of Rectified Spirit received shall be opened in the presence of an Excise Officer not below the rank of a Sub Inspector</li>
                                <li>The licensee shall be bound to keep the daily accounts of the receipts and expenditure of Rectified Spirit in the form mentioned below which shall be produced whenever called for by any Excise Officer not below the rank of a Sub Inspector of Excise</li>
                            </ul>

                            <h5>Account of Ethanol received and used at the licensed premises situated at M/s Auro Vaccines
Pvt.Ltd., Sy.No.69/A, 70/AA2, 70/AA5, 70/AA6, 70/AA7, 71/A5, 72/A6, 72, Indrakaran (V), Sangareddy
(M&D), Telangana (8000 B.Ls of Rectified SpiritUEthanol/Absolute Alcohol per annum). </h5>
                            <table class="excise-table">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>Date</th>
                                        <th>Opening Balance</th>
                                        <th>Quantity received</th>
                                        <th>Source of supply number and date of quantity the letter of advice in<br />
                                            hand and route by which supply received.</th>
                                        <th>Total Quantity in Hand</th>
                                        <th>Quantity Used</th>
                                        <th>Purpose For Which Used</th>
                                        <th>Closing Balance</th>
                                        <th>Remarks</th>
                                    </tr>
                                    <tr>

                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>4</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>7</td>
                                        <td>8</td>
                                        <td>9</td>
                                    </tr>


                                </tbody>
                            </table>
                            <ul class="excise-para">
                                <li>The licensee shall pay annual licence fee as may be fixed by the Government from time to time for
grant of renewal of licence. </li>
                                <li>Any breach of the above conditions or such other conditions applicable to the license as laid down
the rules will render the licence liable to the penalties and criminal action under 
Excise Act 1968, as well as to the forfeiture of licence. </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

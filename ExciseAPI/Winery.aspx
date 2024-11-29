<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Winery.aspx.cs" Inherits="ExciseAPI.Winery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Winery</div>
            <div class="content">
                <div class="text-center">
                <div class="row">
                     <div class="col-md-5 col-sm-5" style="text-align: end;">
                            <label class="custom-label">Winery Service :</label>
                        </div>
                    <div class="col-md-4 col-sm-6">
                        <asp:DropDownList ID="ddl_winery" class="form-control" runat="server" OnSelectedIndexChanged="ddl_winery_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                             <asp:ListItem Value="1">Application for LOI (Wine) in Form-W1</asp:ListItem>
                            <asp:ListItem Value="2">Application for Licence (Winery)</asp:ListItem>
                            <asp:ListItem Value="3">Renewal forms</asp:ListItem>
                           <%-- <asp:ListItem Value="4">Application For Transfer Of Licence</asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>

                </div>
            </div>
                </div>
            </div>
        </div>
             <div class="block black bg-white" id="GrantofLOI" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                        <table class="excise-table">
                          <thead>
                          </thead>
                          <tbody>
                              <tr>
                                  <th style="text-align: left;">SERVICE NAME</th>
                                  <td colspan="2">Grant of Letter of Intent for establishment of any new winery</td>
                              </tr>
                              <tr>
                                  <th style="text-align: left;">SERVICE FEE</th>
                                  <td colspan="2">Rs.25,000/-</td>
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
                                  <td>Stage 1 -- AC(D)<br />Stage 2 -- CPE<br />Stage 3 - Govt.</td>
                                
                              </tr>
                              <tr>
                                  <th style="text-align: left;">TIME LINES</th>
                                  <td>No Time Lines Policy matter</td>
                                  
                              </tr>
                          </tbody>
                      </table>
                         <div style="padding-top: 0;">
                             

                          <ol class="excise-para" type="1">
                              <li> 
                                <ol type="a">
                                    <li>Name and address:</li>
                                    <li>Name and address of the undertaking:</li>
                                    <li>Whether Public/Private Ltd., or Partnership Proprietary concern:</li>
                                </ol>
                            </li>
                            <br/>
                              <li>Location where the applicant intends to establish the Winery</b></li><br>
                          <li>Whether the applicant owns sufficient land at the proposed site: If so the details thereof </li>
                          
                            <ol type="a">
                                <li>Challan No. & date in support of payment of fee as required under Rule 4(2)(a):</li>
                                <li>Whether original Challan is enclosed to this application: </li>
                            </ol>
                        <br/>

                          <li>Proposed Investment Details</li>
                        
                            <ol type="a">
                                <li> Capital investment</li>
                                <li>Borrowings</li>
                                <li>Investment on Land</li>
                                <li>Investment on Buildings</li>
                                <li>Investment on Plant and Machinery</li>
                                <li>Working Capital</li>
                              </ol><br>
                          
                          <li>Whether sufficient water is available at the proposed place</li><br/>
                          
                          <li>A Whether proper power supply is available at proposed place to meet the requirements of the  unit:</li><br/>

                          <li>Details of the Raw Materials</li>
                          <ol type="a">
                            <li>Quantity and value of raw materials to be imported or of imported origin per year</li>
                            <li> Quantity and value of raw materials of indigenous origin per year</li>
                            <li>Quantity of Spirit required for fortification purpose per year:</li>
                        </ol>
                        <br/>
                        <li>Whether the applicant is able to secure the raw material as stated in Col. No.7 without the and of the Government:</li><br/>

                        <li>Whether the plant and machinery to be installed is of imported or indigenous and its details:</li><br/>

                        <li>Details of the Wines proposed to be Manufactured:</li>
                        
                        <ol type="a">
                            <li> Name(s) of the wine proposed to manufactured:</li>
                            <li> Standards of the product(s) proposed to manufacture:</li>
                            <li>Brief process of manufacture:</li>
                        </ol>
                        <br/>

                        <li>Estimated annual production of wine in proof litres:</li><br>

                        <li>Whether the proposed unit will have any buyback arrangement? If so the details thereof:</li>

                        <li>
                            <ol type="a">
                                <li> Time required to secure land:</li>
                                <li>Time required for erecting plant and machinery:</li>
                            </ol> 
                        </li>
                        <br/>
                        <li>Employment potential of the proposed unit: (Indicate category-wise)</li>
                          </ol>

                          
                      </div>
                        </div>
                    </div>
                 </div>
            <div class="block black bg-white" id="GrantofLicence" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                         <table class="excise-table">
                          <thead>
                          </thead>
                          <tbody>
                              <tr>
                                  <th style="text-align: left;">SERVICE NAME</th>
                                  <td colspan="2">Grant of new License in form W1</td>
                              </tr>
                              <tr>
                                  <th style="text-align: left;">SERVICE FEE</th>
                                  <td colspan="2">Rs.4,000/-</td>
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
                                  <td>Stage 1 -- AC(D)<br />Stage 2 - CPE</td>
                                 
                              </tr>
                              <tr>
                                  <th style="text-align: left;">TIME LINES</th>
                                  <td>No Time Lines</td>
                                 
                              </tr>
                          </tbody>
                      </table>
  
                      <div style="padding-top: 0;">

                          <h4>PROCEDURE:-</h4>

                          <ol class="excise-para" type="1">
                              <li>The holder of letter of intent shall obtain licence from the Commissioner 
                                within six months from the date of sanction of the Government in the form of Letter of Intent referred to in rule 4(2)(b).
                            </li>
                              <br/>
                              <li>The holder of letter of intent shall apply in Form-W(1) (A) and the application shall be accompanied by:</li>
                            
                          <ol type="a">

                            <li>Copy of the sanction (Letter of Intent) accorded by the Government.</li>
                            <li>Description and plans for the construction of the proposed manufactory.</li>
                            <li>Statement of plant and machinery proposed to be erected.</li>
                            <li>'No Objection Certificate' from the local body competent to issue.</li>
                            <li>'No Objection Certificate' from the competent authority under Factories Act, 1948. </li>
                            <li>Clearance Certificate from the Andhra Pradesh Pollution Control Board. </li>
                            <li>An undertaking in the prescribed form on a non-judicial stamp paper of the requisite
                                 value as per the Indian Stamp Act binding himself that he shall erect the plant and machinery 
                                as per the standards, as may be prescribed by the 
                                Commissioner from time to time for maintaining the specifications and quality of products.</li>
                            <li>Counterpart agreement in Form-W(C).</li>

                          </ol>
                              <br/>

                          <li>No licence shall be granted unless the applicant deposits Rs.10,000/- (Rupees ten thousand only) in 
                            the shape of a cash deposit or fixed deposit receipt or Bank guarantee from any scheduled bank situated in 
                            Andhra Pradesh as a security for fulfillment of all the conditions of licence and enter into a counterpart agreement in Form-W(C).</li>
                          
                          <li>
                            <ol type="a">
                                <li>Where the Commissioner is satisfied that the applicant manufactory has fulfilled the conditions specified 
                                    in sub-rules (1) to (3) above, he may grant a licence to the applicant in Form-W2.</li>
                                <li>The license fee for a new manufactory shall be Rs.2000/- per annum till the commencement of production or 
                                    expiry of two years period from the issue of letter of intent whichever is earlier.</li>
                              </ol><br>
                          </li>
                          <li>The licensee shall before expiry of two years from the date of grant of letter of intent report to the Commissioner, 
                            the date on which the construction or expansion of manufactory is completed and the date from which its working is commenced.</li><br>
                          
                          <li>In case the licensee fails to construct and work the manufactory before expiry of two years 
                            from the date of grant of letter of intent, the licence sanctioned under Sub-rule (4)(a) shall be liable for cancellation without 
                            compensation for any damage or loss.</li>
                          </ol>

                          
                      </div>
                    </div>
                </div>
            </div>
            <div class="block black bg-white" id="RenewalofLicence" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                         <table class="excise-table">
                          <thead>
                          </thead>
                          <tbody>
                              <tr>
                                  <th style="text-align: left;">SERVICE NAME</th>
                                  <td colspan="2">Renewal of W1 license</td>
                              </tr>
                              <tr>
                                  <th style="text-align: left;">SERVICE FEE</th>
                                  <td colspan="2">Rs.4,000/-</td>
                              </tr>
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
                                  <td>Stage 1 -- AC(D)<br />Stage 2 - CPE</td>
                                 
                              </tr>
                              <tr>
                                  <th style="text-align: left;">TIME LINES</th>
                                  <td>No Time Lines</td>
                                  
                              </tr>
                          </tbody>
                      </table>

                          <div style="padding-top: 0;">
                         
                        <ol class="excise-para" type="1">
                            <li>Licence granted under these rules shall come into effect from such date as specified therein</li>
                            <li>Licence shall ordinarily be for a period of one year.</li>
                            <li>The licensee shall get his licence renewed before the commencement of the Licence year, by paying the licence fee as prescribed in rule 6 otherwise he is neither eligible to go into production nor permitted to transact any business.</li>
                            <li> If the licensee fails to apply for renewal by paying the specified fee before the commencement of the licence year, he shall pay the licence fee along with late fee at 10% of the annual licence fee for renewal of his licence.</li>
                            <li>Every application for renewal of licence under these rules shall bear a court fee stamp of requisite value as specified in the Indian Stamp Act and shall be addressed to the Commissioner.</li>
                            <li>Where the Commissioner is satisfied that the licensee has fulfilled the conditions specified for renewal and that the manufacturing facilities on ground are not modified in any manner in deviation of the provisions of previous licence, he may renew the licence.</li>
                            <li>The grant of licensee to get his licence renewal stands forfieted if the license is not renewed continuously for a period of 3 years.</li>
                        </ol><br>
                        
                           <h5>Excise Duty:</h5>
                        <ol class="excise-para" type="a">
                            <li>The Excise duty shall be paid at such rates as may be specified by the Government.</li>
                            <li>The licensee shall execute an agreement binding himself, his heirs, legal representatives and assignees to observe the conditions of licence, hypothecating the buildings, machinery, apparatus together with the stock as security for the payment of money, which may be due to the Government.</li>

                        </ol><br>

  
  
                      </div>
                    </div>
                </div>
            </div>
            <div class="block black bg-white" id="TransferofLicence" runat="server" visible="false">
                <div class="content">
                    <div class="col-md-12 col-lg-12">
                         <table  class="excise-table">
                          <thead>
                          </thead>
                          <tbody>
                              <tr>
                                  <th style="text-align: left;">SERVICE NAME</th>
                                  <td colspan="2">Transfer of license of winery.</td>
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
                         

                        <h4>Change or alteration of licence</h4><br>
                        <ol class="excise-para" type="1">
                            <li> Transfer of Licence:</li>
                            <ol type="i">
                            <li> No licensee shall except with the sanction of the Commissioner transfer his license to any other person. The Commissioner may allow such transfer of license on payment of prescribed fee and on production of certificate to the effect that no cases involving contravention of Excise Act and Rules framed there under are pending against him and also on production of Sales Tax and Income Tax clearance certificates.</li>

                            <li>When there are only two partners in the firm holding the licence and one of them withdraws or expires the entity of firm changes from partnership to proprietary and it amounts to transfer of licence.</li>
                            <li>Conversion of a proprietary concern into a firm or a company or a firm into a company and vice versa shall amount to transfer of licence.</li>
                            <li>The Commissioner on payment of the prescribed fee and on obtaining such undertaking or Bond and such other material or documents to protect the interest of the Government as he may deem fit, may grant such permission for the transfer of the licence.</li>
                            <li>Where there is a change of 50% or more partners, it shall be construed as complete change in the ownership, a fee amounting to 10% of the licence fee shall be paid.</li>
                        </ol><br>
                            <h4> 2.Inclusion or exclusion of partners:</h4>
                            <p>No licensee shall except prior permission of the licensing authority get any person included as a partner to his business or get an existing partner excluded.</p>


                            <h4>3. Death of licensee or incapability of the licensee:</h4>
                            <p>A licence issued under these rules shall be only to the person named therein and on his death the legal heirs may apply for continuance of the licence in their name to the Commissioner within thirty days of death of the licensee. If the Commissioner is satisfied he may permit the legal heirs to continue the licence in the name of such legal heirs.

                            </p>
                            

                        
                    </ol>
                          
   
  
  
                         
  
  
                      </div>
                    </div>
                </div>
            </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

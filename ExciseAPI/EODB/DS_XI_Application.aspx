<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="DS_XI_Application.aspx.cs" Inherits="ExciseAPI.EODB.DS_XI_Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <main id="main" class="main">
            <section class="section">
                <div class="row">
                    <div class="col-lg-12">

                        <div class="card">
                            <div class="card-body">
                                <center><h5 class="card-title"></center>

                                <div class="">
                                    <center><h2 style="color:#012970;"> DS APPLICATION FORM</h2>
                    <p> </p></center>
                                </div>
                                <br>
                                <div class="reference-date">
                                    <!-- <input type="text" class="form-control" id="reference" placeholder="reference number" style="width: 200px;"> -->

                                    <div class="reference-date" style="display: flex; justify-content: space-between;">
                                        <div class="row">
                                        </div>
                                        <input type="date" class="form-control" id="date" style="width: 200px;">
                                    </div>
                                    <br>
                                </div>

                                <div class="content">
                                    <form>
                                        <div class="form-group row">
                                            <label for="to" class="col-sm-6 col-form-label">
                                                <strong>The Commissioner of Prohibition & Excise
                               <br>
                                                    Govt of Telangana State
                               <br>
                                                    Hyderabad
                                                </strong>
                                            </label>
                                        </div>
                                        <br>


                                        <p><strong>Respected Sir,</strong></p>
                                        <p>
                                            <strong>Sub:</strong> Excise-Submission of renewal proposals-DS-XI license for the year
    <select class="form-control form-control-sm d-inline w-auto" id="year">
        <option value="2024-25">2023-24</option>
        <option value="2025-26">2024-25</option>
        <option value="2026-27">2025-26</option>
        <option value="2027-28">2026-27</option>
        Request
        <!-- Add more years as needed -->
    </select>
                                            - reg
                                        </p>

                                        <p>
                                            <strong>Ref.:</strong> DS-XI License no. Cr. No.
    <input type="text" class="form-control form-control-sm d-inline w-auto" id="licenseNumber" placeholder="">
                                            dated
                                            <input type="date" class="form-control form-control-sm d-inline w-auto" id="challanDate1">
                                        </p>


                                        <br>
                                        <p>
                                            We are here with submitting DS-XI license renewal proposals for the year 
                                <select class="form-control form-control-sm d-inline w-auto" id="year">
                                    <option value="2024-25">2023-24</option>
                                    <option value="2025-26">2024-25</option>
                                    <option value="2026-27">2025-26</option>
                                    <option value="2027-28">2026-27</option>
                                    <!-- Add more years as needed -->
                                </select>
                                            <!-- (ie. from
                                 <input type="date" class="form-control form-control-sm d-inline w-auto" id="challanDate1">
                                to 
                                <input type="date" class="form-control form-control-sm d-inline w-auto" id="challanDate1">
                                ) along with the following documents for your favorable consideration. -->
                                            with the following documents.
                                        </p>
                                        <br>
                                        <ol>
                                            <li>Application in the form DS-XI duly filled and affixing with court stamp Rs.5/-</li>

                                            <li>Check memo</li>
                                            <li>Original Challan  for Rs.<input type="number" class="form-control form-control-sm d-inline w-auto" id="challanNo1" placeholder="">
                                                remitted Vide 
                                   Challan number
                                                <input type="text" class="form-control form-control-sm d-inline w-auto" id="challanDate1">
                                                dated
                                    <input type="date" class="form-control form-control-sm d-inline w-auto" id="amount1" placeholder="">/- towards license fee at SBI , Bhongiri branch, Hyderabad.
                                            </li>
                                            <li>Copy of Ds-XI license issued by the prohibition & Excise of Hyderabad, Telangana,(Original RS-III license
                                                <input type="text" class="form-control form-control-sm d-inline w-auto" id="challanNo2" placeholder="">
                                                dated 
                                    <input type="date" class="form-control form-control-sm d-inline w-auto" id="challanDate2">
                                            </li>
                                            <li>Counterpart Agreement on non-judicial stamp paper worth Rs.
                                    <input type="number" class="form-control form-control-sm d-inline w-auto" id="stampPaperValue" placeholder="" min="0" step="1">/- 
                                            </li>
                                            <li>Performance certificate issued by the Excise officer in-charge of the unit.
                                            </li>
                                            <li>Utilization certificate duly attested by the Excise officer.
                                
                                            </li>
                                            <li>Inspection report of the unit by the Excise officer.
                                
                                            </li>
                                            <li>Drug License copy.
                                
                                            </li>
                                            <li>Authorization Certificate.
                                
                                            </li>
                                            <li>List of the Director(Proprietary Concern).
                                            </li>
                                            <li>Reconciliation of remitted challans.
                                            </li>



                                        </ol>
                                        <br>

                                        <p>
                                            In view of the above we request you sir, to kindly renew our DS-XI license for the year 
                                <select class="form-control form-control-sm d-inline w-auto" id="renewalYear">
                                    <option value="2024-25">2024-25</option>
                                    <option value="2025-26">2025-26</option>
                                    <option value="2026-27">2026-27</option>
                                    <option value="2027-28">2027-28</option>
                                    <!-- Add more years as needed -->
                                </select>
                                            at the earliest.
                               <br>

                                            <p><strong>Thanking you</strong></p>
                                            <input type="text" class="form-control form-control-sm d-inline w-auto" id="quota" placeholder="">


                                            <center> <div class="submit-button">
                            <button type="submit" class="btn btn-primary">Submit</button></center>
                                </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </main>
    </div>
</asp:Content>

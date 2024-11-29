<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EOB.Master" CodeBehind="Molasses_M4.aspx.cs" Inherits="ExciseAPI.EODB.Molasses_M4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">

        <section class="section">
            <div class="row">
                <div class="col-lg-12">

                    <div class="card">

                        <div class="card-body">
                            <h5 class="card-title">
                                <center>Molasses_M4</center>
                            </h5>
                            <br>
                            <form>
                                <div class="form-group row mb-3">
                                    <label for="applicant_full_details" class="col-sm-4 col-form-label">Name of the Applicant:</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" name="enter the name " placeholder="" id="">
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="undertaking_details" class="col-sm-4 col-form-label">Address of the Applicant:</label>
                                    <!-- <div class="col-sm-8">
                                  <textarea class="form-control" name="undertaking_details" placeholder="" id="undertaking_details"></textarea>
                              </div> -->
                                    <div class="form-section" id="applicantAddressSection">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="houseNo">House No.</label>
                                                    <input type="text" class="form-control" id="houseNo">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="street">Road/Street/Locality</label>
                                                    <input type="text" class="form-control" id="street">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="city">District</label>
                                                    <input type="text" class="form-control" id="city">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="mandal">Mandal/Municipality</label>
                                                    <input type="text" class="form-control" id="mandal">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="district">City/Town/Village</label>
                                                    <input type="text" class="form-control" id="district">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="pinCode">PIN Code</label>
                                                    <input type="text" class="form-control" id="pinCode">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="concern_type" class="col-sm-4 col-form-label">Molasses held by the applicant :</label>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="undertaking_details" class="col-sm-4 col-form-label">Number:</label>
                                    <div class="col-sm-8">
                                        <input type="number" class="form-control col-sm" name="number" placeholder="Enter no" id="distillery_location">
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="undertaking_details" class="col-sm-4 col-form-label">Date:</label>
                                    <!-- <div class="col-sm-8">
                                    <textarea class="form-control" name="undertaking_details" placeholder="Full Residential Address" id="undertaking_details"></textarea>
                                </div> -->
                                    &nbsp;&nbsp;<input type="date" class="form-control col-sm" id="challanDate2">
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="sanction_details" class="col-sm-4 col-form-label">Quantity of molasses permitted for possession at any one time under the licence held by him (in- Quintals) </label>
                                    &nbsp;&nbsp;<input type="number" class="form-control col-sm " name="Quintals" placeholder="Quintals">
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="sanction_details" class="col-sm-4 col-form-label">Balance of Molasses permitted for possession at any one time under the licence held by him (in- Quintals)</label>
                                    &nbsp;&nbsp;<input type="number" class="form-control col-sm" name="Quintals" placeholder="Quintals">
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="sanction_details" class="col-sm-4 col-form-label">Quantity of molasses to be imported-(in Quintals)</label>
                                    &nbsp;&nbsp;<input type="number" class="form-control col-sm" name="Quintals" placeholder="Quintals">
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="other_licence_details" class="col-sm-4 col-form-label">Place from which molasses to be imported :</label>
                                    <div class="col-sm-8">
                                        <textarea class="form-control" name="other_licence_details" placeholder="" id="other_licence_details"></textarea>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="applicant_full_details" class="col-sm-4 col-form-label">Name of the Applicant:</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" name="distillery_location" placeholder="" id="enter the name">
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="undertaking_details" class="col-sm-4 col-form-label">Address of the Applicant:</label><br>
                                    <br>
                                    <!-- <div class="col-sm-8">
                                  <textarea class="form-control" name="undertaking_details" placeholder="" id="undertaking_details"></textarea>
                              </div> -->
                                    <div class="form-section" id="applicantAddressSection">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="houseNo">House No.</label>
                                                    <input type="text" class="form-control" id="houseNo">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="street">Road/Street/Locality</label>
                                                    <input type="text" class="form-control" id="street">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="city">District</label>
                                                    <input type="text" class="form-control" id="city">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="mandal">Mandal/Municipality</label>
                                                    <input type="text" class="form-control" id="mandal">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="district">City/Town/Village</label>
                                                    <input type="text" class="form-control" id="district">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="pinCode">PIN Code</label>
                                                    <input type="text" class="form-control" id="pinCode">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="challan_details" class="col-sm-4 col-form-label">Route( State the place from which removal of molasses to its destination will be by road in the state ) :</label>
                                    <div class="col-sm-8">
                                        <br>
                                        <textarea class="form-control" name="challan_details" placeholder="" id=""></textarea>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="undertaking_details" class="col-sm-4 col-form-label">Period for which the licence is required:</label>
                                    <div class="col-sm-8">
                                        <textarea class="form-control" name="undertaking_details" placeholder="" id="undertaking_details"></textarea>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="undertaking_details" class="col-sm-4 col-form-label">Reasons for importing molasses:</label>
                                    <div class="col-sm-8">
                                        <textarea class="form-control" name="undertaking_details" placeholder="" id="undertaking_details"></textarea>
                                    </div>
                                </div>

                                <div class="form-group row mb-3">
                                    <label for="applicantSignature" class="col-sm-4 col-form-label">Amount:</label>
                                    <div class="col-sm-8">
                                        <input type="number" class="form-control" id="applicantSignature" placeholder="">
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="applicantSignature" class="col-sm-4 col-form-label">Challan No:</label>
                                    <div class="col-sm-8">
                                        <input type="number" class="form-control" id="applicantSignature" placeholder="">
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="applicantSignature" class="col-sm-4 col-form-label">Challan Date:</label>
                                    <div class="col-sm-8">
                                        <input type="date" class="form-control col-sm" id="challanDate2">
                                    </div>
                                </div>
                                <br>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-12 text-center">
                                        <button type="submit" class="btn btn-primary">Submit</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>









                <%--<div class="card-body">
                        <center><h5 class="card-title"></center>
                <div class="">
                    <center><h3>APPLICATION FORM</h3>
                    <p></p></center>
                </div><br><br>
                <div class="reference-date">
                    <!-- <input type="text" class="form-control" id="reference" placeholder="reference number" style="width: 200px;"> -->
                    
                    <div class="reference-date" style="display: flex; justify-content: space-between;">
                        <input type="text" class="form-control" id="reference" placeholder="referenceNumber" style="width: 200px;">
                        <input type="date" class="form-control" id="date" style="width: 200px;">
                    </div>
                    <br>
                    
                </div>
                <div class="content">
                    <form>
                        <div class="form-group row">
                            <label for="to" class="col-sm-6 col-form-label"><strong>To,<br> The Commissioner of Prohibition & Excise
                               <br> Telangana State
                               <br><br>
                            </strong></label>
                            <!-- <div class="col-sm-10">
                                <textarea class="form-control" id="to" rows="3" placeholder="Commissioner of Prohibition & Excise, Government of Telangana State, Abkari Bhavan, M.J Rd, Nampally, Hyderabad, Telangana - 500001"></textarea>
                            </div> -->
                        </div>
                        <div class="form-group row">
                          <label for="through" class="col-sm-2 col-form-label"><strong>Through:</strong></label>
                          <div class="col-sm-10">
                              <textarea class="form-control" id="through" rows="3"
                                  placeholder=""></textarea>
                          </div>
                      </div><br>

                      <div class="form-group row mb-3">
                        <label class="col-sm-4 col-form-label"><b>Whether individual applicant or company?</b></label>
                        <div class="col-sm-8">
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="bar_or_standalone" id="bar" value="Bar">
                                <label class="form-check-label" for="bar">individual applicant</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="bar_or_standalone" id="standalone" value="Standalone">
                                <label class="form-check-label" for="standalone">company</label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group row mb-3">
                      <label for="inputText" class="col-sm-6 col-form-label">1.  (a)Name of the applicant/company:</label>
                      <div class="col-sm-6">
                      <textarea class="form-control" name="applicant_full_details" placeholder="Full Name" id="applicant_full_details"></textarea>
                  </div>
                </div>
                   <div class="form-group row mb-3">
                                        <label for="inputText" class="col-sm-6 col-form-label">(b)Address of the applicant/company:</label>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="houseNo">House No.</label>
                                                    <input type="text" class="form-control" id="houseNo">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="street">Road/Street/Locality</label>
                                                    <input type="text" class="form-control" id="street">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="city">City/Town/Village</label>
                                                    <input type="text" class="form-control" id="city">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="mandal">Mandal/Municipality</label>
                                                    <input type="text" class="form-control" id="mandal">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="district">District</label>
                                                    <input type="text" class="form-control" id="district">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="pinCode">PIN Code</label>
                                                    <input type="text" class="form-control" id="pinCode">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                </div>
                        <p><strong>Dear Sir,</strong></p>
                        <p>
    <strong>Sub:</strong>Request for Renewal of "M-IV" License for the year
    <select class="form-control form-control-sm d-inline w-auto" id="year">
        <option value="2024-25">2024-25</option>
        <option value="2025-26">2025-26</option>
        <option value="2026-27">2026-27</option>
        <option value="2027-28">2027-28</option>
        <!-- Add more years as needed -->
    </select> 
    - Submission of
    Application - Reg.. 
    
</p>

<p>
    <strong>Ref: 1) D-2(RMGO) License Cr.No.</strong> 
    <input type="text" class="form-control form-control-sm d-inline w-auto" id="licenseCrNo1" placeholder=""> 
    <strong>Dated:</strong>
    <input type="date" class="form-control form-control-sm d-inline w-auto" id="licenseDate1">
    <strong>for the year</strong> 
    <select class="form-control form-control-sm d-inline w-auto" id="licenseYear1">
        <option value="2024-25">2024-25</option>
        <option value="2025-26">2025-26</option>
        <option value="2026-27">2026-27</option>
        <!-- Add more years as needed -->
    </select>
</p>
<p>
    <strong>2) M-II License Cr No: M-II NO:</strong> 
    <input type="text" class="form-control form-control-sm d-inline w-auto" id="licenseCrNo2" placeholder=""> 
    <strong>Dt:</strong>
    <input type="date" class="form-control form-control-sm d-inline w-auto" id="licenseDate2">
</p>
<p>
    <strong>3) M-IV License Cr.No:</strong> 
    <input type="text" class="form-control form-control-sm d-inline w-auto" id="licenseCrNo3" placeholder=""> 
    <strong>Dt:</strong>
    <input type="date" class="form-control form-control-sm d-inline w-auto" id="licenseDate3">
    <strong>for the year</strong> 
    <select class="form-control form-control-sm d-inline w-auto" id="licenseYear3">
        <option value="2023-24">2023-24</option>
        <option value="2024-25">2024-25</option>
        <option value="2025-26">2025-26</option>
        <!-- Add more years as needed -->
    </select>
</p>
                        <br>
                        <p>
                            We invite your kind attention to the subject cited above, we would like to inform
                            you that we are planning to lift the molasses from <br>
                            <div class="col-sm-12">
                              <div class="col-sm-10">
                                <textarea class="form-control" id="through" rows="3"
                                    placeholder=""></textarea>
                            </div>
                          </div>respectively. 
                            In this connection, we are here with submitting the M-IV license renewal Application form for the year 
                            <select class="form-control form-control-sm d-inline w-auto" id="licenseRenewalYear">
                                <option value="2024-25">2024-25</option>
                                <option value="2025-26">2025-26</option>
                                <option value="2026-27">2026-27</option>
                                <option value="2027-28">2027-28</option>
                                <!-- Add more years as needed -->
                            </select> 
                            along with process fee challan.
                        </p>
                        
                            <ol>
                                <li>Application in the prescribed proforma.</li>
                                <li>
                                    Application Fee paid vide Challan No <input type="text" class="form-control form-control-sm d-inline w-auto" id="challanNo1" placeholder=""> date
                                    <input type="date" class="form-control form-control-sm d-inline w-auto" id="challanDate1"> for Rs.
                                    <input type="number" class="form-control form-control-sm d-inline w-auto" id="amount1" placeholder="" min="0" step="1">/-
                                </li>
                                <!-- <p>Xerox copy of the "D2 (RMGO)" License for the Year <span class="year">2024-2025</span></p> -->

                                <!-- <li>
                                    General declaration/undertaking on a non-judicial stamp paper worth Rs.
                                    <input type="number" class="form-control form-control-sm d-inline w-auto" id="stampPaperValue" placeholder="100" min="0" step="1">/- in the prescribed proforma.
                                </li> -->
                                <li>
                                    Xerox copy of the "D2 (RMGO)" License for the Year 
                                    <select class="form-control form-control-sm d-inline w-auto" id="licenseYear">
                                        <option value="2023-24">2023-24</option>
                                        <option value="2024-25">2024-25</option>
                                        <option value="2025-26">2025-26</option>
                                        <!-- Add more years as needed -->
                                    </select>
                                </li>
                                <li>
                                    Xerox copy of M-1 license for the year 
                                    <select class="form-control form-control-sm d-inline w-auto" id="licenseYear">
                                        <option value="2023-24">2023-24</option>
                                        <option value="2024-25">2024-25</option>
                                        <option value="2025-26">2025-26</option>
                                        <!-- Add more years as needed -->
                                    </select>
                                </li>
                                
                            </ol><br>
                            
                            <p>
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;We request the Hon'ble Commissioner of Prohibition & Excise, Telangana Hyderabad to kindly arrange to issue/renew our "M-IV License".
                            </p><br>
                            
                        <p><strong>Thanking you</strong></p>     
                            <div class="form-group row">
                              <div class="col-sm-4">
                                <label for="signatory" class="col-form-label"><strong>Your's Faithfully</strong></label><br>
                                <input type="text" class="form-control form-control-sm d-inline w-auto" id="quota" placeholder=""><br><br><br>
                                  
                                  
                        
                        
                          
                    
                </div>
            </div>
            <div class="text-center-btn">
              <center> <button type="submit" class="btn btn-primary">Submit</button></center>
            </form>
            </div>
        </div>--%>
            </div>
            <%--</div>
            </div>--%>
        </section>
    </main>
</asp:Content>



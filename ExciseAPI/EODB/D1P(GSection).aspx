<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="D1P(GSection).aspx.cs" Inherits="ExciseAPI.EODB.D1P_GSection_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">


        <section class="section">
            <div class="row">
                <div class="col-lg-12">

                    <div class="card" style="margin-bottom: 20px; background-color: #f0f8ff; padding: 20px; border-radius: 8px;">
                        <div class="card-body">
                            <h5 class="card-title text-center"><b><u>FORM D1_P</u></b></h5>
                            <br />

                            <div class="content">
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label for="notification_number" class="col-sm-6 col-form-label">Notification Number:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox class="form-control custom-rounded" ID="txtNotify_no" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row mb-3">
                                <div class="col-sm-6 d-flex align-items-center">
                                    <label for="applicant_name" class="col-sm-6 col-form-label">Firm Type:</label>

                                    <div class="col-sm-6 custom-rounded">
                                        <asp:DropDownList class="form-control" ID="ddlFirmType" runat="server">
                                            <asp:ListItem Value="">select</asp:ListItem>
                                            <asp:ListItem Value="1">individual</asp:ListItem>
                                            <asp:ListItem Value="2">Firm</asp:ListItem>
                                            <asp:ListItem Value="3">Partnership</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6 d-flex align-items-center">
                                    <label for="notification_number" class="col-sm-6 col-form-label">Profession Name:</label>
                                    <div class="col-sm-6 custom-rounded">
                                        <asp:DropDownList class="form-control" ID="ddlProfession" runat="server">
                                            <asp:ListItem Value="">select</asp:ListItem>
                                            <asp:ListItem Value="1">Director</asp:ListItem>
                                            <asp:ListItem Value="2">Managing Director</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row mb-3">
                                <div class="col-sm-6 d-flex align-items-center">
                                    <label for="applicant_name" class="col-sm-6 col-form-label">Name of the Applicant / Firm name: </label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtapplicantname" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6 d-flex align-items-center">
                                    <label for="applicant_name" class="col-sm-6 col-form-label">ROC Number(If company): </label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtRocNumber" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="form-section" id="divapplicantAddressSection" runat="server">
                                <h6><b>Applicant/ Firm Details:</b></h6>
                                <br />
                                <div class="row mb-3">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="houseNo">Mobile No.</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtMobile" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="street">PAN No.</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtPan" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="district">Aadhar Number:</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtAadhar" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="mandal">GST-IN:</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtGst" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="city">Email:</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtEmail" runat="server"></asp:TextBox>

                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="form-section" id="applicantAddressDetails" runat="server">
                                <h6><b>Address Details:</b></h6>
                                <br />
                                <div class="row mb-3">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="houseNo">House No.</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtPHouseNo" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="street">Street and Landmark:</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtPStreet" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="district">District</label>
                                            <asp:DropDownList ID="ddlPDistrict" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="mandal">Mandal</label>
                                            <asp:DropDownList ID="ddlPMandal" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="city">Village</label>
                                            <asp:DropDownList ID="ddlPVillage" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="pinCode">PIN Code</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtPPinCode" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group row mb-3">
                                <label for="undertaking_details" class="col-sm-6 col-form-label" style="width: 400px;">Name of the Undertaking:</b></label>
                                <div class="col-sm-6">
                                    <asp:TextBox class="form-control custom-rounded" ID="txtUndertaking" runat="server"></asp:TextBox>

                                </div>
                            </div>
                            <br />


                            <div class="form-group row mb-3">
                                <label for="undertaking_details" class="col-sm-6 col-form-label" style="width: 400px;"><b>Address of the Undertaking:</b></label>
                                <div class="col-sm-6">
                                    <div class="form-check">
                                        <asp:CheckBox ID="CheckBox1" runat="server" />

                                        <label class="form-check-label" for="swimming">Same as the Above Address:</label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-section" id="applicantAddress" runat="server">
                                <div class="row mb-3">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="houseNo">House No.</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtHouseNo" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="street">Street and Landmark:</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtStreet" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="district">District</label>
                                            <asp:DropDownList ID="ddlDistrict" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="mandal">Mandal</label>
                                            <asp:DropDownList ID="ddlMandal" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="city">Village</label>
                                            <asp:DropDownList ID="ddlVillage" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="pinCode">PIN Code</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtPincode" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>


                            <br />

                            <div class="form-section" id="applicantAddressSection" runat="server">
                                <h6><b>Location where the applicant intends to establish the Distillery:</b></h6>
                                <br />
                                <div class="row mb-3">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="district">District</label>
                                            <asp:DropDownList ID="ddlEDistrict" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="mandal">Mandal</label>
                                            <asp:DropDownList ID="ddlEMandal" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="city">Village</label>
                                            <asp:DropDownList ID="ddlEVillage" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="pinCode">Survey No.</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtSurveyNo" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="pinCode">Extent.</label>
                                            <asp:TextBox class="form-control custom-rounded" ID="txtExtent" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group row mb-3">
                                <label for="manufacture_of_spirits" class="col-sm-6 col-form-label"><b>Nature of the manufacture:</b></label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlManufacture" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>

                                </div>
                            </div>


                            <ul>

                                <div class="form-group row mb-3">
                                    <label for="distillery_location" class="col-sm-6 col-form-label">
                                        Whether it is the manufacture of spirits from grains as fermentative 
                                      base:</label>
                                    <div class="col-sm-6">
                                        <div class="radio-group">
                                            <label class="mr-3">
                                                <asp:RadioButtonList ID="rblSpirits" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </label>
                                        </div>
                                    </div>
                                    <!-- <input type="text" class="form-control custom-rounded" name="distillery_location"  id="distillery_location"> -->
                                    <div class="col-sm-6">
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label for="distillery_location" class="col-sm-6 col-form-label">Mention the name of the fermentative base ?</b></label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtFermentative" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <label class="col-sm-6 col-form-label">Whether it is manufacture of Malt Spirit?</label>
                                    <div class="col-sm-6">
                                        <div class="radio-group">
                                            <label class="mr-3">
                                                <asp:RadioButtonList ID="rblMalt" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </label>

                                        </div>
                                    </div>
                                </div>


                                <div class="form-group row mb-3">
                                    <label for="distillery_location" class="col-sm-6 col-form-label">Whether it is the expansion of existing distillery?</label>
                                    <div class="col-sm-6">
                                        <div class="radio-group">
                                            <asp:RadioButtonList ID="rblDistillery" runat="server">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>


                                        </div>
                                    </div>
                                </div>
                            </ul>



                            <ul>
                                <div class="form-group row mb-3">
                                    <label for="existing_license" class="col-sm-6 col-form-label">Existing License held by the applicant:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtExistingLicense" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group row mb-3">
                                    <label for="nature_of_activity" class="col-sm-6 col-form-label">Nature of activity:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtnature_of_activity" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group row mb-3">
                                    <label for="existing_production_capacity" class="col-sm-6 col-form-label">Existing production capacity:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtexisting_production_capacity" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group row mb-3">
                                    <label for="proposed_production_capacity" class="col-sm-6 col-form-label">Production capacity proposed to be increased:</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtproposed_production_capacity" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </ul>
                            </ul>
                              
                                <div class="form-group">
                                    <label for="investment_details">Investment Details:</label><br>
                                    <br>
                                    <ul>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <label for="capital_investment">Capital Investment:</label>
                                                <asp:TextBox class="form-control custom-rounded" ID="txtcapital_investment" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-4">
                                                <label>Borrowings:</label>
                                                <asp:TextBox class="form-control custom-rounded" ID="txtborrowings" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-4">
                                                <label for="investment_land">Investment on Land:</label>
                                                <asp:TextBox class="form-control custom-rounded" ID="txtinvestment_land" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <label for="investment_building">Investment on Building:</label>
                                                <asp:TextBox class="form-control custom-rounded" ID="txtinvestment_building" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-4">
                                                <label for="investment_machinery">Investment on Plant and Machinery:</label>
                                                <asp:TextBox class="form-control custom-rounded" ID="txtinvestment_machinery" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-4">
                                                <label for="working_capital">Working Capital:</label>
                                                <asp:TextBox class="form-control custom-rounded" ID="txtworking_capital" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                    </ul>
                                </div>
                            <br />

                            <div class="form-group row">
                                <label for="sufficient_water" class="col-sm-4 col-form-label">Whether sufficient water is available at the proposed place:</label><br>
                                <br>
                                <div class="col-sm-8">
                                    <div class="radio-group">

                                        <asp:RadioButtonList ID="rblsufficient_water" runat="server">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="form-group row">
                                <label for="power_supply" class="col-sm-4 col-form-label">Whether the proper power supply is available at proposed place to meet the requirements of the unit:</label>
                                <div class="col-sm-8">
                                    <div class="radio-group">

                                        <asp:RadioButtonList ID="rblpower_supply" runat="server">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <br />


                            <div class="form-group row mb-3">
                                <label for="sanction_details" class="col-sm-6 col-form-label ">Details of the raw materials:</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList class="form-control" ID="ddlfermentative_base" runat="server">
                                        <asp:ListItem Value="">---select---</asp:ListItem>
                                        <asp:ListItem Value="1">Molasses as fermentative base</asp:ListItem>
                                        <asp:ListItem Value="2">Grains as fermentation base</asp:ListItem>
                                        <asp:ListItem Value="3">Both Molasses and Grains</asp:ListItem>
                                        <asp:ListItem Value="4">other fermentative base</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <ul>
                                <div class="form-group row mb-3">
                                    <label for="fermentative_name" class="col-sm-6 col-form-label">Mention the name of the fermentative base as main raw material :</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtfermentative_name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </ul>

                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="challan_details">Whether the applicant is able to secure the raw material stated in Col.No.9 without the aid of the government:</label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="radio-group">

                                        <asp:RadioButtonList ID="rblsecuretherawmaterial" runat="server">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="form-group row">
                                <label for="power_supply" class="col-sm-4 col-form-label">Whether the plant and machinery to be installed is of imported or indigenous:</label>
                                <div class="col-sm-8">
                                    <div class="radio-group">

                                        <asp:RadioButtonList ID="rblimportedorindigenous" runat="server">
                                            <asp:ListItem Value="1">imported</asp:ListItem>
                                            <asp:ListItem Value="2">indigenous</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>


                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label>Details of the Spirits proposed to be manufactured:</label>
                                    </div>
                                </div>

                            </div>
                            <br />



                            <ul>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="spirits_names">Name(s) of the spirits proposed to be manufactured:</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <asp:TextBox class="form-control custom-rounded" ID="txtsprit_name" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br>

                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="standards">
                                                Standards of the 
                                                                                  product(s) proposed to
                                                                                  manufacture:</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <asp:TextBox class="form-control custom-rounded" ID="txtstandards" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="manufacture_process">
                                                Brief process of 
                                                                                 manufacture:</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <asp:TextBox class="form-control custom-rounded" ID="txtmanufacture_process" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <br />
                            </ul>

                            <div class="form-group row mb-3">
                                <label class="col-sm-6 col-form-label">Whether the proposed plant requires any technical assistance/know how many from any foriegn collaboration:</label>
                                <div class="col-sm-6">
                                    <div class="radio-group">

                                        <asp:RadioButtonList ID="rbforiegncollab" runat="server">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>

                                </div>
                            </div>



                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>If So, the foreign exchange involved:</label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtforeignexchange" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <br>



                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>Estimated annual production of spirit(s):</label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtEstimatedAprod" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br>

                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>
                                            Whether the proposed unit will have any buyback arrangement?
                                        </label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="radio-group">
                                        <asp:RadioButtonList ID="rblbuybackarrange" runat="server">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <br>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>If so, the foreign exchange involved:</label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtforeignexchangeinvolved" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="land_investment">Time required to secure land:</label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtsecureland" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <br>

                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="building_investment">Time required for erecting plant and machinery:</label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtplantandmechinery" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <br>


                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label for="machinery_investment">Employment potential of the proposed unit:</label>
                                    </div>
                                </div>
                            </div>
                            <br>

                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="working_capital">Supervisory Staff: </label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtsupervisorystaff" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <br>


                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="working_capital">Skilled Workers: </label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtskilledworkers" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br>

                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="working_capital">Un-skilled workers: </label>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:TextBox class="form-control custom-rounded" ID="txtunskilledworkers" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>Any special facilities required from the Government:</label>

                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="radio-group">
                                        <asp:RadioButtonList ID="rblspecialfacilties" runat="server">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br>
                            <h4><b>Enclosures:</b></h4>
                            <div class="form-group row mb-3">
                                <label for="distillery_location" class="col-sm-6 col-form-label">PAN card:</b></label>
                                <div class="col-sm-3">
                                    <asp:TextBox class="form-control custom-rounded" ID="txtEpancard" runat="server"></asp:TextBox>
                                </div>
                            </div>


                            <div class="form-group row mb-3">
                                <label for="distillery_location" class="col-sm-6 col-form-label">Aadhar Card:</b></label>
                                <div class="col-sm-3">
                                    <asp:TextBox class="form-control custom-rounded" ID="Textbox1" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row mb-3">
                            <label for="distillery_location" class="col-sm-6 col-form-label">Proof of the Land:</b></label>
                            <div class="col-sm-3">
                                <input type="file" class="form-control custom-rounded" name="distillery_location" id="distillery_location">
                            </div>
                        </div>

                        <div class="form-group row mb-3">
                            <label for="distillery_location" class="col-sm-6 col-form-label">Distillery process Doc:</b></label>
                            <div class="col-sm-3">
                                <input type="file" class="form-control custom-rounded" name="distillery_location" id="distillery_location">
                            </div>
                        </div>

                        <div class="form-group row mb-3">
                            <label for="distillery_location" class="col-sm-6 col-form-label">Partnership deed(If the select partnership in firm type):</b></label>
                            <div class="col-sm-3">
                                <input type="file" class="form-control custom-rounded" name="distillery_location" id="distillery_location">
                            </div>
                        </div>

                        <div class="form-group row mb-3">
                            <label for="distillery_location" class="col-sm-6 col-form-label">ROC (Registration of Company):</b></label>
                            <div class="col-sm-3">
                                <input type="file" class="form-control custom-rounded" name="distillery_location" id="distillery_location">
                            </div>
                        </div>

                        <div class="form-group row mb-3">
                            <label for="distillery_location" class="col-sm-6 col-form-label">Sanction/Permission from Govt.of India:</b></label>
                            <div class="col-sm-3">
                                <input type="file" class="form-control custom-rounded" name="distillery_location" id="distillery_location">
                            </div>
                        </div>
                        <br />
                        <div class="content col-lg-12 text-center" align="center">
                            <asp:Button ID="btnd1p" Text="Submit" runat="server" CssClass="btn btn-primary" OnClick="btnd1p_Click" />
                            <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                        </div>


                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>





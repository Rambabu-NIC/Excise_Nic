<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="D1R(GSection).aspx.cs" Inherits="ExciseAPI.EODB.D1R_GSection_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .section {
            padding: 2rem 0;
        }

        .card-title {
            font-size: 1.5rem;
            font-weight: bold;
        }

        .form-group label {
            font-weight: 600;
        }

        .form-group h6 {
            font-weight: bold;
            margin-top: 1rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="section">
        <div class="pagetitle text-center">
            <h1>D1-R</h1>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="col-md-12">
                                <div class="pagetitle">
                                    <h1>Personal Details</h1>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Notification Number:</label>

                                        <asp:TextBox ID="txtNotify_no" class="form-control" runat="server"></asp:TextBox>
                                    </div>


                                    <div class="col-md-4 form-group">
                                        <label for="name">Firm Type:</label>

                                        <asp:DropDownList class="form-control" ID="ddlFirmType" runat="server">
                                            <asp:ListItem Value="">select</asp:ListItem>
                                            <asp:ListItem Value="0">individual</asp:ListItem>
                                            <asp:ListItem Value="1">Firm</asp:ListItem>
                                            <asp:ListItem Value="2">Partnership</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Profession Name:</label>

                                        <asp:DropDownList class="form-control" ID="ddlProfession" runat="server">
                                            <asp:ListItem Value="">select</asp:ListItem>
                                            <asp:ListItem Value="1">Director</asp:ListItem>
                                            <asp:ListItem Value="2">Managing Director</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Name of the Applicant / Firm name:</label>

                                        <asp:TextBox class="form-control" ID="txtapplicantname" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">ROC Number(If company):</label>

                                        <asp:TextBox class="form-control" ID="txtRocNumber" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="pagetitle">
                                        <h1>Applicant/Company Details:</h1>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Mobile No:</label>

                                        <asp:TextBox class="form-control" ID="txtMobile" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">PAN No:</label>

                                        <asp:TextBox class="form-control" ID="txtPan" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Aadhar Number:</label>

                                        <asp:TextBox class="form-control" ID="txtAadhar" runat="server"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="col-md-12 row">


                                    <div class="col-md-4 form-group">
                                        <label for="name">GST-IN:</label>

                                        <asp:TextBox class="form-control" ID="txtGst" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="city">Email:</label>
                                        <asp:TextBox class="form-control" ID="txtEmail" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-section" id="Div2" runat="server">
                                <div class="pagetitle ">
                                    <h1>Address of the Applicant:</h1>
                                </div>

                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">House No:</label>

                                        <asp:TextBox class="form-control" ID="txtPHouseNo" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Road No:</label>

                                        <asp:TextBox class="form-control" ID="txtPRoad" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">District:</label>

                                        <asp:DropDownList class="form-control" ID="ddlPDistrict" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Mandal:</label>

                                    <asp:DropDownList class="form-control" ID="ddlPMandal" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Village:</label>

                                    <asp:DropDownList class="form-control" ID="ddlPVillage" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">PIN Code:</label>

                                    <asp:TextBox class="form-control" ID="txtPPinCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Name of the Undertaking:</label>

                                    <asp:TextBox class="form-control" ID="txtUndertaking" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="pagetitle">
                                <h1>Address of the Undertaking:</h1>
                            </div>
                            <br />
                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">

                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <label>Same as the Above Address:</label>
                                </div>
                            </div>
                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">House No:</label>

                                    <asp:TextBox class="form-control" ID="txtHouseNo" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Road No:</label>

                                    <asp:TextBox class="form-control" ID="txtRoadNo" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">District:</label>

                                    <asp:DropDownList class="form-control" ID="ddlDistrict" runat="server">
                                    </asp:DropDownList>
                                </div>


                            </div>

                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Mandal:</label>

                                    <asp:DropDownList class="form-control" ID="ddlMandal" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Village:</label>

                                    <asp:DropDownList class="form-control" ID="ddlVillage" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">PIN Code:</label>

                                    <asp:TextBox class="form-control" ID="txtPincode" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Full details of the sanction/permission obtained from the Government of India:</label>

                                    <asp:TextBox class="form-control" ID="txtsanction_details" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="pagetitle">
                                <h1>Location where the applicant intends to establish the Distillery:</h1>
                            </div>
                            <br />
                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">District:</label>

                                    <asp:DropDownList class="form-control" ID="ddlEDistrict" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Mandal:</label>

                                    <asp:DropDownList class="form-control" ID="ddlEMandal" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Village:</label>

                                    <asp:DropDownList class="form-control" ID="ddlEVillage" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Survey No:</label>

                                    <asp:TextBox class="form-control" ID="txtSurveyNo" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Extent:</label>

                                    <asp:TextBox class="form-control" ID="txtExtent" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Nature of the manufacture:</label>


                                    <asp:DropDownList class="form-control" ID="ddlManufacture" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">
                                        Whether it is the expansion of existing distillery:</label>

                                    <asp:RadioButtonList ID="rblSpirits" class="form-check-input" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                        <asp:ListItem Value="1">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Existing License Number held by the applicant:</label>

                                    <asp:TextBox class="form-control" ID="txtELicenseNo" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Nature of activity:</label>


                                    <asp:TextBox class="form-control" ID="txt_Nature_Activity" runat="server"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Existing production capacity:</label>

                                    <asp:TextBox class="form-control" ID="txtEPCapacity" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Production capacity proposed to be increased:</label>

                                    <asp:TextBox class="form-control" ID="txtproposed_production_capacity" runat="server"></asp:TextBox>
                                </div>

                            </div>



                            <div class="form-section" id="Div4" runat="server">
                                <div class="pagetitle">
                                    <h1>Investment Details(in rupees):</h1>
                                </div>
                                <br />
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Capital Investment:</label>

                                        <asp:TextBox class="form-control" ID="txtcapital_investment" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Borrowings:</label>

                                        <asp:TextBox class="form-control" ID="txtborrowings" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Investment on Land:</label>
                                        <asp:TextBox class="form-control" ID="txtinvestment_land" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Investment on Building:</label>

                                    <asp:TextBox class="form-control" ID="txtinvestment_building" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Investment on Plant and Machinery:</label>

                                    <asp:TextBox class="form-control" ID="txtinvestment_machinery" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Working Capital:</label>

                                    <asp:TextBox class="form-control" ID="txtworking_capital" runat="server"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Whether sufficient water is available at the proposed place:</label>

                                    <asp:RadioButtonList ID="rblsufficient_water" class="form-check-input" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                        <asp:ListItem Value="1">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Whether the proper power supply is available at proposed place to meet the requirements of the unit:</label>

                                    <asp:RadioButtonList ID="rblpower_supply" class="form-check-input" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                        <asp:ListItem Value="1">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">Details of the raw materials:</label>
                                    <asp:DropDownList class="form-control" ID="ddlfermentative_base" runat="server">
                                        <asp:ListItem Value="">---select---</asp:ListItem>
                                        <asp:ListItem Value="0">Molasses as fermentative base</asp:ListItem>
                                        <asp:ListItem Value="1">Grains as fermentation base</asp:ListItem>
                                        <asp:ListItem Value="2">Both Molasses and Grains</asp:ListItem>
                                        <asp:ListItem Value="3">other fermentative base</asp:ListItem>
                                    </asp:DropDownList>


                                </div>
                            </div>


                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">
                                        Whether the applicant is able to 
                                            secure the raw material stated in
                                            Col. No. 10 without the aid of the Government:</label>

                                    <asp:RadioButtonList ID="rblrawmaterial" class="form-check-input" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                        <asp:ListItem Value="1">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label for="name">
                                        Whether the plant and machinery 
                                              to be installed is of:</label>
                                    <asp:RadioButtonList ID="rblimportedorindigenous"  runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">imported</asp:ListItem>
                                        <asp:ListItem Value="1">indigenous</asp:ListItem>
                                    </asp:RadioButtonList>


                                </div>
                            </div>
     

                                <div class="form-section" id="Div5" runat="server">
                                    <div class="pagetitle">
                                        <h1>Details of the Spirits Proposed to be Manufactured:</h1>
                                    </div>
                                    <br />
                                    <div class="col-md-12 row">
                                        <div class="col-md-4 form-group">
                                            <label for="name">Name(s) of the spirits<br /> proposed to be manufactured:</label>

                                            <asp:TextBox class="form-control" ID="txtsprit_name" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">
                                               Standards of the product(s) <br />proposed to be manufactured:</label>

                                            <asp:TextBox class="form-control" ID="txtstandards" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">
                                                Brief process <br />of manufacture:</label>
                                            <asp:TextBox class="form-control" ID="txtmanufacture_process" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>



                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Whether the proposed plant requires any technical assistance/know how many from any foriegn collaboration:</label>

                                        <asp:RadioButtonList ID="rbforiegncollab" class="form-check-input" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                            <asp:ListItem Value="1">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">If So, the foreign exchange involved:</label>

                                        <asp:TextBox class="form-control" ID="txtforeignexchange" runat="server"></asp:TextBox>
                                    </div>

                                </div>


                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Estimated annual production of spirit(s)(in Bulk Litres):</label>

                                        <asp:TextBox class="form-control" ID="txtEstimatedAprod" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Whether the proposed unit will have any buyback arrangement?</label>

                                        <asp:RadioButtonList ID="rblbuybackarrange" class="form-check-input" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                            <asp:ListItem Value="1">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>

                                </div>

                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">If so the details thereof:</label>

                                        <asp:TextBox class="form-control" ID="txtDetailsThereof" runat="server"></asp:TextBox>
                                    </div>
                                    </div>
                                <div class="pagetitle">
                                        <h1>Time requirement:</h1>
                                    </div>

                                    <br />
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Time required to secure land(in acres):</label>

                                        <asp:TextBox class="form-control" ID="txtsecureland" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Time required for erecting plant and machinery in years:</label>

                                        <asp:TextBox class="form-control" ID="txtplantandmechinery" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="form-section" id="Div6" runat="server">
                                    <div class="pagetitle">
                                        <h1>Employment potential of the proposed unit:</h1>
                                    </div>
                                    <br />
                                    <div class="col-md-12 row">
                                        <div class="col-md-4 form-group">
                                            <label for="name">Supervisory Staff: </label>

                                            <asp:TextBox class="form-control" ID="txtsupervisorystaff" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Skilled Workers:</label>

                                            <asp:TextBox class="form-control" ID="txtskilledworkers" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Un-skilled workers: </label>

                                            <asp:TextBox class="form-control" ID="txtunskilledworkers" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Any special facilities required from the Government:</label>

                                        <asp:RadioButtonList ID="rblspecialfacilties" class="form-check-input" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                            <asp:ListItem Value="1">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Pan Card Document:</label>

                                        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control-file border" />
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Aadhar Document:</label>

                                        <asp:FileUpload ID="FileUpload2" runat="server" class="form-control-file border" />

                                    </div>
                                    
                                </div>



                                <div class="col-md-12 row">
                                    
                                    <div class="col-md-4 form-group">
                                        <label for="name">Proof of the Land:</label>

                                        <asp:FileUpload ID="FileUpload" runat="server" class="form-control-file border" />
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Distillery process Doc:</label>
                                        <asp:FileUpload ID="FileUpload3" runat="server" class="form-control-file border" />

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Partnership deed(If the select partnership in firm type):</label>

                                        <asp:FileUpload ID="FileUpload4" runat="server" class="form-control-file border" />

                                    </div>
                                    </div>
                             <div class="col-md-12 row">
                                    
                                 <div class="col-md-4 form-group">
                                        <label for="name">ROC (Registration of Company):</label>

                                        <asp:FileUpload ID="FileUpload6" runat="server" class="form-control-file border" />
                                    </div>
                                 <div class="col-md-4 form-group">
                                        <label for="name">Sanction/Permission from Govt.of India:</label>
                                        <asp:FileUpload ID="FileUpload7" runat="server" class="form-control-file border" />

                                    </div>
                                </div>
                                   <div class="content col-lg-12 text-center" align="center">
                                    <asp:Button ID="btnd1R" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnd1R_Click" />
                                    <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
       
    </section>

















</asp:Content>






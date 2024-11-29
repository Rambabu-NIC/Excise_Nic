<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="RS_III.aspx.cs" Inherits="ExciseAPI.EODB.RS_III" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">

            <h1>FORM RS-III</h1>
            <h2>Application for license to possess and use of rectified spirit for industrial purpose.</h2>

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
                                        <label for="name">Firm Type:</label>

                                        <asp:DropDownList class="form-control" ID="ddlFirmType" runat="server">
                                            <asp:ListItem Value="">select</asp:ListItem>
                                            <asp:ListItem Value="0">individual</asp:ListItem>
                                            <asp:ListItem Value="1">Firm</asp:ListItem>
                                            <asp:ListItem Value="2">Partnership</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Name of the Applicant:</label>

                                        <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="pagetitle">
                                    <h1>Details of the Applicant/Firm:</h1>
                                </div>
                                <br />
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Mobile No.</label>

                                        <asp:TextBox class="form-control" ID="txtMobile" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">PAN No.</label>

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
                                        <label for="name">Email:</label>

                                        <asp:TextBox class="form-control" ID="txtEmail" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">House No.</label>

                                        <asp:TextBox class="form-control" ID="txtPHouseNo" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Road/Street/Locality:</label>

                                        <asp:TextBox class="form-control" ID="txtPStreet" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">District</label>

                                        <asp:DropDownList class="form-control" ID="ddlPDistrict" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Mandal</label>

                                        <asp:DropDownList class="form-control" ID="ddlPMandal" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Village</label>

                                        <asp:DropDownList class="form-control" ID="ddlPVillage" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Pin Code</label>

                                        <asp:TextBox class="form-control" ID="txtPPinCode" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="pagetitle">
                                    <h1>Industry details:</h1>
                                </div>
                                <br />

                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">House No.</label>

                                        <asp:TextBox class="form-control" ID="txtHouseNo" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Road/Street/Locality:</label>

                                        <asp:TextBox class="form-control" ID="txtStreet" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">District</label>

                                        <asp:DropDownList class="form-control" ID="ddlDistrict" runat="server">
                                        </asp:DropDownList>
                                    </div>


                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Mandal</label>

                                        <asp:DropDownList class="form-control" ID="ddlMandal" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Village</label>

                                        <asp:DropDownList class="form-control" ID="ddlVillage" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Pin Code</label>

                                        <asp:TextBox class="form-control" ID="txtPincode" runat="server"></asp:TextBox>
                                    </div>
                                </div>



                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Process of Rectified:</label>

                                        <asp:TextBox class="form-control" ID="txtRectified" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Name of the preparation permitted to  manufacture: </label>

                                        <asp:TextBox class="form-control" ID="txtManufacture" runat="server"></asp:TextBox>
                                    </div>


                                </div>

                                <div class="col-md-12 row">
                                    <div class="col-md-12 form-group d-flex align-items-center">
                                        <label for="name" class="mb-0 me-2">
                                            Kind of alcohol:
       
                                        </label>
                                        <asp:RadioButtonList ID="rblOtherLicenses" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">Rectified</asp:ListItem>
                                            <asp:ListItem Value="1">Alcohol</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>


                                </div>
                                
                                <div class="col-md-12 row">
                                    <div class="col-md-12 form-group">
                                        <label for="name">Quantity that may be possessed at any one time(in bulk litres):</label>

                                        <asp:TextBox class="form-control" ID="txtQuantity" runat="server"></asp:TextBox>
                                    </div>
                                    </div>
                                <div class="pagetitle">
                                    <h1>Quantity that may be used:</h1>
                                </div>
                                <br />
                                <div class="col-md-12 row">
                                    
                                    <div class="col-md-12 form-group">
                                        <label for="name">In a month for manufacturing purpose(in bulk litres):</label>
                                        <asp:TextBox class="form-control" ID="txtManfPurpose" runat="server"></asp:TextBox>
                                    </div>
                                    
                                </div>
                                <div class="col-md-12 row">
                                <div class="col-md-12 form-group">
                                        <label for="name">In a year or current year for licence of manufacturing purpose (in bulk litres):</label>

                                        <asp:TextBox class="form-control" ID="txtCurrentManf" runat="server"></asp:TextBox>
                                    </div>

                                    </div>
                                <div class="pagetitle">
                                    <h1>Enclosures:</h1>
                                </div>
                                <br />




                                <div class="col-md-12 row">

                                    <div class="col-md-6 form-group">
                                        <label for="name">PAN card Document:</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control-file border" />

                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Aadhar Document:</label>

                                        <asp:FileUpload ID="FileUpload2" runat="server" class="form-control-file border" />

                                    </div>


                                </div>



                                <div class="content col-lg-12 text-center" align="center">
                                    <asp:Button ID="btnRS3" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnRS3_Click" />
                                    <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



    </section>
</asp:Content>

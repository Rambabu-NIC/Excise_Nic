<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Home_org.aspx.cs" Inherits="ExciseAPI.Home_org" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
          <div class="w-100 fl container-fluid">
    <div class="block black bg-white">
        <div class="head">Ease of Doing Business</div>
                   
        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <p class="ele">
                        Ease of Doing Business in Telangana aims to create a platform for providing best support towards the prospective and existing business community in the state and drives forward the state's vision of prosperity for all - by employing technology, innovation, inclusivity and sustainability as key factors for development. It provides objective measures of business regulations.
                    </p>
                </div>
            </div>
        </section>
        <section class="section">
            <div class="row col-12">
                <br />
                <div class="card">
                    <div class="card-body">
                        <div class="content col-lg-12">
                            <div class="row mb-3">
                                <label class="label col-sm-2 col-form-label">Applicant Type :</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlApplicant" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlApplicant_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-3" id="divUnitType" runat="server" visible="false">
                                <label class="label col-sm-2 col-form-label">Unit Type :</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlUnitType" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlUnitType_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row mb-3" id="divFormType" runat="server" visible="false">
                                <label class="label col-sm-2 col-form-label">Form Type :</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlFormType" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlFormType_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-3" id="divpublicorprivate" runat="server" visible="false">
                                <label class="label col-sm-2 col-form-label"></label>
                                <div class="col-sm-10">
                                    <div class="radio-group">
                                        <asp:RadioButtonList ID="rblpublicorprivate" runat="server">
                                            <asp:ListItem Value="1">Public</asp:ListItem>
                                            <asp:ListItem Value="2">Private</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-3" id="divpartenership" runat="server" visible="false">
                                <label class="label col-sm-2 col-form-label"></label>
                                <div class="col-sm-10">
                                    <div class="radio-group">
                                        <asp:RadioButtonList ID="rblpartenerorproperiter" runat="server" OnSelectedIndexChanged="rblpartenerorproperiter_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="1">Proprietory</asp:ListItem>
                                            <asp:ListItem Value="2">Partnership</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="content" runat="server" id="divpartenerDetails" visible="false">
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">Applicant Name:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtApplicantName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile No:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtMobileNo" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">PAN No:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtPanNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">Aadhar No:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtAadhar" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">GST No:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtGstNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">Email:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">District:</label>
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddlDistrict" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>


                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal:</label>
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddlMandal" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">Village:</label>
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddlVillage" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">House No:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtHouseNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row mb-3">
                                    <div class="col-sm-6 d-flex align-items-center">
                                        <label class="label col-xs-4 col-sm-5 col-md-5 col-lg-4">Street Road:</label>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtStreet" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="content col-lg-12 text-center" align="center" id="btnapplicant" runat="server" visible="false">
                            <asp:Button ID="btnregsubmit" Text="Submit" runat="server" CssClass="btn btn-primary" OnClick="btnregsubmit_Click" />
                            <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="section" runat="server" visible="false">
            <div class="row">
                <div class="col-lg-6">

                    <div class="card" id="clickableCard">
                        <div class="card-body">
                            <a href="EODB/Type_Manufacturer.aspx">
                                <h5 class="card-title">G Section</h5>
                                <p>Application  for construction and working of distillery for manufacture of spirits</p>
                            </a>

                        </div>
                    </div>

                </div>
                <div class="col-lg-6">

                    <div class="card" id="B-Section">
                        <div class="card-body">
                            <a href="EODB/BSectionForms.aspx">
                                <h5 class="card-title">B-SECTION Forms</h5>
                                <p>Application for Renewal of M-1,M-2,M-4,M-5 forms.</p>

                            </a>
                        </div>
                        <br />
                    </div>

                </div>

                <%--<div class="col-lg-6">

          <div class="card" id="clickme">
            <div class="card-body">
              <h5 class="card-title">Indian Made Foriegn Liqour</h5>
              <p>Application for Issue of letter of intent.
                
              </p>
              <a class="nav-link collapsed" href="../EOB/IML(GSection).aspx"></a>
            </div>
          </div>

        </div>--%>
            </div>
        </section>


        <section class="section" runat="server" visible="false">
            <div class="row">

                <div class="col-lg-6">

                    <div class="card" id="Clubs">
                        <div class="card-body">
                            <a href="EODB/Type_Of_Retailers.aspx">
                                <h5 class="card-title">F-Section</h5>
                                <p>Appication forms of A3,A4(A),A4(G),1B,IHA-1,IHA-2.</p>
                            </a>
                        </div>
                    </div>

                </div>

                <div class="col-lg-6">

                    <div class="card" id="Bars">
                        <div class="card-body">
                            <a href="EODB/CSection.aspx">
                                <h5 class="card-title">C Section</h5>
                                <p>Application for prior clearance for grant of licence RS-II and DS-XI.</p>
                            </a>
                        </div>
                    </div>

                </div>
            </div>
        </section>



    </div>
              </div>
</asp:Content>







<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ExciseAPI.EODB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center" runat="server">
        <div class="col-lg-112 col-md-12 d-flex flex-column align-items-center justify-content-center">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title text-center">Ease of Doing Business</h5>
                    <br />
                    <div class="wrapper ">
                        <div class="col-md-12">
                            <p class="ele">
                                Ease of Doing Business in Telangana aims to create a platform for providing best support towards the prospective and existing business community in the state and drives forward the state's vision of prosperity for all - by employing technology, innovation, inclusivity and sustainability as key factors for development. It provides objective measures of business regulations.
                            </p>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-12 row">
                                <div class="col-md-6 form-group">
                                    <label for="name">Applicant Type :</label>
                                    <asp:DropDownList ID="ddlApplicant" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlApplicant_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlApplicant" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6 form-group" id="divUnitType" runat="server" visible="false">
                                    <label for="name">Unit Type :</label>

                                    <asp:DropDownList ID="ddlUnitType" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlUnitType_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlUnitType" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-12 row" id="divFormType" runat="server" visible="false">
                                <div class="col-md-6 form-group">
                                    <label for="name">Form Type :</label>
                                    <asp:DropDownList ID="ddlFormType" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlFormType_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlFormType" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6 form-group" id="divpublicorprivate" runat="server" visible="false">
                                    <label for="name"></label>
                                    <asp:RadioButtonList ID="rblpublicorprivate" runat="server" RepeatLayout="Table" RepeatColumns="3">
                                        <asp:ListItem Value="1">Public</asp:ListItem>
                                        <asp:ListItem Value="2">Private</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rblpublicorprivate" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-12 row" id="divpartenership" runat="server" visible="false">
                                <div class="col-md-6 form-group">
                                    <label for="name"></label>
                                    <asp:RadioButtonList ID="rblpartenerorproperiter" runat="server" RepeatLayout="Table" RepeatColumns="3" OnSelectedIndexChanged="rblpartenerorproperiter_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="1">Proprietory</asp:ListItem>
                                        <asp:ListItem Value="2">Partnership</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rblpartenerorproperiter" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6 form-group">
                                </div>
                            </div>
                           
                            <div class="wrapper" runat="server" id="divpartenerDetails" visible="false">
                                <div class="col-md-12">
                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">Applicant Name:</label>

                                            <asp:TextBox ID="txtApplicantName" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtApplicantName" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>


                                        <div class="col-md-6 form-group">
                                            <label for="name">Mobile No:</label>

                                            <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobileNo"
                                        ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red">
                                    </asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">Pan No:</label>

                                            <asp:TextBox ID="txtPanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                             <asp:RegularExpressionValidator ControlToValidate="txtPanNo" ErrorMessage="Invalid PAN Number"
                                                                ValidationExpression="([A-Z]){5}([0-9]){4}([A-Z]){1}$" runat="server" ForeColor="Red">
                                                            </asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPanNo" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-6 form-group">
                                            <label for="name">Aadhar No:</label>

                                            <asp:TextBox ID="txtAadhar" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgxAadhaar" runat="server" ControlToValidate="txtAadhar"
                                        ValidationExpression="[0-9]{12}"
                                        ErrorMessage="Invalid Aadhaar Number" ForeColor="Red"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAadhar" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">Gst No:</label>

                                            <asp:TextBox ID="txtGstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtGstNo" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-6 form-group">
                                            <label for="name">Email:</label>

                                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                        ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        Display="Dynamic" ErrorMessage="Invalid email address" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                        ForeColor="Red" Display="Dynamic" ErrorMessage="Required" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtEmail" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">District:</label>

                                            <asp:DropDownList ID="ddlDistrict" CssClass="form-control" runat="server"></asp:DropDownList>

                                        </div>
                                        <div class="col-md-6 form-group">
                                            <label for="name">Mandal:</label>

                                            <asp:DropDownList ID="ddlMandal" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">Village:</label>

                                            <asp:DropDownList ID="ddlVillage" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>
                                        </div>

                                        <div class="col-md-6 form-group">
                                            <label for="name">House No:</label>

                                            <asp:TextBox ID="txtHouseNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtHouseNo" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">Street Road:</label>
                                            <asp:TextBox ID="txtStreet" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtStreet" ErrorMessage="This field cannot be blank." ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-6 form-group">
                                            <asp:Button ID="btnAddApplicant" Text="ADD" runat="server" class="btn btn-info m-2" OnClick="btnAddApplicant_Click" ValidationGroup="Submit"/>
                                            <asp:Label ID="lbladderror" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                             <div class="wrapper" runat="server" id="divgridDetails" visible="false">
                                <div class="content">
                                    <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table text-nowrap"
                                        OnRowCommand="gvdetails_RowCommand" OnRowDataBound="gvdetails_RowDataBound" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                            <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                                            <asp:BoundField DataField="PanNo" HeaderText="Pan No" />
                                            <asp:BoundField DataField="GstNo" HeaderText="Gst No" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:BoundField DataField="HouseNo" HeaderText="HouseNo" />
                                            <asp:BoundField DataField="Street" HeaderText="Street" />
                                             <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkbtnDelete" runat="server" Text="Delete" OnClick="lkbtnDelete_Click"  Visible="false"><img src="../assets/img/Del-Icon.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="content col-md-12 text-center" align="center" id="btnapplicant" runat="server" visible="false">
                                <asp:Button ID="btnhomeclick" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnhomeclick_Click" />
                                <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

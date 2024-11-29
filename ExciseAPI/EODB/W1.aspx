<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="W1.aspx.cs" Inherits="ExciseAPI.EODB.W1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>W1</h1>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnW1tab1" OnClick="btnW1tab1_Click" Enabled="true" />
                                    </li>

                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Location,Investment And Raw Material Details" ID="btnW1tab2" OnClick="btnW1tab2_Click" Enabled="true" />
                                    </li>
                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Details of Wine And Employment" ID="btnW1tab3" OnClick="btnW1tab3_Click" Enabled="true" />
                                    </li>
                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnW1tab4" OnClick="btnW1tab4_Click" Enabled="true" />
                                    </li>

                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="W1tab1" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Personal Details</h1>
                                                </div>
                                                <div class="wrapper" runat="server" id="divgridDetails" visible="false">
                                                    <div class="content">
                                                        <asp:GridView ID="gvpersonaldetails" runat="server" AutoGenerateColumns="False" CssClass="table text-nowrap">
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

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Notification Number:</label>

                                                        <asp:TextBox ID="txtNotify_no" class="form-control" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtNotify_no" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Firm name:</label>

                                                        <asp:TextBox class="form-control" ID="txtFirmname" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmname" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">ROC Number(If company):</label>

                                                        <asp:TextBox class="form-control" ID="txtRocNumber" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRocNumber" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    

                                                </div>

                                                

                                                <div class="col-md-12 row">
                                                    <div class="pagetitle">
                                                        <h1>Name & Address of the Undertaking-1:</h1>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 row">
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Name of the Undertaking:</label>

                                                            <asp:TextBox class="form-control" ID="txtUndertaking" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUndertaking" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">House No.</label>

                                                            <asp:TextBox class="form-control" ID="txtHouseNo" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHouseNo" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Street and Landmark:</label>

                                                            <asp:TextBox class="form-control" ID="txtStreet" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtStreet" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">District</label>

                                                            <asp:DropDownList class="form-control" ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                         <div class="col-md-4 form-group">
                                                            <label for="name">Mandal</label>

                                                            <asp:DropDownList class="form-control" ID="ddlMandal" runat="server" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandal" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Village</label>

                                                            <asp:DropDownList class="form-control" ID="ddlVillage" runat="server">
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlVillage" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                       
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">PIN Code</label>

                                                            <asp:TextBox class="form-control" ID="txtPincode" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPincode" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="pagetitle">
                                                        <h1>Name & Address of the Undertaking-2:</h1>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 row">
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Name of the Undertaking:</label>

                                                            <asp:TextBox class="form-control" ID="txtUndertaking_A" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtUndertaking_A" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">House No.</label>

                                                            <asp:TextBox class="form-control" ID="txtHouseNo_A" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtHouseNo_A" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Street and Landmark:</label>

                                                            <asp:TextBox class="form-control" ID="txtStreet_A" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtStreet_A" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">District</label>

                                                            <asp:DropDownList class="form-control" ID="ddlDistrict_A" runat="server" OnSelectedIndexChanged="ddlDistrict_A_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlDistrict_A" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Mandal</label>

                                                            <asp:DropDownList class="form-control" ID="ddlMandal_A" runat="server" OnSelectedIndexChanged="ddlMandal_A_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlMandal_A" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Village</label>

                                                            <asp:DropDownList class="form-control" ID="ddlVillage_A" runat="server">
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlVillage_A" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-12 row">
                                                        
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">PIN Code</label>

                                                            <asp:TextBox class="form-control" ID="txtPincode_A" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtPincode_A" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="W1tab2" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Location where the applicant intends to establish the Distillery:</h1>
                                                </div>
                                                <br />
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">District</label>

                                                        <asp:DropDownList class="form-control" ID="ddlEDistrict" runat="server" OnSelectedIndexChanged="ddlEDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlEDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Mandal</label>

                                                        <asp:DropDownList class="form-control" ID="ddlEMandal" runat="server" OnSelectedIndexChanged="ddlEMandal_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlEMandal" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Village</label>

                                                        <asp:DropDownList class="form-control" ID="ddlEVillage" runat="server">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="ddlEVillage" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Survey No.</label>

                                                        <asp:TextBox class="form-control" ID="txtSurveyNo" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtSurveyNo" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Extent.</label>

                                                        <asp:TextBox class="form-control" ID="txtExtent" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtExtent" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group d-flex align-items-center">
                                                        <label for="name" class="mb-0 me-2">
                                                            Whether the applicant owns sufficient land at the proposed site: 
                                                        </label>
                                                        <asp:RadioButtonList ID="rbl_sufLand_owns" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="rbl_sufLand_owns" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>


                                                </div>
                                                 <div class="col-md-12 row">
                                                      <div class="col-md-4 form-group">
                                                          </div>
                                                     </div>
                                                <br />
                                                <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Investment Details:</h1>
                                                </div>
                                                <br />
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Capital Investment:</label>

                                                        <asp:TextBox class="form-control" ID="txtcapital_investment" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtcapital_investment" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Borrowings:</label>

                                                        <asp:TextBox class="form-control" ID="txtborrowings" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtborrowings" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Investment on Land:</label>
                                                        <asp:TextBox class="form-control" ID="txtinvestment_land" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtinvestment_land" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Investment on Building:</label>

                                                        <asp:TextBox class="form-control" ID="txtinvestment_building" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtinvestment_building" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Investment on Plant and Machinery:</label>

                                                        <asp:TextBox class="form-control" ID="txtinvestment_machinery" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtinvestment_machinery" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Working Capital:</label>

                                                        <asp:TextBox class="form-control" ID="txtworking_capital" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtworking_capital" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>


                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Whether sufficient water is available at the proposed place:</label>

                                                        <asp:RadioButtonList ID="rblsufficient_water" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="rblsufficient_water" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Whether the proper power supply is available at proposed place to meet the requirements of the unit:</label>

                                                        <asp:RadioButtonList ID="rblpower_supply" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="rblpower_supply" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    </div>
                                                 <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                    </div>
                                                </div>
                                                    </div>
                                           <br />
                                                <br />
                                            <div class="col-md-12 row">

                                                <div class="pagetitle">
                                                    <h1>Details of Raw Material:</h1>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <table style="width: 100%" class="table">
                                                        <tr>
                                                            <th></th>
                                                            <th>Quantity</th>
                                                            <th>Value</th>
                                                        </tr>
                                                        <tr>
                                                            <td>Raw materials to be imported or of imported origin per year:</td>

                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtRImported_Quantity" runat="server" placeholder="Quantity"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtRImported_Quantity" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtRImported_Value" runat="server" placeholder="Value"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtRImported_Value" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Raw materials if indigenous origin :</td>

                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtRIndigenous_Quantity" runat="server" placeholder="Quantity"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtRIndigenous_Quantity" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtRIndigenous_Value" runat="server" placeholder="Value"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtRIndigenous_Value" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Sprit Required for Fortification purpose per year :</td>

                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtsprit_Quantity" runat="server" placeholder="Quantity"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtsprit_Quantity" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtsperit_Value" runat="server" placeholder="Value"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtsperit_Value" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>

                                                        </tr>

                                                    </table>
                                                </div>
                                           

                                            <div class="col-md-12 row">
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Whether the applicant is able to secure the raw material stated in Col.No.9 without the aid of the government:</label>

                                                    <asp:RadioButtonList ID="rblsecuretherawmaterial" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                                        <asp:ListItem Value="1">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="rblsecuretherawmaterial" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Whether the plant and machinery to be installed is of imported or indigenous:</label>

                                                    <asp:RadioButtonList ID="rblimportedorindigenous" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0">imported</asp:ListItem>
                                                        <asp:ListItem Value="1">indigenous</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="rblimportedorindigenous" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Import Or Indigenous Details:</label>

                                                    <asp:TextBox class="form-control" ID="txtimportIndigenous" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtimportIndigenous" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                                 </div>
                                                 </div>
                                        </div>
                                        <div id="W1tab3" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Details of the Wine proposed to be manufactured:</h1>
                                                </div>
                                                <br />
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Name(s) of the Wine proposed to be manufactured:</label>

                                                        <asp:TextBox class="form-control" ID="txtsprit_name" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtsprit_name" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">
                                                            Standards of the 
                                                                    product(s) proposed to
                                                                    manufacture:</label>

                                                        <asp:TextBox class="form-control" ID="txtstandards" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtstandards" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">
                                                            Brief process of 
                                                                    manufacture:</label>
                                                        <asp:TextBox class="form-control" ID="txtmanufacture_process" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtmanufacture_process" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>



                                                <div class="col-md-12 row">
                                                    <div class="col-md-6 form-group">
                                                        <label for="name">Estimated annual production of Wine in Proof ltrs:</label>

                                                        <asp:TextBox class="form-control" ID="txtEstimatedAprod" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtEstimatedAprod" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-6 form-group">
                                                        <label for="name">Whether the proposed unit will have any buyback arrangement?</label>

                                                        <asp:RadioButtonList ID="rblbuybackarrange" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="rblbuybackarrange" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>

                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">If so, the foreign exchange involved:</label>

                                                        <asp:TextBox class="form-control" ID="txtforeignexchangeinvolved" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtforeignexchangeinvolved" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Time required to secure land:</label>

                                                        <asp:TextBox class="form-control" ID="txtsecureland" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtsecureland" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Time required for erecting plant and machinery:</label>

                                                        <asp:TextBox class="form-control" ID="txtplantandmechinery" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtplantandmechinery" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtsupervisorystaff" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Skilled Workers:</label>

                                                            <asp:TextBox class="form-control" ID="txtskilledworkers" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtskilledworkers" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Un-skilled workers: </label>

                                                            <asp:TextBox class="form-control" ID="txtunskilledworkers" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtunskilledworkers" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Any special facilities required from the Government:</label>

                                                        <asp:RadioButtonList ID="rblspecialfacilties" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="rblspecialfacilties" ErrorMessage="This field cannot be blank." ValidationGroup="W1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group"></div>
                                                    <div class="col-md-4 form-group"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="W1tab4" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">

                                                <div class="pagetitle">
                                                    <h1>Documents :</h1>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Document Name :</label>
                                                    <asp:DropDownList class="form-control" ID="ddlFileUpload" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name"></label>
                                                    <%-- <asp:FileUpload ID="FileUpload2" runat="server" class="form-control-file border" />--%>
                                                    <asp:FileUpload ID="fileloiuploaddoctype" runat="server" CssClass="form-control input-b-b" />
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name"></label>
                                                    <br />
                                                    <asp:Button runat="server" Text="Add" ID="btnfileAdd" OnClick="btnfileAdd_Click" class="btn btn-info m-2" />
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">
                                                <asp:Label ID="lblFileUploaderror" runat="server" ForeColor="Red"></asp:Label>
                                            </div>
                                            <div id="divuploadedDocuments" runat="server" visible="false">
                                                <div class="content table-container">

                                                    <div style="width: 100%; overflow: auto;">
                                                        <asp:GridView ID="gvaddrecordsofLOI" CssClass="custom-table text-nowrap"
                                                            runat="server" AutoGenerateColumns="false" ShowFooter="false" AutoGenerateDeleteButton="false" EmptyDataText="No Documents are available to show" EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True"
                                                            OnRowCommand="gvaddrecordsofLOI_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SNo" ItemStyle-Width="5%">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="DocumentName" ItemStyle-Width="35%" HeaderText="Document Type" />
                                                                <asp:TemplateField HeaderText="Documet Copy" ItemStyle-CssClass="txt-cnt">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtn_Documents" runat="server" Text="View" CommandName="lnkbtn_Documents" CommandArgument='<%# Eval("DocumentSerialNumber").ToString() %>' ForeColor="Green"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="25%">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lknbtndocDelete" runat="server" Text="Delete" OnClick="lknbtndocDelete_Click"><img src="../assets/img/Del-Icon.png" onclick="" /></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                </div>
                                            </div>


                                            <div class="content col-lg-12 text-center" align="center">
                                                <asp:Button ID="btnd1p" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnd1p_Click" />
                                                <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="W1Submit" />
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>

</asp:Content>

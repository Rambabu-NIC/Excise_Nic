<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EOB.Master" CodeBehind="IHA2.aspx.cs" Inherits="ExciseAPI.EODB.IHA2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= txtRegDate.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',  // You can customize the format as per your need
                changeMonth: true,
                changeYear: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>Form IHA-2</h1>
            <h2>[Rule-5(i)]</h2>
            <h3>Application for Grant of Club License</h3>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnIHA2tab1" OnClick="btnIHA2tab1_Click" Enabled="true" />
                                    </li>

                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnIHA2tab2" OnClick="btnIHA2tab2_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="IHA2tab1" class="tab-content" runat="server" visible="true">
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
                            </div>
                            <div class="col-md-12 row">
                                <div class="col-md-4 form-group">
                                    <label for="name">Name and Style of proposed Licence:</label>

                                    <asp:TextBox class="form-control" ID="txtNameProposedLicence" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNameProposedLicence" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-md-4 form-group"></div>
                                <div class="col-md-4 form-group"></div>
                            </div>
                            <div class="col-md-12 row">
                                <div class="pagetitle">
                                    <h1>Full Address of the Premises to be Licensed :</h1>
                                </div>
                                <br />
                                <div class="col-md-12 row">

                                    <div class="col-md-4 form-group">
                                        <label for="name">House No:</label>

                                        <asp:TextBox class="form-control" ID="txtHouseNo_C" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHouseNo_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Road/Street/Locality</label>

                                        <asp:TextBox class="form-control" ID="txtStreet_C" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStreet_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">District</label>

                                        <asp:DropDownList class="form-control" ID="ddlDistrict_C" runat="server" OnSelectedIndexChanged="ddlDistrict_C_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDistrict_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>

                                </div>
                                <div class="col-md-12 row">


                                    <div class="col-md-4 form-group">
                                        <label for="name">Mandal:</label>

                                        <asp:DropDownList class="form-control" ID="ddlMandal_C" runat="server" OnSelectedIndexChanged="ddlMandal_C_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlMandal_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Village:</label>

                                        <asp:DropDownList class="form-control" ID="ddlVillage_C" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlVillage_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Pin Code:</label>

                                        <asp:TextBox class="form-control" ID="txtPinCode_C" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPinCode_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>

                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="pagetitle">
                                    <h1>Registration</h1>
                                </div>

                                <div class="content">
                                    <div class="col-md-12 row">
                                        <div class="col-md-4 form-group">
                                            <label for="name">Registration Number:</label>

                                            <asp:TextBox class="form-control" ID="txtRegNo" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRegNo" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Date of Registration:</label>

                                            <asp:TextBox class="form-control" ID="txtRegDate" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtRegDate" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Whether Copy of Bye-Laws and Articles of Association is Enclosed</label>
                                            <asp:RadioButtonList ID="rblEnclosed" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0">Yes</asp:ListItem>
                                                <asp:ListItem Value="1">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="rblEnclosed" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>

                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">No Of Members</label>
                                            <asp:TextBox class="form-control" ID="txtNoMembers" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNoMembers" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-6 form-group">
                                            <label for="name">No Of Members who have paid their memebership fee for the last 3 years</label>
                                            <asp:TextBox class="form-control" ID="txtnomembership" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtnomembership" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>



                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-4 form-group">
                                            <label for="name">Total Area of the Club Premises (in SqMtrs)</label>

                                            <asp:TextBox class="form-control" ID="txtClubPremises" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtClubPremises" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>


                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Build-up Area (in SqMtrs)</label>
                                            <asp:TextBox class="form-control" ID="txtbuiduparea" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtbuiduparea" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Whether the club is located </label>
                                            <asp:RadioButtonList ID="rblclublocated" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Own building </asp:ListItem>
                                                <asp:ListItem Value="2">Government building</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="rblclublocated" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-4 form-group">
                                            <label for="name">Size of Liquor Consumption Area (in SqMtrs)</label>
                                            <asp:TextBox class="form-control" ID="txtLiquor_Cons_Area" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtLiquor_Cons_Area" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-4 form-group"></div>
                                        <div class="col-md-4 form-group"></div>
                                    </div>

                                    <div class="col-md-12 row">
                                        <div class="pagetitle">
                                            <h1>whether the club has following facilities </h1>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Billiards</label>
                                            <asp:RadioButtonList ID="rblBilliards" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="rblBilliards" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Lawn Tennis/Table Tennis</label>
                                            <asp:RadioButtonList ID="rblawntabletennis" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="rblawntabletennis" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Shuttle Badminton/Ball Badminton</label>
                                            <asp:RadioButtonList ID="rblbadminton" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="rblbadminton" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-12 row">
                                            <div class="col-md-4 form-group">
                                                <label for="name">Gymnasium/Health Club</label>
                                                <asp:RadioButtonList ID="rblGymnasium" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="rblGymnasium" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="col-md-4 form-group">
                                                <label for="name">Swimming Pool</label>
                                                <asp:RadioButtonList ID="rblSwimmingPool" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="rblSwimmingPool" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="col-md-4 form-group"></div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">Whether there is Kitchen for Cooking and Serving Complete Meals</label>
                                            <asp:RadioButtonList ID="rblMeals" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="rblMeals" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-6 form-group">
                                            <label for="name">Whether there is Separate Dining Room/Dining Area for Serving Meals</label>
                                            <asp:RadioButtonList ID="rblServingMeals" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="rblServingMeals" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>


                                        </div>
                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-6 form-group">
                                            <label for="name">Whether Separate Toilet Facilities are Provided for Males and Females</label>
                                            <asp:RadioButtonList ID="rblToiletFacilities" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="rblToiletFacilities" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-6 form-group">
                                            <label for="name">
                                                Whether the Club has been Convicted of Offences under the provisions of excise act, 
                                                intoxicating liquor (Prohibition of Advertisement) Act, 1978 or any non-bailable Offence:</label>
                                            <asp:RadioButtonList ID="rblOffences" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="rblOffences" ErrorMessage="This field cannot be blank." ValidationGroup="IHA2Submit" ForeColor="Red"></asp:RequiredFieldValidator>


                                        </div>
                                    </div>
                                    </div>
                                </div>
                                            </div>
                                         <div id="IHA2tab2" class="tab-content" runat="server" visible="true">
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
                                            <asp:Button runat="server" Text="Add" ID="btnfileAdd" OnClick="btnfileAdd_Click" class="btn btn-info m-2" />
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
                                        <div class="content col-lg-12 text-center">
                                            <asp:Button ID="btnIHA2" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnIHA2_Click" />
                                            <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                        </div>
                                             </div>
                                        </div>
                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="IHA2Submit"/>
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






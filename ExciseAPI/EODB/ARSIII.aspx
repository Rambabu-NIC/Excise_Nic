<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="ARSIII.aspx.cs" Inherits="ExciseAPI.EODB.ARSIII" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= txtApporximatedate.ClientID %>").datepicker({
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
            <h1>ARS III</h1>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnRS3tab1" OnClick="btnRS3tab1_Click" Enabled="true" />
                                    </li>

                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnRS3tab2" OnClick="btnRS3tab2_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="RS3tab1" class="tab-content" runat="server" visible="true">
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
                                                    <div class="col-md-6 form-group">
                                                        <label for="name">Firm name:</label>

                                                        <asp:TextBox class="form-control" ID="txtFirmname" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtFirmname" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-6 form-group">
                                                        <label for="name">ROC Number(If company):</label>
                                                        <asp:TextBox class="form-control" ID="txtRocNumber" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRocNumber" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-6 form-group">
                                                        <label for="name">The Amount of Captail Proposed to be Invested in venture:</label>
                                                        <asp:TextBox class="form-control" ID="txtventure" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtventure" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">

                                                    <div class="pagetitle">
                                                        <h1>Name of the Place and site Which the building housing the manifacturing is/are situated or to be constructed:</h1>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">House No.</label>

                                                        <asp:TextBox class="form-control" ID="txtHouseNo" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHouseNo" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Road/Street/Locality:</label>

                                                        <asp:TextBox class="form-control" ID="txtStreet" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStreet" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">District</label>

                                                        <asp:DropDownList class="form-control" ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>



                                                    <div class="col-md-12 row">
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Mandal</label>

                                                            <asp:DropDownList class="form-control" ID="ddlMandal" runat="server" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlMandal" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Village</label>

                                                            <asp:DropDownList class="form-control" ID="ddlVillage" runat="server">
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlVillage" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-4 form-group">
                                                            <label for="name">Pin Code</label>

                                                            <asp:TextBox class="form-control" ID="txtPincode" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPincode" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-12 row">
                                                    <div class="pagetitle">
                                                        <h1>Description With Boundaries of Premises:</h1>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">North:</label>

                                                        <asp:TextBox class="form-control" ID="txtNorth" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNorth" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">East:</label>

                                                        <asp:TextBox class="form-control" ID="txtEast" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEast" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">West:</label>

                                                        <asp:TextBox class="form-control" ID="txtWest" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtWest" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>


                                                </div>

                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">South:</label>

                                                        <asp:TextBox class="form-control" ID="txtSouth" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtSouth" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">
                                                            Discription of each main division or sub division
       
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtdivision" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtdivision" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Spirit Store:</label>
                                                        <asp:TextBox ID="txtSpirit" class="form-control" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtSpirit" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Laboratory:</label>

                                                        <asp:TextBox class="form-control" ID="txtLaboratory" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtLaboratory" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Finished store:</label>
                                                        <asp:TextBox ID="txtFinishedstore" class="form-control" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtFinishedstore" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-8 form-group">
                                                        <label for="name">Apporximate date Form which the appliciant desires to commence the Manufatchuring:</label>

                                                        <asp:TextBox class="form-control ui-datepicker" ID="txtApporximatedate" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtApporximatedate" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group">
                                                        <label for="name">The Number and Full description of the vast stills and other perminant Apparatus and machenire which the applicant wishes to setup or work or already setup giving distinguishing letter or number of letters and number of each :</label>
                                                        <asp:TextBox class="form-control" ID="txtvaststills" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtvaststills" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group">
                                                        <label for="name">The maximum Quantites in bulk litiers of plain spirt requeried for the year :</label>
                                                        <asp:TextBox class="form-control" ID="txtmaxbulkQuantites" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtmaxbulkQuantites" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group">
                                                        <label for="name">Willingness of the applicant to deposit the costs, charges and expenses (including salaries and allowances) of such Excise staff as may be posted at the manufactory by the Excise Commissioner or his nominee:</label>
                                                        <asp:TextBox class="form-control" ID="txtwillingness" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtwillingness" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group">
                                                        <label for="name">Willingness of the applicant to furnish security in cash in Government Bonds for the due performance of the conditions on which the licence may be granted:</label>
                                                        <asp:RadioButtonList ID="rblIsfurnishcapasity" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="rblIsfurnishcapasity" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group">
                                                        <label for="name">Whether quarters of the Excise staff will be provided within the manufactory or its vicinity if required by the Commissioner.</label>
                                                        <asp:RadioButtonList ID="rblwhetherquarters" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="rblwhetherquarters" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group">
                                                        <label for="name">
                                                            The Kind and number of the Licence under the Drugs Act if any held by the applicant:
                                                        </label>
                                                        <asp:RadioButtonList ID="rblLicenceundertheDrugs" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rblLicenceundertheDrugs" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group">
                                                        <label for="name">
                                                            List of all preparations which the applicant proposes to manufacture and or those manufactured during the preceding year, in the manufactory showing the percentage or proportion of spirit in terms of London Proof litres contained in each such preparations quoting the authority under which the preparation is/was manufactured.
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtlistofallperparations" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtlistofallperparations" ErrorMessage="This field cannot be blank." ValidationGroup="ARS3Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                        <div id="RS3tab2" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Documents :</h1>
                                                </div>
                                                 <div class="col-md-12 row">
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
                                                </div>

                                                <div class="content col-lg-12 text-center">
                                                    <asp:Button ID="btnRS2" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnRS2_Click" />
                                                    <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="ARS3Submit"/>
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

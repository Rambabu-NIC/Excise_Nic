<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="M5.aspx.cs" Inherits="ExciseAPI.EODB.M5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= txtlicenceDate.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',  // You can customize the format as per your need
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtLicenceStartDate.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',  // You can customize the format as per your need
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtLicenceendDate.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',  // You can customize the format as per your need
                changeMonth: true,
                changeYear: true
            });

        });
    </script>
    <script type="text/javascript">
    function calculateTotal() {
        var total = 0;

        // Get all the textboxes by their IDs
        var txtBox1 = document.getElementById('<%= txtopeningstockmolasses.ClientID %>').value;
        var txtBox2 = document.getElementById('<%= txtMolassesProductionCFY.ClientID %>').value;
        var txtBox3 = document.getElementById('<%= txtDispatchOfMoLasses.ClientID %>').value;
        var txtBox4 = document.getElementById('<%= txtClosingStockMolasses.ClientID %>').value;
        var txtBox5 = document.getElementById('<%= txtExpectedMolassesCFY.ClientID %>').value;
        var txtBox6 = document.getElementById('<%= txtExpectedMolassesNFY.ClientID %>').value;

        // Parse values to float and add to total
        total += parseFloat(txtBox1) || 0;
        total += parseFloat(txtBox2) || 0;
        total += parseFloat(txtBox3) || 0;
        total += parseFloat(txtBox4) || 0;
        total += parseFloat(txtBox5) || 0;
        total += parseFloat(txtBox6) || 0;

        // Set the total value to the Total textbox
        document.getElementById('<%= txtTotal.ClientID %>').value = total.toFixed(2);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>Molasses_M5</h1>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnM5tab1" OnClick="btnM5tab1_Click" Enabled="true" />
                                    </li>
                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Stock Details" ID="btnM5tab2" OnClick="btnM5tab2_Click" Enabled="true" />
                                    </li>
                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnM5tab3" OnClick="btnM5tab3_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="M5tab1" class="tab-content" runat="server" visible="true">
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
                                                    <label for="name">Licence Type:</label>
                                                    <asp:DropDownList class="form-control" ID="ddlLicenceType" runat="server">
                                                        <asp:ListItem Value="0">--Select --</asp:ListItem>
                                                        <asp:ListItem Value="1">M-I</asp:ListItem>
                                                    </asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlLicenceType" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Licence Number :</label>
                                                    <asp:TextBox ID="txtlicenceNo" class="form-control" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtlicenceNo" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4 form-group">
                                                    <label for="name">Licence Date :</label>
                                                    <asp:TextBox ID="txtlicenceDate" class="form-control ui-datepicker" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtlicenceDate" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-md-12 row">
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Quantity of Molasses to be Exported (in Quintals) :</label>
                                                    <asp:TextBox ID="txtexportedQty" class="form-control" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtexportedQty" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                                <div class="col-md-4 form-group">
                                                </div>
                                                <div class="col-md-4 form-group">
                                                </div>


                                            </div>
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Place to which Molasses is to be Exported</h1>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">House No.</label>

                                                        <asp:TextBox class="form-control" ID="txtHouseNo_C" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHouseNo_C" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Street and Landmark:</label>

                                                        <asp:TextBox class="form-control" ID="txtStreet_C" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtStreet_C" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">District</label>

                                                        <asp:DropDownList class="form-control" ID="ddlDistrict_C" runat="server" OnSelectedIndexChanged="ddlDistrict_C_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDistrict_C" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>


                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Mandal</label>

                                                        <asp:DropDownList class="form-control" ID="ddlMandal_C" runat="server" OnSelectedIndexChanged="ddlMandal_C_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandal_C" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Village</label>

                                                        <asp:DropDownList class="form-control" ID="ddlVillage_C" runat="server">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlVillage_C" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">PIN Code</label>

                                                        <asp:TextBox class="form-control" ID="txtPincode_C" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPincode_C" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Name and Address of the person </h1>
                                                </div>
                                                <div class="col-md-12 row">

                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Name :</label>
                                                        <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtName" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">House No.</label>

                                                        <asp:TextBox class="form-control" ID="txtHHouseNo" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtHHouseNo" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Street and Landmark:</label>

                                                        <asp:TextBox class="form-control" ID="txtHStreet" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtHStreet" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">District</label>

                                                        <asp:DropDownList class="form-control" ID="ddlHDistrict" runat="server" OnSelectedIndexChanged="ddlHDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlHDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                   
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Mandal</label>

                                                        <asp:DropDownList class="form-control" ID="ddlHMandal" runat="server" OnSelectedIndexChanged="ddlHMandal_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlHMandal" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Village</label>

                                                        <asp:DropDownList class="form-control" ID="ddlHVillage" runat="server">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlHVillage" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                               </div>
                                               <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">PIN Code</label>

                                                        <asp:TextBox class="form-control" ID="txtHPincode" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtHPincode" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                   </div>
                                                
                                            </div>

                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Period for which the Licence is Required </h1>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Licence StartDate :</label>
                                                    <asp:TextBox ID="txtLicenceStartDate" class="form-control ui-datepicker" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtLicenceStartDate" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Licence EndDate :</label>
                                                    <asp:TextBox ID="txtLicenceendDate" class="form-control ui-datepicker" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtLicenceendDate" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Reasons for Exporting Molasses:</label>
                                                    <asp:TextBox ID="txtReasonsimport" class="form-control" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtReasonsimport" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="M5tab2" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
                                                <div class="col-md-12 row">
                                                    <div class="pagetitle">
                                                        <h1>Stock Details :</h1>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <label for="name">Opening Stock of Molasses :</label>
                                                        <asp:TextBox ID="txtopeningstockmolasses" class="form-control ui-datepicker" runat="server" onkeyup="calculateTotal()"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtopeningstockmolasses" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <label for="name">Molasses Production of current Finicial Year :</label>
                                                        <asp:TextBox ID="txtMolassesProductionCFY" class="form-control ui-datepicker" runat="server" onkeyup="calculateTotal()"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtMolassesProductionCFY" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <label for="name">Dispatch of Molasses from current Finicial Year :</label>
                                                        <asp:TextBox ID="txtDispatchOfMoLasses" class="form-control ui-datepicker" runat="server" onkeyup="calculateTotal()"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtDispatchOfMoLasses" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <label for="name">Closing stock of molasses from current Finicial Year :</label>
                                                        <asp:TextBox ID="txtClosingStockMolasses" class="form-control ui-datepicker" runat="server" onkeyup="calculateTotal()"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtClosingStockMolasses" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <label for="name">Expected Molasses production from current Finicial Year :</label>
                                                        <asp:TextBox ID="txtExpectedMolassesCFY" class="form-control ui-datepicker" runat="server" onkeyup="calculateTotal()"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtExpectedMolassesCFY" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <label for="name">Expected Molasses production from next Finicial Year :</label>
                                                        <asp:TextBox ID="txtExpectedMolassesNFY" class="form-control ui-datepicker" runat="server" onkeyup="calculateTotal()"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtExpectedMolassesNFY" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <label for="name">Total :</label>
                                                        <asp:TextBox ID="txtTotal" class="form-control ui-datepicker" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtTotal" ErrorMessage="This field cannot be blank." ValidationGroup="M5Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="M5tab3" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
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

                                                </div>
                                                <div class="content col-lg-12 text-center">
                                                    <asp:Button ID="btnM5" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnM5_Click" />
                                                    <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="M5Submit"/>
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

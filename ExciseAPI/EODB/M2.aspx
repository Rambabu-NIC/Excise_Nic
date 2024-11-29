<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EOB.Master" CodeBehind="M2.aspx.cs" Inherits="ExciseAPI.EODB.M2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">

            <h1>Molasses_M2</h1>

        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                             <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnM2tab1" OnClick="btnM2tab1_Click" Enabled="true" />
                                    </li>
                                   
                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnM2tab2" OnClick="btnM2tab2_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="M2tab1" class="tab-content" runat="server" visible="true">
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


                                <div class="pagetitle">
                                    <h1>Location where molasses will be kept:</h1>
                                </div>
                                <br />
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">House No.</label>

                                        <asp:TextBox class="form-control" ID="txtHouseNo" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtHouseNo" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Road/Street/Locality:</label>

                                        <asp:TextBox class="form-control" ID="txtStreet" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStreet" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">District</label>

                                        <asp:DropDownList class="form-control" ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">


                                    <div class="col-md-4 form-group">
                                        <label for="name">Mandal</label>

                                        <asp:DropDownList class="form-control" ID="ddlMandal" runat="server" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMandal" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Village</label>

                                        <asp:DropDownList class="form-control" ID="ddlVillage" runat="server">
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlVillage" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <div class="col-md-12 row">

                                    <div class="col-md-6 form-group">
                                        <label for="name">Approximate stock of molasses on the commencement of the required licence (in - Quintals/Tons)</label>

                                        <asp:TextBox class="form-control" ID="txtMolassesQuintals" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMolassesQuintals" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">
                                            Total quantity of molasses that would be received during the term of the<br />
                                            licence in :</label>

                                        <asp:TextBox class="form-control" ID="txtMolassesLicense" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMolassesLicense" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Maximum quantity of molasses to be possessed at any one time in quintals:</label>

                                        <asp:TextBox class="form-control" ID="txtMolassesQty" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMolassesQty" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Details of purposes for which molasses will be used:</label>

                                        <asp:TextBox class="form-control" ID="txtMolasses" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMolasses" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Quantity required annually for each such purpose (in quintals):</label>

                                        <asp:TextBox class="form-control" ID="txtRequiredQty" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtRequiredQty" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Period For Which the License Is Required:</label>

                                        <asp:TextBox class="form-control" ID="txtPeriod" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPeriod" ErrorMessage="This field cannot be blank." ValidationGroup="M2Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                </div>
                                            </div>
                                <div id="M2tab2" class="tab-content" runat="server" visible="true">
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
                                <div class="content col-lg-12 text-center">
                                    <asp:Button ID="btnM2" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnM2_Click" />
                                    <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                         
                                    </div>
                                    </div>
                                        </div>
                                         <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="M2Submit" />
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



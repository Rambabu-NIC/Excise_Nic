<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EOB.Master" CodeBehind="DSXVII.aspx.cs" Inherits="ExciseAPI.EODB.DSXVII" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">

            <h1>DS XVII Application for Licence</h1>

        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnDStab1" OnClick="btnDStab1_Click" Enabled="true" />
                                    </li>

                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnDStab2" OnClick="btnDStab2_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="DStab1" class="tab-content" runat="server" visible="true">
                                      <div class="col-md-12">
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
                                        <label for="name">Firm name:</label>

                                        <asp:TextBox class="form-control" ID="txtFirmname" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtFirmname" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">ROC Number(If company):</label>
                                        <asp:TextBox class="form-control" ID="txtRocNumber" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRocNumber" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Maximum quantity desired to be possesed in a year:</label>
                                        <asp:TextBox class="form-control" ID="txtMaxQty" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaxQty" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-12 row">
                                    <div class="pagetitle">
                                        <h1>Details of the premises to be licensed for the pupose of possession,use,manufacture or sale of Ds:</h1>
                                    </div>
                                    <br />
                                    <div class="col-md-12 row">
                                        <div class="col-md-4 form-group">
                                            <label for="name">House No.</label>

                                            <asp:TextBox class="form-control" ID="txtHouseNo" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHouseNo" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Street and Landmark:</label>

                                            <asp:TextBox class="form-control" ID="txtStreet" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStreet" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4 form-group"></div>
                                    </div>
                                    <div class="col-md-12 row">
                                        <div class="col-md-4 form-group">
                                            <label for="name">District</label>

                                            <asp:DropDownList class="form-control" ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Mandal</label>

                                            <asp:DropDownList class="form-control" ID="ddlMandal" runat="server" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlMandal" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label for="name">Village</label>

                                            <asp:DropDownList class="form-control" ID="ddlVillage" runat="server">
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlVillage" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 row">

                                    <div class="col-md-4 form-group">
                                        <label for="name">Survey No:</label>

                                        <asp:TextBox class="form-control" ID="txtSurveyNo" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSurveyNo" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Extent:</label>

                                        <asp:TextBox class="form-control" ID="txtExtent" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtExtent" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">PIN Code</label>

                                        <asp:TextBox class="form-control" ID="txtPincode" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPincode" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group d-flex align-items-center">
                                        <label for="name" class="mb-0 me-2">
                                            Is Applicant previous as exprience in this bussiness or othe bussiness:
                                        </label>
                                        <asp:RadioButtonList ID="rblIsApplicant" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                            <asp:ListItem Value="1">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rblIsApplicant" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Exprience Details</label>

                                        <asp:TextBox class="form-control" ID="txtexprienceDetails" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtexprienceDetails" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Details of Other Licences held by him:</label>
                                        <asp:TextBox class="form-control" ID="txtOtherLicences" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtOtherLicences" ErrorMessage="This field cannot be blank." ValidationGroup="DSSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4 form-group">
                                    </div>
                                    <div class="col-md-4 form-group">
                                    </div>
                                </div>



                            </div>
                                            </div>
                                         <div id="DStab2" class="tab-content" runat="server" visible="true">
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
                            <div class="content col-lg-12 text-center" align="center">
                                <asp:Button ID="btnM1" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnM1_Click" />
                                <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                                             </div>
                                              </div>
                                        </div>
                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="DSSubmit" />
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



<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="M1_Preview.aspx.cs" Inherits="ExciseAPI.EODB.M1_Preview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>Molasses_M1 Preview</h1>
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
                                        <label for="name">Name of the Sugar/Gur factory:</label>
                                        <asp:Label ID="lblSugarFactory" runat="server"></asp:Label>

                                    </div>
                                </div>
                                <div class="pagetitle">
                                    <h1>Location of the factory:</h1>
                                </div>
                                <br />
                                <div class="col-md-12 row">

                                    <div class="col-md-4 form-group">
                                        <label for="name">District</label>

                                        <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Mandal</label>
                                        <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Village</label>
                                        <asp:Label ID="lblVillage" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-12 row">

                                    <div class="col-md-4 form-group">
                                        <label for="name">Survey No:</label>
                                        <asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Extent No:</label>
                                        <asp:Label ID="lblExtent" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-12 form-group d-flex align-items-center">
                                        <label for="name" class="mb-0 me-2">
                                            Whether the applicant is owner or a person in charge of the factory:
       
                                        </label>
                                        <asp:Label ID="lblrblOwnLand" runat="server"></asp:Label>

                                    </div>
                                </div>
                                <div class="pagetitle">
                                    <h1>If Owner, Details thereof:</h1>
                                </div>
                                <br />
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Mobile Number:</label>
                                        <asp:Label ID="lbltxtOMobile" runat="server"></asp:Label>

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Pan Number:</label>
                                        <asp:Label ID="lbltxtOPan" runat="server"></asp:Label>

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Aadhar Number</label>
                                        <asp:Label ID="lbltxtOAadhar" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">GST-IN:</label>
                                        <asp:Label ID="lbltxtOGst" runat="server"></asp:Label>

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Email:</label>
                                        <asp:Label ID="lbltxtOEmail" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-4 form-group">
                                        <label for="name">Details of the use or uses which molasses will be put to:</label>
                                        <asp:Label ID="lbltxtMolasse" runat="server"></asp:Label>

                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label for="name">Quantity required annually for such use case:</label>
                                        <asp:Label ID="lbltxtAnualQty" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-12 form-group">
                                        <label for="name">Details of arrangements for the storage of molasses whether pucca built tanks or steel tanks are provided for the storage:</label>
                                        <asp:Label ID="lblrblstoragetank" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Period for which the licence is required:</label>
                                        <asp:Label ID="lbltxtPeriodLicense" runat="server"></asp:Label>

                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Total quantity of molasses expected to be produced during the year:</label>
                                        <asp:Label ID="lbltxtMProduced" runat="server"></asp:Label>

                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="pagetitle">
                                        <h1>Documents :</h1>
                                    </div>
                                    <div id="divuploadedDocuments" runat="server" visible="false">
                                        <div class="content table-container">

                                            <div style="width: 100%; overflow: auto;">
                                                <asp:GridView ID="gvM1Documents" CssClass="custom-table text-nowrap"
                                                    runat="server" AutoGenerateColumns="false" ShowFooter="false" AutoGenerateDeleteButton="false" EmptyDataText="No Documents are available to show" EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True" OnRowCommand="gvM1Documents_RowCommand">
                                                   <%-- OnRowCommand="gvaddrecordsofLOI_RowCommand"--%>
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
                                                       
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

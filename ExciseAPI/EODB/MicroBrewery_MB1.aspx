<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="MicroBrewery_MB1.aspx.cs" Inherits="ExciseAPI.EODB.MicroBrewery_MB1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>FORM-MB</h1>
            <h5>Application for prior Clearance for grant of licence for Microbrewery/standalone Microbrewery</h5>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnMBtab1" OnClick="btnMBtab1_Click" Enabled="true" />
                                    </li>

                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnMBtab2" OnClick="btnMBtab2_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="MBtab1" class="tab-content" runat="server" visible="true">
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
                                                    <label for="name">Notification Number:</label>

                                                    <asp:TextBox ID="txtNotify_no" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtNotify_no" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Firm name:</label>

                                                    <asp:TextBox class="form-control" ID="txtFirmname" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmname" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">ROC Number(If company):</label>

                                                    <asp:TextBox class="form-control" ID="txtRocNumber" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRocNumber" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                           

                                            <div class="col-md-12 row">

                                               
                                                <div class="col-md-6 form-group">
                                                    <label for="name">Details of Hotel/Restaurant:</label>

                                                    <asp:TextBox class="form-control" ID="txtRestaurant" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRestaurant" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-6 form-group">
                                                    <label for="name">Trade License from GHMC, Local authority:</label>

                                                    <asp:TextBox class="form-control" ID="txtTradeLicense" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTradeLicense" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">

                                                
                                                <div class="col-md-6 form-group">
                                                    <label for="name">Details of plinth area of premises to be licensed and its location:</label>

                                                    <asp:TextBox class="form-control" ID="txtPlinthArea" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPlinthArea" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-6 form-group">
                                                    <label for="name">Details of any other licence held by him:</label>

                                                    <asp:TextBox class="form-control" ID="txtOtherLicense" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOtherLicense" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">

                                                
                                                <div class="col-md-6 form-group">
                                                    <label for="name">Date on which he likely to commence business:</label>

                                                    <asp:TextBox class="form-control" ID="txtCommenceBusiness" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCommenceBusiness" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-6 form-group d-flex align-items-center">
                                                    <label for="name" class="mb-0 me-2">Whether attached to Bar or Standalone:</label>

                                                    <asp:RadioButtonList ID="rblsecuretherawmaterial" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0">Bar</asp:ListItem>
                                                        <asp:ListItem Value="1">Standalone</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rblsecuretherawmaterial" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">

                                                
                                                <div class="col-md-6 form-group">
                                                    <label for="name">if bar, enter the details of bar:</label>

                                                    <asp:TextBox class="form-control" ID="txtBar" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBar" ErrorMessage="This field cannot be blank." ValidationGroup="MB1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <br />
                                           
                                        </div>
                                        <div id="MBtab2" class="tab-content" runat="server" visible="true">
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
                                                <asp:Button ID="btnMB" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnMB_Click" />
                                                <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="MB1Submit" />
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

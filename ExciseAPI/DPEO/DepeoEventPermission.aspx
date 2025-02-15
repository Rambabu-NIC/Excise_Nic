﻿<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DepeoEventPermission.aspx.cs" Inherits="ExciseAPI.DPEO.DepeoEventPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Event Permits</div>
            <div class="content">
                 <div id="div" style="max-height:600px;overflow-x:auto; overflow-y:hidden;" >
                <asp:GridView ID="GvSupplier" CssClass="table table-striped table-bordered nowrap gvv"
                    runat="server" AutoGenerateColumns="false" ShowFooter="false" AutoGenerateDeleteButton="false" EmptyDataText="No Details are available to show"
                    EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True" ClientIDMode="Static" OnPageIndexChanging="GvSupplier_PageIndexChanging"
                    AllowPaging="True" PageSize="5" OnRowCommand="GvSupplier_RowCommand" OnRowDataBound="GvSupplier_RowDataBound">
                    <HeaderStyle BackColor="#999872" />
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application No">
                            <ItemTemplate>
                                <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("AppReg_NO") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="btnUpdate" runat="server" Visible="true" CommandName="View" ForeColor="Blue" CausesValidation="false" Text='<%#Eval("AppReg_NO")%>'></asp:LinkButton>
                                <asp:Label ID="LblAppID" runat="server" Text='<%# Bind("Reg_No") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Application Name & Premises">
                            <ItemTemplate>

                                <asp:Label ID="lblSuppCode" runat="server" Text='<%# Bind("App_Name") %>'></asp:Label>
                                &nbsp;
                                                                     <asp:Label ID="lblMandcode" runat="server" Text='<%# Bind("Res_Address") %>'></asp:Label>&nbsp;
                                                                      <asp:Label ID="lblLicNo" runat="server" Text='<%# Bind("Name_Premises") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Applicant Name">
                            <ItemTemplate>
                                <asp:Label ID="lblSuppCode" runat="server" Text='<%# Bind("App_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Res_Address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Venue">
                            <ItemTemplate>
                                <asp:Label ID="lblVenue" runat="server" Text='<%# Bind("Name_Premises") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Event/Occasion">
                            <ItemTemplate>
                                <asp:Label ID="lblOccasion" runat="server" Text='<%# Bind("Event_Occasion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Of Event">
                            <ItemTemplate>
                                <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Permit fee paid">
                            <ItemTemplate>
                                <asp:Label ID="lblAdd" runat="server" Text='<%# Bind("License_Fee") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Documents">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblLock" runat="server" CommandName="ViewDoc" Visible="true"
                                    Text="View" ForeColor="Blue"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Applicaton">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" Visible="true"
                                    Text="View" ForeColor="Blue"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- <asp:TemplateField HeaderText="Transfer Application">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_TransDPEO" runat="server" Width="90px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:LinkButton ID="lbltrsnfer" runat="server" Visible="true"
                                    Text="Transfer" ForeColor="Blue" OnClick="btnTransfer_Click"></asp:LinkButton>
                                <asp:Label ID="lblTransDPEO" Text='<%# Bind("ExDist_Cd")%>' Visible="false"
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnApprove_Click"></asp:LinkButton>
                                &nbsp;&nbsp;
                                                                     <asp:LinkButton ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" OnClick="btnReject_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--<div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Get Details" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btnGet_Click" />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>--%>
            </div>
                </div>
            <div class="content">
                <div class="table-responsive dt-responsive">
                    <asp:GridView ID="GvTransApp" CssClass="table table-striped table-bordered nowrap gvv"
                        runat="server" AutoGenerateColumns="false" ShowFooter="false" AutoGenerateDeleteButton="false" EmptyDataText="No Details are available to show"
                        EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True" ClientIDMode="Static"
                        AllowPaging="True" PageSize="5" OnPageIndexChanging="GvTransApp_PageIndexChanging"
                        OnRowCommand="GvTransApp_RowCommand" OnRowDataBound="GvTransApp_RowDataBound">
                        <HeaderStyle BackColor="#999872" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Application No">
                                <ItemTemplate>
                                    <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("AppReg_NO") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="btnUpdate" runat="server" Visible="true" CommandName="View" ForeColor="Blue" CausesValidation="false" Text='<%#Eval("AppReg_NO")%>'></asp:LinkButton>
                                    <asp:Label ID="LblAppID" runat="server" Text='<%# Bind("Reg_No") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Application Name & Premises">
                                <ItemTemplate>

                                    <asp:Label ID="lblSuppCode" runat="server" Text='<%# Bind("App_Name") %>'></asp:Label>
                                    &nbsp;
                                                                     <asp:Label ID="lblMandcode" runat="server" Text='<%# Bind("Res_Address") %>'></asp:Label>&nbsp;
                                                                      <asp:Label ID="lblLicNo" runat="server" Text='<%# Bind("Name_Premises") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Aadhar Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDistcode" runat="server" Text='<%# Bind("Aadhaar") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Event/Occasion">
                                <ItemTemplate>
                                    <asp:Label ID="lblOccasion" runat="server" Text='<%# Bind("Event_Occasion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Of Event">
                                <ItemTemplate>
                                    <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--   <asp:TemplateField HeaderText="Event Slot">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSlot" runat="server" Text='<%# Bind("Eventtime") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Permit fee paid">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdd" runat="server" Text='<%# Bind("License_Fee") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--       <asp:TemplateField HeaderText="Event Permission">
                                                                <ItemTemplate>
                                                                    <asp:RadioButtonList ID="rbdstatus" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                            <%--       <asp:TemplateField HeaderText="Permit View">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnUpdate" runat="server" Visible="true" CommandName="View" Text="View" ForeColor="Blue"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Inspection View">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnInsview" runat="server" Visible="true" CommandName="InsView" Text="View" ForeColor="Blue"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Documents">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblLock" runat="server" CommandName="ViewDoc" Visible="true"
                                        Text="View" ForeColor="Blue"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Applicaton">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" Visible="true"
                                        Text="View" ForeColor="Blue"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--          <asp:TemplateField HeaderText="Transfer Application">
                                                                <ItemTemplate>
                                                                        <asp:DropDownList ID="ddl_TransDPEO"  runat="server" Width="90px">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        
                                                     
                                                    </asp:DropDownList>
                                                     <asp:LinkButton ID="lbltrsnfer" runat="server" Visible="true"
                                                                        Text="Transfer" ForeColor="Blue" OnClick="btnTransfer_Click"></asp:LinkButton>
                                                                           <asp:Label ID="lblTransDPEO" Text='<%# Bind("")%>' Visible="false"
                                                        runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <%-- <asp:LinkButton ID="lblLock" runat="server" CommandName="ViewDoc" Visible="true"
                                                                        Text="View"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnApprove_Click"></asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <br />
                                    <br />
                                    <br />
                                                                     <asp:LinkButton ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" OnClick="btnReject_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        </div>
   
        <div class="w-100 fl container-fluid" runat="server" id="pannelOK" visible="false">
            <div class="block black bg-white">
                <div class="head">Details of Premises to be Licensed</div>
                <div class="content">
                    <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">
                            Name of Applicant</label>
                        <div class="col-md-3">
                            <asp:DropDownList Enabled="false" ID="DropDownList1" runat="server">
                                <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Miss" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Smt" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                              <asp:TextBox ID="txtAppliName" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <label class="col-md-3 col-form-label text-right">
                            Aadhaar Number</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtAdharNum" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    
                     <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">
                       Mobile No</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtMobile" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    
                  
                        <label class="col-md-3 col-form-label text-right">Email</label>
                         <div class="col-md-3">
                            <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                         
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Label ID="lblReg" Visible="false" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lblTDPEO" Visible="false" runat="server" Text="Label"></asp:Label>
                  <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">Age</label>
                       <div class="col-md-3">
                            <asp:TextBox ID="txtAge" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    
                    <label class="col-md-3 col-form-label text-right">Father's Name</label>
                       <div class="col-md-3">
                        
                            <asp:TextBox ID="txtFatherName" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                   
                      </div>
                   <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">Residential Address</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtAdd" CssClass="form-control input-b-b" runat="server" TextMode="MultiLine" MaxLength="200" ReadOnly="true"></asp:TextBox>
                        </div>
                   
                 
                        <label class="col-md-3 col-form-label text-right">House/Door Number</label>
                       <div class="col-md-3">
                            <asp:TextBox ID="txtHsNum" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                       
                    <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">Name Of the Premises</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtNmePrem" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    
                    <label class="col-md-3 col-form-label text-right">Street</label>
                         <div class="col-md-3">
                            <asp:TextBox ID="txtStreet" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                <br />
                    <div class="block black bg-white">
                        <div class="head">Boundries</div>
                    </div>
                    <div class="content">
                            <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">East</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtEast" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                       
                        <label class="col-md-3 col-form-label text-right">West</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtWest" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">North</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtNorth" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        
                       <label class="col-md-3 col-form-label text-right">South</label>
                             <div class="col-md-3">
                                <asp:TextBox ID="txtSouth" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">Revenue District</label>
                           <div class="col-md-3">
                                <asp:TextBox ID="lblRDist" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                         <label class="col-md-3 col-form-label text-right">Mandal</label>
                           <div class="col-md-3">
                                <asp:TextBox ID="lblbRMand" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                       <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">Village/Locality</label>
                             <div class="col-md-3">
                                <asp:TextBox ID="lblbRVill" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        
                        <label class="col-md-3 col-form-label text-right">Excise District</label>
                             <div class="col-md-3">
                                <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblExDist" runat="server"></asp:Label>
                            </div>
                        </div>
                         <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">Excise Station</label>
                           <div class="col-md-3">
                                <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblExStation" runat="server"></asp:Label>
                                <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                            </div>
                      
                        <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">
                                Whether the Permises<br />
                                is in Conformity with the Rule 7<br />
                                of Telangana Excise(Grand<br />
                                of Licence<br />
                                                                                of Selling by
                               
                                In-House&Conditions of<br />
                              
                                licence Rules 2005)</label>
                          <div class="col-md-3">
                                <asp:Label ID="lblRule7" runat="server"></asp:Label>
                            </div>
                        
                        <label class="col-md-3 col-form-label text-right">Date And Time of Event</label>
                           <div class="col-md-3">
                                <asp:Label ID="ddlEvntTm" Enabled="false" runat="server"></asp:Label>
                                <asp:Label ID="txtEvnDate" Enabled="false" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">Type Of Event</label>
                            <div class="col-md-3">
                                <asp:Label ID="Label5" Enabled="false" runat="server" Text=""></asp:Label>
                            </div>
                       
                         <label class="col-md-3 col-form-label text-right">Event On Occasion Of</label>
                           <div class="col-md-3">
                                <asp:Label ID="txtEvent" Enabled="false" MaxLength="150"
                                    runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">Licence Fee</label>
                            <div class="col-md-3">
                                <asp:Label ID="lblFee" Enabled="false" runat="server" Text=""></asp:Label>
                            </div>
                       
                        <label class="col-md-3 col-form-label text-right">Licence Fee</label>
                            <div class="col-md-3">
                                <asp:Label ID="Label1" Enabled="false" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="block black bg-white">
                        <div class="head">Date and Remarks Entered by SHO</div>
                    </div>
                    <div class="content">
                        <div class="form-group col-xs-12 col-sm-6 col-md-12 col-lg-12 p-0 xs-field">
                            <label class="col-xs-6 col-sm-6 col-md-6 col-lg-4">Inspection
                                <br />
                                Date and Time  </label>
                            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-8">
                                <asp:TextBox ID="txtDtInsp" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-12 col-lg-12 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Remarks</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                                <asp:TextBox ID="txtRemarks" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="w-100 fl container-fluid">
                    <div class="block black bg-white">
                        <div class="head">Payment Details</div>
                        <div class="content">
                            <div class="form-group row ">
                                <div class="col-md-12">
                                    <asp:Repeater ID="dltPaymentDetails" runat="server" Visible="false">
                                        <ItemTemplate>
                                            <p><%#Eval("PaymentDetails")%></p>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:Label ID="lblPaymentDetailsNo" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

               
            </div>
        </div>
             
    </div>
     <div class="w-100 fl container-fluid" runat="server" visible="false" id="RegDoc">
            <div class="block black bg-white">
                 <div class="head">Upload Documents</div>
    <div class="content">
                  
                        <div class="col-md-12">
                            <div class="card">
                              
                                <div class="col-md-12">
                                    <asp:Label ID="lblDocReg" runat="server" Text="Label"></asp:Label>
                                    <asp:GridView ID="grddocs" CssClass="table table-striped table-bordered nowrap gvv"
                                        runat="server" AutoGenerateColumns="false" ShowFooter="false" AutoGenerateDeleteButton="false" EmptyDataText="No Details are available to show"
                                        EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True" ClientIDMode="Static" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                        OnRowCommand="grddocs_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sno" ItemStyle-VerticalAlign="Top">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Uploaded Documents"
                                                ItemStyle-VerticalAlign="Top">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldoccd" runat="server" Text='<%# Bind("UploadDco_Code") %>'
                                                        Visible="false"></asp:Label>
                                                    <asp:Label ID="lbldocname" runat="server" Text='<%# Bind("UploadDco_Name") %>'></asp:Label>
                                                    <asp:Label ID="lbldocsno" runat="server" Text='<%# Bind("UploadDocs_Sno") %>'
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Documents View" ItemStyle-VerticalAlign="Top">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnView" runat="server" CommandName="View" Text="View"></asp:LinkButton>
                                                    <asp:Label ID="lbl_Apptype" runat="server" Text='<%#Eval("Application_Type")%>'
                                                        Visible="false"></asp:Label>
                                                    <asp:Label ID="lblAppid" runat="server" Text='<%# Bind("Reg_No") %>'
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle BackColor="#378686" Font-Bold="True" ForeColor="White" />
                                        <EmptyDataRowStyle HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            No Records
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
         </div>
</asp:Content>

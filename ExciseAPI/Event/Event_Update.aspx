<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master"  CodeBehind="Event_Update.aspx.cs" Inherits="ExciseAPI.Event.Event_Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <style>
        .eventlinkbtn {
            padding: 5px 10px;
            font-size: 14px;
            line-height: 2;
            border-radius: 5px;
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Event Update</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date Of Event</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtDate" CssClass="form-control input-b-b" runat="server"></asp:TextBox>

                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtMobileNumber" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                          <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobileNumber"
                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">E-Mail ID</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            Display="Dynamic" ErrorMessage="Invalid email address" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                            ForeColor="Red" Display="Dynamic" ErrorMessage="Required" />
                    </div>
                </div>
            </div>
            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnUpdate" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server" OnClick="btnUpdate_Click"
                        Text="Get Details" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
            <asp:HiddenField ID="hf" runat="server" />
        </div>


    </div>
    <div class="w-100 fl container-fluid" id="divEvent" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="head">Event Update</div>
            <div class="content">
                <asp:GridView ID="gvEvent" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                    <%--OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand"--%>
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AppReg_No" HeaderText="ApplicationNo" />
                        <asp:BoundField DataField="App_Name" HeaderText="Applicant Name" />
                        <asp:BoundField DataField="FName" HeaderText="FatherName" />
                        <asp:BoundField DataField="Mob_No" HeaderText="Mobile No" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                         <asp:BoundField DataField="Res_Address" HeaderText="Address" />
                         <asp:BoundField DataField="DateOfEvent" HeaderText="DateOfEvent" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>
                </asp:GridView>


            </div>
        </div>
    </div>

</asp:Content>



<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Public_Complaint_Form.aspx.cs" Inherits="ExciseAPI.ECMS.Public_Complaint_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
       
            <h3>Public Complaint Form</h3>
       
        <div class="block black bg-white">                                                                              
            <div class="head">Personal Details</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtName" CssClass="form-control input-b-b" runat="server" MaxLength="75"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Phone<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtPhone" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Aadhaar</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtAadhaar" CssClass="form-control input-b-b" runat="server" MaxLength="12"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Email<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server" MaxLength="75"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="head">Complaint Details</div>
            <div class="content">


                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlDist" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlMand" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlMand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlVill" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Complaint Details<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtComplaintdtls" TextMode="MultiLine" CssClass="form-control input-b-b" runat="server" MaxLength="1000"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Attachment<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:FileUpload ID="FileUpload1" CssClass="form-control input-b-b" runat="server" />
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Complaint Source<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                       <asp:DropDownList ID="ddlComplaintSource" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

        </div>
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btn_Submit_Click" />


        </div>
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
        </div>
    </div>
    <asp:HiddenField ID="hf" runat="server" />


</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ControlRoomForm.aspx.cs" Inherits="ExciseAPI.ECMS.ControlRoomForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .com_Label {
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 col-sm-12 txt-cnt">
        <asp:Label ID="lblResultMessage" runat="server" Style="text-align: center"></asp:Label>
    </div>
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Control Room Form</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">ComplaintID</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtComplaintID" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Complaint Source<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlComplaintSource" runat="server" class="form-control input-b-b" Readonly="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Complaint Name<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtComplaintName" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">District<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlDist" runat="server" class="form-control input-b-b" ReadOnly="true" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Mandal<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlMand" runat="server" class="form-control input-b-b" ReadOnly="true" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Village<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlVill" runat="server" class="form-control input-b-b" ReadOnly="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Complaint Details<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtComplaintdtls" TextMode="MultiLine"
                            Rows="1" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Attachment<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:LinkButton ID="linklblAttachment" runat="server" EnableTheming="True"
                            OnClick="linklblAttachment_Click"
                            ToolTip="Download "></asp:LinkButton>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Status<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-b-b" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div runat="server" id="divreason" visible="false">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Reason<span style="color: Red">*</span></label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:DropDownList ID="ddlReason" runat="server" class="form-control input-b-b">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Complaint Type<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlComplaintType" runat="server" class="form-control input-b-b" OnSelectedIndexChanged="ddlComplaintType_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div runat="server" id="divvoilation" visible="false">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">A4 Shop Violation<span style="color: Red">*</span></label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:DropDownList ID="ddlAVoilation" runat="server" class="form-control input-b-b">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div runat="server" id="divshop" visible="false">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">2B Shop Violation<span style="color: Red">*</span></label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:DropDownList ID="ddlBVoilation" runat="server" class="form-control input-b-b">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div runat="server" id="divOthers" visible="false">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Remarks<span style="color: Red">*</span></label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtOthers" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Assigned To<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlAssignedto" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4 com_Label">Time Stamp</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTimestamp" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>   
    <div class="w-100 fl container-fluid" id="divatr" runat="server" visible="false">

        <div class="block black bg-white">
            <div class="head">ATR</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">ATR</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtATR" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">ATR Upload</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:LinkButton ID="linkbtnATR" runat="server" EnableTheming="True"
                            OnClick="linkbtnATR_Click"
                            ToolTip="Download "></asp:LinkButton>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Feedback<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtFeedback" CssClass="form-control input-b-b" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
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
    <asp:HiddenField ID="hf" runat="server" />
</asp:Content>


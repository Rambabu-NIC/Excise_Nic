<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="EnquiryForm.aspx.cs" Inherits="ExciseAPI.ECMS.EnquiryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script type="text/javascript">

        function pageLoad() {
            $(document).ready(function () {
                $("input[id*='txtInspectionDate']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
                //$("input[id*='txtTo']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 col-sm-12 txt-cnt">
        <asp:Label ID="lblResultMessage" runat="server" Style="text-align: center"></asp:Label>
    </div>
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Enquiry Form</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">ComplaintID</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtComplaintID" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Complaint Details</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtComplaintdtls" TextMode="MultiLine" Rows="1" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Complaint Type</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlComplaintType" runat="server" class="form-control input-b-b" ReadOnly="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Attachments</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:Label ID="lblAttachment" runat="server"></asp:Label>
                        <%--<asp:FileUpload ID="FileUpload1" CssClass="form-control input-b-b" runat="server" Readonly="true" />--%>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlMand" runat="server" class="form-control input-b-b" ReadOnly="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlVill" runat="server" class="form-control input-b-b" ReadOnly="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Received Time Stamp</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTimestamp" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Status<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Assigned To Enquiry Officer<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlAssignedto" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="w-100 fl container-fluid">
                <div class="block black bg-white">
                    <div class="head">ATR Preliminary As Submitted By The Enquiry Officer</div>
                    <div class="content">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Inspection Date<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtInspectionDate" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Inspection Officer<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtIOfficer" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Crime Detection Status<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:DropDownList ID="ddl_Crime" runat="server" class="form-control input-b-b" OnSelectedIndexChanged="ddl_Crime_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="divdetected" runat="server" visible="false">
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Crime Location<span style="color: Red">*</span></label>
                                <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                    <asp:TextBox ID="txtCrimeLocation" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">COR No<span style="color: Red">*</span></label>
                                <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                    <asp:TextBox ID="txtCOR" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Persons Arrested<span style="color: Red">*</span></label>
                                <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                    <asp:TextBox ID="txtParrested" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Contraband Seized<span style="color: Red">*</span></label>
                                <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                    <asp:TextBox ID="txtContrabandSeized" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Contraband Value(INR)<span style="color: Red">*</span></label>
                                <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                    <asp:TextBox ID="txtCValue" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%--<div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Remarks<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtRemarks" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            </div>
                        </div>--%>
                        </div>
                    </div>
                </div>
            </div>
            <div class="w-100 fl container-fluid" id="divATR" runat="server" visible="false">
                <div class="block black bg-white">
                    <div class="head">ATR</div>
                    <div class="content">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">ATR<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtATR" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Cases Booked<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtCasesBooked" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Persons Arrested<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtPersonsArrested" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Seizure Type<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:DropDownList ID="ddlSeizure" runat="server" class="form-control input-b-b" OnSelectedIndexChanged="ddlSeizure_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field" id="divvehicle" runat="server" visible="false">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">No Of Vehicles Seized<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtVehiclesSeized" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field" id="divContraband" runat="server" visible="false">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Contraband Type<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:DropDownList ID="ddlContraband" runat="server" class="form-control input-b-b" OnSelectedIndexChanged="ddlContraband_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field" id="divContraband1" runat="server" visible="false">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Quantity Seized(litres)<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtQuantity" CssClass="form-control input-b-b" runat="server">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field" id="divIllicit" runat="server" visible="false">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">Illicit Liquor<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:DropDownList ID="ddlIllicitLiquor" runat="server" class="form-control input-b-b">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field" id="divNDPS" runat="server" visible="false">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">NDPS<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:DropDownList ID="ddlNdps" runat="server" class="form-control input-b-b">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">U/S<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:TextBox ID="txtUndersection" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-5 col-sm-6 col-md-6 col-lg-5">ATR Upload<span style="color: Red">*</span></label>
                            <div class="col-xs-7 col-sm-6 col-md-6 col-lg-7">
                                <asp:FileUpload ID="FileUpload_ATR" CssClass="form-control input-b-b" runat="server" />
                            </div>
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
    </div>
    <asp:HiddenField ID="hf" runat="server" />


</asp:Content>


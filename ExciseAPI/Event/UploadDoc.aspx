<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="UploadDoc.aspx.cs" Inherits="ExciseAPI.Event.UploadDoc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Upload Documents</div>
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-12">
                        <div class="pcoded-inner-content">
                            <div class="main-body">
                                <div class="page-wrapper">
                                    <div class="page-header">
                                        <div class="row m-b-20">
                                            <div class="col-md-12">
                                               <%-- <h4 class="text-center"></h4>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="page-body">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="card">
                                                    <asp:Panel ID="Panel1" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">
                                                        <%-- <div class="card-block">--%>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <asp:HiddenField ID="hf" runat="server" />
                                                                <span style="color: Red">Note: Marked with * are Mandatory</span>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <div class="col-md-3   text-center">
                                                                <label>
                                                                    Select Document:<span style="color: Red">*</span></label>
                                                            </div>
                                                            <div class="col-md-4 text-left">
                                                                <asp:DropDownList CssClass="form-control" CausesValidation="True" ID="ddl_Doc" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="form-group row">
                                                            <div class="col-md-3   text-center">
                                                                <label>
                                                                    File Upload:<span style="color: Red">*</span></label>
                                                            </div>
                                                            <div class="col-md-4 text-center">
                                                                <asp:FileUpload ID="FileUpload_docs" runat="server" />
                                                                <br />
                                                                <span style="color: Red">(Only PDF,JPG,JPEG,PNG files are allowed(2MB))</span>
                                                                <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidatorr" runat="server" ControlToValidate="FileUpload_docs"
                                            ErrorMessage="Only PDF files are allowed" ValidationExpression="(.*\.([Pp][Dd][Ff])$)">  
                                        </asp:RegularExpressionValidator>--%>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <div class="col-md-2   text-center">
                                                            </div>
                                                            <div class="col-md-8 text-center">
                                                                <asp:Button ID="btnSave" runat="server" Text="Upload" OnClick="btnSave_Click" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10"
                                                                    Visible="true" />
                                                            </div>
                                                        </div>
                                                        <div class="content text-center">

                                                            <div class="col-xs-12 col-sm-12 txt-cnt">
                                                                <asp:Label ID="lblmsg" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                                <asp:Image ID="Image2" runat="server" />
                                                                <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                                                    OnClick="btnImgRefresh_Click" />
                                                                <span class="form-bar"></span>
                                                                <div class="container-fluid text-center">
                                                                    <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha" AutoCompleteType="Disabled" MaxLength="6"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="captch_FilteredTextBoxExtender1" runat="server"
                                                                        BehaviorID="captch_FilteredTextBoxExtender" FilterType="numbers"
                                                                        TargetControlID="captch"></ajaxToolkit:FilteredTextBoxExtender>
                                                                    <span class="form-bar"></span>
                                                                </div>
                                                            </div>


                                                        </div>
                                                        <div class="form-group row">
                                                            <div class="col-md-12 text-center">
                                                                <asp:Button ID="btnPrivious" runat="server" Text="Previous" OnClick="btnPrvious_Click"
                                                                    CssClass="btn btn-secondary b b-btn" Visible="true" />
                                                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CssClass="btn btn-secondary b b-btn"
                                                                    Visible="true" />
                                                                <%-- <asp:Button ID="btnSubmitreg" runat="server" CssClass="btn btn-primary b b-btn" 
                                            OnClick="btnSubmit_Click" Text="Submit" Visible="true" />--%>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-4">
                                                            </div>
                                                            <div class="col-md-12">
                                                                <asp:GridView ID="grddocs" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                                                    BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="grddocs_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sno" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldoccd" runat="server" Text='<%# Bind("UploadDco_Code") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lbldocname" runat="server" Text='<%# Bind("UploadDco_Name") %>'></asp:Label>
                                                                                <asp:Label ID="lbldocsno" runat="server" Text='<%# Bind("UploadDocs_Sno") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Documents View" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%-- <iframe id="iframedoc" runat="server" height="200px" src='<%# GetImage(Eval("UploadDco_File")) %>'
                                        width="200px"></iframe>--%>
                                                                                <asp:LinkButton ID="btnView" runat="server" CommandName="View" Text="View"></asp:LinkButton>
                                                                                <asp:Label ID="lbl_Apptype" runat="server" Text='<%#Eval("Application_Type")%>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblAppid" runat="server" Text='<%# Bind("Reg_No") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <%--  <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>&nbsp|&nbsp--%>
                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Dlt" OnClientClick="return Confirm(this)"
                                                                                    Text="Delete"></asp:LinkButton>
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

                                                    </asp:Panel>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />
                        <br />
                        <br />
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

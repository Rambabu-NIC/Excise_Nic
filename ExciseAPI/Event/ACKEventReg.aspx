<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master"  CodeBehind="ACKEventReg.aspx.cs" Inherits="ExciseAPI.Event.ACKEventReg" %>

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

<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Acknowledgement</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Application Registred Successfully</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        
                       
                </div>
                    </div>
                
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Applicantion Number is:</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:Label ID="lblInwardNo" runat="server" Font-Bold="true" ForeColor="#47a029"></asp:Label>
                        </div>
                </div>
                

            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10"  runat="server"
                     Text="Get Details" OnClick="btn_Save_Click" />
                    
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
            <asp:HiddenField ID="hf" runat="server" />
        </div>
        
    </div>
        </div>
    
</asp:content>

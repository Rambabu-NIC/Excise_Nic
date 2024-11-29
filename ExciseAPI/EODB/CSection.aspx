<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CSection.aspx.cs" Inherits="ExciseAPI.EODB.CSection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        tr {
            border-bottom: 1px solid #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                           
                            <form>
                                <table style="width: 100%">
                                    <tr>
                                        <th>Type</th>
                                        <th>Form Type</th>
                                        <th>Description</th>
                                    </tr>
                                    <tr>
                                        <td>RS-II</td>
                                        <td><a href="RS_II_ApplicationForm.aspx">RS-II</a></td>
                                        <td>Application For RS-II Form</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>RS-III</td>
                                        <td><a href="RS_III.aspx">RS-III</a></td>
                                        <td>Application For RS-III Form</td>
                                        <td></td>
                                    </tr>
                                    <%-- <tr>
                                        <td></td>
                                        <td><a href="A4(B).aspx">A4B</a></td>
                                        <td></td>

                                        <td></td>
                                    </tr>--%>
                                </table>



                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>




</asp:Content>

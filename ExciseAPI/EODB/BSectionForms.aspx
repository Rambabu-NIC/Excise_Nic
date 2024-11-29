<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master"   CodeBehind="BSectionForms.aspx.cs" Inherits="ExciseAPI.EODB.BSectionForms" %>
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
                            <%-- <center>
                            <h5 class="card-title">Application for prior Clearance for grant of licence for Microbrewery/standalone Microbrewery</h5>
                        </center>--%>

                            <form>


                                <table style="width: 100%">
                                    <tr>
                                        <th>Type</th>
                                        <th>Form Type</th>
                                        <th>Description</th>
                                    </tr>
                                    <tr>
                                        <td>M1</td>
                                        <td><a href="M1.aspx">M1</a></td>
                                        <td>Application For Molasses M1 Form</td>
                                        <td></td>
                                    </tr>
                                   <%-- <tr>
                                        <td></td>
                                        <td><a href="A4(B).aspx">A4B</a></td>
                                        <td></td>

                                        <td></td>
                                    </tr>--%>
                                    <tr>
                                        <td>M2</td>
                                        <td><a href="M2.aspx">M2</a></td>
                                        <td>Application For Molasses M2 Form</td>

                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>M4</td>
                                        <td><a href="M4.aspx">M4</a></td>
                                        <td>Application For Molasses M4 Form</td>

                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>

                                    </tr>

                                  

                                    <tr>
                                        <td>M5</td>

                                        <td><a href="M5.aspx">M5</a></td>
                                        <td>Application For Molasses M5 Form</td>
                                    </tr>
                                    
                                    
                                </table>



                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>












    
</asp:Content>


 

<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="Type_Of_Retailers.aspx.cs" Inherits="ExciseAPI.EODB.Type_Of_Retailers" %>
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
                                        <th>Retailer Type</th>
                                        <th>Form Type</th>
                                        <th>Description</th>
                                    </tr>
                                    <tr>
                                        <td>A4 Retailers</td>
                                        <td><a href="A3.aspx">A3(A)</a></td>
                                        <td>Application For A3 Form</td>
                                        <td></td>
                                    </tr>
                                   <%-- <tr>
                                        <td></td>
                                        <td><a href="A4(B).aspx">A4B</a></td>
                                        <td></td>

                                        <td></td>
                                    </tr>--%>
                                    <tr>
                                        <td></td>
                                        <td><a href="A4(A).aspx">A4(A)</a></td>
                                        <td>Application For A4A Form</td>

                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td><a href="#">A4(G)</a></td>
                                        <td>Application For A4G Form</td>

                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>

                                    </tr>

                                    <tr>
                                        <td>Bars</td>
                                        <td><a href="Bars1(A).aspx">1A</a></td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td></td>

                                        <td><a href="Bars1B.aspx">1B</a></td>
                                        <td>Application For Bars</td>
                                    </tr>
                                    <%--<tr>
                                        <td></td>

                                        <td><a href="Bars2B.aspx">2B</a></td>
                                        <td></td>
                                    </tr>--%>
                                    <tr>
                                        <td>Clubs</td>
                                        <td><a href="IHA_1.aspx">IHA-1</a></td>
                                        <td>Application For IHA1 Clubs Form</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td><a href="IHA-2.aspx">IHA-2</a></td>
                                        <td>Application For IHA2 Clubs Form</td>
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

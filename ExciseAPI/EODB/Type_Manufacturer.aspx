<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="Type_Manufacturer.aspx.cs" Inherits="ExciseAPI.EODB.Type_Manufacturer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style>
        th {
            padding: 10px; /* Adjust padding as needed */
        }
    </style>--%>
    <%-- <style>
      table, th, td {
         border:1px solid black;
      }
   </style>--%>
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
                            <div class="content">
                                <%-- <center>
                            <h5 class="card-title">Application for prior Clearance for grant of licence for Microbrewery/standalone Microbrewery</h5>
                        </center>--%>

                                <form>


                                    <table style="width: 100%">
                                        <tr>
                                            <th>Type Of Manufacturer</th>
                                            <th>Form Type</th>
                                            <th>Description</th>
                                        </tr>
                                        <tr>
                                            <td>Primary distillery</td>

                                            <td><a href="D1R(GSection).aspx">D1(R)</a></td>
                                            <td>Application for LOI Form For Manufacture Of Spirits</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td><a href="D1P(GSection).aspx">D1(P)</a></td>
                                            <td>Application for LOI Form for Manufacture Of Malt Spirits</td>

                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>

                                        </tr>

                                        <tr>
                                            <td>Distillery</td>
                                            <td><a href="IML(GSection).aspx">DM1(A)</a></td>
                                            <td>Application For LOI Form For Manufacture Of Indian Made Foriegn Liquors</td>
                                        </tr>

                                        <tr>
                                            <td>Brewery</td>

                                            <td><a href="Brewery.aspx">B1</a></td>
                                            <td>Application Form For Prior Clearance Of Brewery</td>
                                        </tr>
                                        <tr>
                                            <td>Winery</td>
                                            <td><a href="Winery.aspx">W1</a></td>
                                            <td>Application Form For Manufacture Of Wines</td>
                                        </tr>
                                        <tr>
                                            <td>Micro Brewery</td>
                                            <td><a href="MicroBrewery_MB1.aspx">MB1(A)</a></td>
                                            <td>Application for prior clearance for grant of licence for Microbrewery/Standalone Microbrewery</td>
                                        </tr>
                                    </table>



                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>

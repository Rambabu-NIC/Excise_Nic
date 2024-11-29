<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DistGazette.aspx.cs" Inherits="ExciseAPI.DistGazette" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="card">
            <div class="card-body">
                <div class="col-md-12" align="center">
                    <h3 class="form-signin-heading">
                        <%-- <asp:Image ID="Image1" ImageUrl="~/Assests/images/Logged_Out.jpg" CssClass="img-fluid"
                            runat="server" />--%></h3>
                    <div class="row">
                        <div class="col-md-12">
                            <div>
                                <center>
                                    <font color="#203354" size="4px"><u><b>District Wise Gazettes</b></u></font></center>
                            </div>
                            <br />
                            <table class="table-n">
                                <tr>

                                    <td>1.</td>

                                    <td>&nbsp;<a href="RDLCReports/DG/Adilabad.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">ADILABAD</font></a>
                                    </td>
                                    <td>18.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Nirmal.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">NIRMAL </font>
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>2.</td>
                                    <td>&nbsp;<a href="RDLCReports/DG/Kumrambheem Asifabad.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">Kumrambheem Asifabad</font></a>
                                    </td>
                                    <td>19.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Nizamabad.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">NIZAMABAD</font></a></td>
                                </tr>
                                <tr>
                                    <td>3.</td>
                                    <td>&nbsp;<a href="RDLCReports/DG/Bhadradri Kothagudem.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">Bhadradri Kothagudem</font></a>&nbsp;
                                    </td>
                                    <td>20.</td>
                                    <td>&nbsp;<a href="RDLCReports/DG/Nagar Kurnool.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">NAGARKURNOOL </font>
                                    </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>4.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Bhupalapally.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">BUPALPALLY </font></a>
                                    </td>
                                    <td>21</td>
                                    <td>
                                        <a href="RDLCReports/DG/nalgonda.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">NALGONDA </font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>5.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Hyderabad.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">HYDERABAD</font></a></td>
                                    <td>22.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Peddapally.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">PEDDAPALLI</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>6.</td>
                                    <td>&nbsp;<a href="RDLCReports/DG/gadwal.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">JOGULAMBA - GADWAL </font>
                                    </a>
                                        &nbsp;
                                    </td>
                                    <td>23.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Rajanna Sircilla.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">RAJANNA(SIRISILLA)</font></a>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>7.</td>
                                    <td>&nbsp;<a href="RDLCReports/DG/Jangaon.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">JANGAON</font></a></td>
                                    <td>24.</td>
                                    <td>

                                        <a href="RDLCReports/DG/Siddipet.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">SIDDIPET </font></a>

                                    </td>
                                </tr>
                                <tr>
                                    <td>8.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Jagtial.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">JAGITHYAL</font></a>
                                    </td>
                                    <td>25.</td>
                                    <td>

                                        <a href="RDLCReports/DG/Sanga Reddy.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">SANGAREDDY </font></a>

                                    </td>
                                </tr>
                                <tr>
                                    <td>9.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Khammam.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">KHAMMAM</font></a></td>
                                    <td>26.</td>
                                    <td>
                                        <a href="RDLCReports/DG/suryapet.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">SURYAPET
                                        </font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>10.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Karimnagar.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">KARIMNAGAR</font></a></td>
                                    <td>27.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Secundrabad.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">SECUNDERABAD </font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>11.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Kama Reddy.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">KAMAREDDY</font></a></td>
                                    <td>28.</td>
                                    <td>
                                        <a href="RDLCReports/DG/shamshabad.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">SHAMSHABAD </font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>12.</td>
                                    <td>
                                        <a href="RDLCReports/DG/mahabubabad.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">MAHABUBABAD</font></a></td>
                                    <td>29.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Saroornagar.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">SAROORNAGAR</font></a></td>
                                </tr>
                                <tr>
                                    <td>13.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Mahabubnagar.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">MAHABUBNAGAR </font>
                                        </a>
                                    </td>
                                    <td>30.</td>
                                    <td>

                                        <a href="RDLCReports/DG/Vikarabad.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">VIKARABAD </font></a>

                                    </td>
                                </tr>
                                <tr>
                                    <td>14.</td>

                                    <td>
                                        <a href="RDLCReports/DG/Mancherial.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">MANCHERIAL</font></a>
                                    </td>

                                    <td>31.</td>

                                    <td>
                                        <a href="RDLCReports/DG/Warangal Urban.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">WARANGAL URBAN</font></a></td>
                                </tr>
                                <tr>
                                    <td>15.</td>

                                    <td>
                                        <a href="RDLCReports/DG/Medchal.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">MEDCHAL</font>
                                        </a>
                                    </td>

                                    <td>32.</td>

                                    <td>&nbsp;
                                            <a href="RDLCReports/DG/Warangal Rural.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">WARANGAL RURAL</font></a></td>
                                </tr>
                                <tr>
                                    <td>16.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Malkajgiri.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">MALKAJGIRI</font></a><a href="RDLCReports/DG/saroornagar.pdf"><font color="blue" style="text-transform: uppercase;"> </font></a>
                                    </td>
                                    <td>33.</td>
                                    <td>
                                        <a href="RDLCReports/DG/wanaparthy.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">WANAPARTHY </font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>17.</td>
                                    <td>
                                        <a href="RDLCReports/DG/Medak.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">MEDAK </font></a>

                                    </td>
                                    <td>34</td>
                                    <td>

                                        <a href="RDLCReports/DG/Yadadri Bhuvanagiri.pdf" target="_blank"><font color="blue" style="text-transform: uppercase;">YADADRI BHUVANAGIRI</font></a></td>
                                </tr>

                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

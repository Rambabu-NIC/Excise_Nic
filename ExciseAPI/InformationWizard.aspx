<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InformationWizard.aspx.cs" Inherits="ExciseAPI.InformationWizard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            transition: transform 0.2s, box-shadow 0.2s, background-color 0.2s, color 0.2s;
            cursor: pointer;
            background-color: white;
            color: black;
        }

        /*.card:hover {
                transform: scale(1.05);
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
                background-color: #012970;
                color: white;
            }*/

        /*.card-body a {
            color: inherit;
        }

            .card-body a:hover {
                color: white;
            }

        .card:hover .card-title {
            color: white;
        }*/
        .custom-card-background {
            background-color: white; /* Replace with your desired color */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Information Wizard</div>
            <div class="content">
                <div class="col-md-12 col-lg-12">
                    <div class="col-md-4 col-lg-4">


                        <div class="card custom-card-background">
                            <div class="custom-card-header" style="background-color:rgb(177 223 210);color:black;">
                                Primary Distillery
               
                            </div>
                            <div class="card-body">
                                <a class="nav-link collapsed" href="Primary_Distillery.aspx">
                                    <h3 class="card-title">Application For Primary <br />Distillery</h3>

                                </a>
                                <br />
                            </div>
                            <div class="custom-card-footer" style="background-color:rgb(177 223 210);">
                            </div>
                        </div>


                    </div>
                    <div class="col-md-4 col-lg-4">
                        <div class="card custom-card-background">
                            <div class="custom-card-header" style="background-color:rgb(225 192 121);color:black;">
                                Secondary Distillery
               
                            </div>
                            <div class="card-body">
                                <a class="nav-link collapsed" href="Secondary_Distillery.aspx">
                                    <h3 class="card-title">Application For Secondary <br />Distillery</h3>

                                </a>
                                <br />
                            </div>
                            <div class="custom-card-footer" style="background-color:rgb(225 192 121);color:black;">
                            </div>
                        </div>

                    </div>
                    <div class="col-md-4 col-lg-4">
                        <div class="card custom-card-background">
                            <div class="custom-card-header" style="background-color:#e7a3a3;color:black;">
                                Brewery
               
                            </div>
                            <div class="card-body">
                                <a class="nav-link collapsed" href="Brewery.aspx">
                                    <h3 class="card-title">Application For<br /> Brewery</h3>

                                </a>
                                <br />
                            </div>
                            <div class="custom-card-footer" style="background-color:#e7a3a3">
                            </div>
                        </div>

                    </div>
                    


                </div>
                <div class="col-md-12 col-lg-12">
                    <div class="col-md-4 col-lg-4">
                        <div class="card custom-card-background">
                            <div class="custom-card-header" style="background-color:#8aebb5;color:black">
                                Winery
               
                            </div>
                            <div class="card-body">
                                <a class="nav-link collapsed" href="Winery.aspx">
                                    <h3 class="card-title">Application For Winery</h3>

                                </a>
                                <br />
                            </div>
                            <div class="custom-card-footer" style="background-color:#8aebb5;color:black">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-lg-4">
                        <div class="card custom-card-background">
                            <div class="custom-card-header1" style="background-color:rgb(177 223 210);color:black;">
                                MicroBrewery
               
                            </div>
                            <div class="card-body">
                                <a class="nav-link collapsed" href="MicroBrewery.aspx">
                                    <h3 class="card-title">Application For MicroBrewery</h3>

                                </a>
                                <br />
                            </div>
                            <div class="custom-card-footer1" style="background-color:rgb(177 223 210);color:black;">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-lg-4">
                        <div class="card custom-card-background">
                            <div class="custom-card-header1" style="background-color:rgb(225 192 121);color:black;">
                                Molasses
               
                            </div>
                            <div class="card-body">
                                <a class="nav-link collapsed" href="Molasses.aspx">
                                    <h3 class="card-title">Application For Molasses</h3>

                                </a>
                                <br />

                            </div>
                            <div class="custom-card-footer1" style ="background-color:rgb(225 192 121);color:black;">
                            </div>
                        </div>

                    </div>
                    </div>
                 <div class="col-md-12 col-lg-12">
                    <div class="col-md-4 col-lg-4">
                        <div class="card custom-card-background">
                            <div class="custom-card-header1" style="background-color:#e7a3a3;color:black;">
                                Shops,Bars,Clubs,Tourism,CSD
               
                            </div>
                            <div class="card-body">
                                <a class="nav-link collapsed" href="F_Section.aspx">
                                    <h3 class="card-title">Application For Shops,Bars,Clubs,Tourism and CSD</h3>

                                </a>

                            </div>
                            <div class="custom-card-footer1" style="background-color:#e7a3a3;color:black;">
                            </div>
                        </div>

                    </div>
                    <div class="col-md-4 col-lg-4">
                        <div class="card custom-card-background">
                            <div class="custom-card-header1" style="background-color:#8aebb5;color:black">
                                RS and DS Licenses
               
                            </div>
                            <div class="card-body">
                                <a class="nav-link collapsed" href="RSandDs.aspx">
                                    <h3 class="card-title">Application For RS and DS Licenses</h3>

                                </a>
                                <br />
                            </div>
                            <div class="custom-card-footer1"  style="background-color:#8aebb5;color:black">
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

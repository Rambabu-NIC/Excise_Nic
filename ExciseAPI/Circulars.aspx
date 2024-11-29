<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="Circulars.aspx.cs" Inherits="ExciseAPI.Circulars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pdf-icon {
            vertical-align: middle;
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Circulars</div>
            <div class="content">
                <div class="wrap">
                    <table class="table table-bordered table-responsive  table-striped" cellspacing="0" border="0" id="FileMoveList2" style="color: #333333; border-collapse: collapse;">

                        <tbody>
                            <tr style="color: #326693; background-color: #326693; font-size: 13px;">

                                <th scope="col" style="font-size: 15px; color: #fff;">S.No</th>
                                <th scope="col" style="font-size: 15px; width: 10%; color: #fff;">GO No/circular</th>
                                <th class="text-center" scope="col" style="font-size: 15px; color: #fff;">Abstract</th>
                                <th scope="col" style="font-size: 15px; color: #fff;">Download</th>

                            </tr>
                            <tr style="color: #284775;">
                                <td style="font-size: 14px;">1</td>
                                <td style="text-align: center; font-size: 14px;"></td>
                                <td style="font-size: 14px;">List of penal provisions of various Acts implemented by Prohibition & Excise Department
                                </td>
                                <td class="rowalign" align="center" style="font-size: Large; width: 50px;">
                                    <a href="..\RDLCReports/Lisofpenalprovisions.pdf" target="_blank" style="color: #284775;">
                                        <img src="../Assets/images/PDF.png" width="25" height="25">
                                        <br>
                                        <span style="font-size: 13px">Size 300KB </span>

                                    </a>
                                </td>
                            </tr>
                            <tr style="color: #284775;">
                                <td style="font-size: 14px;">2</td>
                                <td style="text-align: center; font-size: 14px;">86</td>
                                <td style="font-size: 14px;">Prohibition and Excise- Allotment of retail liquor (A4) shops
                                in the State for licence period 2023-25 (01.12.2023 to 30.11.2025)- Notification –
                                Orders- Issued
                                </td>
                                <td class="rowalign" align="center" style="font-size: Large; width: 50px;">
                                    <a href="..\RDLCReports/G.O.Ms.No.86-01.08.2023-Notification.pdf" target="_blank" style="color: #284775;">
                                        <img src="../Assets/images/PDF.png" width="25" height="25">
                                        <br>
                                        <span style="font-size: 13px">Size 2.06MB </span>

                                    </a>
                                </td>
                            </tr>
                            <tr style="color: #284775;">
                                <td style="font-size: 14px;">3</td>
                                <td style="text-align: center; font-size: 14px;">46</td>
                                <td style="font-size: 14px;">Grant of licence of selling by bar and condition of licence Rules ,2005 </td>
                                <td class="rowalign" align="center" style="font-size: Large; width: 50px;">
                                    <a href="..\RDLCReports/GO MS no 46 dt 10-05-2023.pdf" target="_blank" style="color: #284775;">
                                    <img src="../Assets/images/PDF.png" width="25" height="25">
                                    <br>
                                    <span style="font-size: 13px">Size 1.90MB </span>

                                </a>
                                </td>
                            </tr>
                            <tr style="color: #284775;">
                                <td style="font-size: 14px;">4</td>
                                <td style="text-align: center; font-size: 14px;">3060</td>
                                <td style="font-size: 14px;">DPE circular for collection of penalty on late submission of BGs</td>
                                <td class="rowalign" align="center" style="font-size: Large; width: 50px;">
                                    <a href="..\RDLCReports/DPE circular for collection of penalty on late submission of BGs.pdf" target="_blank" style="color: #284775;">
                                    <img src="../Assets/images/PDF.png" width="25" height="25">
                                    <br>
                                    <span style="font-size: 13px">Size 79KB </span>

                                </a>
                                </td>
                            </tr>
                            

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

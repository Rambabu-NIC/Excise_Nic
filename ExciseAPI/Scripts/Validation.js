function Callback() {
    $('#ContentPlaceHolder1_btnCallBack').click();
}

function ClearOTPControls() {
    $("span[id*='ErrorMessage']").html("");
}
function ClearChangePasswordControls() {
    $("#txtpresentpwd").val("");
    $("span[id*='lblErrorPassword']").html("");
    $("#txtnewpwd").val("");
    $("span[id*='lblErrorNewPassword']").html("");
    $("#txtconfirmpwd").val("");
    $("span[id*='lblErrorconfirmPassword']").html("");
}
function ClearForgetPasswordControls() {

    $("#txtforgetUserid").val("");
    $("span[id*='ErrorMessage']").html("");
    $("#txtforgetEneterOtp").hide();
    $("#txtforgetEneterOtp").val("");
    $("#txtforgetNewPassword").hide();
    $("#txtforgetNewPassword").val("");
    $("#txtforgetConfirmPassword").hide();
    $("#txtforgetConfirmPassword").val("");
    $("#btnResetPassword").hide();

}

function ClearChangePasswordPopUpControls() {

    $("#Div_Master_PwdChangedMessage").hide();
    $("span[id*='Span_Master_ErrorMessage']").html("");


    $("#Div_Master_PwdChanged").show();

    $("#txtpresentpwd").val("");
    $("span[id*='lblErrorPassword']").html("");

    $("#txtnewpwd").val("");
    $("span[id*='lblErrorNewPassword']").html("");

    $("#txtconfirmpwd").val("");
    $("span[id*='lblErrorconfirmPassword']").html("");

    PopUpConfirmHide();


}

function ClearRMPPFields() {

    $("#ContentPlaceHolder1_ddlMineralforpermit").prop('selectedIndex', 0);
    $("#ContentPlaceHolder1_txtqtyreq").val("");
    $("#ContentPlaceHolder1_ddlqtyreq").prop('selectedIndex', 0);
    $("#ContentPlaceHolder1_txtvalidityreq").val("");
    $("#ContentPlaceHolder1_ddlmodeoftransport").prop('selectedIndex', 0);


}

function PopUpConfirmHide() {

    $('#changepwdpopup').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
    return true;
};


/*-------------Accept Only Numbers Start-------*/
function Isnumeric(e) {
    var verified = (e.which == 8 || e.which == undefined || e.which == 0) ? null : String.fromCharCode(e.which).match(/[^0-9]/);
    return verified;
}
/*-------------Accept Only Numbers END-------*/
/*Mobile Validation Start*/
function validatemobile(MobileNumber) {
    var MobileRegEx = /^[6-9]{1}[0-9]{9}$/;
    var verified = MobileRegEx.test(MobileNumber);
    return verified;
}
/*Mobile Validation END*/

/*-------------Email Validation Start---------*/
function ValidateEmail(Email) {
    var EmailRegEx = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
    var verified = EmailRegEx.test(Email);
    return verified;
}
/*-------------Email Validation END---------*/

/*-------------AadharNo Validation Start---------*/
function ValidateAadharNumber(AadharNo) {
    var AadharNoRegEx = /^[0-9]{12}$/;
    var verified = AadharNoRegEx.test(AadharNo);
    return verified;
}
/*-------------AadharNo Validation END---------*/

/*-------------Pincode Validation Start---------*/
function ValidatePincodeNumber(Pincode) {
    var PincodeRegEx = /^[5]{1}[0-9]{5}$/;
    var verified = PincodeRegEx.test(Pincode);
    return verified;
}
/*-------------Pincode Validation END---------*/

/*-------------Vehicle Number Validation Start---------*/
function ValidateVehicleNumber(VehicleNo) {
    //var VehicleNoRegEx = /^([A-Za-z]){2}(?:[0-9]){1,2}(?:[A-Za-z]){1,2}(?:[0-9]){1,4}$/;
    var VehicleNoRegEx = /^([A-Za-z]){2}(?:[0-9]){1,2}(?:[A-Za-z0-9]){1,2}(?:[0-9]){1,4}$/;
    var verified = VehicleNoRegEx.test(VehicleNo);
    return verified;
}
/*-------------Vehicle Number Validation END---------*/

/*-------------Licence Number Validation Start---------*/
function ValidateLicenceNumber(LicenceNo) {
    var LicenceNoRegEx = /^[a-zA-Z]{5}[0-9]{10}$/;
    var verified = LicenceNoRegEx.test(LicenceNo);
    return verified;
}
/*-------------Vehicle Number Validation END---------*/


/*-------------Stationery Number Validation Start---------*/
function ValidateStationeryNumber(StationeryNumber) {
    var StationeryNoRegEx = /^[a-zA-Z]{4}[0-9]{8}$/;
    var verified = StationeryNoRegEx.test(StationeryNumber);
    return verified;
}
/*-------------Stationery Number Validation END---------*/


/*-------------Pan Number Validation Start---------*/
function ValidatePanNumber(PanNo) {
    var PanNoRegEx = /^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$/;
    var verified = PanNoRegEx.test(PanNo);
    return verified;
}
/*-------------Pan Number Validation END---------*/

/*-------------GST Number Validation Start---------*/
function validateGST(GSTNo) {
    var GSTRegEx = /^[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1}$/;
    var verified = GSTRegEx.test(GSTNo);
    return verified;
}
/*-------------GST Number Validation END---------*/

/*-------------AadharNo Validation Start---------*/

function AcceptNumbersAndCharacters(e) {
    var regex = new RegExp("^[a-zA-Z0-9]+$");
    var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (e.keyCode != 8) {
        if (e.keyCode != 9) {
            if (e.keyCode != 32) {
                if (!regex.test(key)) {
                    e.preventDefault();
                    return false;
                }
            }
        }
    }
}
/*-------------AadharNo Validation END---------*/


/*-------------Accept Only Characters Validation  END---------*/


function AcceptOnlyCharacters(e) {
    var regex = new RegExp("^[a-zA-Z]+$");
    var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (e.keyCode != 8) {
        if (e.keyCode != 9) {
            if (e.keyCode != 32) {
                if (!regex.test(key)) {
                    e.preventDefault();
                    return false;
                }
            }
        }
    }
}
/*-------------Accept Only Characters Validation END---------*/



function numericValidation(txtvalue) {
    var e = event || evt;
    var charCode = e.which || e.keyCode;
    if (!(document.getElementById(txtvalue.id).value)) {
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    else {
        var val = document.getElementById(txtvalue.id).value;
        if (charCode == 46 || (charCode > 31 && (charCode > 47 && charCode < 58))) {
            var points = 0;
            points = val.indexOf(".", points);
            if (points >= 1 && charCode == 46) {
                return false;
            }
            if (points == 1) {
                var lastdigits = val.substring(val.indexOf(".") + 1, val.length);
                if (lastdigits.length >= 3) {
                    return false;
                }
            }
            return true;
        }
        else {
            return false;
        }
    }
}


function CompareApprovedQuantity(RowIndex, lblEstimatedQty, lblError, txt_TPI_ApprovedQuantity) {

    var ApprovedQty = parseFloat($("#" + txt_TPI_ApprovedQuantity).val());
    ApprovedQty = ApprovedQty ? ApprovedQty : 0;

    var EstimatedQty = parseFloat($("#" + lblEstimatedQty).html());
    EstimatedQty = EstimatedQty ? EstimatedQty : 0;
    $("#ContentPlaceHolder1_Span_TPA_ADActionOnApplication").html("");
    $("#ddl_TP_ddActionApprovedDays").prop("selectedIndex", 0);
    //$("#ContentPlaceHolder1_Div_TPA_ADActionOTP").show();
    $("#ContentPlaceHolder1_txt_TPA_ADActionOTP").val("");
    $("#ContentPlaceHolder1_txt_TPA_ADActionRemarks").val("");
    $("span[id*='Span_TPA_ADActionOnApplication']").html("");
    $("span[id*='Span_TPA_ADActionSubmitError']").html("");

    if (ApprovedQty > EstimatedQty) {
        $("#" + lblError).html("Approved Quantity should not Exceed Estimated Quantity.");
        $("#" + txt_TPI_ApprovedQuantity).val("");
        $("#" + txt_TPI_ApprovedQuantity).focus();
        return false;
    }
    else {
        $("#" + lblError).html("");
    }
}
/*-------------Start GenerateOtp For Forget password And Reset -----------------*/
$("#ContentPlaceHolder1_lbl").css('color', 'red');


$("body").on("click", '#btnGenerateOtp', function () {

    var isValidate = true;
    if ($("#txtforgetUserid").val() == "") {
        $("span[id*='ErrorMessage']").html("UserID can't be an empty.");
        $("span[id*='ChangePasswordErrorMessage']").html("");
        $("#txtforgetUserid").focus();
        isValidate = false;
    }

    else {

        $("span[id*='ErrorMessage']").html("");
    }
    if (!isValidate) {

        return false;
    }
});

$("body").on("change", "#txtforgetUserid", function () {

    $("span[id*='ErrorMessage']").html("");
    $("#txtforgetEneterOtp").hide();
    $("#txtforgetEneterOtp").val("");

    $("#txtforgetNewPassword").hide();
    $("#txtforgetNewPassword").val("");

    $("#txtforgetConfirmPassword").hide();
    $("#txtforgetConfirmPassword").val("");

    $("#btnResetPassword").hide();


});

$("body").on("click", '#btnResetPassword', function () {

    var isValidate = true;

    if ($("#txtforgetUserid").val() == "") {
        $("span[id*='ChangePasswordErrorMessage']").html("UserID can't be an empty.");
        $("#txtforgetUserid").focus();
        isValidate = false;
    }
    else if ($("#txtforgetEneterOtp").val() == "") {
        $("span[id*='ChangePasswordErrorMessage']").html("Otp can't be an empty.");
        $("#txtforgetEneterOtp").focus();
        isValidate = false;
    }

    else if ($("#txtforgetNewPassword").val() == "") {
        $("span[id*='ChangePasswordErrorMessage']").html("New Password can't be an empty.");
        $("#txtforgetNewPassword").focus();
        isValidate = false;
    }

    else if ($("#txtforgetConfirmPassword").val() == "") {
        $("span[id*='ChangePasswordErrorMessage']").html("Confirm Password can't be an empty.");
        $("#txtforgetConfirmPassword").focus();
        isValidate = false;
    }

    else if ($("#txtforgetNewPassword").val() != $("#txtforgetConfirmPassword").val()) {
        $("span[id*='ChangePasswordErrorMessage']").html("New Password and Confirm Password Must Be same");
        isValidate = false;

    }
    else {
        $("span[id*='ErrorMessage']").html("");
        $("span[id*='ChangePasswordErrorMessage']").html("");
    }
    if (!isValidate) {

        return false;
    }

});
    /*-------------End GenerateOtp For Forget password And Reset -----------------*/


    /*------------------- For login Start----------------*/


$("input[id*='btnLogin']").click(function () {
    var isValidate = true;

    if (($("input[id*='txtLoginUsername']").val() == '') && ($("input[id*='txtLoginPassword']").val() == '')) {
        $("span[id*='SpanLoginErrorMessage']").html("User Name & Password can't be an empty.");
        isValidate = false;
    }
    else if ($("input[id*='txtLoginUsername']").val() == '') {
        $("span[id*='SpanLoginErrorMessage']").html("User Name can't be an empty.");
        isValidate = false;
    }
    else if ($("input[id*='txtLoginPassword']").val() == '') {
        $("span[id*='SpanLoginErrorMessage']").html("Password can't be an empty.");
        isValidate = false;
    }
    else {
        $("span[id*='SpanLoginErrorMessage']").html("");
    }

    if (!isValidate) {

        return false;
    }

});
$("body").on("keypress", '#txtLoginUsername', function (e) {
    $("span[id*='SpanLoginErrorMessage']").html("");
});
$("body").on("keypress", '#txtLoginPassword', function (e) {
    $("span[id*='SpanLoginErrorMessage']").html("");
});
$("input[id*='txtLoginUsername']").keydown(function (event) {
    if (event.keyCode == 13) {
        $("input[id*='btnLogin']").trigger('click');
    }
});

$("input[id*='txtLoginPassword']").keydown(function (e) {
    if (e.which == 13) {
        $("input[id*='btnLogin']").trigger('click');
    }
});


    /*------------------- For login end----------------*/

/*---------- For change password start----------------*/
$("body").on("click", '#btnchangepwd', function () {


    if ($("#txtpresentpwd").val() == "") {
        $("span[id*='lblErrorPassword']").html("Present Password can't be an empty.");
        $("#txtpresentpwd").focus();
        return false;
    }
    else {
        $("span[id*='lblErrorPassword']").html("");

    }
    if ($("#txtnewpwd").val() == "") {
        $("span[id*='lblErrorNewPassword']").html("New Password can't be an empty.");
        $("#txtnewpwd").focus();
        return false;
    }
    else if ($("#txtpresentpwd").val() == $("#txtnewpwd").val()) {
        $("span[id*='lblErrorNewPassword']").html("present and New Password can't be Same.");
        $("#txtnewpwd").focus();
        return false;
    }

    else {
        $("span[id*='lblErrorNewPassword']").html("");
    }


    if ($("#txtconfirmpwd").val() == "") {
        $("span[id*='lblErrorconfirmPassword']").html("Confirm Password can't be an empty.");
        $("#txtconfirmpwd").focus();
        return false;
    }

    else if ($("#txtnewpwd").val() != $("#txtconfirmpwd").val()) {
        $("span[id*='lblErrorconfirmPassword']").html("New Password and Confirm Password Must Be same");
        return false;

    }
    else {

        $("span[id*='lblErrorconfirmPassword']").html("");
    }


});

$("body").on("focusout", '#txtpresentpwd', function () {

    var isValidate = true;
    if ($("#txtpresentpwd").val() == "") {
        $("span[id*='lblErrorPassword']").html("Present Password can't be an empty.");
        $("#txtpresentpwd").focus();
        isValidate = false;
    }
    else {
        $("span[id*='lblErrorPassword']").html("");

    }
    if (!isValidate) {

        return false;
    }
});

$("body").on("focusout", '#txtnewpwd', function () {

    var isValidate = true;
    if ($("#txtpresentpwd").val() == "") {
        $("span[id*='lblErrorPassword']").html("Present Password can't be an empty.");
        $("#txtpresentpwd").focus();
        isValidate = false;
    }
    else if ($("#txtnewpwd").val() == "") {
        $("span[id*='lblErrorNewPassword']").html("New Password can't be an empty.");
        $("#txtnewpwd").focus();
        isValidate = false;
    }
    else if ($("#txtpresentpwd").val() == $("#txtnewpwd").val()) {
        $("span[id*='lblErrorNewPassword']").html("present and New Password can't be Same.");
        $("#txtnewpwd").focus();
        isValidate = false;
    }
    else {
        $("span[id*='lblErrorPassword']").html("");
        $("span[id*='lblErrorNewPassword']").html("");
    }
    if (!isValidate) {

        return false;
    }
});

$("body").on("focusout", '#txtconfirmpwd', function () {

    var isValidate = true;
    if ($("#txtpresentpwd").val() == "") {
        $("span[id*='lblErrorPassword']").html("Present Password can't be an empty.");
        $("#txtpresentpwd").focus();
        isValidate = false;
    }
    else if ($("#txtnewpwd").val() == "") {
        $("span[id*='lblErrorNewPassword']").html("New Password can't be an empty.");
        $("#txtnewpwd").focus();
        isValidate = false;
    }
    else if ($("#txtpresentpwd").val() == $("#txtnewpwd").val()) {
        $("span[id*='lblErrorNewPassword']").html("present and New Password can't be Same.");
        $("#txtnewpwd").focus();
        isValidate = false;
    }
    else if ($("#txtconfirmpwd").val() == "") {
        $("span[id*='lblErrorconfirmPassword']").html("Confirm Password can't be an empty.");
        $("#txtconfirmpwd").focus();
        isValidate = false;
    }
    else if ($("#txtnewpwd").val() != $("#txtconfirmpwd").val()) {
        $("span[id*='lblErrorconfirmPassword']").html("New Password and Confirm Password Must Be same");
        isValidate = false;

    }
    else {
        $("span[id*='lblErrorPassword']").html("");
        $("span[id*='lblErrorNewPassword']").html("");
        $("span[id*='lblErrorconfirmPassword']").html("");
    }
    if (!isValidate) {

        return false;
    }
});
    /*---------- For change password end----------------*/

//Event Registration Validations Start region
$("body").on("click", "#ContentPlaceHolder1_btn_Save_Event", function () {
    debugger;
    if ($("#ContentPlaceHolder1_DropDownList2").val() == 0) {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select The Name.");
        $("#ContentPlaceHolder1_DropDownList2").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtAppliName").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Applicant Name.");
        $("#ContentPlaceHolder1_txtAppliName").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtFatherName").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Father Name.");
        $("#ContentPlaceHolder1_txtFatherName").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtAge").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Age.");
        $("#ContentPlaceHolder1_txtAge").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtAdharNum").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Aadhar Number.");
        $("#ContentPlaceHolder1_txtAdharNum").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtMobile").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Mobile Number.");
        $("#ContentPlaceHolder1_txtMobile").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtEmail").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Email Address.");
        $("#ContentPlaceHolder1_txtEmail").focus();
        return false;
    }

    //else if ($("#ContentPlaceHolder1_ddl_SQP_Quantity_Units").val() == 0) {
    //    $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select SQP Units.");
    //    $("#ContentPlaceHolder1_ddl_SQP_Quantity_Units").focus();
    //    return false;
    //}
    else if ($("#ContentPlaceHolder1_txtAdd").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Residential Address.");
        $("#ContentPlaceHolder1_txtAdd").focus();
        return false;
    }
    //else if ($("#ContentPlaceHolder1_ddl_AAP_Quantity_Units").val() == 0) {
    //    $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select Annual Production.");
    //    $("#ContentPlaceHolder1_ddl_AAP_Quantity_Units").focus();
    //    return false;
    //}
    else if ($("#ContentPlaceHolder1_txtHsNum").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter House/Door Number.");
        $("#ContentPlaceHolder1_txtHsNum").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtNmePrem").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Name Of the Premises.");
        $("#ContentPlaceHolder1_txtNmePrem").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtStreet").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Street.");
        $("#ContentPlaceHolder1_txtStreet").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtEast").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter East Boundries.");
        $("#ContentPlaceHolder1_txtEast").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtWest").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter West Boundries.");
        $("#ContentPlaceHolder1_txtWest").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtNorth").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter North Boundries.");
        $("#ContentPlaceHolder1_txtNorth").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtSouth").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter South Boundries.");
        $("#ContentPlaceHolder1_txtSouth").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_ddlRevDistrict").val() == 0) {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select Revenue District.");
        $("#ContentPlaceHolder1_ddlRevDistrict").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_ddlMandal").val() == 0) {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select Madal.");
        $("#ContentPlaceHolder1_ddlMandal").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_ddlLocality").val() == 0) {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select Locality.");
        $("#ContentPlaceHolder1_ddlLocality").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_ddlWhether").val() == 0) {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select Whether.");
        $("#ContentPlaceHolder1_ddlWhether").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_txtEvnDate").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select Evnent Date.");
        $("#ContentPlaceHolder1_txtEvnDate").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_ddlEvntTm").val() == 0) {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select Event time.");
        $("#ContentPlaceHolder1_ddlEvntTm").focus();
        return false;
    }
    else if ($("#ContentPlaceHolder1_ddlEvntType").val() == 0) {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Select Event Type.");
        $("#ContentPlaceHolder1_ddlEvntType").focus();
        return false;
    }

    else if ($("#ContentPlaceHolder1_txtEvent").val() == "") {
        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Please Enter Event On Occasion Of.");
        $("#ContentPlaceHolder1_txtEvent").focus();
        return false;
    }

    //For Radio Button 

    //else if ($("input[id*='txtntfgconsigneename']").val() == '') {
    //    $("span[id*='errornewtransitformforgranite']").html("please enter consignee name.");
    //    $("#contentplaceholder1_txtntfgconsigneename").focus();
    //    $("#contentplaceholder1_radiobuttongroup").focus();
    //    //e.preventdefault();
    //    alert('test');
    //    return false;
    //}
    //For Upload Documents

    //var totalGridViewRows = $("#ContentPlaceHolder1_gv tr").length;
    //if (totalGridViewRows < 2) {
    //    $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("Details Missing.");
    //    $("#ContentPlaceHolder1_gva").focus();
    //    return false;
    //}
    //else {
    //    $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("");
    //}
});

    //For Upload Documents

//$("body").on("click", "#ContentPlaceHolder1_btnloilegacyappliation", function () {

//    var totalGridViewRows = $("#ContentPlaceHolder1_gvaddExtentOQL tr").length;
//    if (totalGridViewRows < 2) {
//        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("ADMG Recomendations Missing.");
//        $("#ContentPlaceHolder1_gvaddExtentOQL").focus();
//        return false;
//    }
//    else {
//        $('#ContentPlaceHolder1_lblApplicantrerrorApp').html("");
//    }

//});

function ShowInformationMesage(message) {
    debugger;
    $('#info-modal').modal('show');
    document.getElementById("infoText").innerHTML = message;
    document.getElementById("btnInfoClose").focus();
}

function ErrorMesage(message, controllerId) {
    $("#PopMessage").dialog(
        {
            title: "Error",
            modal: true,
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                    $('[id*=' + controllerId + ']').select();
                    $('[id*=' + controllerId + ']').focus();
                }
            }
        });
    document.getElementById("MessageText").innerHTML = message;
}

//function ShowMessageSuccess(message) {
//    $('#msgSuccess').show();
//    $("box").scrollTop(0);
//    $('#lblMsgSuccessBody').text(message);
//    setTimeout(function () {
//        $('#msgSuccess').fadeTo(300, -1).slideUp(1000, function () {
//            $('#msgSuccess').alert('close');
//        });
//    }, 2000);
//}
//function ShowMessageDanger(message) {
//    $('#msgDanger').show();
//    $("box").scrollTop(0);
//    $('#lblMsgDangerBody').text(message);
//    setTimeout(function () {
//        $('#msgDanger').fadeTo(300, -1).slideUp(1000, function () {
//            $('#msgDanger').alert('close');
//        });
//    }, 2000);
////}
//function ShowMessageDanger(message) {
//    $('#msgDanger').show();
//    $("box").scrollTop(0);
//    $('#lblMsgDangerBody').text(message);
//    setTimeout(function () {
//        $('#msgDanger').fadeTo(300, -1).slideUp(1000, function () {
//            $('#msgDanger').alert('close');
//        });
//    }, 2000);
////}
//function ShowMessageWarning(message) {
//    $('#msgWarning').show();
//    $("box").scrollTop(0);
//    $('#lblMsgWarningBody').text(message);
//    setTimeout(function () {
//        $('#msgWarning').fadeTo(300, -1).slideUp(1000, function () {
//            $('#msgWarning').alert('close');
//        });
//    }, 2000);
//}

//function ShowMessageWarning(message) {
//    $('#msgWarning').show();
//    $("box").scrollTop(0);
//    $('#lblMsgWarningBody').text(message);
//    setTimeout(function () {
//        $('#msgWarning').fadeTo(300, -1).slideUp(1000, function () {
//            $('#msgWarning').alert('close');
//        });
//    }, 2000);
//}

function ShowMessageSuccess(message) {
    debugger;
    $('#msgSuccess').show();
    $("box").scrollTop(0);
    $('#lblMsgSuccessBody').text(message);
}
function HideMessageSucess() {
    $('#msgSuccess').fadeTo(300, -1).slideUp(1000, function () {
        $('#msgSuccess').alert('close');
    });
}
function ShowMessageDanger(message) {
    $('#msgDanger').show();
    $("box").scrollTop(0);
    $('#lblMsgDangerBody').text(message);
}
function HideMessageDanger() {
    $('#msgDanger').fadeTo(300, -1).slideUp(1000, function () {
        $('#msgDanger').alert('close');
    });
}

function ShowMessageDanger(message) {
    $('#msgDanger').show();
    $("box").scrollTop(0);
    $('#lblMsgDangerBody').text(message);
}
function HideMessageDanger() {
    $('#msgDanger').fadeTo(300, -1).slideUp(1000, function () {
        $('#msgDanger').alert('close');
    });
}

function ShowMessageWarning(message) {
    $('#msgWarning').show();
    $("box").scrollTop(0);
    $('#lblMsgWarningBody').text(message);
}
function HideMessageWarning() {
    $('#msgWarning').fadeTo(300, -1).slideUp(1000, function () {
        $('#msgWarning').alert('close');
    });
}

function ShowMessageInfo(message) {
    $('#msgInfo').show();
    $("box").scrollTop(0);
    $('#lblMsgInfoHeader').text(message);
}
function HideMessageInfo() {
    $('#msgInfo').fadeTo(300, -1).slideUp(2000, function () {
        $('#msgInfo').alert('close');
    });
}

//function GetEmployeeInformation(name, position,) {
//    debugger;
//    $('#EmployeeInformation').show();
//    $('#lblEmpName').text(name);
//    $('#lblPosition').text(position);
//    //$('#lblHRISno').text(HRISno);
//}
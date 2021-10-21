//function ShowMessageSuccess() {
//    $('#msgSuccess').show();
//    setTimeout(function () {
//        $('#msgSuccess').fadeTo(300, 0.5).slideUp(2000, function () {
//            $('#msgSuccess').alert('close');
//        });
//    }, 6000);
//}

//function ShowMessageDanger() {
//    $('#msgDanger').show();
//}
//function ShowMessageWarning() {
//    $('#msgWarning').show();
//}
//function ShowMessageInfo() {
//    $('#msgInfo').show();
//}

function ShowWarningMessage() {
    $('#msgWarning').modal('show');
    return false;
}

//function ShowSuccessMessage(msg) {
//    $(function () {
//        alertify.success(msg);
//    });
//}
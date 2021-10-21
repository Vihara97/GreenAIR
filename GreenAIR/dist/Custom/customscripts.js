function ShowMessageSuccessTest() {
    debugger;
    $('#msgSuccess').show();
    $("box").scrollTop(0);
    //setTimeout(function () {
    //    $('#msgSuccess').fadeTo(300, 0.5).slideUp(1000, function () {
    //        $('#msgSuccess').alert('close');
    //    });
    //}, 2000);
}

function ShowMessageDangerTest() {
    $('#msgDanger').show();
    $("box").scrollTop(0);
    setTimeout(function () {
        $('#msgDanger').fadeTo(300, 0.5).slideUp(1000, function () {
            $('#msgDanger').alert('close');
        });
    }, 2000);
}

function ShowMessageWarningTest() {
    $('#msgWarning').show();
    $("box").scrollTop(0);
    setTimeout(function () {
        $('#msgWarning').fadeTo(300, 0.5).slideUp(2000, function () {
            $('#msgWarning').alert('close');
        });
    }, 6000);
}
function ShowMessageInfoTest() {
    $('#msgInfo').show();
    $("box").scrollTop(0);
    setTimeout(function () {
        $('#msgInfo').fadeTo(300, 0.5).slideUp(2000, function () {
            $('#msgInfo').alert('close');
        });
    }, 6000);
}

function ShowMessageErrorTest() {
    $('#msgError').show();
    $("#msgError").focus(function () {
        alert("Handler for .focus() called.");
    });
    setTimeout(function () {
        $('#msgError').fadeTo(300, 0.5).slideUp(1000, function () {
            $('#msgError').alert('close');
        });
    }, 2000);
}

function ShowMessage(message, type) {
    debugger;
    var messageType;
    switch (type) {
        case "Success":
            messageType = "success";
            break;
        case "Danger":
            messageType = "danger";
            break;
        case "Info":
            messageType = "info";
            break;
        case "Warning":
            messageType = "warning";
            break;
    }
    $.notify({
        icon: 'fa fa-bell',
        title: 'Notify Message',
        message: message
    }, {
        type: messageType,
        placement: {
            from: "top",
            align: "right"
        },
        time: 1000,
        delay: 100
    });
}
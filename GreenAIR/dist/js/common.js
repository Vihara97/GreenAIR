//get time from ajax date time
function FormatTime(time) {
    var serverNowGetTime = time.replace(/\/Date\(/, '').replace(/\)\//, '');
    var offset = (new Date()).getTime() - serverNowGetTime;
    var serverNowGetTime = new Date((new Date()) - offset);
    var hh = ('0' + serverNowGetTime.getHours()).slice(-2);
    var mm = ('0' + serverNowGetTime.getMinutes()).slice(-2);
    var ss = ('0' + serverNowGetTime.getSeconds()).slice(-2);
    return hh + ':' + mm;
    //return hh + ':' + mm + ':' + ss;
}

function FormatDateTime(datetime) {
    var dateString = datetime.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = currentTime.getMonth() + 1;
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();

    var serverNowGetTime = datetime.replace(/\/Date\(/, '').replace(/\)\//, '');
    var offset = (new Date()).getTime() - serverNowGetTime;
    var serverNowGetTime = new Date((new Date()) - offset);
    var hh = ('0' + serverNowGetTime.getHours()).slice(-2);
    var mm = ('0' + serverNowGetTime.getMinutes()).slice(-2);

    return year + "-" + month + "-" + day + " " + hh + ':' + mm;
}

function FormatDate(date) {
    var dateString = date.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = currentTime.getMonth() + 1;
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var date = year + "-" + month + "-" + day;
    return date;
}

function FormatNumber(number, decimals, dec_point, thousands_sep) {
    //  discuss at: http://phpjs.org/functions/number_format/
    // original by: Jonas Raoni Soares Silva (http://www.jsfromhell.com)
    // improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
    // improved by: davook
    // improved by: Brett Zamir (http://brett-zamir.me)
    // improved by: Brett Zamir (http://brett-zamir.me)
    // improved by: Theriault
    // improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
    // bugfixed by: Michael White (http://getsprink.com)
    // bugfixed by: Benjamin Lupton
    // bugfixed by: Allan Jensen (http://www.winternet.no)
    // bugfixed by: Howard Yeend
    // bugfixed by: Diogo Resende
    // bugfixed by: Rival
    // bugfixed by: Brett Zamir (http://brett-zamir.me)
    //  revised by: Jonas Raoni Soares Silva (http://www.jsfromhell.com)
    //  revised by: Luke Smith (http://lucassmith.name)
    //    input by: Kheang Hok Chin (http://www.distantia.ca/)
    //    input by: Jay Klehr
    //    input by: Amir Habibi (http://www.residence-mixte.com/)
    //    input by: Amirouche
    //   example 1: number_format(1234.56);
    //   returns 1: '1,235'
    //   example 2: number_format(1234.56, 2, ',', ' ');
    //   returns 2: '1 234,56'
    //   example 3: number_format(1234.5678, 2, '.', '');
    //   returns 3: '1234.57'
    //   example 4: number_format(67, 2, ',', '.');
    //   returns 4: '67,00'
    //   example 5: number_format(1000);
    //   returns 5: '1,000'
    //   example 6: number_format(67.311, 2);
    //   returns 6: '67.31'
    //   example 7: number_format(1000.55, 1);
    //   returns 7: '1,000.6'
    //   example 8: number_format(67000, 5, ',', '.');
    //   returns 8: '67.000,00000'
    //   example 9: number_format(0.9, 0);
    //   returns 9: '1'
    //  example 10: number_format('1.20', 2);
    //  returns 10: '1.20'
    //  example 11: number_format('1.20', 4);
    //  returns 11: '1.2000'
    //  example 12: number_format('1.2000', 3);
    //  returns 12: '1.200'
    //  example 13: number_format('1 000,50', 2, '.', ' ');
    //  returns 13: '100 050.00'
    //  example 14: number_format(1e-8, 8, '.', '');
    //  returns 14: '0.00000001'

    number = (number + '')
        .replace(/[^0-9+\-Ee.]/g, '');
    var n = !isFinite(+number) ? 0 : +number,
        prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
        sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
        dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
        s = '',
        toFixedFix = function (n, prec) {
            var k = Math.pow(10, prec);
            return '' + (Math.round(n * k) / k)
                .toFixed(prec);
        };
    // Fix for IE parseFloat(0.55).toFixed(0) = 0;
    s = (prec ? toFixedFix(n, prec) : '' + Math.round(n))
        .split('.');
    if (s[0].length > 3) {
        s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
    }
    if ((s[1] || '')
        .length < prec) {
        s[1] = s[1] || '';
        s[1] += new Array(prec - s[1].length + 1)
            .join('0');
    }
    return s.join(dec);
}

function GetSystemDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    return yyyy + '-' + mm + '-' + dd;
}

function GetSystemTime() {
    var today = new Date();
    var hh = today.getHours();
    var mm = today.getMinutes();
    var ss = today.getSeconds();

    return hh + ':' + mm + ':' + ss;
}

function GetSystemHour() {
    var today = new Date();
    var hh = today.getHours();

    return hh;
}

function ConfirmOnDelete() {
    if (confirm("Are you sure you want to delete?") == true)
        return true;
    else
        return false;
}

function ConfirmOncancel() {
    if (confirm("Are you sure you want to cancel?") == true)
        return true;
    else
        return false;
}

function PageIndexChangeConfirm() {
    if (confirm("Please update record before move to the next page /n Are you sure you want to continue?") == true)
        return true;
    else
        return false;
}

function InformationMesage(message) {
    $("#PopMessage").dialog(
        {
            title: "Information",
            modal: true,
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                }
            }
        });
    document.getElementById("MessageText").innerHTML = message;
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

function SearchPopFunction(divName, titleNmae) {
    $("#" + divName).dialog(
        {
            minHeight: 200,
            minWidth: 600,
            draggable: true,
            title: titleNmae,
            modal: true,
            buttons: {
                OK: function () {
                    $(this).dialog('close');
                },
                Close: function () {
                    $(this).dialog('close');
                }
            }, open: function (type, data) {
                $(this).parent().appendTo("form");
            }
        });
}

function scrollChat(divName) {
    $("#" + divName).contentWindow.scrollTo(0, 999999);ss
}
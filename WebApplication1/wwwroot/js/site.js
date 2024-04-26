// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.






const select = document.querySelector('select');

select.onchange = function () {
    let ControllerId = $("#commandId").val();
    $.ajax({
        type: 'GET',
        url: '/Home/ParametersPartialView',
        data: { "ControllerId": ControllerId },
        success: function (response) {
            //сюда вставляем код  с разметкой
            $("#parameters").html($(response))
            /*alert(ControllerId)*/
        },
        failure: function () {
            alert("failure");
            modal.modal('hide')
        },
        error: function (response) {
            alert("ошибка");
        }
    });
}

var a = 1;
function myFunction() {
    //var table = document.getElementById('History');
    //var newRow = document.createElement("tr");
    //var addTh = document.createElement("th");
    //addTh.innerHTML = a;

    //newRow.appendChild(addTh);

    let terminalId = document.getElementById('id').value
    let p1,p2,p3
    if (document.getElementById('parameter_value1') == null) {
        p1 = 0;
    }
    else
        p1 = document.getElementById('parameter_value1').value;
    if (document.getElementById('parameter_value2') == null) {
        p2 = 0;
    }
    else
        p3 = document.getElementById('parameter_value2').value;
    if (document.getElementById('parameter_value3') == null) {
        p3 = 0;
    }
    else
        p3 = document.getElementById('parameter_value3').value;
    var myDictionary = {
        command_id: $("#commandId").val(),
        parameter1: p1,
        parameter2: p2,
        parameter3: p3
    };

    $.ajax({
        type: 'POST',
        url: '/Home/TerminalResponse',
        data: {
            "GetParams": myDictionary,
            "terminalId": terminalId
        },
        success: function (response) {
            //сюда вставляем код  с разметкой
            $("#History").append(response);
            /*alert(document.getElementById('opaa'));*/
            /* addTr.innerHTML(response);*/
            /*addTr.appendChild.html(response)*/
            /*document.getElementById('History').HTML(response)*/
            /*addTr.appendChild.html(response)*/

        },
        failure: function () {
            alert("failure");
            modal.modal('hide')
        },
        error: function (response) {
            console.error(xhr.responseText);
            alert("ошибка");
        }
    });
    /*table.appendChild(newRow);*/
    a++;
}






///*$(function () {*/
//    $('select').on('change', function (e) {
//        let ControllerId = $("#commandId").val();
//        $.ajax({
//            type: 'GET',
//            url: '/Home/ParametersPartialView',
//            data: { "ControllerId": ControllerId },
//            success: function (response) {
//                /*$("#block1").load("Home/ParametersPartialView");*/
//                //сюда вставляем код  с разметкой
//                /*$("#block1").text(response)*/
//                $("#block1").html($(response))
//               /* $("#block1").append(response)*/
//                /*alert(ControllerId)*/
//            },
//            failure: function () {
//                alert("failure");
//                modal.modal('hide')
//            },
//            error: function (response) {
//                alert("ошибка");
//                modal.modal('hide')
//            }
//        });

//    });
//    /*alert("запрос выполнен")*/
//    //$('select').change();
///*});*/


//function c() {
//    alert("жоопа");
//}
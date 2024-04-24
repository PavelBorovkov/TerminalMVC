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
            $("#block1").html($(response))
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


//function myFunction() {
//    var x = document.getElementById("command").innerHTML;
//    document.getElementById("parameter_name1").innerHTML = x.val();
//}






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
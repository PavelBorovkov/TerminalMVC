// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.






//const select = document.querySelector('select');

//select.onchange = function () {
//    let item = select.value;
//    return item;
//}


//function myFunction() {
//    var x = document.getElementById("command").innerHTML;
//    document.getElementById("parameter_name1").innerHTML = x.val();
//}


$(function () {
    $('select').on('change', function (e) {
        let ControllerId = 1;
        $.ajax({
            type: 'GET',
            url: '/Home/GetParameters',
            data: { "ControllerId": ControllerId },
            success: function (response) {
                
               //сюда вставляем код  с разметкой
            },
            failure: function () {
                modal.modal('hide')
            },
            error: function (response) {
                alert("ошибка");
            }
        });

    });

    $('select').change();
});


//function c() {
//    alert("жоопа");
//}
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.






    let select = document.querySelector('select');

    select.onchange = function () {
        let ControllerId = $("#commandId").val();
        $.ajax({
            type: 'GET',
            url: '/Home/ParametersPartialView',
            data: { "ControllerId": ControllerId },
            success: function (response) {
                $("#parameters").html($(response))
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

    let a = 1;
    function myFunction() {
        let terminalId = document.getElementById('id').value
        let p1, p2, p3
        if (document.getElementById('parameter_value1') == null) {
            p1 = 0;
        }
        else
            p1 = document.getElementById('parameter_value1').value;

        if (document.getElementById('parameter_value2') == null) {
            p2 = 0;
        }
        else
            p2 = document.getElementById('parameter_value2').value;
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

        var table = document.getElementById("History");
        var newRow = table.insertRow(0);


        $.ajax({
            type: 'POST',
            url: '/Home/TerminalResponse',
            data: {
                "GetParams": myDictionary,
                "terminalId": terminalId
            },
            success: function (response) {
                newRow.innerHTML =response;

                var rows = table.getElementsByTagName("tr");

                for (var i = 0; i < rows.length; i++) {
                    table.rows[i].cells[0].textContent = i+1;
                };
                a++;
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

    }







﻿phoneNumber = 0;
$(document).ready(function ()
{  
    AddNewPhone();
});

$("#AddPhone").on('click', function ()
{
    AddNewPhone();
})

function AddNewPhone()
{
    $.ajax({
        url: "/Employees/AddPhone",
        type: "GET",
        data: {
            number: phoneNumber
        },
        success: function (respons)
        {
            $("#Phones").append(respons);
            phoneNumber++;
        }
    })
}
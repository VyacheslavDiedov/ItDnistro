jQuery(document).ready(function ($) {
    var $loading = $('<div class="loading"><img  alt="" /></div>');
    $(".default").each(function () {
        var defaultVal = $(this).attr('title');
        $(this).focus(function () {
            if ($(this).val() == defaultVal) {
                $(this).removeClass('active').val('');
            }
        });
        $(this).blur(function () {
            if ($(this).val() == '') {
                $(this).addClass('active').val(defaultVal);
            }
        })
            .blur().addClass('active');
    });
    $('.button4').click(function (d) {
        removeToDefault();
    });

    $('.btn-submit').click(function (e) {

        var emailReg = /^\w+([\.-]?\w+)*@@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        var telReg1 = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/;
        removeToDefault();
        var e_mes = document.getElementById("email-err");
        var n_mes = document.getElementById("name-err");
        var t_mes = document.getElementById("tel-err");


        var data = {
            FullName: $("#input-name").val(),
            EMail: $("#input-email").val(),
            PhoneNumber: $("#input-phone").val(),
            TourTypeId: @ViewBag.TourId

    };

    if (data.EMail.length == 0) {

        e_mes.innerText = "Обов'язкове поле";
    }
    if (data.EMail.length != 0 && !emailReg.test(data.EMail)) {

        e_mes.innerText = "Введіть валідну email адресу";
    }
    if (data.FullName.length == 0) {
        n_mes.innerText = "Обов'язкове поле";

    }
    if (data.PhoneNumber.length == 0) {
        t_mes.innerText = "Обов'язкове поле";
    }
    if (data.PhoneNumber.length != 0 && !data.PhoneNumber.match(telReg1)) {
        t_mes.innerText = "Введіть валідний номер телефону ";
    }
    if (e_mes.innerText != "") {
        $('#input-email').css("box-shadow", "0 0 5px #FF0000");
    }
    if (n_mes.innerText != "") {
        $('#input-name').css("box-shadow", "0 0 5px #FF0000");
    }
    if (t_mes.innerText != "") {
        $('#input-phone').css("box-shadow", "0 0 5px #FF0000");
    }

    if (t_mes.innerText == "" && e_mes.innerText == "" && n_mes.innerText == "") {
        $("[data-dismiss=modal]").trigger({ type: "click" });
        $.ajax({
            url: "/Home/SetData",
            type: 'POST',
            cache: false,
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: Swal.fire(
                'Чудово!',
                'Вас зареєстровано!',
                'success'
            )
        });

    }

    e.preventDefault();
});
});
function removeToDefault() {
    $('.default').each(function () {
        var defaultVal = $(this).attr('placeholder');
        if ($(this).val() == defaultVal) {
            $(this).val('');
        }
    });
    x = document.getElementsByClassName("error");  // Find the elements
    for (var i = 0; i < x.length; i++) {
        x[i].innerText = "";    // Change the content
    }
    $('#input-email').css("box-shadow", "0 0 1px #00b33c ");
    $('#input-name').css("box-shadow", "0 0 1px #00b33c ");
    $('#input-phone').css("box-shadow", "0 0 1px #00b33c ");
}
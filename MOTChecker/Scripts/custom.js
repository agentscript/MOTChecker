$(document).ready(function () {

    $('#regplate').on('keypress', function (event) {
        var regex = new RegExp("^[a-zA-Z0-9]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    });

    $("[id='searchcars']").on('click', function () {
        var registration = $('#regplate').val();
        $.ajax({
            url: "/Home/Search",
            data: {
                'reg': registration
    },
            type: "GET",
            success: function (response) {
                $('#dvPartialView').html(response);
            },
            error: function (err) {
                alert(err.responseText);
            }
        });
    });
});
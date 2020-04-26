$(document).ready(function () {

    // Sign Up
    $("#signup-btn").click(function () {
        if ($("#confirm-password").val() != $("#Password").val()) {
            $("#password-mismatch-error").show();
            return false;
        }
    });

    $("#confirm-password").keypress(function () {
        $("#password-mismatch-error").hide();
    });

    // User Profile
    $("#edit-btn").click(function () {
        $("input").removeAttr("disabled");
        $("select").removeAttr("disabled");
        $(".username-card").show();
        $(".password-card").show();
    });

    // Admin
    $("#search-lastname,#search-testid").keyup(function () {
        var value = $(this).val().toLowerCase();
        $("#user-table tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

});
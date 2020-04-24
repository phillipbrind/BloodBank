$(document).ready(function () {

    // Log in
    $("#user").focus(function () {
        $("#user-line").css("background-color", "#F1562A");
    });

    $("#user").blur(function () {
        $("#user-line").css("background-color", "#000");
    });

    $("#password").focus(function () {
        $("#password-line").css("background-color", "#F1562A");
    });

    $("#password").blur(function () {
        $("#password-line").css("background-color", "#000");
    });

    $("#user").hover(function () {
        $("#user-line").css("height", "2px")
    }, function () {
        $("#user-line").css("height", "1px")
    });

    $("#password").hover(function () {
        $("#password-line").css("height", "2px")
    }, function () {
        $("#password-line").css("height", "0.5px")
    });

    // Sign Up
    $("#firstname").focus(function () {
        $("#fname-line").css("background-color", "#F1562A");
    });

    $("#firstname").blur(function () {
        $("#fname-line").css("background-color", "#000");
    });

    $("#lastname").focus(function () {
        $("#lname-line").css("background-color", "#F1562A");
    });

    $("#lastname").blur(function () {
        $("#lname-line").css("background-color", "#000");
    });

    $("#age").focus(function () {
        $("#age-line").css("background-color", "#F1562A");
    });

    $("#age").blur(function () {
        $("#age-line").css("background-color", "#000");
    });

    $("#address").focus(function () {
        $("#address-line").css("background-color", "#F1562A");
    });

    $("#address").blur(function () {
        $("#address-line").css("background-color", "#000");
    });

    $("#blood-type").focus(function () {
        $("#bloodtype-line").css("background-color", "#F1562A");
    });

    $("#blood-type").blur(function () {
        $("#bloodtype-line").css("background-color", "#000");
    });

    $("#username").focus(function () {
        $("#username-line").css("background-color", "#F1562A");
    });

    $("#username").blur(function () {
        $("#username-line").css("background-color", "#000");
    });

    $("#confirm-pass").focus(function () {
        $("#confirm-pass-line").css("background-color", "#F1562A");
    });

    $("#confirm-pass").blur(function () {
        $("#confirm-pass-line").css("background-color", "#000");

        if ($("#confirm-pass").val() == "") {
            $("#error-message").toggle();
        }
    });

    $("#firstname").hover(function () {
        $("#fname-line").css("height", "2px")
    }, function () {
        $("#fname-line").css("height", "0.5px")
    });

    $("#lastname").hover(function () {
        $("#lname-line").css("height", "2px")
    }, function () {
        $("#lname-line").css("height", "1px")
    });

    $("#age").hover(function () {
        $("#age-line").css("height", "2px")
    }, function () {
        $("#age-line").css("height", "0.5px")
    });

    $("#address").hover(function () {
        $("#address-line").css("height", "2px")
    }, function () {
        $("#address-line").css("height", "0.5px")
    });

    $("#lastname").hover(function () {
        $("#lname-line").css("height", "2px")
    }, function () {
        $("#lname-line").css("height", "1px")
    });

    $("#blood-type").hover(function () {
        $("#bloodtype-line").css("height", "2px")
    }, function () {
        $("#bloodtype-line").css("height", "1px")
    });

    $("#username").hover(function () {
        $("#username-line").css("height", "2px")
    }, function () {
        $("#username-line").css("height", "0.5px")
    });

    $("#confirm-pass").hover(function () {
        $("#confirm-pass-line").css("height", "2px")
    }, function () {
        $("#confirm-pass-line").css("height", "1px")
    });

    $("#signup-btn").click(function () {
        if ($("#ConfirmPassword").val() != $("#Password").val()) {
            $("#password-mismatch-error").show();
            return false;
        }
    });

    // User Profile
    $("#edit-btn").click(function () {
        $("input").removeAttr("disabled");
        $("select").removeAttr("disabled");
        $(".username-card").show();
        $(".password-card").show();
    });

    // Admin
    $("#search-lastname").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#user-table tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#search-testid").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#user-table tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

});
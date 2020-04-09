// User Login Profile
$("#logged-user").hover(function () {
    $("#user-menu").fadeIn();
});

$("#user-menu").hover(function () {
    $("#user-menu").show();
}, function () {
    $("#user-menu").fadeOut();
});

// Log in
$("#user").focus(function () {
    $("#user-line").css("background-color", "tomato");
});

$("#user").blur(function () {
    $("#user-line").css("background-color", "#000");
});

$("#password").focus(function () {
    $("#password-line").css("background-color", "tomato");
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
    $("#fname-line").css("background-color", "tomato");
});

$("#firstname").blur(function () {
    $("#fname-line").css("background-color", "#000");
});

$("#lastname").focus(function () {
    $("#lname-line").css("background-color", "tomato");
});

$("#lastname").blur(function () {
    $("#lname-line").css("background-color", "#000");
});

$("#age").focus(function () {
    $("#age-line").css("background-color", "tomato");
});

$("#age").blur(function () {
    $("#age-line").css("background-color", "#000");
});

$("#address").focus(function () {
    $("#address-line").css("background-color", "tomato");
});

$("#address").blur(function () {
    $("#address-line").css("background-color", "#000");
});

$("#blood-type").focus(function () {
    $("#bloodtype-line").css("background-color", "tomato");
});

$("#blood-type").blur(function () {
    $("#bloodtype-line").css("background-color", "#000");
});

$("#username").focus(function () {
    $("#username-line").css("background-color", "tomato");
});

$("#username").blur(function () {
    $("#username-line").css("background-color", "#000");
});

$("#confirm-pass").focus(function () {
    $("#confirm-pass-line").css("background-color", "tomato");
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

if ($("#confirm-pass").val() == "") {
    $("#error-message").toggle();
}

$("#signup-btn").click(function () {
    if ($("#confirm-pass").val() != $("#password").val()) {
        $("#error-message").toggle();
        return false;
    }
});
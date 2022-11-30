
        const toggleForm = () => {
            const container = document.querySelector('.container');
    container.classList.toggle('active');
};

jQuery(document).ready(function ($) {
    checklocalstorage();
    Loginuser();
   
    $('.cd-popup-trigger').on('click', function (event) {
        event.preventDefault();

    });

    //close popup
    $('.cd-popup').on('click', function (event) {
        if ($(event.target).is('.cd-popup-close') || $(event.target).is('.cd-popup')) {
            event.preventDefault();
            $(this).removeClass('is-visible');
        }
    });
    //close popup when clicking the esc keyboard button
    $(document).keyup(function (event) {
        if (event.which == '27') {
            $('.cd-popup').removeClass('is-visible');
        }
    });
});
var names;
var emails;
var mobiles;
var passs;
var conpasss;
$('#fullname').keyup(function () {
    var fullname = $('#fullname').val()
    if (fullname.length < 6) {
        $('#fullname').css({ "outline": "red", "border": "1px solid red" });
        $('#fullname').attr("placeholder","Name Should Be greater then 6");

        names = false;
    } else {
        $('#fullname').css({ "outline": "none", "border": "none" });
        names = true;

    }
});
$('#email').keyup(function () {
    var email = $('#email').val()
    if (email.length < 6) {
        $('#email').css({ "outline": "red", "border": "1px solid red" });
        $('#email').attr("placeholder", "Email is must");
        emails = false;
    } else {
        $('#email').css({ "outline": "none", "border": "none" });
        emails = true;
    }
});
$('#mobile').keyup(function () {
    var mobile = $('#mobile').val()
    if (mobile.length !== 10) {
        $('#mobile').css({ "outline": "red", "border": "1px solid red" });
        $('#mobile').attr("placeholder", "Please Provide me valid Number");
        mobiles = false;
    } else {
        $('#mobile').css({ "outline": "none", "border": "none" });
        mobiles = true;
    }
});
$('#password').keyup(function () {
    var password = $('#password').val()
    if (password.length < 6) {
        $('#password').css({ "outline": "red", "border": "1px solid red" });
        $('#password').attr("placeholder", "password Should Be greater then 6");
        passs = false;
    } else {
        $('#password').css({ "outline": "none", "border": "none" });
        passs = true;
    }
});
$('#confirmpassword').keyup(function () {
    var confirmpassword = $('#confirmpassword').val()
    if (confirmpassword.length < 6) {
        $('#confirmpassword').css({ "outline": "red", "border": "1px solid red" });
        $('#confirmpassword').attr("placeholder", "Password Should Be greater then 6");
        conpasss = false;
    } else {
        $('#confirmpassword').css({ "outline": "none", "border": "none" });
        conpasss = true;
    }
});


function checklocalstorage() {
    var data = document.baseURI;
    
    if (data === "http://103.255.39.101:80/Store/Registration") {
        if (localStorage.length > 2) {

            var d = {


                Mobile: parseInt(localStorage.getItem('username')),
                Password: localStorage.getItem('password')

            }
            $.ajax({
                type: 'post',
                url: 'http://103.255.39.101:80/Store/Registration/Login',
                crossDomain: true,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(d),
                success: function (data) {

                    if (data[1].Message == "success") {
                        window.localStorage.setItem('username', data[0].user_email);
                        window.localStorage.setItem('password', data[0].user_password);
                        mangal = false;
                        window.location.href = "http://103.255.39.101:80/Store/";
                    } else {
                        $('.message').html("<span style=" + "color:red;" + "> User Not Valid</span>")
                        $('.cd-popup').addClass('is-visible');
                        setTimeout(function () {
                            $('.cd-popup').removeClass('is-visible');
                        }, 1000)
                    }


                },
                error: function (error) {
                    console.log(error)
                }
            })
        }
    }
}
function postuser() { 
    
    $('#submituserdata').click(function () {
        $('.message').html("<span style=" + "color:red;" + "></span>");
        var u = {

            User_name: $('#fullname').val(),
            User_email: $('#email').val(),
            User_mobile: $('#mobile').val(),
            User_password: $('#password').val()
        }
        var fullname = $('#fullname').val()
        var email = $('#email').val()
        var mobile = $('#mobile').val()
        var pass = $('#password').val()
        var conpass = $('#confirmpassword').val()
        if (fullname.length === 0) {
            $('#fullname').css({ "outline": "red", "border": "1px solid red" });
            $('.message').html("<span style=" + "color:red;" + "> Feild is Required</span><br>")
        }
        if (email.length === 0) {
            $('#email').css({ "outline": "red", "border": "1px solid red" });
            $('.message').html("<span style=" + "color:red;" + "> Feild is Required</span><br>")
        }
        if (mobile.length === 0) {
            $('#mobile').css({ "outline": "red", "border": "1px solid red" });
            $('.message').html("<span style=" + "color:red;" + "> Feild is Required</span><br>")
        }

        if (names == true && emails == true && mobiles == true && passs == true && conpasss == true) {
            $('.message').html("<span style=" + "color:red;" + "></span>");
            if (pass === conpass) {
                $.ajax({
                    type: 'post',
                    url: 'http://103.255.39.101:80/Store/Registration/Register',
                    crossDomain: true,
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(u),
                    success: function (data) {

                        for (var i = 0; i < data.length; i++) {
                            $('.message').append("<span style=" + "color:red;" + ">" + data[i] + "</span><br>");

                        };
                        if (data[0] == "success") {
                            $('.cd-popup').addClass('is-visible');
                            setTimeout(function () {
                                $('.cd-popup').removeClass('is-visible');
                            },1000)
                            toggleForm();
                        } else {
                            $('.cd-popup').addClass('is-visible');
                            setTimeout(function () {
                                $('.cd-popup').removeClass('is-visible');
                            }, 1000)
                            
                        }
                        
                        

                    },
                    error: function (error) {
                        console.log(error)
                    }
                })
            } else {

                $('#confirmpassword').css({ "outline": "red", "border": "1px solid red" });
                $('#password').css({ "outline": "red", "border": "1px solid red" });
                $('.message').append("<span style=" + "color:red;" + "> Password doesnot match</span>")
                $('.cd-popup').addClass('is-visible');
                setTimeout(function () {
                    $('.cd-popup').removeClass('is-visible');
                }, 1000)
            }
            
        }
        else {
            if (pass !== conpass) {
                $('.message').append("<span style=" + "color:red;" + "> Password is not matched</span>")
                $('.cd-popup').addClass('is-visible');
                setTimeout(function () {
                    $('.cd-popup').removeClass('is-visible');
                }, 1000)
            } else {
                $('#confirmpassword').css({ "outline": "red", "border": "1px solid red" });
                $('#password').css({ "outline": "red", "border": "1px solid red" });
                $('.message').append("<span style=" + "color:red;" + "> Feild Are Required</span>")
                $('.cd-popup').addClass('is-visible');
                setTimeout(function () {
                    $('.cd-popup').removeClass('is-visible');
                }, 1000)
            }
            
        }
           
        
       
       
    })
   
}
function Loginuser() {

    $('#user_login').click(function () {
        var u = {

            Email: $('#Login_email').val(),
            Mobile: $('#Login_email').val(),
            Password: $('#Login_password').val(),
            
        }
            $.ajax({
                type: 'post',
                url: 'http://103.255.39.101:80/Store/Registration/Login',
                crossDomain: true,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(u),
                success: function (data) {

                    if (data[1].Message == "success") {
                        window.localStorage.setItem('username', data[0].user_email);
                        window.localStorage.setItem('password', data[0].user_password);

                        window.location.href = "http://103.255.39.101:80/Store/";
                    } else {
                        $('.message').html("<span style=" + "color:red;" + "> User Not Valid</span>")
                        $('.cd-popup').addClass('is-visible');
                        setTimeout(function () {
                            $('.cd-popup').removeClass('is-visible');
                        }, 1000)
                    }


                },
                error: function (error) {
                    console.log(error)
                }
            })
        
       
    })
}


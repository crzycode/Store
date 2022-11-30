

$(document).ready(function () {

   
    
});

function replaceimg(data) {

    $('.big_img_section').html('<img class="big_img" src="' + data + '" alt="Alternate Text" />')
}
function Addtocart(id, m) {
   
    var c = {
        user: $('#user').val(),
        product_id: id,
        price:m

    }
    $.ajax({
        type: 'POST',
        url: 'http://103.255.39.101:80/Store/Cart/addtocart/',
        crossDomain: true,
        dataType:'JSON',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(c),
        success: function (data) {
            console.log(data)
            $('.quatitiy').val(data[0])
            $('.cart_circle').html(data[1])
           
        },
        error: function (error) {
        }
    })    
}
function removecart(id, m) {
    
    var c = {
        user: $('#user').val(),
        product_id: id,
        price: m
    }
    $.ajax({
        type: 'POST',
        url: 'http://103.255.39.101:80/Store/Cart/removefromcart/',
        crossDomain: true,
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(c),
        success: function (data) {
            console.log(data)
            $('.quatitiy').val(data[0])
            $('.cart_circle').html(data[1])
            

        },
        error: function (error) {
        }
    })
}
function gotocart() {
   
    window.location.href = 'http://103.255.39.101:80/Store/Cart/Index/'
}
function TryParseInt(str, defaultValue) {
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return retValue;
}


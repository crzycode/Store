

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
        url: 'https://localhost:44382/Cart/addtocart/',
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
        url: 'https://localhost:44382/Cart/removefromcart/',
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
   
   window.location.href = "https://localhost:44382/Cart/Index"
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


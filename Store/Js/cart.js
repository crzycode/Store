$(document).ready(function () {
    gotocart_page();
})
var totalmaount = 0;

function gotocart_page() {
   
    var user = $('#cart_user').val();
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44382/Cart/gotocart/',
        data: { user: user },
        dataType: 'JSON',
        success: function (data) {
            console.log(data[0])
            
            var html = '';
            for (var i = 1; i < data.length; i++) {
               

               
                

                html += ' <div class="row" style="display:flex;height: 150px;border-bottom: 1px solid black; margin-right: 30px;margin-left: 30px;">'
                html += '<input class="a" type="text" name="name" value="" style="display:none;" />'
                html += '<div class="col-lg-3 img_section"> <img class="imgsection_img" src="' + data[i].image + ' " alt="Alternate Text" /> </div>'
                html += '<div class="col-lg-7">'
                html += '<span class="cart_product_name">' + data[i].product_name + '</span>'

                html += ' <div style="display:flex; align-items:center; position:absolute;bottom:10px;">'
                html += 'Quantity: &nbsp; &nbsp;'
                html += '<div onclick="Add_tocart(' + data[i].product_id +','+ data[i].price + ')" class="button_plus">+</div>'
                html += '<input id="quantity_counter' + data[i].product_id + '" placeholder="QTY" type="text" name="name" value="' + data[i].quantity + '"class="quatitiy" style="border-bottom: 0px solid #000; box-shadow: 0 0px 0 0 #000;" />'
                html += '<div onclick = "remove_cart(' + data[i].product_id + ',' + data[i].price +')" class="button_minus" >-</div >'
                html += '</div >'
                html += '</div >'
                html += '<div class="col-lg-3" style="text-align:end;"> '
            
                html += '<span class="cart_product_price"> ₹'+ data[i].price + '</span>'
                html += ' </div>'
                html += ' </div >'






            }
            $('.totalprice').html(" ₹" + Number(data[0]).toFixed(2))
            $('.cart_body').html(html)





        },
        error: function (error) {

        }

    })



}

function Add_tocart(id, m) {
  
    var c = {
        user: $('#cart_user').val(),
        product_id: id,
        price:m
    }
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44382/Cart/addtocart/',
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(c),
        success: function (data) {
          
           
         
            $('#quantity_counter' + id).val(data[0]);
          
            $('.cart_circle').html(data[1])
            $('.totalprice').html(" ₹" + Number(data[2]).toFixed(2))

        },
        error: function (error) {
        }
    })
}
function remove_cart(id,m) {
   
    var c = {
        user: $('#cart_user').val(),
        product_id: id,
        price:m
    }
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44382/Cart/removefromcart/',
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(c),
        success: function (data) {
          
            
            $('#quantity_counter' + id).val(data[0]);
            $('.cart_circle').html(data[1])
            $('.totalprice').html(" ₹" + Number(data[2]).toFixed(2))

        },
        error: function (error) {
        }
    })
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




$(document).ready(function () {
    
    $.ajax({
        type: 'Get',
        url: 'https://localhost:44382/Home/allproduct',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
       
        success: function (data) {
            console.log(data);
            var html = '';
            for (var i = 0; i < data.length; i++) {
                html +=' <div class="col-lg-3 col-md-4 col-sm-6 product_wrapper card">'
                html += '<div class="row"> <img onclick="gotobuy(' + data[i].product_id +')" class="image_adjust" src="' + data[i].Images +'" alt="Alternate Text" /></div>'
                html += '<div class="row text-center" style="padding: 10px 10px 10px 10px;">'
                html += '<span class="h3 product_name">' + data[i].Product_Name + '</span><br />'
                html += '<span class="h5 product_name">' + data[i].Category +'</span><br /><br /><br />'
                html += '<span class="h3 product_price">' + data[i].Selling_Price +'</span><br />'
                html += '<span class="Free_delevery">Free Delevery by mangal singh</span>'
                html+=' </div>'
                html+='</div>'
            }
            $('.Product_body').html(html);
            function getPageList(totalPage, page, maxLength) {
                function range(start, end) {
                    return Array.from(Array(end - start + 1), (_, i) => i + start)
                }
                var sideWidth = maxLength < 9 ? 1 : 2;
                leftWidth = (maxLength - sideWidth * 2 - 3) >> 1;
                rightWidth = (maxLength - sideWidth * 2 - 3) >> 1;

                if (totalPage <= maxLength) {
                    return range(1, totalPage)
                }
                if (page <= maxLength - sideWidth - 1 - rightWidth) {
                    return range(1, maxLength - sideWidth - 1).concat(0, range(totalPage - sideWidth + 1, totalPage), []);
                }
                if (page >= totalPage - sideWidth - 1 - rightWidth) {
                    return range(1, sideWidth).concat(0, range(totalPage - sideWidth - 1 - rightWidth - leftWidth, totalPage),[]);
                }
                return range(1, sideWidth).concat(0, range(page - leftWidth, page + rightWidth), 0, range(totalPage - sideWidth + 1, totalPage), []);

            }
            $(function () {
                var numberOfItem = $(".card_content .card").length;
                var limitperpage = 20;
                var totalpages = Math.ceil(numberOfItem / limitperpage);
                var paginationSize = 10;
                var currentPage;
                function showpage(whichpage) {
                    if (whichpage < 1 || whichpage > totalpages) return false;
                    currentPage = whichpage;
                    $(".card_content .card").hide().slice((currentPage - 1) * limitperpage, currentPage * limitperpage).show();

                    $(".pagination li").slice(1, -1).remove();
                    getPageList(totalpages, currentPage, paginationSize).forEach(item => {
                        $("<li>").addClass("page-item").addClass(item ? "current-page" : "dots")
                            .toggleClass("activate", item === currentPage).append($("<a>").addClass("page-link")
                                .attr({ href: "javascript:void(0)" }).text(item || "...")).insertBefore(".next-page");
                    });
                    $(".previous-page").toggleClass("disable", currentPage === 1);
                    $(".next-page").toggleClass("disable", currentPage === totalpages);
                    return true;
                }
                $(".pagination").append(
                    $("<li>").addClass("page-item").addClass("previous-page").append($("<a>").addClass("page-link").attr({ href: "javascript:void(0)" }).text("prev")),
                    $("<li>").addClass("page-item").addClass("next-page").append($("<a>").addClass("page-link").attr({ href: "javascript:void(0)" }).text("Next")),

                );
                $(".card_content").show();
                showpage(1);
                $(document).on("click", ".pagination li.current-page:not(.activate)", function () {
                    return showpage(+$(this).text());
                })
                $(".next-page").on("click", function () {
                    return showpage(currentPage + 1);
                })
                $(".previous-page").on("click", function () {
                    return showpage(currentPage - 1);
                })
            })
        
        },
        error: function (error) {
            console.log(error)
        }
    })

   

})

function gotobuy(id) {
    $.ajax({
        type: 'post',
        url: 'https://localhost:44382/Details/details',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
       /* data: JSON.stringify({id:id}),*/
        success: function (data) {
            console.log(data)
            if (data.Message == "Success") {
               
                window.location.href = "https://localhost:44382/Details/Index/" + id;
            }
        },
        error: function (error) {
            console.log("rr")
        }

    })
}











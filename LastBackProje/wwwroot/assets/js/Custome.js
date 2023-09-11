
$(document).ready(function (){

    //$('#searchInput')?.keyup(function () {
    //    if ($(this).val().trim().length == 0) {
    //        $('#searchBody')?.html('');
    //    }
    //}
    
    //$('#searchbtn')?.click(function (e) {
    //    e.preventDefault();

    //    let search = $('#searchInput').val().trim();
    //    let categoryID = $('#categoryid').val();


    //    let searchurl = 'product/search?search=' + search + 'categoryid=' + categoryid

    //    if (search.length >= 3) {
    //        fetch(searchurl)
    //            .then(res => res.text())
    //            .then(data => {
    //                console.log(data);

    //                $('#searchBody').html(data)
    //            })
    //    }



    //    console.log(search + ' ' + categoryID)
    //})

    $('.modalbtn')?.click(function (e) {
        e.preventdefault();

        let url = $(this).attr('href');


        fetch(url)
            .then(res => res.text())
            .then(data => {
                $('modal-content').html(data)
                $('.quick-view-image').slick({
                    slidestoshow: 1,
                    slidestoscroll: 1,
                    arrows: false,
                    dots: false,
                    fade: true,
                    asnavfor: '.quick-view-thumb',
                    speed: 400,
                });

                $('.quick-view-thumb').slick({
                    slidestoshow: 4,
                    slidestoscroll: 1,
                    asnavfor: '.quick-view-image',
                    dots: false,
                    arrows: false,
                    focusonselect: true,
                    speed: 400,
                });
            })
    })


    $('.AddBasket').click(function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        fetch(url)
            .then(res => res.text())
            .then(data => {
                $('.header-cart').html(data);
            });
    })

})

$(function () {
    $('.back-to-top').click(function (e) {
        e.preventDefault();

        $("html,body").animate({scrollTop: 0},800);
    });

    var vitrimenu = $('.header-container.menu').offset().top;
    $(window).scroll(function () {
        var vitribody = $('html').scrollTop();
        // scroll menu
        if(vitribody>=vitrimenu){
            $('.header-container.menu').addClass('alter');
            $('.header-topbar').addClass('hidden-bar');
        }else{
            $('.header-container.menu').removeClass('alter');
            $('.header-topbar').removeClass('hidden-bar');
        }

        // scroll back to top
        if(vitribody>=300){
            $('.back-to-top').addClass('bienhinh');
        }else{
            $('.back-to-top').removeClass('bienhinh');
        }
    });

    // top bar section
    var close_dis = $(".close-dis");
    var header_topbar = $(".header-topbar");
    close_dis.click(function () {
        header_topbar.toggleClass("hidden-bar");
    });

    //side nav section
    //close sidebar
    $('.close-side a:first-child, .overlay-menu').click(function(){
        $('.wrap-nav').removeClass('active-wrap-nav');
        $('.overlay-menu').removeClass('active-overlay');
    });

    //show sidebar and overlay
    $('.menu-bar').click(function(){
        $('.wrap-nav').toggleClass('active-wrap-nav');
        $('.overlay-menu').toggleClass('active-overlay');
    });
    // show tabcontent coresponding tab
    $('.toggle-menu').click(function () {
        $('.side-nav').toggleClass('active-sub');
        $('.close-side a:first-child').hide();
        $('.close-side a:last-child').show();
        $('.wrap-sub-menu').hide();
        $(this).parent().find('.wrap-sub-menu').show();
    });
    //return tab
    $('.close-side a:last-child').click(function () {
        $('.side-nav').removeClass('active-sub');
        $('.close-side a:first-child').show();
        $(this).hide();
    })

    //minicart section

    //show minicart
    $('.all-mini-cart').click(function(){
        $('.minicart-content').toggleClass('active-minicart');
        $('.overlay-menu').toggleClass('active-overlay');
    });
    //close minicart
    $('.close-cart, .overlay-menu').click(function(){
        $('.minicart-content').removeClass('active-minicart');
        $('.overlay-menu').removeClass('active-overlay');
    });

    $('.click-here-search').click(function (e) {
        e.preventDefault();

        $('.form-search-top').addClass('close-search');
    });

    $('.form-search-top .close').click(function (e) {
        e.preventDefault();

        $('.form-search-top').removeClass('close-search');
    });
    $('.advertisement-option span.kz-close').click(function (e) {
        e.preventDefault();

        $('.box-advertisement').toggleClass('close-box-adver');
    });


    $('.button-filter').click(function (e) {
        e.preventDefault();

        $('.multiple-option').toggleClass('xh-block-filter');
    });

    $('.column a').click(function (e) {
        e.preventDefault();

        $('.column a').removeClass('active');
        $(this).addClass('active');

    });

    $('.column .col-third').click(function (e) {
        e.preventDefault();

        $('.grid-group-item').removeClass('col-lg-3');
        $('.grid-group-item').removeClass('list-group-item');
        $('.grid-group-item').addClass('col-lg-4');

    });

    $('.column .col-four').click(function (e) {
        e.preventDefault();

        $('.grid-group-item').removeClass('col-lg-4');
        $('.grid-group-item').removeClass('list-group-item');
        $('.grid-group-item').addClass('col-lg-3');
    });

    $('.column .col-five').click(function (e) {
        e.preventDefault();

        $('.grid-group-item').removeClass('col-lg-3');
        $('.grid-group-item').removeClass('col-lg-4');
        $('.grid-group-item').addClass('list-group-item');
    });

    $('.list-action .pro-quick-view').click(function (e) {
        e.preventDefault();

        $('.box-product-quick-view').addClass('active-minicart');
    });


    $(document).on("click",".pro-imgs .btn-close",function() {

        $('.box-product-quick-view').removeClass('active-minicart');
    });


    $(".vote-star").rating({
        "emptyStar": "kz-star-line",
        "filledStar": "kz-star-fill",
        "color":"#03d607",
        "click": function (e) {
            $(".star_number").val(e.stars);
        }
    });

        $('.previews a').click(function () {
            var largeImage = $(this).attr('data-full');
            console.log(largeImage);
            $('.selected').removeClass();
            $(this).addClass('selected');
            $('.full img').hide();
            $('.full img').attr('src', largeImage);
            $('.full img').show();
        });

        $('.full img').on('click', function () {
            var modalImage = $(this).attr('src');
            $.fancybox.open(modalImage);
        });


        $('.collapse').on('shown.bs.collapse', function() {
			$(this).parent().find(".kz-plus").removeClass("kz-plus").addClass("kz-minus");

		}).on('hidden.bs.collapse', function(){
			$(this).parent().find(".kz-minus").removeClass("kz-minus").addClass("kz-plus");
        });

        $('.toggle-faqs').click(function (e) {
            e.preventDefault();
            $('.toggle-faqs').removeClass('block-faqs');
            $(this).children().toggleClass('block-faqs');
        });


        $('.open_login').click(function (e) {
            e.preventDefault();
            $('.checkout_coupon').removeClass('xuathien_coupon');
            $('.checkout_login').toggleClass('xuathien_login');
        });

        $('.open_coupon').click(function (e) {
            e.preventDefault();
            $('.checkout_login').removeClass('xuathien_login');
            $('.checkout_coupon').toggleClass('xuathien_coupon');
        });



        $('.create-account').click(function (e) {
            e.preventDefault();
            $('.cus-nav-tab li').removeClass('active');
            $('.cus-nav-tab li:last-child').addClass('active');
        });

        $('.create-account.exist-account').click(function (e) {
            e.preventDefault();
            $('.cus-nav-tab li').removeClass('active');
            $('.cus-nav-tab li:first-child').addClass('active');
        });

        $('.pro-quick-view').click(function (e) {
            var url = $(this).data("url");
            $.ajax({
                url:url,
                method:"GET",
                success:function (data) {
                    $("#pro-infor").html(data);
                }
            });
        });



})

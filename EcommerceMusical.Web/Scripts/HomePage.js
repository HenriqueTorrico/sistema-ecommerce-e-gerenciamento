$(document).ready(function () {
    $('.carousel').slick({
        autoplay: true,
        autoplaySpeed: 2000,
        infinite: true,
        speed: 500,
        fade: true,
        cssEase: 'linear',
        prevArrow: $("#arrow-prev"),
        nextArrow: $("#arrow-next"),
    });
});

$(document).ready(function () {
    $('.comentarios-clientes').slick({
        autoplay: true,
        autoplaySpeed: 1000,
        infinite: true,
        speed: 500,
        fade: true,
        cssEase: 'linear',
        prevArrow: $("#leftArrow"),
        nextArrow: $("#arrow-rightArrow"),
    });
});

$(document).ready(function () {
    $grids = $('.categorias-homepage');
    $grid = $grids.find('div a');

    smoothScrolling(200);

    function smoothScrolling(duration) {
        ($grid).on('click', function (event) {
            var $this = $(this),
                $body = $('html, body'),
                target = $($this.attr('href'));
            event.preventDefault();
            $body.animate({ scrollTop: target.offset().top - 130 });
        });
    }
});

$(document).ready(function () {
    $('.prodDesta').slick({
        infinite: false,
        dots: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000,
        prevArrow: $("#arrow-prev-destaque"),
        nextArrow: $("#arrow-next-destaque"),
        responsive: [
            {
                breakpoint: 900,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 700,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                }
            }
        ]
    });

    $('.prodOferta').slick({
        infinite: false,
        dots: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000,
        prevArrow: $("#arrow-prev-oferta"),
        nextArrow: $("#arrow-next-oferta"),
        responsive: [
            {
                breakpoint: 900,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 700,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                }
            }
        ]
    });

    $('.prodLancamento').slick({
        infinite: false,
        dots: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000,
        prevArrow: $("#arrow-prev-lancamento"),
        nextArrow: $("#arrow-next-lancamento"),
        responsive: [
            {
                breakpoint: 900,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 700,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                }
            }
        ]
    });

    $('.prodPremium').slick({
        infinite: false,
        dots: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000,
        prevArrow: $("#arrow-prev-premium"),
        nextArrow: $("#arrow-next-premium"),
        responsive: [
            {
                breakpoint: 900,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 700,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                }
            }
        ]
    });
});
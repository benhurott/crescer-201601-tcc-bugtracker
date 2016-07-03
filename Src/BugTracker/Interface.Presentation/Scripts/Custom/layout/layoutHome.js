$(function () {

    $('.nav-link[data-target-id="' + document.title + '"]').addClass('active');

    var $information = $('#informations');

    if ($information.height() > 0) {
        $information.css('display', 'block');
    }

})

jQuery(function ($) {

    //Ajax contact
    var form = $('.contact-form');
    form.submit(function () {
        $this = $(this);
        $.post($(this).attr('action'), function (data) {
            $this.prev().text(data.message).fadeIn().delay(3000).fadeOut();
        }, 'json');
        return false;
    });

    //Goto Top
    $('.gototop').click(function (event) {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $("body").offset().top
        }, 500);
    });
    //End goto top		

});
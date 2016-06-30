'use strict'

$(function () {

    $('.delete').on("click", function () {

        var id = $(this).attr('id');

        $('.delete').popover({
            placement: 'left',
            html: 'true',
            title: 'Sure?',
            content: 'Are you sure to delete this application?' + '<a href="/Application/DeleteApp/' + id + '">Yes</a>'
        });
    });
});

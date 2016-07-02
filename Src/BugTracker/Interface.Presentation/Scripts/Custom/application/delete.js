'use strict'

$(function () {

    $('.delete').popover({
        placement: 'left',
        html: 'true',
        title: 'Sure?',
        content: 'Are you sure to delete this application?' + '<a href="/Application/DeleteApp/' + $('.delete').attr('id') + '">Yes</a>'
    });
});

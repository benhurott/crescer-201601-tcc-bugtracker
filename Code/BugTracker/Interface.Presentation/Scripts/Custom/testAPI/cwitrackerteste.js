'use strict';

$(function () {
    CwiTracker.tracker({
        type: CwiTracker.ERROR,
        tags: ["teste", "teste2"],
        trace: "deu pau"
    }, function callback(error, info) {
        if (error) {
            console.log(error);
        } else {
            console.log(info);
        }
    });
});
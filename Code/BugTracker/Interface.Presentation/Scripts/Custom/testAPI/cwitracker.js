'use strict';

function CwiTracker() {
	this.urlPost = 'asdaskdp';
}

CwiTracker.track = function (obj) {
	return $.ajax({
        url: this.urlPost,
        data: obj,
        type: 'POST',
    });
}

var CwiTracker = new CwiTracker();
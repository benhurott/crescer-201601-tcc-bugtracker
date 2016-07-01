'use strict';

function CwiTracker() {
    this.hashCode = 'e26b5b51-be69-40c2-8471-1956e014453410';
    this.urlPost = '/BugTracker/Add';
    this.ERROR = 1;
    this.INFO = 2;
    this.WARNING = 3;
}

CwiTracker.track = function (obj, callback) {
    obj['HashCode'] = this.hashCode;

    $.ajax({
        url: this.urlPost,
        data: obj,
        type: 'POST',
        success: function (success) {
            callback(null, success);
        },
        error: function (error) {
            callback(error, null);
        }
    });
}

var CwiTracker = new CwiTracker();

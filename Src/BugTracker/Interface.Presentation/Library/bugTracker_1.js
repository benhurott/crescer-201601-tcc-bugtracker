'use strict';

function CwiTracker() {
    this.hashCode = 'b7c9413d-0747-45ed-84e9-ade95cbba15b81';
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
'use strict';

function CwiTracker() {
    this.hashCode = 'b7c9413d-0747-45ed-84e9-ade95cbba15b81';
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
'use strict';

function CwiTracker() {
    this.hashCode = 'b7c9413d-0747-45ed-84e9-ade95cbba15b81';
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

'use strict';

function BugTrackerView() {
    this.page = 0;
    this.bModel = new BugTrackerModel();
    this.win = $(window);
}

BugTrackerView.prototype.init = function () {
    self = (this);

    this.loadData();

    this.win.scroll(function () {
        if ($(document).height() - self.win.height() === self.win.scrollTop())
            self.loadData();
    });
};


BugTrackerView.prototype.loadData = function () {
    self = (this);

    self.page += 1;

    this.bModel.getPagined(this.page).done(function (data) {
        $('#list-bug-tracks').append(data);
    });
};

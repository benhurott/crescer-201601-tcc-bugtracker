'use strict';

function BugTrackerModel() {
    this.urlGetPagined = '/BugTracker/GetBugTrackerPaginedByApp';
    this.urlCount = '/BugTracker/GetCountBugTrackerByApp';
}

BugTrackerModel.prototype.getPagined = function (page) {
    return $.ajax({
        url: this.urlGetPagined,
        data: { idApplication: idApplication, page: page }
    });
}

BugTrackerModel.prototype.countBugs = function (idApplication) {
    return $.ajax({
        url: this.urlCount,
        data: { idApplication: idApplication }
    });
}

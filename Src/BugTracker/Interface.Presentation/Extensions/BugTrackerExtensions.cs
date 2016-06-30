﻿using Interface.Presentation.Models.BugTracker;
using Domain = BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Extensions
{
    public static class BugTrackerExtensions
    {
        public static BugTrackerViewModel BugTrackerToViewModel(this Domain.BugTracker bugTracker)
        {
            return
                new BugTrackerViewModel(
                    bugTracker.Description,
                    bugTracker.OccurredDate,
                    bugTracker.Status,
                    bugTracker.Tags,
                    bugTracker.Navigation.Browser.Name,
                    bugTracker.Navigation.Browser.Version,
                    bugTracker.Navigation.OperationalSystem.Name
                );
        }

        public static ICollection<BugTrackerViewModel> FromModel(this ICollection<Domain.BugTracker> bugTracks)
        {
            var BugTracksViewModels = new List<BugTrackerViewModel>();

            foreach (var bug in bugTracks)
            {
                BugTracksViewModels.Add(BugTrackerToViewModel(bug));
            }

            return BugTracksViewModels;
        }
    }
}
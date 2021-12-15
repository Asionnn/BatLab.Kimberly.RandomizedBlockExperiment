using System;
using System.Collections.Generic;
using System.Text;

namespace BatLab.Kimberly.RandomizedBlockExperiment
{
    public class Response
    {
        private double ReactionTime { get; set; }
        private string Question1 { get; set; }
        private int AccuracyRating { get; set; }
        private int IntuitivenessRating { get; set; }

        public Response(double reactionTime, string question1, int accuracyRating, int intuitivenessRating)
        {
            ReactionTime = reactionTime;
            Question1 = question1;
            AccuracyRating = accuracyRating;
            IntuitivenessRating = intuitivenessRating;
        }
    }
}

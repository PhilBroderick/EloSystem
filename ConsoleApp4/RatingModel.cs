using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class RatingModel
    {

        private const int kFactor = 15;
        public const double Win = 1;
        public const double Lose = 0;
        public const double Draw = 0.5;

        protected double _ratingA;
        protected double _ratingB;

        protected double _scoreA;
        protected double _scoreB;

        protected double _expectedA;
        protected double _expectedB;

        protected double _newRatingA;
        protected double _newRatingB;

        public RatingModel(Matchup matchup)
        {
            SetNewSettings(Convert.ToDouble(matchup.enteredTeams[0].TeamRating), Convert.ToDouble(matchup.enteredTeams[1].TeamRating), matchup.User1Score, matchup.User2Score);

            matchup.enteredTeams[0].TeamRating = Convert.ToDecimal(this._newRatingA);

            matchup.enteredTeams[1].TeamRating = Convert.ToDecimal(this._newRatingB);
        }

        /**
        * Set new input data.
        *
        * @param double ratingA Current rating of A
        * @param double ratingB Current rating of B
        * @param double scoreA Score of A
        * @param double scoreB Score of B
        * @return self
        */

        public RatingModel SetNewSettings(double ratingA, double ratingB, double scoreA, double scoreB)
        {
            _ratingA = ratingA;
            _ratingB = ratingB;
            _scoreA = scoreA;
            _scoreB = scoreB;

            List<double> expectedScores = _getExpectedScores(_ratingA, _ratingB);
            _expectedA = expectedScores[0];
            _expectedB = expectedScores[1];

            List<double> newRatingsList = _getNewRatings(_ratingA, _ratingB, _expectedA, _expectedB, _scoreA, _scoreB);
            _newRatingA = newRatingsList[0];
            _newRatingB = newRatingsList[1];

            return this;
        }

        /**
         * Retrieve the calculated data.
         *
         * @return List<double> A list containing the new ratings for A and B.
        */
        public List<double> GetNewRatings()
        {
            List<double> newRatingsList = new List<double>
            {
                _newRatingA,
                _newRatingB
            };

            return newRatingsList;
        }

        // Protected & private functions begin here
        /**
         * @param double ratingA The Rating of Player A
         * @param double ratingB The Rating of Player B
         * @return List<double>
         */
        protected List<double> _getExpectedScores(double ratingA, double ratingB)
        {
            double expectedScoreA = 1 / (1 + (Math.Pow(10, (ratingB - ratingA) / 400)));
            double expectedScoreB = 1 / (1 + (Math.Pow(10, (ratingA - ratingB) / 400)));

            List<double> expectedScoresList = new List<double>
            {
                expectedScoreA,
                expectedScoreB
            };

            return expectedScoresList;
        }

        /**
         * @param double ratingA The Rating of Player A
         * @param double ratingB The Rating of Player A
         * @param double expectedA The expected score of Player A
         * @param double expectedB The expected score of Player B
         * @param double scoreA The score of Player A
         * @param double scoreB The score of Player B
         * @return List<double>
         */
        protected List<double> _getNewRatings(double ratingA, double ratingB, double expectedA, double expectedB, double scoreA, double scoreB)
        {
            double newRatingA = ratingA + (RatingModel.kFactor * (scoreA - expectedA));
            double newRatingB = ratingB + (RatingModel.kFactor * (scoreB - expectedB));

            List<double> newRatingList = new List<double>
            {
                newRatingA,
                newRatingB
            };

            return newRatingList;
        }
    }
}

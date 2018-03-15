namespace OutreachOperations.Ranking.Elo
{
    /// <summary>
    /// https://metinmediamath.wordpress.com/2013/11/27/how-to-calculate-the-elo-rating-including-example/
    /// 
    /// </summary>
    internal class DefaultEloCalculator : EloCalculator
    {
        private int _maximumRatingChange = 15;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerA">Player 'A' of Match</param>
        /// <param name="playerB">Player 'B' of Match</param>
        /// <param name="outCome">The outcome of the match either win, loss or draw</param>
        /// <returns>New ratings for both players</returns>
        public NewRatings Calculate(CurrentPlayerRating playerA, CurrentPlayerRating playerB, MatchOutcome outCome)
        {
            PlayerRatingCalculator calculator = new PlayerRatingCalculator();

            int playerAExpectedOutcome = calculator.CalculateExpectedOutcome(playerA.Rating, playerB.Rating);

            int playerBExpectedOutcome = calculator.CalculateExpectedOutcome(playerB.Rating, playerA.Rating);

            decimal playerAOutcome = 0;
            switch (outCome)
            {
                case MatchOutcome.PlayerAWin:
                    playerAOutcome = 1;
                    break;
                case MatchOutcome.Draw:
                    playerAOutcome = 0.5M;

                    break;
                case MatchOutcome.PlayerBWin:
                    playerAOutcome = 0;

                    break;
            }

            decimal playerBOutcome = 0;
            switch (outCome)
            {
                case MatchOutcome.PlayerAWin:
                    playerBOutcome = 0;
                    break;
                case MatchOutcome.Draw:
                    playerBOutcome = 0.5M;

                    break;
                case MatchOutcome.PlayerBWin:
                    playerBOutcome = 1;

                    break;
            }
            
            var newPLayerRatingA = new NewlayerRatingsDefault() {PlayerId = "A", Rating = calculator.CalculateNewRating(playerA.Rating, _maximumRatingChange, playerAExpectedOutcome, playerAOutcome)};
            var newPLayerRatingB = new NewlayerRatingsDefault() {PlayerId = "B", Rating = calculator.CalculateNewRating(playerB.Rating, _maximumRatingChange, playerBExpectedOutcome, playerBOutcome)};
            
            return new NewRatingsDefault {PlayerA = newPLayerRatingA,PlayerB = newPLayerRatingB};
        }

        public NewRatings Calculate(int playerARating, string playerAId, int playerBRating, string playerBId, MatchOutcome outCome)
        {
            return Calculate(new CurrentPlayerRatingDefault {PlayerId = playerAId, Rating = playerARating}
                , new CurrentPlayerRatingDefault {PlayerId = playerBId, Rating = playerBRating}, outCome);
        }
    }
}
namespace OutreachOperations.Ranking.Elo
{
    /// <summary>
    /// https://metinmediamath.wordpress.com/2013/11/27/how-to-calculate-the-elo-rating-including-example/
    /// 
    /// </summary>
    public class DefaultEloCalculator : EloCalculator
    {
        private int _maximumRatingChange = 15;


        public NewRatings Calculate(CurrentPlayerRating playerA, CurrentPlayerRating playerB, Outcome outCome)
        {
            PlayerRatingCalculator calculator = new PlayerRatingCalculator();

            int playerAExpectedOutcome = calculator.CalculateExpectedOutcome(playerA.Rating, playerB.Rating);

            int playerBExpectedOutcome = calculator.CalculateExpectedOutcome(playerB.Rating, playerA.Rating);

            decimal playerAOutcome = 0;
            switch (outCome)
            {
                case Outcome.PlayerAWin:
                    playerAOutcome = 1;
                    break;
                case Outcome.Draw:
                    playerAOutcome = 0.5M;

                    break;
                case Outcome.PlayerBWin:
                    playerAOutcome = 0;

                    break;
            }
            decimal playerBOutcome = 0;
            switch (outCome)
            {
                case Outcome.PlayerAWin:
                    playerBOutcome = 0;
                    break;
                case Outcome.Draw:
                    playerBOutcome = 0.5M;

                    break;
                case Outcome.PlayerBWin:
                    playerBOutcome = 1;

                    break;
            }


            var newPLayerRatingA = new NewlayerRatingsDefault() {PlayerId = "A", Rating = calculator.CalculateNewRating(playerA.Rating, _maximumRatingChange, playerAExpectedOutcome, playerAOutcome)};
            var newPLayerRatingB = new NewlayerRatingsDefault() {PlayerId = "B", Rating = calculator.CalculateNewRating(playerB.Rating, _maximumRatingChange, playerBExpectedOutcome, playerBOutcome)};




            return new NewRatingsDefault(){PlayerA = newPLayerRatingA,PlayerB = newPLayerRatingB};
        }
    }

    public enum Outcome
    {
        PlayerAWin,
        Draw,
        PlayerBWin
    }
}
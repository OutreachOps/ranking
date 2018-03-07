namespace OutreachOperations.Ranking.Elo
{
    public interface EloCalculator
    {
        NewRatings Calculate(CurrentPlayerRating playerA, CurrentPlayerRating playerB, Outcome outCome);
    }

    public static class EloCalculatorFactory
    {
        public static EloCalculator Create()
        {
            return new DefaultEloCalculator();
        }
    }


    public interface CurrentPlayerRating
    {
        string PlayerId { get; set; }
        int Rating { get; set; }
    }

    class CurrentPlayerRatingDefault : CurrentPlayerRating
    {
        public string PlayerId { get; set; }
        public int Rating { get; set; }
    }

    public interface NewPlayerRating   
    {
        string PlayerId { get; set; }

        int Rating { get; set; }
    }

    public interface NewRatings
    {
        NewPlayerRating PlayerA { get; set; }
        NewPlayerRating PlayerB { get; set; }
    }

    public class NewRatingsDefault : NewRatings
    {
        public NewPlayerRating PlayerA { get; set; }
        public NewPlayerRating PlayerB { get; set; }
    }

    public class NewlayerRatingsDefault : NewPlayerRating
    {
        public string PlayerId { get; set; }
        public int Rating { get; set; }
    }
}

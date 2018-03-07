namespace OutreachOperations.Ranking.Elo
{
    public class CurrentPlayerRatingDefault : CurrentPlayerRating
    {
        public string PlayerId { get; set; }
        public int Rating { get; set; }
    }
}
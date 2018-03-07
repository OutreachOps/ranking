namespace OutreachOperations.Ranking.Elo
{
    public interface CurrentPlayerRating
    {
        string PlayerId { get; set; }
        int Rating { get; set; }
    }
}
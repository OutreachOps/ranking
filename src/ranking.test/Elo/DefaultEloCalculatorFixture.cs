using OutreachOperations.Ranking.Elo;
using Xunit;

namespace OutreachOperations.Ranking.Test.Elo
{
    public class DefaultEloCalculatorFixture
    {
        [Fact]
        public void CanCreateDefaultEloCalculator()
        {
            var calculator = EloCalculatorFactory.Create();

            Assert.NotNull(calculator);
        }

        [Fact]
        public void PlayerADefeatsPlayerB()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(
                new CurrentPlayerRatingDefault {PlayerId = "A", Rating = 1572}
                , new CurrentPlayerRatingDefault {PlayerId = "B", Rating = 1583}, MatchOutcome.PlayerAWin);

            Assert.Equal(1572 + 8,result.PlayerA.Rating);
            Assert.Equal(1583 -8, result.PlayerB.Rating);

        }

        [Fact]
        public void PlayerBDefeatsPlayerA()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(
                new CurrentPlayerRatingDefault { PlayerId = "A", Rating = 1572 }
                , new CurrentPlayerRatingDefault { PlayerId = "B", Rating = 1583 }, MatchOutcome.PlayerBWin);

            Assert.Equal(1572 - 7, result.PlayerA.Rating);
            Assert.Equal(1583 + 7, result.PlayerB.Rating);
        }

        [Fact]
        public void PlayersDraw()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(
                new CurrentPlayerRatingDefault { PlayerId = "A", Rating = 1572 }
                , new CurrentPlayerRatingDefault { PlayerId = "B", Rating = 1583 }, MatchOutcome.Draw);

            Assert.Equal(1572 , result.PlayerA.Rating);
            Assert.Equal(1583 , result.PlayerB.Rating);
        }

        [Fact]
        public void PlayerADefeatsPlayerB_ParamInput()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(1572, "A", 1583, "B", MatchOutcome.PlayerAWin);

            Assert.Equal(1572 + 8, result.PlayerA.Rating);
            Assert.Equal(1583 - 8, result.PlayerB.Rating);

        }

        [Fact]
        public void PlayerBDefeatsPlayerA_ParamInput()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(1572, "A", 1583, "B", MatchOutcome.PlayerBWin);

            Assert.Equal(1572 - 7, result.PlayerA.Rating);
            Assert.Equal(1583 + 7, result.PlayerB.Rating);
        }

        [Fact]
        public void PlayersDraw__ParamInput()
        {
            var calculator = EloCalculatorFactory.Create();

            var result = calculator.Calculate(1572,"A",1583,"B",MatchOutcome.Draw);

            Assert.Equal(1572, result.PlayerA.Rating);
            Assert.Equal(1583, result.PlayerB.Rating);
        }
    }


}

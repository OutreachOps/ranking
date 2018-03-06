using Solaris7.Ranking.glicko2;
using Xunit;

namespace Solaris7.Ranking.Test.glicko2
{
    public class Glicko2Fixture
    {
        [Fact(Skip = "Glicko not implemented")]
        public void CanCreateDefaultImplementation()
        {
            Glicko2 ranking = Glicko2Factory.Create();

            Assert.NotNull(ranking);
        }
    }
}

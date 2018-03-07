# Ranking
Outreach Operations player ranking library 

Ranking library for;
 - Elo based player ranking.


[![Build status](https://ci.appveyor.com/api/projects/status/og4x66runmo1b9r7?svg=true)](https://ci.appveyor.com/project/adrianrussell/ranking)

# Usage

Create calculator and calculate new ratings for players based on the outcome.

```cs
var calculator = EloCalculatorFactory.Create();

    var result = calculator.Calculate(
        new CurrentPlayerRatingDefault {PlayerId = "A", Rating = 1572},
        new CurrentPlayerRatingDefault {PlayerId = "B", Rating = 1583},
        MatchOutcome.PlayerAWin);
```

using NUnit.Framework;
using System;
using GolfScoreOnly.Models;

namespace GolfSCoreOnlyTest
{
    [TestFixture]
    public class GoldScoreModelTests
    {                 

        [Test]
        public void CalculateNettScore_GivenScoreLessThanZero_ReturnZero()
        {
            //arrange
            Player p1 = new Player("P1", 15);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = -1 };

            //act
            var stroke = 5;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.AreEqual(0, nettScore);
        }

        [Test]
        public void CalculateNettScore_NettScore_GreaterThanZero()
        {
            //arrange
            Player p1 = new Player("P1", 15);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 4 };

            //act
            var stroke = 5;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(nettScore >= 0);
        }

        [Test]
        public void CalculateNettScore_Scratch_GrossEqualNett()
        {
            //arrange
            Player p1 = new Player("P1", 0);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 4 };

            //act
            var stroke = 5;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(nettScore == sut.Gross);
        }

        [Test]
        public void CalculateNettScore_OneTo18_GrossWithinOneOfNett()
        {
            //arrange
            Player p1 = new Player("P1", 10);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 5 };

            //act
            var stroke = 5;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(Math.Abs(nettScore - sut.Gross) <= 1 );
        }

        [Test]
        public void CalculateNettScore_OneTo18_GrossEqualNettIfStrokeGreaterThanHandicap()
        {
            //arrange
            Player p1 = new Player("P1", 10);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 5 };

            //act
            var stroke = 11;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(nettScore == sut.Gross);
        }

        [Test]
        public void CalculateNettScore_OneTo18_NettIsStrokeMinusOne()
        {
            //arrange
            Player p1 = new Player("P1", 10);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 5 };

            //act
            var stroke = 9;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(nettScore == sut.Gross -1 );
        }

        [Test]
        public void CalculateNettScore_19To36_GrossWithinTwoOfNett()
        {
            //arrange
            Player p1 = new Player("P1", 25);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 5 };

            //act
            var stroke = 10;
            var nettScore = sut.CalculateNett(stroke);
            var diff = Math.Abs(nettScore - sut.Gross);
            //assert
            Assert.That(nettScore != sut.Gross);
            Assert.That( diff >= 1 && diff <= 2 );
        }

        [Test]
        public void CalculateNettScore_19To36_GrossEqualNettPlus1IfStrokeGreaterThanHandicapPlus18()
        {
            //arrange
            Player p1 = new Player("P1", 25);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 5 };

            //act
            var stroke = 10;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(nettScore == sut.Gross - 1);
        }

        [Test]
        public void CalculateNettScore_19To36_GrossEqualNettPlus2IfStrokeLessThanHandicapPlus18()
        {
            //arrange
            Player p1 = new Player("P1", 25);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 5 };

            //act
            var stroke = 3;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(nettScore == sut.Gross - 2);
        }

        [Test]
        public void CalculateNettScore_PlayerHandicap_LessThanOr36()
        {
            //arrange
            Player p1 = new Player("P1", 37);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 5 };

            //act
            var stroke = 3;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(p1.Handicap == 36);
        }

        [Test]
        public void CalculateNettScore_PlayerHandicap_LessThan0()
        {
            //arrange
            Player p1 = new Player("P1", -5);
            Hole h1 = new Hole(1, 4);
            var sut = new Score { Player = p1, Hole = h1, Gross = 5 };

            //act
            var stroke = 3;
            var nettScore = sut.CalculateNett(stroke);

            //assert
            Assert.That(p1.Handicap == 0);
        }
    }
}

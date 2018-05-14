using System;
using System.Collections.Generic;
using Xunit;

namespace Rasodu.IndexesConstituents.Client.Test
{
    public class ConstituentTest
    {
        [Fact]
        public void CompareToTest()
        {
            //arrange
            var first = new Constituent
            {
                StockExchange = "NYSE",
                Identifier = "GE",
            };
            var second = new Constituent
            {
                StockExchange = "NYSE",
                Identifier = "GE",
            };
            //act
            var result = first.CompareTo(second);
            //assert
            Assert.True(result == 0);
        }
        [Fact]
        public void CompareToTestNotSame()
        {
            //arrange
            var first = new Constituent
            {
                StockExchange = "NYSE",
                Identifier = "GE",
            };
            var second = new Constituent
            {
                StockExchange = "NYSE",
                Identifier = "XOM",
            };
            //act
            var result = first.CompareTo(second);
            //assert
            Assert.True(result != 0);
        }
        [Fact]
        public void EqualsTest()
        {
            //arrange
            var first = new Constituent
            {
                StockExchange = "NYSE",
                Identifier = "GE",
            };
            var second = new Constituent
            {
                StockExchange = "NYSE",
                Identifier = "GE",
            };
            //act
            var result = first.Equals(second);
            //assert
            Assert.True(result);
        }

        [Fact]
        public void EqualsTestWhenNotSame()
        {
            //arrange
            var first = new Constituent
            {
                StockExchange = "NYSE",
                Identifier = "GE",
            };
            var second = new Constituent
            {
                StockExchange = "NYSE",
                Identifier = "XOM",
            };
            //act
            var result = first.Equals(second);
            //assert
            Assert.False(result);
        }
    }
}
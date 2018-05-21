using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Rasodu.IndexesConstituents.Updater.Test
{
    public class HelperTest
    {
		[Fact]
		public void GetAllSourceClasses()
		{
            //arrange
            var helper = new Helper();
            var expectedSourceClasses = new Dictionary<String, Type>
            {
                { "DowJones30", typeof(IndexConstituentsSourceForDJ30) },
                { "Nasdaq100", typeof(IndexConstituentsSourceForNasdaq100) },
                { "Nifty100", typeof(IndexConstituentsSourceForNifty100) },
                { "SP500", typeof(IndexConstituentsSourceForSP500) },
            };
            //act
            var actualSourceClasses = helper.GetAllSourceClasses();
            //assert
            Assert.Equal(expectedSourceClasses, actualSourceClasses);
        }
    }
}

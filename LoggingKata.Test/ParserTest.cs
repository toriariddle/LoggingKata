using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LoggingKata.Test
{
    [TestFixture]
    public class TacoParserTestFixture
    {
        [Test]
        public void EmptyStringReturnNull ()
        {
            var empty = "";
            var emptyStringTest = new TacoParser();

            //Act
            var valueReturned = emptyStringTest.Parse(empty);

            //Assert:
            Assert.IsNull(valueReturned);
            //TODO: Complete ShouldParseLine
        }

        [Test]
        public void ShouldParseLine()
        {
            //Arrange
            var sampleData = "-84.677017, 34.073638 , Taco Bell Acwort...";

            //TODO: Complete ShouldParseLine

        }
    }
}

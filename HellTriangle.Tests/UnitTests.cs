using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HellTriangle.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ExampleTest_Equal26()
        {
            var elementsValues = new[] {
                new []{ 6 },
                new []{ 3, 5 },
                new []{ 9, 7, 1 },
                new []{ 4, 6, 8, 4 },
            };

            Assert.AreEqual(HellTriangleCalculator.TryGetMaxSumTopToBottom(0, 0, elementsValues), 26);
        }

        [TestMethod]
        public void LargeAmountElementsTest_Equal36()
        {
            var elementsValues = new[] {
                new []{ 1 },
                new []{ 1, 2 },
                new []{ 1, 2, 3 },
                new []{ 1, 2, 3, 4 },
                new []{ 1, 2, 3, 4, 5 },
                new []{ 1, 2, 3, 4, 5, 6 },
                new []{ 1, 2, 3, 4, 5, 6, 7 },
                new []{ 1, 2, 3, 4, 5, 6, 7, 8 },
            };

            Assert.AreEqual(HellTriangleCalculator.TryGetMaxSumTopToBottom(0, 0, elementsValues), 36);
        }

        [TestMethod]
        public void TriangleInvalidLessElementsOnXAxis_ThereAreLessElementsThanExpectedInXAxis()
        {
            var elementsValues = new[] {
                new []{ 6 },
                new []{ 3, }, //One less element
                new []{ 9, 7, 1 },
                new []{ 4, 6, 8, 4 },
            };

            try
            {
                HellTriangleCalculator.TryGetMaxSumTopToBottom(0, 0, elementsValues);
                Assert.Fail("Diferent error than expected");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, HellTriangleCalculator.ExceptionMessageThereAreLessElementsThanExpectedInXAxis);
            }
            catch (Exception)
            {
                Assert.Fail("Diferent error than expected");
            }
        }

        [TestMethod]
        public void TriangleInvalidMoreElementsOnXAxis_ThereAreMoreElementsThanExpectedInXAxis()
        {
            var elementsValues = new[] {
                new []{ 6 },
                new []{ 3, 5, 2 }, //One more element
                new []{ 9, 7, 1 },
                new []{ 4, 6, 8, 4 },
            };

            try
            {
                HellTriangleCalculator.TryGetMaxSumTopToBottom(0, 0, elementsValues);
                Assert.Fail("Diferent error than expected");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, HellTriangleCalculator.ExceptionMessageThereAreMoreElementsThanExpectedInXAxis);
            }
            catch (Exception)
            {
                Assert.Fail("Diferent error than expected");
            }
        }

        [TestMethod]
        public void TriangleInvalidInvalidGivenYAxis_TheGivenYAxisDoesntExist()
        {
            var elementsValues = new[] {
                new []{ 6 },
                new []{ 3, 5 }, 
                new []{ 9, 7, 1 },
                new []{ 4, 6, 8, 4 }
            };

            try
            {
                HellTriangleCalculator.TryGetMaxSumTopToBottom(4, 0, elementsValues); //Invalid given Y axis
                Assert.Fail("Diferent error than expected");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, HellTriangleCalculator.ExceptionMessageTheGivenYAxisDoesntExist);
            }
            catch (Exception)
            {
                Assert.Fail("Diferent error than expected");
            }
        }

        [TestMethod]
        public void TriangleInvalidInvalidGivenXAxis_TheGivenXAxisDoesntExist()
        {
            var elementsValues = new[] {
                new []{ 6 },
                new []{ 3, 5 },
                new []{ 9, 7, 1 },
                new []{ 4, 6, 8, 4 }
            };

            try
            {
                HellTriangleCalculator.TryGetMaxSumTopToBottom(0, 2, elementsValues); //Invalid given X axis
                Assert.Fail("Diferent error than expected");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message ,HellTriangleCalculator.ExceptionMessageTheGivenXAxisDoesntExist);
            }
            catch (Exception)
            {
                Assert.Fail("Diferent error than expected");
            }
        }
    }
}

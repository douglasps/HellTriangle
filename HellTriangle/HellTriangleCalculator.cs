using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellTriangle
{
    public static class HellTriangleCalculator
    {
        public const string ExceptionMessageInvalidTriangle = "Invalid triangule";
        public const string ExceptionMessageTheGivenYAxisDoesntExist = "The given Y axis doesn't exist";
        public const string ExceptionMessageTheGivenXAxisDoesntExist = "The given X axis doesn't exist";
        public const string ExceptionMessageThereAreMoreElementsThanExpectedInXAxis = "There are more elements than expected in the X axis";
        public const string ExceptionMessageThereAreLessElementsThanExpectedInXAxis = "There are less elements than expected in the X axis";

        public static int TryGetMaxSumTopToBottom(int yAxisIndex, int xAxisIndex, int[][] elementsValues)
        {
            //If there isn't the given yAxisIndex
            ValidateYAxisExistence(yAxisIndex, elementsValues);

            //If there isn't the given xAxisIndex
            ValidateXAxisExistence(yAxisIndex, xAxisIndex, elementsValues);

            //If there isn't another "row" (Y axis), return the current value
            var nextYAxis = yAxisIndex + 1;
            if (nextYAxis >= elementsValues.Length) return elementsValues[yAxisIndex][xAxisIndex];

            //If there are less elements than expected in the X axis
            ValidateLessXAxisThanExpected(yAxisIndex, elementsValues, nextYAxis);

            //If there are more elements than expected in the X axis
            ValidateMoreXAxisThanExpected(yAxisIndex, elementsValues, nextYAxis);

            var nextLeftIndex = xAxisIndex <= 0 ? 0 : xAxisIndex;
            var nextRightIndex = nextLeftIndex + 1;

            var sumLeft = TryGetMaxSumTopToBottom(nextYAxis, nextLeftIndex, elementsValues);
            var sumRight = TryGetMaxSumTopToBottom(nextYAxis, nextRightIndex, elementsValues);

            return elementsValues[yAxisIndex][xAxisIndex] + (sumLeft > sumRight ? sumLeft : sumRight);
        }

        #region Validations
        /// <summary>
        /// Validates if the Y axis exists in the given multidimensional array
        /// </summary>
        /// <param name="yAxisIndex">The current Y axis</param>
        /// <param name="elementsValues">The multidimensional array</param>
        private static void ValidateYAxisExistence(int yAxisIndex, int[][] elementsValues)
        {
            if (elementsValues.Length <= yAxisIndex)
                throw new InvalidOperationException(ExceptionMessageTheGivenYAxisDoesntExist);
        }

        /// <summary>
        /// Validates if the X axis exists in the given multidimensional array
        /// </summary>
        /// <param name="yAxisIndex">The current Y axis</param>
        /// <param name="xAxisIndex">The current X axis</param>
        /// <param name="elementsValues">The multidimensional array</param>
        private static void ValidateXAxisExistence(int yAxisIndex, int xAxisIndex, int[][] elementsValues)
        {
            if (elementsValues[yAxisIndex].Length <= xAxisIndex)
                throw new InvalidOperationException(ExceptionMessageTheGivenXAxisDoesntExist);

        }

        /// <summary>
        /// Validates if there are more x axis than expected
        /// </summary>
        /// <param name="yAxisIndex">The current Y axis</param>
        /// <param name="elementsValues">The multidimensional array</param>
        /// <param name="nextYAxis">The next Y axis</param>
        private static void ValidateMoreXAxisThanExpected(int yAxisIndex, int[][] elementsValues, int nextYAxis)
        {
            if (elementsValues[nextYAxis].Length > elementsValues[yAxisIndex].Length + 1)
                throw new InvalidOperationException(ExceptionMessageThereAreMoreElementsThanExpectedInXAxis);
        }

        /// <summary>
        /// Validates if there are less x axis than expected
        /// </summary>
        /// <param name="yAxisIndex">The current Y axis</param>
        /// <param name="elementsValues">The multidimensional array</param>
        /// <param name="nextYAxis">The next Y axis</param>
        private static void ValidateLessXAxisThanExpected(int yAxisIndex, int[][] elementsValues, int nextYAxis)
        {
            if (elementsValues[nextYAxis].Length <= elementsValues[yAxisIndex].Length)
                throw new InvalidOperationException(ExceptionMessageThereAreLessElementsThanExpectedInXAxis);
        }
        #endregion
    }
}

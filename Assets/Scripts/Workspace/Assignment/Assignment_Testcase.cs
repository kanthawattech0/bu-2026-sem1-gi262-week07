using NUnit.Framework;
using UnityEngine;

namespace Assignment
{
    public class Assignment_Testcase
    {
        private IAssignment assignment;

        [SetUp]
        public void Setup()
        {
            // Use StudentSolution as the test subject
            assignment = new StudentSolution();
        }

        [TearDown]
        public void Teardown()
        {
            if (assignment is MonoBehaviour monoBehaviour)
            {
                UnityEngine.Object.DestroyImmediate(monoBehaviour);
            }

            assignment = null;
        }

        #region Lecture

        [Category("Lecture")]
        [TestCase(
            TestName = "LCT01_SequentialSearch1DArray",
            Description = "Lecture: Sequential Search in 1D Array"
        )]
        public void LCT01_SequentialSearch1DArray()
        {
            int actual = assignment.LCT01_SequentialSearch1DArray();

            Assert.AreEqual(5, actual);
        }


        [Category("Lecture")]
        [TestCase(
            TestName = "LCT02_SequentialSearch2DArray",
            Description = "Lecture: Sequential Search in 2D Array"
        )]
        public void LCT02_SequentialSearch2DArray()
        {
            int[] actual = assignment.LCT02_SequentialSearch2DArray();

            CollectionAssert.AreEqual(
                new int[] { 2, 1 },
                actual
            );
        }


        [Category("Lecture")]
        [TestCase(
            TestName = "LCT03_BinarySearch",
            Description = "Lecture: Binary Search"
        )]
        public void LCT03_BinarySearch()
        {
            int actual = assignment.LCT03_BinarySearch();

            Assert.AreEqual(3, actual);
        }

        #endregion


        #region Assignment

        [Category("Assignment")]
        [TestCase(
            new int[] { 1, 2, 2, 2, 3 },
            2,
            new int[] { 1, 3 },
            TestName = "AS01_FindFirstAndLastElementOfArray_Basic"
        )]
        [TestCase(
            new int[] { 1, 2, 3, 4, 5 },
            6,
            new int[] { -1 },
            TestName = "AS01_FindFirstAndLastElementOfArray_NotFound"
        )]
        [TestCase(
            new int[] { 5, 5, 5, 5, 5 },
            5,
            new int[] { 0, 4 },
            TestName = "AS01_FindFirstAndLastElementOfArray_AllSame"
        )]
        [TestCase(
            new int[] { 1 },
            1,
            new int[] { 0, 0 },
            TestName = "AS01_FindFirstAndLastElementOfArray_SingleElement"
        )]
        [TestCase(
            new int[] { 1, 2, 3 },
            2,
            new int[] { 1, 1 },
            TestName = "AS01_FindFirstAndLastElementOfArray_SingleOccurrence"
        )]
        public void Test_AS01_FindFirstAndLastElementOfArray(
            int[] array,
            int target,
            int[] expected)
        {
            int[] actual =
                assignment.AS01_FindFirstAndLastElementOfArray(array, target);

            CollectionAssert.AreEqual(
                expected,
                actual,
                $"Expected indices [{string.Join(",", expected)}] " +
                $"but got [{string.Join(",", actual ?? new int[0])}]"
            );
        }


        [Category("Assignment")]
        [TestCase(
            new int[] { 4, 2, 10, 9, 8, 11 },
            9,
            8,
            TestName = "AS02_FindMaxLessThan_Basic"
        )]
        [TestCase(
            new int[] { 4, 2, 10, 9, 8, 11 },
            2,
            -1,
            TestName = "AS02_FindMaxLessThan_NoLess"
        )]
        [TestCase(
            new int[] { 1, 2, 3, 5, 6 },
            5,
            3,
            TestName = "AS02_FindMaxLessThan_Middle"
        )]
        [TestCase(
            new int[] { 15, 5, 20, 40, 30 },
            5,
            -1,
            TestName = "AS02_FindMaxLessThan_Smallest"
        )]
        [TestCase(
            new int[] { 1, 2, 3 },
            4,
            3,
            TestName = "AS02_FindMaxLessThan_AllLess"
        )]
        public void Test_AS02_FindMaxLessThan(
            int[] array,
            int target,
            int expected)
        {
            int actual =
                assignment.AS02_FindMaxLessThan(array, target);

            Assert.AreEqual(
                expected,
                actual,
                $"Expected {expected} but got {actual}"
            );
        }


        [Category("Assignment")]
        [TestCase(
            new int[] { 1, 3, 5, 7, 9 },
            4,
            8,
            new int[] { 5, 7 },
            TestName = "AS03_FindRange_Basic"
        )]
        [TestCase(
            new int[] { 1, 2, 3, 4, 5 },
            6,
            10,
            new int[] { },
            TestName = "AS03_FindRange_Empty"
        )]
        [TestCase(
            new int[] { 10, 20, 30, 40, 50 },
            10,
            50,
            new int[] { 10, 20, 30, 40, 50 },
            TestName = "AS03_FindRange_All"
        )]
        [TestCase(
            new int[] { 1, 2, 3, 4, 5 },
            2,
            4,
            new int[] { 2, 3, 4 },
            TestName = "AS03_FindRange_Middle"
        )]
        [TestCase(
            new int[] { 5 },
            5,
            5,
            new int[] { 5 },
            TestName = "AS03_FindRange_Single"
        )]
        public void Test_AS03_FindRange(
            int[] array,
            int min,
            int max,
            int[] expected)
        {
            int[] actual =
                assignment.AS03_FindRange(array, min, max);

            CollectionAssert.AreEqual(
                expected,
                actual,
                $"Expected [{string.Join(",", expected)}] " +
                $"but got [{string.Join(",", actual ?? new int[0])}]"
            );
        }

        #endregion


        #region Extra

        [Category("Extra")]
        [TestCase(
            new int[] { 2, 3, 7, 8, 10 },
            15,
            new int[] { 2, 3, 7 },
            TestName = "EX01_FindTargetEnemies_Basic"
        )]
        [TestCase(
            new int[] { 2, 3, 7, 8, 10 },
            3,
            new int[] { 2 },
            TestName = "EX01_FindTargetEnemies_Single"
        )]
        [TestCase(
            new int[] { 2, 3, 7, 8, 10 },
            6,
            new int[] { 2, 3 },
            TestName = "EX01_FindTargetEnemies_Two"
        )]
        [TestCase(
            new int[] { 1, 2, 3 },
            10,
            new int[] { 1, 2, 3 },
            TestName = "EX01_FindTargetEnemies_All"
        )]
        [TestCase(
            new int[] { 5, 10 },
            4,
            new int[] { },
            TestName = "EX01_FindTargetEnemies_None"
        )]
        public void Test_EX01_FindTargetEnemies(
            int[] enemyHPs,
            int mana,
            int[] expected)
        {
            int[] actual =
                assignment.EX01_FindTargetEnemies(enemyHPs, mana);

            CollectionAssert.AreEquivalent(
                expected,
                actual,
                $"Expected [{string.Join(",", expected)}] " +
                $"but got [{string.Join(",", actual ?? new int[0])}]"
            );
        }

        #endregion
    }
}
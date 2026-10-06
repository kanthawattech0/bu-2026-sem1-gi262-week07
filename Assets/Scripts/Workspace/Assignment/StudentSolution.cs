using System;
using System.Collections.Generic;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int[] LCT02_SequentialSearch2DArray()
        {
            int[,] array = new int[,]
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };

            int target = 23;
            int row = -1;
            int col = -1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == target)
                    {
                        row = i;
                        col = j;

                        return new int[] { row, col };
                    }
                }
            }

            return new int[] { row, col };
        }

        public int LCT03_BinarySearch()
        {
            int[] array = new int[]
            {
                11, 12, 21, 23, 34, 45, 56, 78, 90
            };

            int target = 23;

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (array[middle] == target)
                {
                    return middle;
                }
                else if (array[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }

        #endregion


        #region Assignment

        public int[] AS01_FindFirstAndLastElementOfArray(
            int[] array,
            int target)
        {
            int first = -1;
            int last = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    if (first == -1)
                    {
                        first = i;
                    }

                    last = i;
                }
            }

            if (first == -1)
            {
                return new int[] { -1 };
            }

            return new int[] { first, last };
        }

        public int AS02_FindMaxLessThan(
            int[] array,
            int target)
        {
            int result = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < target)
                {
                    if (result == -1 || array[i] > result)
                    {
                        result = array[i];
                    }
                }
            }

            return result;
        }

        public int[] AS03_FindRange(
            int[] array,
            int min,
            int max)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }

        #endregion


        #region Extra

        public int[] EX01_FindTargetEnemies(
            int[] enemyHPs,
            int mana)
        {
            int[] sortedHP = new int[enemyHPs.Length];

            for (int i = 0; i < enemyHPs.Length; i++)
            {
                sortedHP[i] = enemyHPs[i];
            }

            Array.Sort(sortedHP);

            List<int> result = new List<int>();
            int usedMana = 0;

            for (int i = 0; i < sortedHP.Length; i++)
            {
                if (usedMana + sortedHP[i] <= mana)
                {
                    result.Add(sortedHP[i]);
                    usedMana += sortedHP[i];
                }
                else
                {
                    break;
                }
            }

            return result.ToArray();
        }

        #endregion
    }
}
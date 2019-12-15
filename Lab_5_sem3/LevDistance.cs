using System;

namespace Lab_5_sem3
{
    public class LevDistance
    {
        public static int GetDistance(string source, string destination)
        {
            if (source == null || destination == null)
            {
                return -1;
            }
            int lenSrc = source.Length;
            int lenDst = destination.Length;
            if (lenSrc == 0 && lenDst == 0)
            {
                return 0;
            }
            if (lenSrc == 0)
            {
                return lenDst;
            }
            if (lenDst == 0)
            {
                return lenSrc;
            }
            string strSrc = source.ToUpper();
            string strDst = destination.ToUpper();
            int[,] matrix = new int[lenSrc + 1, lenDst + 1];
            for(int i = 0; i <= lenSrc; i++)
            {
                matrix[i, 0] = i;
            }
            for(int j = 0; j <= lenDst; j++)
            {
                matrix[0, j] = j;
            }
            for (int i = 1; i <= lenSrc; i++)
            {
                for (int j = 1; j <= lenDst; j++)
                {
                    int chEqual = 1;
                    if (strSrc[i - 1] == strDst[j - 1])
                    {
                        chEqual = 0;
                    }
                    int ins = matrix[i, j - 1] + 1; 
                    int del = matrix[i - 1, j] + 1; 
                    int change = matrix[i - 1, j - 1] + chEqual;
                    matrix[i, j] = Math.Min(Math.Min(ins, del), change);
                    if ((i > 1) && (j > 1) && (strSrc[i - 1] == strDst[j - 2]) && (strSrc[i - 2] == strDst[j - 1]))
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + chEqual);
                    }
                }
            }
            return matrix[lenSrc, lenDst];
        }
    }
}

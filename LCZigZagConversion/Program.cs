using System;
using System.Collections.Generic;

namespace LCZigZagConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            ZigZagConversion("PAYPALISHIRING", 3); //should return PAHNAPLSIIGYIR. "PINALSIGYAHRPI" with 4 rows.

            void ZigZagConversion(string s, int numRows)
            {
                if (numRows == 1) { Console.WriteLine(s); }

                Dictionary<int, string> zigzagRows = new Dictionary<int, string>();

                for (int i = 0; i < numRows; i++)
                {
                    zigzagRows.Add(i, string.Empty);
                }

                int rowTracker = 0;

                bool incrementingRows = true;

                for (int i = 0; i < s.Length; i++)
                {
                    if (incrementingRows && rowTracker < numRows)
                    {
                        zigzagRows[rowTracker] += s[i];
                        rowTracker++;
                        if (rowTracker == numRows )
                        {
                            incrementingRows = !incrementingRows;
                            rowTracker -= 2;
                            continue;
                        }
                    }
                    if (!incrementingRows && rowTracker > -1)
                    {
                        zigzagRows[rowTracker] += s[i];
                        rowTracker--;
                        if (rowTracker == -1)
                        {
                            incrementingRows = !incrementingRows;
                            rowTracker += 2;
                            continue;
                        }
                    }
                }

                string convertedString = string.Empty;

                foreach (KeyValuePair<int, string> entry in zigzagRows)
                {
                    convertedString += entry.Value;
                }

                Console.WriteLine(convertedString);
            }
        }
    }
}

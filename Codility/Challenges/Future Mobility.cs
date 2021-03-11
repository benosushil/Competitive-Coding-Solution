using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A, int[] B) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        long moves = 0;
        int mod = 1000000007;
        var n = A.Length;
        // To store the number of required stones in k-th position
        var C = new long[n];
        for(var i = 0; i < n; i++)
        {
            C[i] = A[i] - B[i];
        }

        for(var i = 0; i < n - 2; i++)
        {
            // If k-th position needs no stones
            if (C[i] == 0)
            {
                continue;
            }
            // If movement from k-th to k+1-th is not feasible
            else if ((C[i] < 0 && C[i + 1] < 0) || (C[i] > 0 && C[i + 1] > 0) || C[i + 1] == 0)
            {
                C[i + 2] += C[i];
                moves +=  Math.Abs(C[i]);
                C[i] = 0;
            }
            // Try to level k+1 position and move others to k+2
            else
            {
                moves +=  Math.Abs(C[i]);
                // if k+1 can hold all k extra/minus
                if (Math.Abs(C[i + 1]) > Math.Abs(C[i]))
                {
                    C[i + 1] += C[i];
                    C[i] = 0;
                }
                else
                {
                    C[i + 2] += C[i] + C[i + 1];
                    C[i + 1] = 0;
					C[i] = 0;
                }
            }
        }

        // Move last two elements in C
        if(n >= 2)
        {
            moves += Math.Abs(C[n-2]);
            C[n-1] += C[n-2];
            C[n-2] = 0;
        }

        // If rearrangement is impossible
        if(C[n - 1] != 0)
        {
            return -1;
        }

        return (int)(moves % mod);
    }
}

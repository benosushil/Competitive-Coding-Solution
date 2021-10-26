using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        int max = A[0];
        int N = A.Length;
        for (int i = 0; i < N; i++)
        {
            long stackMax = A[i];
            long previousStack = 0;
            // 0 to i-1
            for(int j = 0; j < i; j++)
                previousStack = (previousStack/2) + A[j];
            // coins from previous stacks
            stackMax += previousStack/2;

            long nextStack = 0;
            // 0 to i-1
            for(int j = N-1; j > i; j--)
                nextStack = (nextStack/2) + A[j];
            // coins from next stack
            stackMax  += nextStack/2;
            max = max > stackMax ? max : (int)stackMax;
        }
        return max;
    }
}

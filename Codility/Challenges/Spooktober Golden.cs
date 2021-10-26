using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        int max = A[0];
        int N = A.Length;

        if(N == 1)
            return max;
        
        int[] forwardMoveStack = new int[N];
        int[] backwardMoveStack = new int[N];
        
        forwardMoveStack[0] = A[0];
        for (int i = 1; i < N; i++)
        {
            forwardMoveStack[i] += A[i] + (forwardMoveStack[i-1]/2);
        }

        backwardMoveStack[N - 1] = A[N-1];
        for (int i = N-2; i >= 0; i--)
        {
            backwardMoveStack[i] += A[i] + (backwardMoveStack[i+1]/2);
        }

        for (int i = 0; i < N; i++)
        {
            var iMax = A[i];
            if (i == 0)
                iMax += backwardMoveStack[i+1]/2;
            else if (i == N-1)
                iMax += forwardMoveStack[i-1]/2;
            else
                iMax += (backwardMoveStack[i+1]/2) + (forwardMoveStack[i-1]/2);
            max = max > iMax ? max : iMax; 
        }
        return max;
    }
}

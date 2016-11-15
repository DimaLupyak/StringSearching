using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;

namespace StringSearch
{
    [Description("Knuth–Morris–Pratt algorithm. Returns identical strings")]
    [StringSearchAlgorithm("Knuth–Morris–Pratt algorithm", Version = "2.0")]
    public class AlgorithmKmp : ISearchAlgorithm
    {
        #region ISearchAlgorithm
        public ResultItem Search(string s, string key)
        {
            int n = s.Length;
            int m = key.Length;
            var pmt = PartialMatchTable(key);

            int i = 0; // position of current character in key
            int j = 0; // beginning of current match in S
            while (i < n)
            {
                if (s[i] == key[j])
                {
                    j++;
                    i++;
                }
                if (j == m) { return new ResultItem(i - m, key); }
                else if (i < n && s[i] != key[j]) // mismatch after j matches
                {
                    // Skip lps[j - 1] chars; they will match
                    if (j > 0) { j = pmt[j - 1]; }
                    else i++;
                }
            }
            return null; // no matches found
        }

        public IEnumerable<ResultItem> SearchAll(string s, string key)
        {
            int n = s.Length;
            int m = key.Length;
            var pmt = PartialMatchTable(key);

            int i = 0; // position of current character in key
            int j = 0; // beginning of current match in S
            var matchIndices = new List<ResultItem>();
            while (i < n)
            {
                if (s[i] == key[j])
                {
                    j++;
                    i++;
                }
                if (j == m)
                {
                    matchIndices.Add(new ResultItem(i - m, key));
                    j = pmt[j - 1];
                }
                else if (i < n && s[i] != key[j]) // mismatch after j matches
                {
                    // Skip pmt[j - 1] chars; they will match
                    if (j > 0) { j = pmt[j - 1]; }
                    else i++;
                }
            }
            return matchIndices;
        }
        #endregion
        #region Implementation
        // Standard Knuth-Morris-Pratt algorithm for building
        // the partial match table. 
        private int[] PartialMatchTable(string s)
        {
            int n = s.Length;
            var pmt = new int[n];

            // j = 0-based index in S of the next char in current candidate substr.
            // j also keeps track of matching chars between prefix iterations.
            int j = 0;

            // i = current position being evaluated in S
            for (int i = 1; i < n; i++)
            {
                // While the char at index i in S mis-matches the char at index j
                // in current candidate substring, reset j to fall back the length 
                // of the (j-1)'th prefix's longest border (in # of chars.) Often this 
                // involves falling back to j=0 and comparing chars manually after
                // while-loop terminates.
                while (j > 0 && s[i] != s[j])
                {
                    j = pmt[j - 1];
                }
                // Keeps track of the matching characters between prefixes, so next
                // prefix iteration can skip comparing any previously computed (i, j).
                //
                // e.g. S = abcababcbabaab
                // iteration 3 finds 'a'=='a' for 'abc', 'abca'; increments i.
                // iteration 4 finds 'b'=='b' for 'abca', 'abcab'; skips
                //  comparing 1st char of 'abca' when looking for border.
                if (s[i] == s[j]) { j++; }

                // Done matching; the prefix i has j chars in common with the
                // next prefix. i.e. j = length of i'th prefix's longest border.
                pmt[i] = j;
            }
            pmt[0] = 0; // i=0 -> S[0..i-1] is invalid (negative length)
            return pmt;
        }
        #endregion
    }
}

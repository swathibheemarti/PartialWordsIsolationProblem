using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolationPartialWords
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "cc^aa^^^^aa^bb^aa^b^a^^^g^h^e^d^eee^eeeee^e^e^f^f^ffffff^fff^i^f";

            //char[][] arrChars =  GetCharacterArray(input, 1, 5);

            bool isa1isolated = Find1Isolation(input, 'e',  GetS(input, new char[]{'a','b','c'}), GetH(input), 1, 5);



            Console.Read();
        }

        private static char[][] GetCharacterArray(string input, int p, int q)
        {
            int l = input.Length;

            char[][] charArray = new char[q][];


            for (int i = 0; i < q; i++)
            {
                char[] chars = new char[l / q + 1];

                for (int j = 0; j <= l / q; j++)
                {
                    if (q * j + i < l)
                    {
                        chars[j] = input[q * j + i];
                    }
                }

                charArray[i] = chars;
            }

            return charArray;
        } 

        private static bool Find1Isolation(string input, char ch, int[] S, int[] H, int p, int q)
        {
            bool is1Isolated = true;

            for (int i = 0; i < input.Length; i++)
            {
                bool left = true, right = true, above = true, below = true;

                if (input[i] == ch)
                {
                    if (S.Contains(i) && i >= q)
                    {
                        left = S.Contains(i - q) || H.Contains(i - q);
                    }

                    if (S.Contains(i))
                    {
                        right = S.Contains(i + q) || H.Contains(i + q);
                    }

                    if (S.Contains(i) && i >= p)
                    {
                        above = S.Contains(i - p) || H.Contains(i - p);
                    }

                    if (S.Contains(i))
                    {
                        below = S.Contains(i + p) || H.Contains(i + p);
                    }

                    is1Isolated = left && right && above && below;

                    if (!is1Isolated)
                    {
                        break;
                    }
                }
            }

            return is1Isolated;
        }

        private static int[] GetS(string input, char[] subsetChars)
        {
            List<int> lst = new List<int>();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (subsetChars.Contains(input[i]))
                {
                    lst.Add(i);
                }
            }

            return lst.ToArray();
        }

        private static int[] GetH(string input)
        {
            List<int> lst = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '^')
                {
                    lst.Add(i);
                }
            }

            return lst.ToArray();
        }
    }
}

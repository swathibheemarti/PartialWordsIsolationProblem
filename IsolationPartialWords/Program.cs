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

            Console.WriteLine("Please enter the character you want to see isolations for : ");
            char ch = Convert.ToChar(Console.Read());

            Console.WriteLine("Your string : " + input);
            Console.WriteLine("Checking isolations......");

            bool is_1isolated = Find1Isolation(input, GetS(input, new char[]{ ch }), GetH(input), 1, 5);
            bool is_2isolated = Find2Isolation(input, GetS(input, new char[]{ ch }), GetH(input), 1, 5);
            bool is_3isolated = Find3Isolation(input, GetS(input, new char[]{ ch }), GetH(input), 1, 5);

            Console.WriteLine("\n\n{0} is \n\n1 isolated: {1} \n2 isolated: {2} \n3 isolated: {3}", ch.ToString(),
                              is_1isolated.ToString(), is_2isolated.ToString(), is_3isolated.ToString());
                                                      



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

        private static bool Find1Isolation(string input, int[] S, int[] H, int p, int q)
        {
            bool is1Isolated = true;

            for (int i = 0; i < S.Length; i++)
            {
                bool left = true, right = true, above = true, below = true;

                if (S[i] >= q)
                {
                    left = S.Contains(S[i] - q) || H.Contains(S[i] - q);
                }

                right = S.Contains(S[i] + q) || H.Contains(S[i] + q);


                if (S[i] >= p)
                {
                    above = S.Contains(S[i] - p) || H.Contains(S[i] - p);
                }

                below = S.Contains(S[i] + p) || H.Contains(S[i] + p);

                is1Isolated = left && right && above && below;

                if (!is1Isolated)
                {
                    break;
                }
            }

            return is1Isolated;
        }

        private static bool Find2Isolation(string input, int[] S, int[] H, int p, int q)
        {
            bool is1Isolated = true;

            for (int i = 0; i < S.Length; i++)
            {
                bool left = true, right = true, above = true, below = true;

                left  = S.Contains(S[i] - q) || H.Contains(S[i] - q);
                right = S.Contains(S[i] + q) || H.Contains(S[i] + q);
                above = S.Contains(S[i] - p) || H.Contains(S[i] - p);
                below = S.Contains(S[i] + p) || H.Contains(S[i] + p);

                is1Isolated = left && right && above && below;

                if (!is1Isolated)
                {
                    break;
                }
            }

            return is1Isolated;
        }

        private static bool Find3Isolation(string input, int[] S, int[] H, int p, int q)
        {
            bool is1Isolated = true;

            for (int i = 0; i < S.Length; i++)
            {
                bool left = true, right = true, above = true, below = true;

                left = S.Contains(S[i] - q) || H.Contains(S[i] - q);

                if (S[i] < input.Length - q)
                {
                    right = S.Contains(S[i] + q) || H.Contains(S[i] + q);    
                }
                
                
                above = S.Contains(S[i] - p) || H.Contains(S[i] - p);
                
                if (S[i] < input.Length - p)
                {
                    below = S.Contains(S[i] + p) || H.Contains(S[i] + p);    
                }

                is1Isolated = left && right && above && below;

                if (!is1Isolated)
                {
                    break;
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

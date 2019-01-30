using TextAnalyser.Library.Models;

namespace TextAnalyser.Library.Interfaces
{
    public static class ListSortHelper
    {
        public static string[] SortByLength(this string[] words)
        {
            for (int i = 1; i < words.Length; i++)
            {
                string temp = words[i];

                int j = i - 1;
                while (j >= 0 && temp.Length < words[j].Length)
                {
                    words[j + 1] = words[j];
                    j--;
                }
                words[j + 1] = temp;
            }

            return words;
        }

        public static string[] SortByASCII(this string[] words)
        {
            int min = 0;

            string word = string.Empty;

            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[i].Length > words[j].Length)
                        min = words[i].Length;
                    else
                        min = words[j].Length;
                    for (int k = 0; k < min; k++)
                    {
                        if (words[i][k] > words[j][k])
                        {
                            word = words[i].ToString();
                            words[i] = words[j];
                            words[j] = word;
                            break;
                        }
                        else if (words[i][k] == words[j][k])
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    }
                }

            }
            return words;
        }
    }
}

using TextAnalyser.Library.Models;

namespace TextAnalyser.Library.Interfaces
{
    public static class ListSortHelper
    {
        public static Word[] SortWordLength(this Word[] words)
        {
            int length = words.Length;

            Word temp = words[0];

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (words[i].Item.Length > words[j].Item.Length)
                    {
                        temp = words[i];

                        words[i] = words[j];

                        words[j] = temp;
                    }
                }
            }

            return words;
        }

        public static string[] SortAIIS(this string[] words)
        {
            int min = 0;

            string word = string.Empty;

            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[i].Length < words[j].Length)
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

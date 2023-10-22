using System;

namespace Word_World
{
    class Program
    {
        static void Main(string[] args)
        {
            //* veya - yazılmazsa hata veriyor,tekrar eden keli-
            string word = "", str_check = "", str = "Miss Polly had a poor dolly, who was sick. She called for the talled doctor Solly to come quick.He knocked on the DOOR like a actor in the healthcare sector.";// Strings for pattern, text which wil be checked and original text
            string[] wordlist1 = null, wordlist2 = null;// Wordlists of original text and checked text
            string[] wordsplit = new string[1];//Splitted words list of pattern according to "-" or "*" symbol
            int split_check = 0, control = 0;//variable for checking substrings of the words and variable to determine if text contains pattern
            bool flag = false;//Check for text, pattern andif the text contains pattern
            while (true)
            {
                Console.WriteLine("Miss Polly had a poor dolly, who was sick. She called for the talled doctor Solly to come quick.He knocked on the DOOR like a actor in the healthcare sector."); 
                //Miss Polly had a poor dolly, who was sick. She called for the talled doctor Solly to come quick.He knocked on the DOOR like a actor in the healthcare sector.
                //            while (flag == false)//Checking text if it is appropriate
                //            {
                //                flag = true;
                //                Console.Write("Please Enter The Text = ");
                //                str = Console.ReadLine();
                //                for (int i = 0; i < str.Length; i++)//Checks every word of text according to ascii table
                //                {
                //                    if ((Convert.ToInt16(str[i]) != 32 && Convert.ToInt16(str[i]) != 44 && Convert.ToInt16(str[i]) != 46)
                //                        && (Convert.ToInt16(str[i]) < 65 || (Convert.ToInt16(str[i]) > 90 && Convert.ToInt16(str[i]) < 97) || Convert.ToInt16(str[i]) > 122))
                //                    {
                //                        Console.WriteLine("Please use only  English alphabet letters, comma ',' and dot '.' in your text!\n");
                //                        flag = false;
                //                        break;
                //                    }

                //                }

                //;

                //            }
                flag = false;
                while (flag == false)//Checks if the pattern appropriate
                {
                    flag = true;
                    Console.WriteLine("\nPlease Enter The Pattern = ");
                    word = Console.ReadLine();
                    for (int i = 0; i < word.Length; i++)//Checks words of pattern according to ascii table
                    {
                        if ((Convert.ToInt16(word[i]) != 45 && Convert.ToInt16(word[i]) != 42) && Convert.ToInt16(word[i]) < 65 || (Convert.ToInt16(word[i]) > 90 && Convert.ToInt16(word[i]) < 97) || Convert.ToInt16(word[i]) > 122)
                        {
                            Console.WriteLine("Please use only  English alphabet letters, symbol '*' and symbol '-' in your pattern!\n");
                            flag = false;
                            break;
                        }

                    }

                    if (word.Contains("*") && word.Contains("-"))// Checks if there is "*" and "-" in the same pattern
                    {
                        Console.WriteLine("You can not use character '*' and character '-' same time in your pattern!\n");
                        flag = false;
                    }

                }

                word = word.ToLower();//For checking


                if (word.Contains("*"))//Splits word according to "*"
                {
                    wordsplit = null;
                    wordsplit = word.Split("*");

                }
                else if (word.Contains("-"))//Splits word according to "-"
                {
                    wordsplit = null;
                    wordsplit = word.Split("-");

                }
                else
                    wordsplit[0] = word;//If there is no "*" or "-"


                for (int i = 0; i < str.Length; i++)//Replaces all other words in the string
                {
                    if (Convert.ToInt16(str[i]) != 32 && (Convert.ToInt16(str[i]) < 65 || Convert.ToInt16(str[i]) > 90 && Convert.ToInt16(str[i]) < 97 && Convert.ToInt16(str[i]) > 123))
                    {
                        str = str.Replace(Convert.ToString(str[i]), " ");

                    }

                }
                wordlist1 = str.Split(" ");//Splits the string into its words
                for (int i = 0; i < wordlist1.Length; i++)//Changes identical words
                {
                    for (int j = i + 1; j < wordlist1.Length; j++)
                    {
                        if (wordlist1[i] == wordlist1[j])
                            wordlist1[j] = null;
                    }
                }
                str_check = str.ToLower();//For checking
                wordlist2 = str_check.Split(" ");//Letter list with lowercase


                for (int i = 0; i < wordlist2.Length; i++)//Finds if the leter exist in string
                {
                    split_check = 0;
                    flag = true;
                    for (int j = 0; j < wordsplit.Length; j++)//Loop for compare splitted pattern and words in the text
                    {
                        if (flag == false)
                            break;
                        else if (wordlist2[i] == "")//To prevent out of range 
                            flag = false;

                        if (wordlist2[i].Length < word.Length)//To prevent out of range
                            flag = false;


                        else if (j == 0 && word.Contains("*") && wordlist2[i].Substring(0, wordsplit[j].Length) != wordsplit[j])//Compares word's first letters and paterns first letters

                            flag = false;

                        else if (j == wordsplit.Length - 1 && word.Contains("*") && wordlist2[i].Substring(wordlist2[i].Length - wordsplit[j].Length, wordsplit[j].Length) != wordsplit[j])//Compares word's last letters and paterns last letters
                            flag = false;


                        else if ((word.Contains("-") || word.Contains("*") == false) && (wordlist2[i].Substring(split_check, wordsplit[j].Length) != wordsplit[j] || word.Length != wordlist2[i].Length))//Checks if the word contain pattern
                            flag = false;

                        else if (word.Contains("*") && (wordlist2[i].Contains(wordsplit[j]) == false))//Checks if the word contains pattern
                            flag = false;

                        split_check = split_check + wordsplit[j].Length + 1;//For finding which substring shou taken

                    }
                    if (wordlist1[i] == null || wordlist1[i] == "")
                        flag = false;

                    if (flag == true)//For writing words which equal to pattern
                    {
                        Console.WriteLine(wordlist1[i]);
                        control = control + 1;//Determines if the text contain patter
                    }


                }
                if (control == 0)
                {
                    Console.WriteLine("Text Does Not Contain The Pattern You Looked For");

                }


            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input a word: ");
            string word = Console.ReadLine();

            if (IsVowel(word[0]))    //checks if the first letter of the word is a vowel
            {
                if (IsVowel(word[word.Length - 1]))  //checks if the last letter of the word is a vowel
                {
                    Console.WriteLine(word + "yay");
                }
                else
                {
                    Console.WriteLine(word + "ay");
                }
            }
            else
            {
                bool vowelFound = false;
                for (int i = 1; i < word.Length; i++) //looks for the first instance of a vowel in word
                {
                    if (IsVowel(word[i])) 
                    {
                        Console.WriteLine(word.Substring(i) + word.Substring(0, i) + "ay"); //take the consonants leading up to the vowel and move them to the end

                        i = word.Length;   //breaks out of the loop
                        vowelFound = true;
                    }
                }
                if (!vowelFound)  //if no vowels were found
                {
                    Console.WriteLine(word + "ay");
                }

            }


            Console.ReadLine();
        }

        static bool IsVowel(char letter)
        {
            if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
            {
                return true;
            }
            else
            {
                return false;
            }
        }  //This method takes a char and returns true if is a vowel, or false otherwise.
    }
}

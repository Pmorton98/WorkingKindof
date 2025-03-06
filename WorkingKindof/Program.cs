using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
namespace CowBullGame

{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(); //Creats a new random -  generate random numbers 
            bool validNum = false; //track if valid number with unique digits is creates 
            bool win = false;
            int guessNum = 0;
            int CowAndBullNum = 0;


            while (!validNum) //loop runs until valid number is generated
            {
                CowAndBullNum = rand.Next(1023, 9876); //generates a random number between x and y (what is the highest number it can generate?) 



                string CowBullString = CowAndBullNum.ToString(); //converts the numbe to a string so we can check for repeats 
                bool repeat = false; //This will set to true if we find duplicates 


                for (int i = 0; i < 3; i++) //loop through each digit in the string 
                {
                    for (int j = i + 1; j < 4; j++) //compare digit I with all digits after 
                    {
                        if (CowBullString[i] == CowBullString[j])
                        {
                            repeat = true; //if any digits match, set repeat to true 
                            break; //exit the inner loop if the duplicate was found 
                        }
                    }
                    if (repeat) break;  //Exit the outer loop as well if a duplicate was found 
                }
                validNum = !repeat; // if repeat is False, it means all digits are unique, so ValidNum becomes 'True' 
                //stop the while loop - continue until a unique number is found 
            }

            Console.WriteLine("A valid 4 digit number has been generated!");
            string secretNumber = CowAndBullNum.ToString(); //converts the numbe to a string so we can check for repeats

            Console.WriteLine("Enter a guess");
            string guess = Console.ReadLine();
            bool Valid = false;

            while (!win) //loop runs until win set to true 
            {
                Console.Write("Enter a 4 digit guess: "); //prompt the user to enter a guess
                guess = Console.ReadLine();
                guessNum++; //increment the guess number

                if (!HasUniqueDigits(guess)) //check if the guess has unique digits
                {
                    Console.WriteLine("Invalid guess, try again!"); //if not, print an error message and continue the loop
                    continue;
                }

                if (guess == secretNumber) //check if the guess is correct
                {
                    win = true;
                    Console.WriteLine($"You guessed the number! It took you {guessNum} guesses.");

                }
                else
                {
                    Console.WriteLine("Incorrect Guess try again");

                }


                static bool HasUniqueDigits(string str) //method to check if the guess has unique digits
                {
                    if (str.Length != 4) //check if the guess is 4 digits long
                    {
                        return false; //if not, return false
                    }

                    for (int i = 0; i < 3; i++) //loop through each digit in the string
                    {
                        for (int j = i + 1; j < 4; j++) //compare digit I with all digits after
                        {
                            if (str[i] == str[j]) //if any digits match, return false
                            {
                                return false;
                            }
                        }
                    }


                    return true; //if no duplicates were found, return true

                }
            }

        }
    }
}

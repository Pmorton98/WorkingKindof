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
                validNum=true; //assume the number is valid until we find a duplicate
                CowAndBullNum = rand.Next(1023, 9876); //generates a random number between x and y (what is the highest number it can generate?) 



                string CowBullString = CowAndBullNum.ToString(); //converts the numbe to a string so we can check for repeats 
                bool repeat = false; //This will set to true if we find duplicates 


                for (int i = 0; i < 3; i++) //loop through each digit in the string 
                {
                    for (int j = i + 1; j < 4; j++) //compare digit I with all digits after 
                    {
                        if (CowBullString[i] == CowBullString[j])
                        {
                            validNum = false; //if any digits match, set repeat to true 
                             //exit the inner loop if the duplicate was found 
                        }
                    }
                 //Exit the outer loop as well if a duplicate was found 
                }
               // if repeat is False, it means all digits are unique, so ValidNum becomes 'True' 
                //stop the while loop - continue until a unique number is found 
            }

            Console.WriteLine("A valid 4 digit number has been generated!");
            string secretNumber = CowAndBullNum.ToString(); //converts the numbe to a string so we can check for repeats
            string guess= "";

            while (!win) //loop runs until win set to true 
            {
                bool ValidGuess = false;
                Console.Write("Enter a 4 digit guess: "); //prompt the user to enter a guess
                guess = Console.ReadLine(); //read the user's input
                do 
                {
                    ValidGuess = true ;
                    if (guess.Length != 4) //check if the guess is 4 digits long
                    {
                        ValidGuess = false;
                    }
                    for (int i = 0; i < 2; i++) //loop through each digit in the string
                    {
                        for (int j = i + 1; j < 4; j++) //compare digit I with all digits after
                        {
                            if (guess[i] == guess[j]) //if any digits match, return false
                            {
                                ValidGuess =  false;
                            }
                        }
                    }
                    if (!ValidGuess)
                    {
                        Console.WriteLine("Invalid guess, too long or repeating numbers!");
                        Console.Write("Enter a 4 digit guess: "); //prompt the user to enter a guess
                        guess = Console.ReadLine(); //read the user's input
                    }
                }while (!ValidGuess);
                guessNum++; //increment the guess number
                Console.WriteLine("test for cowa n bulls");

                //if (!HasUniqueDigits(guess)) //check if the guess has unique digits
                //{
                //    Console.WriteLine("Invalid guess, too long or repeating numbers!");
                //    //if not, print an error message and continue the loop
                //}

                if (guess == secretNumber) //check if the guess is correct
                {
                    win = true;
                    Console.WriteLine($"You guessed the number! It took you {guessNum} guesses.");

                }
                else
                {
                    Console.WriteLine("Incorrect Guess try again");
                    //do cows and bull count here

                }

            }

        }
    }
}

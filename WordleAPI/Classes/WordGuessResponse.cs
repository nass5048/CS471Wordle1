using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleBackend.Enums;

namespace WordleAPI.Classes;

public class WordGuessResponse
{
    public string Word { get; set; }

    public List<ResponseColor> Colors { get; set; }

    /*
        Function Name: WordGuessResponse
        Input: N/A
        Output: new WordGuessResponse object
        Brief Description:
            Creates empty guess object
    */
    public WordGuessResponse()
    {

    }

    /*
        Function Name: WordGuessResponse
        Input: CorrectWord, GuessedWord, Mode, and isBot (AI guess)
        Output: updated WordGuessResponse object
        Brief Description:
            Compares guessed word with correct word.
            Creates green, yellow and grey letter guesses dependent on selected game mode.
            AI can't do challange mode > only normal mode.
    */
    public WordGuessResponse(string CorrectWord, string GuessedWord, Challenge challenge, bool isBot)
    {
        Word = GuessedWord;
        Colors = new List<ResponseColor>();

        // Checks each character position 
        for (int i = 0; i < 5; i++)
        {
            // Game Modes vases
            switch (challenge) {
                case Challenge.Normal:
                case Challenge.HardMode:
                    if (CorrectWord[i] == GuessedWord[i])
                    {
                        Colors.Add(ResponseColor.green);
                    }
                    else if (ShouldYellow(i, GuessedWord, CorrectWord))
                    {
                        Colors.Add(ResponseColor.yellow);
                    }
                    else
                    {
                        Colors.Add(ResponseColor.grey);
                    }
                    break;
                // All Yellow mode: only displays yellow letters (ignores correct positions)
                case Challenge.AllYellow:
                    if (CorrectWord == GuessedWord)
                    {
                        Colors.Add(ResponseColor.green);
                    }
                    else if (ShouldYellowOnly(i, GuessedWord, CorrectWord))
                    {
                        Colors.Add(ResponseColor.yellow);
                    }
                    else
                    {
                        Colors.Add(ResponseColor.grey);
                    }
                    break;
                // All Green mode: only diplays green letters (exact matches)
                case Challenge.AllGreen:
                    if (CorrectWord[i] == GuessedWord[i])
                    {
                        Colors.Add(ResponseColor.green);
                    }
                    else
                    {
                        Colors.Add(ResponseColor.grey);
                    }
                    break;
            }
        }
    }

    /*
        Function Name: ShouldYellow
        Input: index of character position, guess word, and correct word
        Output: updated WordGuessResponse object
        Brief Description:
            Checks if character is within the word and handles duplicate letters
    */  
    private bool ShouldYellow(int index, string guess, string correct)
    {
        int correctLetterCheck = correct.Where(p => p == guess[index]).Count();
        // gets if the letters can be yellow or grey
        // checks num of green letters
        int greenLetterCount = 0;
        for (int i = 0; i < 5; i++)
        {
            if (guess[i] == correct[i] && guess[index] == guess[i])
                greenLetterCount++;
        }

        // if there's equal num of green letters and num of letters,
        // displays all the correct letters > no yellow letters
        if (greenLetterCount == correctLetterCheck)
        {
            return false;
        }

        // checks num of letters in guess up to index
        int letterCheck = 0;
        for (int i = 0; i <= index; i++)
        {
            if (guess[i] == guess[index])
                letterCheck++;
        }
        // if more num of green letters than num of letters, rest of the letters are grey
        if (letterCheck > correctLetterCheck)
        {
            return false;
        }

        if (correct.Contains(guess[index]))
        {
            return true;
        }
        return false;
    }

    /*
        Function Name: ShouldYellowOnly
        Input: index of character position, guess word, and correct word
        Output: true if letter should be displayed in yellow, false otherwise 
        Brief Description:
            Implementation of All Yellow game mode by checking if a character is
            within the word regardless of its position
    */
    private bool ShouldYellowOnly(int index, string guess, string correct)
    {
        if(guess == correct)
            return false;

        int correctLetterCheck = correct.Where(p => p == guess[index]).Count();
        //gets if the letters can be yellow or grey
        //check numbe rof green letters
        int greenLetterCount = 0;
        //for (int i = 0; i < 5; i++)
        //{
        //    if (guess[i] == correct[i] && guess[index] == guess[i])
        //        greenLetterCount++;
        //}
        //if there are the exact amount of green letters as number of letters than you have all the correct letters no letters should be yellow
        if (greenLetterCount == correctLetterCheck)
        {
            return false;
        }
        //check number of letters in guess up to index
        int letterCheck = 0;
        for (int i = 0; i <= index; i++)
        {
            if (guess[i] == guess[index])
                letterCheck++;
        }
        //if there are more green letters than number of letters than you know the rezt have to be grey
        if (letterCheck > correctLetterCheck)
        {
            return false;
        }

        if (correct.Contains(guess[index]))
        {
            return true;
        }
        return false;
    }

}

// Feedback colors after guesses
public enum ResponseColor
{
    grey,
    yellow,
    green
}

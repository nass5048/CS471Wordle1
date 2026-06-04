using WordleBackend.Enums;

namespace WordleAPI.Classes;

public class Stats
{
    public int GamesPlayed { get; set; }
    public int GamesWon { get; set; }
    public int RobotWins { get; set; } // Num of times AI beats user
    public int RobotLosses { get; set; } // Num of times user beats AI
    
    public int CurrentStreak { get; set; } // Num of current consecutive wins
    public int MaxStreak { get; set; } // Num of all-time consecutive wings

    public decimal AverageGuesses { get; set; }

    public DateTime? LastPlayed { get; set; }
    public TimeSpan? DailyWordTime { get; set; }

    // Stores guesses from most recent Daily Wordle game
    public List<WordGuessResponse?>? DailyGuesses { get; set; }

    public int robotCount { get; set; } // Num of AI guesses
    
    /*
        Function Name: FinishGame
        Input: true/false win, list of guesses during gameplay, and GameMode
        Output: N/A
        Brief Description:
            Updates player statistics, streak info, daily Wordle results, and
            AI results after gameplay is finished by the user
    */
    public async Task FinishGame(bool win, List<WordGuessResponse?> guesses, GameMode mode)
    {
        // Tracks time it takes for user to complete daily Wordle
        if(mode == GameMode.Daily)
        {
            DailyWordTime = DateTime.Now - LastPlayed;

        }
        // Prevents multiple games in one day from counting
        if (!LastPlayed.HasValue || !(LastPlayed.Value.Date == DateTime.Today))
        {
            GamesPlayed++;
            // Updates user's streak
            if (LastPlayed.HasValue && LastPlayed.Value.Date.AddDays(1) == DateTime.Today)
            {
                CurrentStreak++;
                if (CurrentStreak > MaxStreak)
                {
                    MaxStreak = CurrentStreak;
                }
            }
            else
            {
                CurrentStreak = 1;
            }

            LastPlayed = DateTime.Today;
            // Adds value of 1 to total GamesWon of the user for stats purposes
            if (win)
            {
                GamesWon++;
            }

            DailyGuesses = guesses;
            // Compares user and AI gameplay
            if (robotCount <= DailyGuesses.Count(p => p != null))
            {
                RobotWins++;
            }
            else
            {
                RobotLosses++;
            }
        }
    }

}


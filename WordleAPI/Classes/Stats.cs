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

    public int TotalGuesses { get; set; }

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
        if (mode != GameMode.Daily)
            return;

        // Only count one Daily game per day
        //if (LastPlayed.HasValue && LastPlayed.Value.Date == DateTime.Today)
        //    return;

        GamesPlayed++;

        int guessCount = guesses.Count(g => g != null);

        TotalGuesses += guessCount;

        AverageGuesses = Math.Round(
            (decimal)TotalGuesses / GamesPlayed,
            2
        );

        if (win)
        {
            DailyWordTime = DateTime.Now - LastPlayed;
            GamesWon++;

            if (LastPlayed.HasValue &&
                LastPlayed.Value.Date.AddDays(1) == DateTime.Today)
            {
                CurrentStreak++;
            }
            else
            {
                CurrentStreak = 1;
            }

            if (CurrentStreak > MaxStreak)
            {
                MaxStreak = CurrentStreak;
            }
        }
        else
        {
            CurrentStreak = 0;
        }

        DailyGuesses = guesses;

        int userGuesses = guesses.Count(g => g != null);

        if (robotCount <= userGuesses)
        {
            RobotWins++;
        }
        else
        {
            RobotLosses++;
        }

        LastPlayed = DateTime.Today;
    }

}


namespace WordleAPI.Classes;

public class Stats
{
    public long UserID { get; set; }
    public int GamesPlayed { get; set; }
    public int GamesWon { get; set; }
    public int RobotWins { get; set; }
    public int RobotLosses { get; set; }
    public int CurrentStreak { get; set; }
    public DateTime? LastPlayed { get; set; }
    public int MaxStreak { get; set; }
    public List<WordGuessResponse?> Guesses { get; set; }

    public int robotCount { get; set; }
    
    public async Task FinishGame(bool win, List<WordGuessResponse?> guesses)
    {
        //prevents multiple games in one day from counting
        if (!LastPlayed.HasValue || !(LastPlayed.Value.Date == DateTime.Today))
        {
            GamesPlayed++;
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
            if (win)
            {
                GamesWon++;
            }
            Guesses = guesses;
            if (robotCount <= Guesses.Count(p => p != null))
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


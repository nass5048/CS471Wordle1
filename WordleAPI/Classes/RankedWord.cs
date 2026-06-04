using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleAPI.Classes;

public class RankedWord
{
    // Ranks score of word
    public long Ranking { get; set; }

    // Word associate with the rank score
    public string Word { get; set; }

    /*
        Function Name: RankedWord
        Input: ranking and word
        Output: N/A
        Brief Description:
            Initializes a word and its rank score for the AI 
    */
    public RankedWord(long ranking, string word) 
    {
        Ranking = ranking;
        Word = word;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleAPI.Classes;

public class CharacterDictionary
{
    // Tracks character
    public char Character { get; set; }

    // Num of character count (occurances)
    public long Count { get; set; }

    // Position of character in word (can be number 0-4)
    public int Location { get; set; }

    /*
        Function Name: CharacterDictionary
        Input: character, count and location
        Output: N/A
        Brief Description:
            Initializes character with its count and location
    */

    public CharacterDictionary(char character, long count, int location)
    {
        Character = character;
        Count = count;
        Location = location;
    }
}
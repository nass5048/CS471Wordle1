using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleAPI.Classes;

public class LetterLocation
{
    // Character stored at a specific position
    public char letter;

    // Position of the character within word
    public int location;

    /*
        Function Name: LetterLocation
        Input: letter and location
        Output: new LetterLocation object
        Brief Description:
            Initializes a character and its corresponding 
            location within a word
    */

    public LetterLocation(char letter, int location)
    {
        this.letter = letter;
        this.location = location;
    }
}

public class CharacterComparer : IEqualityComparer<LetterLocation>
{
    /*
        Function Name: Equals
        Input: x and y LetterLocation objects
        Output: true if objects equal the same character and location, false otherwise
        Brief Description:
            Determines whether the objects are equal to each other
    */

    public bool Equals(LetterLocation x, LetterLocation y)
    {
        // Define your custom equality logic here.
        // For example, compare based on a specific property:
        return x.location == y.location && x.letter == y.letter;
    }

    /*
        Function Name: GetHashCode
        Input: LetterLocation object
        Output: Hash code of the Letterlocation object
        Brief Description:
            Initializes a character and its corresponding 
            location within a word
    */

    public int GetHashCode(LetterLocation obj)
    {
        // Generate a hash code based on the properties used in Equals.
        // A common way is to combine hash codes of relevant properties:
        return obj == null ? 0 : obj.location;
    }
}

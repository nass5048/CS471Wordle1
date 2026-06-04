using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WordleAPI;

public static class Utilitys
{
    /*
        Function Name: GetEmbeddedTextResource
        Input: resourceName
        Output: Items contained in resourceName as a string
        Brief description:
            Retrieves and returns items contained of text file 
            embedded into app
    */
    public static string GetEmbeddedTextResource(string resourceName)
    {

        
        // Get the assembly where the resource is embedded
        var assembly = Assembly.GetExecutingAssembly();

        // Construct the full resource name. This usually follows the pattern:
        // "YourDefaultNamespace.YourSubfolderIfAny.YourFileName.txt"
        // You can find the exact name using assembly.GetManifestResourceNames() if unsure.
        string fullResourceName = $"{assembly.GetName().Name}.{resourceName}";

        // Open embedded resource stream
        using (Stream stream = assembly.GetManifestResourceStream(fullResourceName))
        {
            // Checks if resource exists before attempting to read
            if (stream == null)
            {
                throw new FileNotFoundException($"Embedded resource '{fullResourceName}' not found.");
            }

            // Reads and returns contenets
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    /*
        Function Name: IsWordInText
        Input: word and resourceName
        Output: true if searched word is exists in the file, false otherwise
        Brief description:
            Reads word list from resourceName and checks if word input exists
    */    

    public static bool IsWordInText(string word, string resourceName)
    {
        // Read full file text
        var wordList = GetEmbeddedTextResource(resourceName);

        // Normalize all lines
        var validWords = wordList
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.Trim().ToLowerInvariant())
            .ToHashSet(); // faster lookups

        // Normalize input 
        string normalizedWord = word.Trim().ToLowerInvariant();

        return validWords.Contains(normalizedWord);
    }

}

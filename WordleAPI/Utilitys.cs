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
}

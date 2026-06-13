using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WordleAPI;

namespace WordleBackend
{
    public class ValidWords
    {
        public List<Words> AllWords { get; set; }
        

        private void UpdateStoredWords (ValidWords validWords)
        {
            AllWords = validWords.AllWords;
        }
        /*
        Function Name: LoadValidWords
        Input: HTTP client that requests data from API
        Output: N/A
        Brief Description:
            Loads current word info from the backend API and updates the local storage
        */
        public async Task LoadValidWords(HttpClient Http)
        {
            var test = await Http.GetFromJsonAsync<ValidWords>("https://localhost:7160/api/word");
            if (test != null)
                UpdateStoredWords(test);
        }

        /*
            Function Name: SaveValidWords
            Input: HTTP client that saves data from API
            Output: N/A
            Brief Description:
                Sends current word info to the backend API for storage
        */

        public async Task SaveValidWords(HttpClient Http)
        {
            await Http.PostAsJsonAsync("https://localhost:7160/api/word", this);
        }


    }
    public class Words
    {
        public string Word { get; set; }
        public bool CanUse { get; set; }
    }
}

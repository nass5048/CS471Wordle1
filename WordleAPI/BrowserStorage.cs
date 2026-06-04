using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace WordleBackend
{
    public class BrowserStorage
    {
        private readonly IJSRuntime js;

        /*
            Function Name: BrowserStorage
            Input: JavaScript runtime instance
            Output: new BrowserStorage object
            Brief description:
                Initializes browser storage so to perform local storage operations
        */

        public BrowserStorage(IJSRuntime js)
        {
            this.js = js;
        }

        /*
            Function Name: Set
            Input: Storage key and associated value
            Output: N/A
            Brief description:
                Stores a value in the browser's local storage using key
        */

        public ValueTask Set(string key, string value) =>
            js.InvokeVoidAsync("localStorage.setItem", key, value);


        /*
            Function Name: Get
            Input: Storage key
            Output: Value associated with key
            Brief description:
                Retrieves a value from the browser's local storage
        */   

        public ValueTask<string> Get(string key) =>
            js.InvokeAsync<string>("localStorage.getItem", key);

        /*
            Function Name: Remove
            Input: Storage key
            Output: N/A
            Brief description:
                Removes a stored item from the browser's local storage
        */

        public ValueTask Remove(string key) =>
            js.InvokeVoidAsync("localStorage.removeItem", key);
    }
}

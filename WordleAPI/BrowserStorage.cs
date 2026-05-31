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

        public BrowserStorage(IJSRuntime js)
        {
            this.js = js;
        }

        public ValueTask Set(string key, string value) =>
            js.InvokeVoidAsync("localStorage.setItem", key, value);

        public ValueTask<string> Get(string key) =>
            js.InvokeAsync<string>("localStorage.getItem", key);

        public ValueTask Remove(string key) =>
            js.InvokeVoidAsync("localStorage.removeItem", key);
    }
}

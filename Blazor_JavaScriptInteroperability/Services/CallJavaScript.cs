using Blazor_JavaScriptInteroperability.Models;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
namespace Blazor_JavaScriptInteroperability.Services
{
	public class CallJavaScript
	{
		private  readonly IJSRuntime js;
		public int res = 0;
		public string data;
		public List<Product> products;

		public CallJavaScript(IJSRuntime js)
		{
			this.js = js;
			products = new List<Product>();
		}

		public  async void Print()
		{
			await js.InvokeVoidAsync("display");
		}

		public async Task Add()
		{
			res = await js.InvokeAsync<int>("add", 10, 20);
		}

		public async Task GetData()
		{
			data = await js.InvokeAsync<string>("getData");
			products = JsonSerializer.Deserialize<List<Product>>(data);
		}
	}
}

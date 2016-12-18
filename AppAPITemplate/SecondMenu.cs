using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

namespace AppAPITemplate
{
	public class SecondMenu : Menu
	{
		MenuItem clicked = new MenuItem();

		public SecondMenu(MenuItem menuItem)
		{
			clicked = menuItem;

			Title = "API Template";
			Content = list;

			list.ItemTapped += (sender, e) =>
			{
				list.SelectedItem = null;
				//Navigation.PushAsync(new SecondMenu(e.Item as MenuItem));
				ClickMenuItem(e.Item as MenuItem);
			};
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			list.ItemsSource = await CallAPI(clicked);
		}


		static async Task<List<MenuItem>> CallAPI(MenuItem menuItem)
		{
			string response = await GetResponseFromAPI(menuItem);

			List<MenuItem> list = ConstructMenuItemList(response);

			return list;
		}


		public void ClickMenuItem(MenuItem itemClicked)
		{
			//Implements menu item click
			//e.g. Navigation.PushAsync(new SecondMenu(e.Item as string));
			Navigation.PushAsync(new InfoPage(itemClicked));
		}


		static async Task<string> GetResponseFromAPI(MenuItem menuItem)
		{
			string query = ConstructQuery(menuItem);

			using (var client = new HttpClient())
			{
				var response = await client.GetStringAsync(query);
				return response.ToString();
			}
		}

		static List<MenuItem> ConstructMenuItemList(string response)
		{

			List<MenuItem> menuItems = new List<MenuItem>();

			dynamic jsonResult = JsonConvert.DeserializeObject(response); 

			foreach (var item in jsonResult)
			{
				MenuItem tempMenuItem = new MenuItem();

				tempMenuItem.Name = item["Name"].Value;
				tempMenuItem.Description = item["Description"].Value;


				menuItems.Add(tempMenuItem);


			}


			return menuItems;

		}



		static string ConstructQuery(MenuItem menuItem)
		{
			string name = menuItem.Name.Replace(" ", String.Empty);

			string query = "http://upsidealienappapi.s3.amazonaws.com/SecondMenu" + name + ".json";

			return query;
		}
	}
}


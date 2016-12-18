using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AppAPITemplate
{
	public class FirstMenu : Menu
	{
		public FirstMenu()
		{
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

			MenuItem fake = new MenuItem
			{
				Name = "Thomas",
				Description = "Cartwright"
			};

			list.ItemsSource = await CallAPI(fake);
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
			Navigation.PushAsync(new SecondMenu(itemClicked));
		}


		static async Task<string> GetResponseFromAPI(MenuItem menuItem)
		{
			string query = ConstructQuery(menuItem);

			//string results = "[{ One : \"Thomas 2\", Two : \"Is the best 2\", Three : \"And number three \", Four : \"And is four too much\", Five : \"A a high five\"}]"; //string results = call query.
			using (var client = new HttpClient())
			{
				var response = await client.GetStringAsync(query);
				return response.ToString();
			}
		}

		static List<MenuItem> ConstructMenuItemList(string response)
		{

			List<MenuItem> menuItems = new List<MenuItem>();

			dynamic jsonResult = JsonConvert.DeserializeObject(response); //var jsonResult = Newtonsoft.Json.Linq.JObject.Parse(results);

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
			string query = "http://upsidealienappapi.s3.amazonaws.com/FirstMenu.json";

			return query;
		}

	}
}


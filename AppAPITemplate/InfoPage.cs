using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace AppAPITemplate
{
	public class InfoPage : ContentPage
	{
		/*
			Displays all the information for the API menus	
		*/
		static Label One = new Label
		{
			Text = "",
			TextColor = Color.White,
			FontSize = 50,
			BackgroundColor = Color.Aqua,
			HorizontalTextAlignment = TextAlignment.Center,
			VerticalTextAlignment = TextAlignment.Center,
			HorizontalOptions = LayoutOptions.Fill,
			FontFamily = Device.OnPlatform(
				"Oswald-Bold",
				null,
				null
			),
		};
		static Label Two = new Label
		{
			Text = "",
			HorizontalTextAlignment = TextAlignment.Center,
			VerticalTextAlignment = TextAlignment.Center,
			HorizontalOptions = LayoutOptions.FillAndExpand,
			TextColor = Color.Gray,
			FontFamily = Device.OnPlatform(
				"Oswald-Bold",
				null,
				null
			),
		};
		static Label Three = new Label
		{
			Text = "",
			WidthRequest = 0,
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,
			VerticalTextAlignment = TextAlignment.End,
			HorizontalTextAlignment = TextAlignment.Center,
			TextColor = Color.Gray,
			FontFamily = Device.OnPlatform(
				"Oswald-Bold",
				null,
				null
			),
		};
		static Label Four = new Label
		{
			Text = "",
			HorizontalOptions = LayoutOptions.Start,
			TextColor = Color.Gray,
			FontFamily = Device.OnPlatform(
				"Oswald-Bold",
				null,
				null
			),
		};
		static Label Five = new Label
		{
			Text = "",
			HorizontalOptions = LayoutOptions.Start,
			TextColor = Color.Gray,
			FontFamily = Device.OnPlatform(
				"Oswald-Bold",
				null,
				null
			),
		};

		public class InfoPageLayoutChildren : StackLayout
		{
			public InfoPageLayoutChildren()
			{
				Spacing = 2;
				WidthRequest = 0;
				Orientation = StackOrientation.Horizontal;
				Children.Add(new StackLayout
				{
					Spacing = 2,
					WidthRequest = 0,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = {

								new Label
									{
										Text = "Day Low",
										HorizontalOptions = LayoutOptions.Start,
										TextColor = Color.Gray,
										FontFamily = Device.OnPlatform(
											"Oswald-Bold",
											null,
											null
										),
									},
								new Label
									{
										Text = "Day High",
										HorizontalOptions = LayoutOptions.Start,
										TextColor = Color.Gray,
										FontFamily = Device.OnPlatform(
											"Oswald-Bold",
											null,
											null
										),
									},
								},
				});

				Children.Add(new StackLayout
				{
					Spacing = 2,
					WidthRequest = 0,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = {
						Four,
						Five
					},
				});

			}
		}

		public class InfoPageLayout : StackLayout
		{
			public InfoPageLayout()
			{
				HeightRequest = 70;
				Spacing = 5;
				Orientation = StackOrientation.Vertical;
				Children.Add(
					One
				);
				Children.Add(
					Two
				);
				Children.Add(new InfoPageLayoutChildren());
				Children.Add(
					Three
				);
			}
		}


		public MenuItem currentItem;

		//This holds the Views (it will switch between saying "Loading" and showing the info)
		public InfoPage(MenuItem item)
		{
			currentItem = item;
			Content = new InfoPageLayout();
		}


		protected override async void OnAppearing()
		{
			base.OnAppearing();

			List<string> list = await CallAPI(currentItem);
			One.Text = list[0];
			Two.Text = list[1];
			Three.Text = list[2];
			Four.Text = list[3];
			Five.Text = list[4];
		}

		static async Task<List<string>> CallAPI(MenuItem menuItem)
		{
			string response = await GetResponseFromAPI(menuItem);

			List<string> list = ConstructList(response);

			return list;
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

		static string ConstructQuery(MenuItem menuItem)
		{
			string name = menuItem.Name.Replace(" ", String.Empty);

			string query = "http://upsidealienappapi.s3.amazonaws.com/" + name + "InfoJSON.json";

			return query;
		}

		static List<string> ConstructList(string response)
		{

			List<string> items = new List<string>();

			dynamic jsonResult = JsonConvert.DeserializeObject(response); 
			//dynamic jsonResult = Newtonsoft.Json.Linq.JObject.Parse(results);

			foreach (var item in jsonResult)
			{
				string one = item["One"].Value.ToString();
				string two = item["Two"].Value;
				string three = item["Three"].Value;
				string four = item["Four"].Value;
				string five = item["Five"].Value;

				items.Add(one);
				items.Add(two);
				items.Add(three);
				items.Add(four);
				items.Add(five);
			}

			return items;

		}

	
	}
}


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppAPITemplate;

namespace AppAPITemplate
{
	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new FirstMenu());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}

}




















/*
 	public class TimePage : ContentPage
	{
		readonly Label timeLabel = new Label
		{
			Text = "Loading...",
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			VerticalOptions = LayoutOptions.CenterAndExpand,
		};

		public TimePage()
		{
			Content = timeLabel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			timeLabel.Text = await RequestTimeAsync();
		}

		static async Task<string> RequestTimeAsync()
		{
			using (var client = new HttpClient())
			{
				var jsonString = await client.GetStringAsync("http://date.jsontest.com/");
				var jsonObject = JObject.Parse(jsonString);
				return jsonObject["time"].Value<string>();
			}
		}
	}



	public class DemoStackLayout: StackLayout
	{
	    public DemoStackLayout()
	    {
	        HeightRequest = 70;
	        Spacing = 5;
	        Orientation = StackOrientation.Horizontal;
	        Children.Add(new Icon("A", Color.FromRgb(0.7, 0.8, 1.0)) {
	            WidthRequest = 70,
	        });
	        Children.Add(new StackLayout {
	            Spacing = 2,
	            WidthRequest = 0,
	            HorizontalOptions = LayoutOptions.FillAndExpand,
	            Children = {
	                new Name("Alice"),
	                new Subject("Meeting on Friday"),
	                new Body("Peter, Let's meet on Friday at 10 am"),
	            },
	        });
	        Children.Add(new Time("1:00 PM") {
	            WidthRequest = 50,
	        });
	    }
	}

	public class FruitListPage : ContentPage
	{
		public FruitListPage()
		{
			//This lists all the fruits and a little description
			var listView = new ListView
			{
				ItemsSource = new List<Fruit> {
				new Fruit { Name = "Apple", Description = "Awesome!" },
				new Fruit { Name = "Banana", Description = "Beautiful!" },
				new Fruit { Name = "Cherry", Description = "Cheap!" },
			},
				ItemTemplate = new DataTemplate(typeof(FruitCell)),
				RowHeight = FruitCell.RowHeight,
			};

			//When you click on any item in the list - it fires up a FruitDetailPage
			listView.ItemTapped += (sender, e) =>
			{
				listView.SelectedItem = null;
				Navigation.PushAsync(new FruitDetailPage(e.Item as Fruit));
			};

			Title = "Fruits";
			Content = listView;
		}
	}

	public class Fruit
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}


	public class FruitCell : ViewCell
	{
		public const int RowHeight = 55;

		public FruitCell()
		{
				var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
				nameLabel.SetBinding(Label.TextProperty, "Name");

				var descriptionLabel = new Label { TextColor = Color.Gray };
				descriptionLabel.SetBinding(Label.TextProperty, "Description");

				View = new StackLayout
				{
					Spacing = 2,
					Padding = 5,
					Children = {
					nameLabel,
					descriptionLabel,
				},	
			};
		}
	}

	public class FruitDetailPage : ContentPage
	{
		public FruitDetailPage(Fruit fruit) 
		{
			Title = fruit.Name;
			Content = new Label
			{
				Text = fruit.Description,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
		}
	}

*/

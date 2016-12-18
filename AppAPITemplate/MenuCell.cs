using System;
using Xamarin.Forms;

namespace AppAPITemplate
{
	public class MenuCell : ViewCell
	{
		/*
			Menu cell = all the code for displaying the info of a MenuItem
		*/
		public const int RowHeight = 55;

		public MenuCell()
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
}


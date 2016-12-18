using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAPITemplate
{
	public class APICaller
	{
		public APICaller()
		{



		}

		//Calls the API for the second menu item
		public async Task<List<MenuItem>> SecondMenuAPICall(MenuItem currentItem)
		{
			//Create an Example API
			List<MenuItem> secondMenuList = new List<MenuItem>
			{
				new MenuItem { Name = "2 Thomas" + currentItem.Name, Description = "Is Great"},
				new MenuItem { Name = "2 Cartwright" + currentItem.Name, Description = "Is Also Great"},

			};

			return secondMenuList;

		}
	}
}


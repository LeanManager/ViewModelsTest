﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ZwabyAdminApp
{
	public partial class ArithmeticPage : ContentPage
	{
		public ArithmeticPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new ColorPage());
		}
	}
}

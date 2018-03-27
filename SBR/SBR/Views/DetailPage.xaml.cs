using SBR.Models;
using SBR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SBR.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		public DetailPage (Sample sample)
		{
			InitializeComponent ();
            BindingContext = new DetailPageViewModel(sample);
        }
	}
}
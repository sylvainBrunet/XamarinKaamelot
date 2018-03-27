using SBR.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SBR
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            
              
              InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);

            



        }
       

    
    }
}

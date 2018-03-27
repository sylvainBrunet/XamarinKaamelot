using SBR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SBR.Ressources;
using Newtonsoft.Json;
using SBR.ViewModels;
using SBR.Views;
using System.Collections.ObjectModel;
using System.Linq;

namespace SBR.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        
        private ObservableCollection<Sample> _sample = new ObservableCollection<Sample>();
        public INavigation Navigation { get; set; }
       
        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            
            //liste des samples
            string jsonbrut = Ressources.Ressources.GetJSONFromRessources("sounds.json");

            ListeSamples = oldListSamples = JsonConvert.DeserializeObject<List<Sample>>(jsonbrut);
           

            //titre
            Title = "la lappli de moi";
            //La les commande
            GotoDetailPage = new Command(async (object o) => await ExecuteGotoDetailCommand(o));
            RefreshCommand = new Command(async (object o) => await ExecuteRefreshCommand());
            RefreshCommand.Execute(null);

        }

        private List<Sample> oldListSamples;
        private List<Sample> listeSamples;

        public List<Sample> ListeSamples
        {
            get { return listeSamples; }
            set
            {
                listeSamples = value;
                OnPropertyChanged();
            }
        }

        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                
                
               filterSample();
                OnPropertyChanged();
            }
        }


        public Command RefreshCommand { get; set; }
        public Command GotoDetailPage { get; set; }
        

        private async Task ExecuteRefreshCommand()
        {
            Device.BeginInvokeOnMainThread(() => IsBusy = true);
            Query = "";
                string json = Ressources.Ressources.GetJSONFromRessources("sounds.json");
                ListeSamples = oldListSamples = JsonConvert.DeserializeObject<List<Sample>>(json);
            Device.BeginInvokeOnMainThread(() => IsBusy = false);

        }
        
        private async Task ExecuteGotoDetailCommand(object param)
        {
            try
            {
                
                    var sample = (Sample)param;
                await Navigation.PushAsync(new DetailPage(sample));
               
            }
            catch (Exception Ex)
            {

            }
        }
        private void filterSample()
        {

            ListeSamples = oldListSamples.Where(x => x.Title.ToLower().Contains(query.ToLower())).ToList();
        }

    }
}

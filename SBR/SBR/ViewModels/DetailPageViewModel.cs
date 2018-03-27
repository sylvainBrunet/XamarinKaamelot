using Plugin.Share;
using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using SBR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SBR.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        static CrossLocale? locale = null;
        public Sample Sample { get; set; }

        public DetailPageViewModel(Sample sample)

        {
            Sample = sample;
            PlaySampleCommand = new Command(async ()=> await ExecutePlaySampleCommand());
            PlaySpeechCommand = new Command(async () => await ExecutePlaySpeechCommandAsync());
            ShareCommand = new Command(ShareCommandExecute);
        }

        private void ShareCommandExecute(object obj)
        {
           CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage {Title ="bla" , Text="blas" });
        }

        public Task<IEnumerable<CrossLocale>> InstalledLanguages { get; }

        private async Task ExecutePlaySpeechCommandAsync()
        {
            
            locale = new CrossLocale { Language = "fr", Country = "FR" };
            await CrossTextToSpeech.Current.Speak(Sample.Title, locale);
        }

        public Command PlaySampleCommand { get; set; }
        public Command ShareCommand { get; set; }
        public Command PlaySpeechCommand { get; set; }
        private async Task ExecutePlaySampleCommand()
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                var stream = Ressources.Ressources.GetSampleFromRessources(Sample.File);
                    if (stream != null)
                    {
                        player.Load(stream);
                        player.Play();
                    }
                   
                }
                );
            }
            catch (Exception Ex)
            {

            }
        }

    }
    
}

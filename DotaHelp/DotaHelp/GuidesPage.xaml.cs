using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DotaHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuidesPage : ContentPage
    {
        public GuidesPage()
        {
            InitializeComponent();
            var browser1 = new WebView
            {
                Source = "https://gosu.ai/blog/dota2/how-to-get-better-as-a-carry/"
            };
        }

        private void carry_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://gosu.ai/blog/dota2/how-to-get-better-as-a-carry/"));
        }

        private void beginners_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://gosu.ai/blog/dota2/best-dota-hero-beginners/"));
        }

        private void brood_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://gosu.ai/blog/dota2/gosu-ai-guides-broodmather/"));
        
        }

        private void kunkka_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://gosu.ai/blog/dota2/gosu-ai-guides-kunkka/"));
        }

        private void jugg_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://gosu.ai/blog/dota2/gosu-ai-guides-juggernaut-7-26/"));
        }
    }
}
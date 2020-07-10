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
    public partial class statAverages : ContentPage
    {
        public statAverages(int kills, int assists, int deaths, int lastHits, int denies, int heroDamage, int buildingDamage, int gpm, int xpm, int healingDone, int supportCont, int stacks)
        {
            InitializeComponent();
            yourKills.Text = kills.ToString();
            yourAssists.Text = assists.ToString();
            yourDeaths.Text = deaths.ToString();
            yourLastHits.Text = lastHits.ToString();
            yourDenies.Text = denies.ToString();
            yourHeroDamage.Text = heroDamage.ToString();
            yourBuildingDamage.Text = buildingDamage.ToString();
            yourGpm.Text = gpm.ToString();
            yourXpm.Text = xpm.ToString();
            yourHealing.Text = healingDone.ToString();
            yourSupport.Text = supportCont.ToString();
            yourStacks.Text = stacks.ToString();
        }
    }
}
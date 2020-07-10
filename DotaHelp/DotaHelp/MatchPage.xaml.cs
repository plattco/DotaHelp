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
    public partial class MatchPage : ContentPage
    {
        public MatchPage(Matches m)
        {
            InitializeComponent();
            kills.Text = m.kills.ToString();
            match.Text = m.matchId.ToString();
            hero.Text = m.heroPlayed;
            role.Text = m.rolePlayed;
            assists.Text = m.assists.ToString();
            deaths.Text = m.deaths.ToString();
            lastHits.Text = m.lastHits.ToString();
            denies.Text = m.denies.ToString();
            heroDamage.Text = m.heroDamage.ToString();
            buildingDamage.Text = m.buildingDamage.ToString();
            gpm.Text = m.gpm.ToString();
            xpm.Text = m.xpm.ToString();
            healing.Text = m.healingDone.ToString();
            support.Text = m.supportCont.ToString();
            stacks.Text = m.stacks.ToString();
        }
    }
}
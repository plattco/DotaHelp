using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DotaHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchesPage : ContentPage
    {
        public MatchesPage()
        {
            InitializeComponent();
            lvMatches.ItemsSource = DB.conn.Table<Matches>().ToList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMatches.ItemsSource = DB.conn.Table<Matches>().ToList();
        }

        MatchPage matchPage;
        private async void lvMatches_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Matches m = lvMatches.SelectedItem as Matches;
            matchPage = new MatchPage(m);
            await Navigation.PushAsync(matchPage, true);
        }

        private async void averages_Clicked(object sender, EventArgs e)
        {
            var theTable = DB.conn.Table<Matches>().ToList();
            List<Matches> listy = theTable;
            int killTotal = 0;
            int killAverage = 0;
            int assistsTotal = 0;
            int assistsAverage = 0;
            int deathTotal = 0;
            int deathAverage = 0;
            int lastHitsTotal = 0;
            int lastHitsAverage = 0;
            int deniesTotal = 0;
            int deniesAverage = 0;
            int heroDamageTotal = 0;
            int heroDamageAverage = 0;
            int buildingDamageTotal = 0;
            int buildingDamageAverage = 0;
            int gpmTotal = 0;
            int gpmAverage = 0;
            int xpmTotal = 0;
            int xpmAverage = 0;
            int healingDoneTotal = 0;
            int healingDoneAverage = 0;
            int supportTotal = 0;
            int supportAverage = 0;
            int stacksTotal = 0;
            int stacksAverage = 0;
            for (int i = 0; i < listy.Count; i++)
            {
                killTotal += listy[i].kills;
                assistsTotal += listy[i].assists;
                deathTotal += listy[i].deaths;
                lastHitsTotal += listy[i].lastHits;
                deniesTotal += listy[i].denies;
                heroDamageTotal += listy[i].heroDamage;
                buildingDamageTotal += listy[i].buildingDamage;
                gpmTotal += listy[i].gpm;
                xpmTotal += listy[i].xpm;
                healingDoneTotal += listy[i].healingDone;
                supportTotal += listy[i].supportCont;
                stacksTotal += listy[i].stacks;
            }
            killAverage = killTotal / listy.Count;
            assistsAverage = assistsTotal / listy.Count;
            deathAverage = deathTotal / listy.Count;
            lastHitsAverage = lastHitsTotal / listy.Count;
            deniesAverage = deniesTotal / listy.Count;
            heroDamageAverage = heroDamageTotal / listy.Count;
            buildingDamageAverage = buildingDamageTotal / listy.Count;
            gpmAverage = gpmTotal / listy.Count;
            xpmAverage = xpmTotal / listy.Count;
            healingDoneAverage = healingDoneTotal / listy.Count;
            supportAverage = supportTotal / listy.Count;
            stacksAverage = stacksTotal / listy.Count;

            statAverages avg = new statAverages(killAverage, assistsAverage, deathAverage, lastHitsAverage, deniesAverage, heroDamageAverage, buildingDamageAverage, gpmAverage, xpmAverage, healingDoneAverage, supportAverage, stacksAverage);
            await Navigation.PushAsync(avg, true);
        }

        private async void carryAverages_Clicked(object sender, EventArgs e)
        {
            var theTable2 = DB.conn.Table<Matches>().ToList();
            List<Matches> listy2 = theTable2;
            int killTotal = 0;
            int killAverage = 0;
            int assistsTotal = 0;
            int assistsAverage = 0;
            int deathTotal = 0;
            int deathAverage = 0;
            int lastHitsTotal = 0;
            int lastHitsAverage = 0;
            int deniesTotal = 0;
            int deniesAverage = 0;
            int heroDamageTotal = 0;
            int heroDamageAverage = 0;
            int buildingDamageTotal = 0;
            int buildingDamageAverage = 0;
            int gpmTotal = 0;
            int gpmAverage = 0;
            int xpmTotal = 0;
            int xpmAverage = 0;
            int healingDoneTotal = 0;
            int healingDoneAverage = 0;
            int supportTotal = 0;
            int supportAverage = 0;
            int stacksTotal = 0;
            int stacksAverage = 0;
            int carryCount = 0;
            for (int i = 0; i < listy2.Count; i++)
            {
                if (listy2[i].rolePlayed == "Hard Carry" || listy2[i].rolePlayed == "Middle" || listy2[i].rolePlayed == "Offlane")
                {
                    killTotal += listy2[i].kills;
                    assistsTotal += listy2[i].assists;
                    deathTotal += listy2[i].deaths;
                    lastHitsTotal += listy2[i].lastHits;
                    deniesTotal += listy2[i].denies;
                    heroDamageTotal += listy2[i].heroDamage;
                    buildingDamageTotal += listy2[i].buildingDamage;
                    gpmTotal += listy2[i].gpm;
                    xpmTotal += listy2[i].xpm;
                    healingDoneTotal += listy2[i].healingDone;
                    supportTotal += listy2[i].supportCont;
                    stacksTotal += listy2[i].stacks;
                    carryCount += 1;
                }
            }
            killAverage = killTotal / carryCount;
            assistsAverage = assistsTotal / carryCount;
            deathAverage = deathTotal / carryCount;
            lastHitsAverage = lastHitsTotal / carryCount;
            deniesAverage = deniesTotal / carryCount;
            heroDamageAverage = heroDamageTotal / carryCount;
            buildingDamageAverage = buildingDamageTotal / carryCount;
            gpmAverage = gpmTotal / carryCount;
            xpmAverage = xpmTotal / carryCount;
            healingDoneAverage = healingDoneTotal / carryCount;
            supportAverage = supportTotal / carryCount;
            stacksAverage = stacksTotal / carryCount;

            statAverages avg = new statAverages(killAverage, assistsAverage, deathAverage, lastHitsAverage, deniesAverage, heroDamageAverage, buildingDamageAverage, gpmAverage, xpmAverage, healingDoneAverage, supportAverage, stacksAverage);
            await Navigation.PushAsync(avg, true);
        }

        private async void supportAverages_Clicked(object sender, EventArgs e)
        {
            var theTable3 = DB.conn.Table<Matches>().ToList();
            List<Matches> listy3 = theTable3;
            int killTotal = 0;
            int killAverage = 0;
            int assistsTotal = 0;
            int assistsAverage = 0;
            int deathTotal = 0;
            int deathAverage = 0;
            int lastHitsTotal = 0;
            int lastHitsAverage = 0;
            int deniesTotal = 0;
            int deniesAverage = 0;
            int heroDamageTotal = 0;
            int heroDamageAverage = 0;
            int buildingDamageTotal = 0;
            int buildingDamageAverage = 0;
            int gpmTotal = 0;
            int gpmAverage = 0;
            int xpmTotal = 0;
            int xpmAverage = 0;
            int healingDoneTotal = 0;
            int healingDoneAverage = 0;
            int supportTotal = 0;
            int supportAverage = 0;
            int stacksTotal = 0;
            int stacksAverage = 0;
            int supportCount = 0;
            for (int i = 0; i < listy3.Count; i++)
            {
                if (listy3[i].rolePlayed == "Hard Support" || listy3[i].rolePlayed == "Soft Support")
                {
                    killTotal += listy3[i].kills;
                    assistsTotal += listy3[i].assists;
                    deathTotal += listy3[i].deaths;
                    lastHitsTotal += listy3[i].lastHits;
                    deniesTotal += listy3[i].denies;
                    heroDamageTotal += listy3[i].heroDamage;
                    buildingDamageTotal += listy3[i].buildingDamage;
                    gpmTotal += listy3[i].gpm;
                    xpmTotal += listy3[i].xpm;
                    healingDoneTotal += listy3[i].healingDone;
                    supportTotal += listy3[i].supportCont;
                    stacksTotal += listy3[i].stacks;
                    supportCount += 1;
                }
            }
            killAverage = killTotal / supportCount;
            assistsAverage = assistsTotal / supportCount;
            deathAverage = deathTotal / supportCount;
            lastHitsAverage = lastHitsTotal / supportCount;
            deniesAverage = deniesTotal / supportCount;
            heroDamageAverage = heroDamageTotal / supportCount;
            buildingDamageAverage = buildingDamageTotal / supportCount;
            gpmAverage = gpmTotal / supportCount;
            xpmAverage = xpmTotal / supportCount;
            healingDoneAverage = healingDoneTotal / supportCount;
            supportAverage = supportTotal / supportCount;
            stacksAverage = stacksTotal / supportCount;

            statAverages avg = new statAverages(killAverage, assistsAverage, deathAverage, lastHitsAverage, deniesAverage, heroDamageAverage, buildingDamageAverage, gpmAverage, xpmAverage, healingDoneAverage, supportAverage, stacksAverage);
            await Navigation.PushAsync(avg, true);
        }
    }
}
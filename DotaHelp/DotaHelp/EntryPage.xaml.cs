using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Essentials;

namespace DotaHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        public String playerId;
        public HttpClient client = new HttpClient();
        public Averages avg = new Averages(); // computes the average stats
        public EntryPage()
        {
            InitializeComponent();
            playerCheck.IsChecked = Preferences.Get("savePlayer", playerCheck.IsChecked);
            player.Text = Preferences.Get("saveThePlayer", ""); // save the playerId for use in the future
        }

        public string createMatchQuery(string matchId) // creates the match query for the api, finds all stats of all players from matchId
        {
            string requestUri = "https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/";
            requestUri += $"?match_id={matchId}"; // this isn't adding matchId properly
            requestUri = requestUri + "&key=7EA285CCC3C9E27C6BC230FC5CC48D88";
            return requestUri;
        }

        public async Task<string> GetMatchQueryResult(string matchId) // puts the match query json results into a string for evaluation
        {
            string id = match.Text;
            string query = createMatchQuery(id);
            string result = null;
            try
            {
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
                Environment.Exit(0);
            }

            return result;
        }

        // inputs all of the data via manual entry or api from matchId. I need to implement a choice of which for the user and two cases here
        public async Task ProcessMatchQuery(string id) 
        {
            string playerID = player.Text;
            string response = await GetMatchQueryResult(id);
            Debug.WriteLine(response);
            // Match match = JsonConvert.DeserializeObject<Match>(response);
            ResultContainer result = JsonConvert.DeserializeObject<ResultContainer>(response);
            var playerFinal = result.Result.players.FirstOrDefault(x => x.playerId == playerID);
            if(playerFinal == null)
            {
                // player not found
            }
            Matches matches = new Matches
            {
                datePerformed = date.Date,
                playerId = playerFinal.playerId,
                matchId = id,
                heroPlayed = identifyHero(playerFinal.heroPlayed), // need to find a way to fill this
                rolePlayed = (string)role.SelectedItem, // need to find a way to fill this
                kills = playerFinal.kills,
                assists = playerFinal.assists,
                deaths = playerFinal.deaths,
                lastHits = playerFinal.lastHits,
                denies = playerFinal.denies,
                heroDamage = playerFinal.heroDamage,
                buildingDamage = playerFinal.buildingDamage,
                gpm = playerFinal.gpm,
                xpm = playerFinal.xpm,
                healingDone = playerFinal.healingDone,
                supportCont = Int32.Parse(support.Text), // need to find a way to fill this
                stacks = Int32.Parse(stacks.Text), // need to find a way to fill this
            };
                DB.conn.Insert(matches);
        }

        // identifies the hero they played via hero_id and returns the localized name of the hero
        // I need to complete this for every hero
        public string identifyHero(int heroId)
        {
            string heroPlayed ="";
            if(heroId == 1)
            {
                heroPlayed = "Anti Mage";
            }
            if (heroId == 2)
            {
                heroPlayed = "Axe";
            }
            if (heroId == 3)
            {
                heroPlayed = "Bane";
            }
            if (heroId == 4)
            {
                heroPlayed = "Bloodseeker";
            }
            if (heroId == 5)
            {
                heroPlayed = "Crystal Maiden";
            }
            if (heroId == 6)
            {
                heroPlayed = "Drow Ranger";
            }
            if (heroId == 7)
            {
                heroPlayed = "Earth Shaker";
            }
            if (heroId == 8)
            {
                heroPlayed = "Juggernaut";
            }
            if (heroId == 9)
            {
                heroPlayed = "Mirana";
            }
            if (heroId == 11)
            {
                heroPlayed = "Shadow Fiend";
            }
            else if(heroId == 23)
            {
                heroPlayed = "Kunkka";
            }
            return heroPlayed;
        }
        // makes sure everything is populated and doesn't crash. In the future I need to throw an error here to the user if they choose manual entry.
        public void submit_Clicked(object sender, EventArgs e) 
        {
            if (stacks.Text == null)
            {
                stacks.Text = "0";
            }
            else if (support.Text == null)
            {
                support.Text = "0";
            }
            else if (xpm.Text == null)
            {
                xpm.Text = "0";
            }
            else if (gpm.Text == null)
            {
                gpm.Text = "0";
            }
            else if (healing.Text == null)
            {
                healing.Text = "0";
            }
            else if (buildingDamage.Text == null)
            {
                buildingDamage.Text = "0";
            }
            else if (heroDamage.Text == null)
            {
                heroDamage.Text = "0";
            }
            else if (denies.Text == null)
            {
                denies.Text = "0";
            }
            else if (lastHits.Text == null)
            {
                lastHits.Text = "0";
            }
            else if (deaths.Text == null)
            {
                deaths.Text = "0";
            }
            else if (assists.Text == null)
            {
                assists.Text = "0";
            }
            else if (kills.Text == null)
            {
                kills.Text = "0";
            }
            else if (match.Text == null)
            {
                match.Text = "0";
            }
            else if (player.Text == null)
            {
                player.Text = "0";
            }
            Matches matches = new Matches
            {               
            datePerformed = date.Date,
                matchId = match.Text,
                playerId = player.Text,
                heroPlayed = (string)hero.SelectedItem,
                rolePlayed = (string)role.SelectedItem,
                kills = Int32.Parse(kills.Text),
                assists = Int32.Parse(assists.Text),
                deaths = Int32.Parse(deaths.Text),
                lastHits = Int32.Parse(lastHits.Text),
                denies = Int32.Parse(denies.Text),
                heroDamage = Int32.Parse(heroDamage.Text),
                buildingDamage = Int32.Parse(buildingDamage.Text),
                gpm = Int32.Parse(gpm.Text),
                xpm = Int32.Parse(xpm.Text),
                healingDone = Int32.Parse(healing.Text),
                supportCont = Int32.Parse(support.Text),
                stacks = Int32.Parse(stacks.Text),
            };
            DB.conn.Insert(matches);

            avg.killsAverage = avg.killsAverage + Int32.Parse(kills.Text);
            avg.assistsAverage = Int32.Parse(assists.Text);
            avg.deathsAverage = Int32.Parse(deaths.Text);
            avg.lastHitsAverage = Int32.Parse(lastHits.Text);
            avg.deniesAverage = Int32.Parse(denies.Text);
            avg.heroDamageAverage = Int32.Parse(heroDamage.Text);
            avg.buildingDamageAverage = Int32.Parse(buildingDamage.Text);
            avg.gpmAverage = Int32.Parse(gpm.Text);
            avg.xpmAverage = Int32.Parse(xpm.Text);
            avg.healingAverage = Int32.Parse(healing.Text);
            avg.supportAverage = Int32.Parse(support.Text);
            avg.stacksAverage = Int32.Parse(stacks.Text);
        }

        private async void submitMatchId_Clicked(object sender, EventArgs e) // processes the match from playerId/manual input
        {
            string id = match.Text;
            await ProcessMatchQuery(id);
        }

        private void playerCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)  // saves the playerId upon selection
        {
            Preferences.Set("savePlayer", playerCheck.IsChecked);
            Preferences.Set("saveId", player.Text);
            playerId = player.Text;
        }

        private void player_TextChanged(object sender, TextChangedEventArgs e) // changes the saved playerId if save is checked
        {
            if (playerCheck.IsChecked)
            {
                Preferences.Set("saveThePlayer", player.Text);
            }
        }
    }
}
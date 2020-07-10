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
        public Averages avg = new Averages();
        public EntryPage()
        {
            InitializeComponent();
            playerCheck.IsChecked = Preferences.Get("savePlayer", playerCheck.IsChecked);
            player.Text = Preferences.Get("saveThePlayer", "");
        }

        public string createMatchQuery(string matchId)
        {
            string requestUri = "https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/";
            requestUri += $"?match_id={matchId}";
            requestUri += "&key=7EA285CCC3C9E27C6BC230FC5CC48D88";
            return requestUri;
        }

        public async Task<string> GetMatchQueryResult(string matchId)
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

        public void ProcessMatchQuery(string id)
        {
            string response = GetMatchQueryResult(id).Result;
            Match match = JsonConvert.DeserializeObject<Match>(response);
            // create result object
            // loop through to find correct accountId
            // create "player" object

            Matches matches = new Matches
            {
                datePerformed = date.Date,
                playerId = match.playerId,
                matchId = id,
                heroPlayed = (string)hero.SelectedItem,
                rolePlayed = (string)role.SelectedItem,
                kills = match.kills,
                assists = match.assists,
                deaths = match.deaths,
                lastHits = match.lastHits,
                denies = match.denies,
                heroDamage = match.heroDamage,
                buildingDamage = match.buildingDamage,
                gpm = match.gpm,
                xpm = match.xpm,
                healingDone = match.healingDone,
                supportCont = Int32.Parse(support.Text),
                stacks = Int32.Parse(stacks.Text),
            };
            DB.conn.Insert(matches);
        }

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

        private void submitMatchId_Clicked(object sender, EventArgs e)
        {
            string id = match.Text;
            ProcessMatchQuery(id);
        }

        private void playerCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Preferences.Set("savePlayer", playerCheck.IsChecked);
            Preferences.Set("saveId", player.Text);
            playerId = player.Text;
        }

        private void player_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (playerCheck.IsChecked)
            {
                Preferences.Set("saveThePlayer", player.Text);
            }
        }
    }
}
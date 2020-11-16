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
            if(heroId == 10)
            {
                heroPlayed = "Morphling";
            }
            if (heroId == 11)
            {
                heroPlayed = "Shadow Fiend";
            }
            if (heroId == 12)
            {
                heroPlayed = "Phantom Lancer";
            }
            if (heroId == 13)
            {
                heroPlayed = "Puck";
            }
            if (heroId == 14)
            {
                heroPlayed = "Pudge";
            }
            if (heroId == 15)
            {
                heroPlayed = "Razor";
            }
            if (heroId == 16)
            {
                heroPlayed = "Sand King";
            }
            if (heroId == 17)
            {
                heroPlayed = "Storm Spirit";
            }
            if (heroId == 18)
            {
                heroPlayed = "Sven";
            }
            if (heroId == 19)
            {
                heroPlayed = "Tiny";
            }
            if (heroId == 20)
            {
                heroPlayed = "Vengeful Spirit";
            }
            if (heroId == 21)
            {
                heroPlayed = "Windranger";
            }
            if (heroId == 22)
            {
                heroPlayed = "Zeus";
            }
            if (heroId == 23)
            {
                heroPlayed = "Kunkka";
            }
            if (heroId == 25)
            {
                heroPlayed = "Lina";
            }
            if (heroId == 26)
            {
                heroPlayed = "Lion";
            }
            if (heroId == 27)
            {
                heroPlayed = "Shadow Shaman";
            }
            if (heroId == 28)
            {
                heroPlayed = "Slardar";
            }
            if (heroId == 29)
            {
                heroPlayed = "Tidehunter";
            }
            if (heroId == 30)
            {
                heroPlayed = "Witch Doctor";
            }
            if (heroId == 31)
            {
                heroPlayed = "Lich";
            }
            if (heroId == 32)
            {
                heroPlayed = "Riki";
            }
            if (heroId == 33)
            {
                heroPlayed = "Enigma";
            }
            if (heroId == 34)
            {
                heroPlayed = "Tinker";
            }
            if (heroId == 35)
            {
                heroPlayed = "Sniper";
            }
            if (heroId == 36)
            {
                heroPlayed = "Necrophos";
            }
            if (heroId == 37)
            {
                heroPlayed = "Warlock";
            }
            if (heroId == 38)
            {
                heroPlayed = "Beastmaster";
            }
            if (heroId == 39)
            {
                heroPlayed = "Queen of Pain";
            }
            if (heroId == 40)
            {
                heroPlayed = "Venomancer";
            }
            if (heroId == 41)
            {
                heroPlayed = "Faceless Void";
            }
            if (heroId == 42)
            {
                heroPlayed = "Wraith King";
            }
            if (heroId == 43)
            {
                heroPlayed = "Death Prophet";
            }
            if (heroId == 44)
            {
                heroPlayed = "Phantom Assassin";
            }
            if (heroId == 45)
            {
                heroPlayed = "Pugna";
            }
            if (heroId == 46)
            {
                heroPlayed = "Templar Assassin";
            }
            if (heroId == 47)
            {
                heroPlayed = "Viper";
            }
            if (heroId == 48)
            {
                heroPlayed = "Luna";
            }
            if (heroId == 49)
            {
                heroPlayed = "Dragon Knight";
            }
            if (heroId == 50)
            {
                heroPlayed = "Dazzle";
            }
            if (heroId == 51)
            {
                heroPlayed = "Clockwerk";
            }
            if (heroId == 52)
            {
                heroPlayed = "Leshrac";
            }
            if (heroId == 53)
            {
                heroPlayed = "Nature's Prophet";
            }
            if (heroId == 54)
            {
                heroPlayed = "Lifestealer";
            }
            if (heroId == 55)
            {
                heroPlayed = "Dark Seer";
            }
            if (heroId == 56)
            {
                heroPlayed = "Clinkz";
            }
            if (heroId == 57)
            {
                heroPlayed = "Omniknight";
            }
            if (heroId == 58)
            {
                heroPlayed = "Enchantress";
            }
            if (heroId == 59)
            {
                heroPlayed = "Huskar";
            }
            if (heroId == 60)
            {
                heroPlayed = "Night Stalker";
            }
            if (heroId == 61)
            {
                heroPlayed = "Broodmother";
            }
            if (heroId == 62)
            {
                heroPlayed = "Bounty Hunter";
            }
            if (heroId == 63)
            {
                heroPlayed = "WWeaver";
            }
            if (heroId == 64)
            {
                heroPlayed = "Jakiro";
            }
            if (heroId == 65)
            {
                heroPlayed = "Batrider";
            }
            if (heroId == 66)
            {
                heroPlayed = "Chen";
            }
            if (heroId == 67)
            {
                heroPlayed = "Spectre";
            }
            if (heroId == 68)
            {
                heroPlayed = "Ancient Apparition";
            }
            if (heroId == 69)
            {
                heroPlayed = "Doom";
            }
            if (heroId == 70)
            {
                heroPlayed = "Ursa";
            }
            if (heroId == 71)
            {
                heroPlayed = "Spirit Breaker";
            }
            if (heroId == 72)
            {
                heroPlayed = "Gyrocopter";
            }
            if (heroId == 73)
            {
                heroPlayed = "Alchemist";
            }
            if (heroId == 74)
            {
                heroPlayed = "Invoker";
            }
            if (heroId == 75)
            {
                heroPlayed = "Silencer";
            }
            if (heroId == 76)
            {
                heroPlayed = "Outworld Devourer";
            }
            if (heroId == 77)
            {
                heroPlayed = "Lycan";
            }
            if (heroId == 78)
            {
                heroPlayed = "Brewmaster";
            }
            if (heroId == 79)
            {
                heroPlayed = "Shadow Demon";
            }
            if (heroId == 80)
            {
                heroPlayed = "Lone Druid";
            }
            if (heroId == 81)
            {
                heroPlayed = "Chaos Knight";
            }
            if (heroId == 82)
            {
                heroPlayed = "Meepo";
            }
            if (heroId == 83)
            {
                heroPlayed = "Treant Protector";
            }
            if (heroId == 84)
            {
                heroPlayed = "Ogre Magi";
            }
            if (heroId == 85)
            {
                heroPlayed = "Undying";
            }
            if (heroId == 86)
            {
                heroPlayed = "Rubick";
            }
            if (heroId == 87)
            {
                heroPlayed = "Disruptor";
            }
            if (heroId == 88)
            {
                heroPlayed = "Nyx Assassin";
            }
            if (heroId == 89)
            {
                heroPlayed = "Naga Siren";
            }
            if (heroId == 90)
            {
                heroPlayed = "Keeper Of The Light";
            }
            if (heroId == 91)
            {
                heroPlayed = "IO";
            }
            if (heroId == 92)
            {
                heroPlayed = "Visage";
            }
            if (heroId == 93)
            {
                heroPlayed = "Slark";
            }
            if (heroId == 94)
            {
                heroPlayed = "Medusa";
            }
            if (heroId == 95)
            {
                heroPlayed = "Troll Warlord";
            }
            if (heroId == 96)
            {
                heroPlayed = "Gyrocopter";
            }
            if (heroId == 97)
            {
                heroPlayed = "Magnus";
                if (heroId == 98)
                {
                    heroPlayed = "Timbersaw";
                }
                if (heroId == 99)
                {
                    heroPlayed = "Bristleback";
                }
                if (heroId == 100)
                {
                    heroPlayed = "Tusk";
                }
                if (heroId == 101)
                {
                    heroPlayed = "Skywrath Mage";
                }
                if (heroId == 102)
                {
                    heroPlayed = "Abbadon";
                }
                if (heroId == 103)
                {
                    heroPlayed = "Elder Titan";
                }
                if (heroId == 104)
                {
                    heroPlayed = "Legion Commander";
                }
                if (heroId == 105)
                {
                    heroPlayed = "Techies";
                }
                if (heroId == 106)
                {
                    heroPlayed = "Ember Spirit";
                }
                if (heroId == 107)
                {
                    heroPlayed = "Earth Spirit";
                }
                if (heroId == 108)
                {
                    heroPlayed = "Underlord";
                }
                if (heroId == 109)
                {
                    heroPlayed = "Terrorblade";
                }
                if (heroId == 110)
                {
                    heroPlayed = "Phoenix";
                }
                if (heroId == 111)
                {
                    heroPlayed = "Oracle";
                }
                if (heroId == 112)
                {
                    heroPlayed = "Winter Wyvern";
                }
                if (heroId == 113)
                {
                    heroPlayed = "Arc Warden";
                }
                else
                {
                    heroPlayed = "Not Found";
                    return heroPlayed;
                }
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
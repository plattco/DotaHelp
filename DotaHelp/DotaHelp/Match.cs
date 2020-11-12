using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;

namespace DotaHelp
{
    [Table("match")] // this one is for building a players match statistics via json from api call, I need to build one that sorts the players first so I can access the correct players "match"
    public class Match
    { 
      [PrimaryKey, AutoIncrement]

    public int Id { get; set; }

        public DateTime datePerformed { get; set; }

        [JsonProperty("account_id")]
        public string playerId { get; set; }

        public string matchId { get; set; }

        [JsonProperty("hero_id")]
        public int heroPlayed { get; set; }

        public string rolePlayed { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("assists")]
        public int assists { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("last_hits")]
        public int lastHits { get; set; }

        [JsonProperty("denies")]
        public int denies { get; set; }

        [JsonProperty("hero_damage")]
        public int heroDamage { get; set; }

        [JsonProperty("tower_damage")]
        public int buildingDamage { get; set; }

        [JsonProperty("gold_per_min")]
        public int gpm { get; set; }

        [JsonProperty("xp_per_min")]
        public int xpm { get; set; }

        [JsonProperty("hero_healing")]
        public int healingDone { get; set; }

        public int supportCont { get; set; }

        public int stacks { get; set; }

    public override string ToString()
    {
        return string.Format("Date: {0} Hero: {1} Role: {2}", datePerformed.ToString("MM/dd/yyyy"), heroPlayed, rolePlayed);
    }

    public static Match ParseCSV(string line)
    {
        string[] toks = line.Split(',');
        Match match = new Match
        {
            datePerformed = DateTime.Parse(toks[0]),
            matchId = toks[1],
            heroPlayed = Int32.Parse(toks[2]),
            rolePlayed = toks[3],
            kills = Int32.Parse(toks[4]),
            assists = Int32.Parse(toks[5]),
            deaths = Int32.Parse(toks[6]),
            lastHits = Int32.Parse(toks[7]),
            denies = Int32.Parse(toks[8]),
            heroDamage = Int32.Parse(toks[9]),
            buildingDamage = Int32.Parse(toks[10]),
            gpm = Int32.Parse(toks[11]),
            xpm = Int32.Parse(toks[12]),
            healingDone = Int32.Parse(toks[13]),
            supportCont = Int32.Parse(toks[14]),
            stacks = Int32.Parse(toks[15])
        };
        return match;
    }
}
}

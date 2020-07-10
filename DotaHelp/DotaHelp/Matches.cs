using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DotaHelp
{
    [Table("matches")]
    public class Matches
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        
        public DateTime datePerformed { get; set; }

        public string playerId { get; set; }

        public string matchId { get; set; }

        public string heroPlayed { get; set; }

        public string rolePlayed { get; set; }

        public int kills { get; set; }

        public int assists { get; set; }

        public int deaths { get; set; }

        public int lastHits { get; set; }

        public int denies { get; set; }

        public int heroDamage { get; set; }

        public int buildingDamage { get; set; }

        public int gpm { get; set; }

        public int xpm { get; set; }

        public int healingDone { get; set; }

        public int supportCont { get; set; }

        public int stacks { get; set; }

        public override string ToString()
        {
            return string.Format("Date: {0} Hero: {1} Role: {2}", datePerformed.ToString("MM/dd/yyyy"), heroPlayed, rolePlayed);
        }

        public static Matches ParseCSV(string line)
        {
            string[] toks = line.Split(',');
            Matches matches = new Matches
            {
                datePerformed = DateTime.Parse(toks[0]),
                matchId = toks[1],
                heroPlayed = toks[2],
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
            return matches;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DotaHelp
{
    public class Averages
    {
        public int killsAverage { get; set; }

        public int assistsAverage { get; set; }

        public int deathsAverage { get; set; }

        public int lastHitsAverage { get; set; }

        public int deniesAverage { get; set; }

        public int heroDamageAverage { get; set; }

        public int buildingDamageAverage { get; set; }

        public int gpmAverage { get; set; }

        public int xpmAverage { get; set; }

        public int healingAverage { get; set; }

        public int supportAverage { get; set; }

        public int stacksAverage { get; set; }


        public override string ToString()
        {
            return string.Format("Kills: {0} Assists: {1} Deaths: {2} Last Hits: {3} Denies: {4} Hero Damage: {5} Building Damage: {6} GPM: {7} XPM: {8} Healing Done: {9} Support Contribution: {10} Stacks: {11}", killsAverage, assistsAverage, deathsAverage, lastHitsAverage, deniesAverage, heroDamageAverage, buildingDamageAverage, gpmAverage, xpmAverage, healingAverage, supportAverage, stacksAverage);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;


namespace DotaHelp
{
    [Table("result")] // for a result full of player stats
    public class ResultContainer
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        [JsonProperty("result")]
        public ResultObject Result { get; set; }
    }

    public class ResultObject
    {

        [JsonProperty("players")]
        public List<Match> players { get; set; }
    }
}

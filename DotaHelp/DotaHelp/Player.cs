using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;


// use this class to define a "player" and store the list of players from an api call. Then Match.cs can access the players to get the correct data
namespace DotaHelp
{ 
    [Table("match")]
class Player
    {
    [PrimaryKey, AutoIncrement]
    }
}

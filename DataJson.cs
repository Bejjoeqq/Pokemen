using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMen
{
    class Account
    {
        [JsonProperty("result")]
        public int result { get; set; }

        [JsonProperty("user_id")]
        public int user_id { get; set; }

        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("poke_name")]
        public String poke_name { get; set; }

        [JsonProperty("power")]
        public int power { get; set; }

        [JsonProperty("hp")]
        public int hp { get; set; }

        [JsonProperty("atk")]
        public int atk { get; set; }

        [JsonProperty("def")]
        public int def { get; set; }

        [JsonProperty("satk")]
        public int satk { get; set; }

        [JsonProperty("sdef")]
        public int sdef { get; set; }

        [JsonProperty("speed")]
        public int speed { get; set; }

        [JsonProperty("floor")]
        public int floor { get; set; }

        [JsonProperty("exp_user")]
        public int exp_user { get; set; }

        [JsonProperty("exp_poke")]
        public int exp_poke { get; set; }

        [JsonProperty("poke_idx")]
        public int poke_idx { get; set; }

        [JsonProperty("diamond")]
        public int diamond { get; set; }

        [JsonProperty("pokecoin")]
        public int pokecoin { get; set; }

        [JsonProperty("pokeball")]
        public int pokeball { get; set; }

        [JsonProperty("stardust")]
        public int stardust { get; set; }

        [JsonProperty("account_id")]
        public int account_id { get; set; }
    }
    class Version
    {
        [JsonProperty("result")]
        public String result { get; set; }
    }
    class Chat
    {
        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("message")]
        public String message { get; set; }
    }
    class ChatCollection
    {
        [JsonProperty("result")]
        public List<Chat> result { get; set; }
    }
    class Rank
    {
        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("power")]
        public int power { get; set; }

        [JsonProperty("exp")]
        public int exp { get; set; }
    }
    class RankCollection
    {
        [JsonProperty("result")]
        public List<Rank> result { get; set; }
    }
    class Username
    {
        [JsonProperty("result")]
        public bool result { get; set; }
    }
    class Enemy
    {
        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("hp")]
        public int hp { get; set; }

        [JsonProperty("atk")]
        public int atk { get; set; }

        [JsonProperty("def")]
        public int def { get; set; }

        [JsonProperty("satk")]
        public int satk { get; set; }

        [JsonProperty("sdef")]
        public int sdef { get; set; }

        [JsonProperty("speed")]
        public int speed { get; set; }

        [JsonProperty("power")]
        public int power { get; set; }

        [JsonProperty("poke_id")]
        public int poke_id { get; set; }

        [JsonProperty("img")]
        public String img { get; set; }
    }
    class EnemyCollection
    {
        [JsonProperty("result")]
        public List<Enemy> result { get; set; }
    }
}

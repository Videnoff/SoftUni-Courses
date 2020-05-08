﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player()
        {
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public Player(string name, string @class) : this()
        {
            this.Name = name;
            this.Class = @class;
        }


        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; }
        

        public string Description { get; set; }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {Name}: {Class}");

            sb.AppendLine($"Rank: {this.Rank}");

            sb.AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }
    }
}

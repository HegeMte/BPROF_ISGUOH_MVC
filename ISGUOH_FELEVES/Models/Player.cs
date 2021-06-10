using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Player
    {

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public string IgazolasSzama { get; set; }

            [StringLength(25)]
            public string PlayerName { get; set; }
            public string Nationality { get; set; }

            [Range(0, 99)]
            public int Rating { get; set; }

            [Range(0, 5)]
            public int WeakFoot { get; set; }

        [JsonIgnore]
        [NotMapped]
            public virtual Team Csapat { get; set; }

            public string TeamID { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is Player)
            {
                Player p = obj as Player;
                return this.IgazolasSzama == p.IgazolasSzama && this.PlayerName == p.PlayerName && this.Nationality == p.Nationality &&
                    this.Rating == p.Rating && this.WeakFoot == p.WeakFoot && this.Csapat == p.Csapat && this.TeamID == p.TeamID;
            }
            return false;

        }


        public override int GetHashCode()
        {
            return 0;
        }
    }
}

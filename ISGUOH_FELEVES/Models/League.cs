using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class League
    {
        [Key]
        public string LeagueID { get; set; } // Ligának a neve
        [StringLength(25)]
        public string Country { get; set; }


        public virtual ICollection<Team> Teams { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is League)
            {
                League L = obj as League;
                return this.LeagueID == L.LeagueID && this.Country == L.Country && this.Teams == L.Teams;
            }
            return false;
        }


        public override int GetHashCode()
        {
            return 0;
        }

    }
}

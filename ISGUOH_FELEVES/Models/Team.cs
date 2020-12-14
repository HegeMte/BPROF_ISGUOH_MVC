using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Team
    {
        [Key]
        public string TeamID { get; set; } //Csapat neve

        [StringLength(25)]
        public string City { get; set; }

        
        public virtual ICollection<Player> Jatekosok { get; set; }

        
        public string LeagueID { get; set; }

        [NotMapped]
        public virtual League League { get; set; }



        public override bool Equals(object obj)
        {
            if (obj is Team)
            {
                Team t = obj as Team;
                return this.TeamID == t.TeamID && this.City == t.City && this.Jatekosok == t.Jatekosok &&
                    this.LeagueID == t.LeagueID && this.League == t.League;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

}

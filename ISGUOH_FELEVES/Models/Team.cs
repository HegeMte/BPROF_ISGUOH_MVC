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
        public string TeamID { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        
        public virtual ICollection<Player> Jatekosok { get; set; }

        
        public string LeagueID { get; set; }

        [NotMapped]
        public virtual League League { get; set; }
    }

}

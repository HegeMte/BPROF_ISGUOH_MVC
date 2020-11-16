using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class League
    {
        [Key]
        public string LeagueID { get; set; }
        [StringLength(25)]
        public string LeagueName { get; set; }
        [StringLength(25)]
        public string Country { get; set; }


        public virtual ICollection<Team> Teams { get; set; }

       

    }
}

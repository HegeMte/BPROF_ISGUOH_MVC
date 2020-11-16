using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Player
    {

            [Key]
            public string IgazolasSzama { get; set; }

            [StringLength(25)]
            public string PlayerName { get; set; }
            public string Nationality { get; set; }

            [Range(0, 99)]
            public int Rating { get; set; }

            [Range(0, 5)]
            public int WeakFoot { get; set; }

            [NotMapped]
            public virtual Team Csapat { get; set; }

            public string TeamID { get; set; }

    }
}

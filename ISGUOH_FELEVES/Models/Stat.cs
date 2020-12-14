using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Stat
    {
        public string LegnagyobbLiga { get; set; }
        public int LeagueCount { get; set; }


        public string MaxRatingJatekos { get; set; }

        public int JatekosokSzama { get; set; }

        public string AvgRatingLeaguename { get; set; }

        public IEnumerable<Player> FilteredPlayers { get; set; }

        public string WeakFootTeam { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is Stat)
            {
                Stat st = obj as Stat;
                return this.LegnagyobbLiga == st.LegnagyobbLiga && this.LeagueCount == st.LeagueCount
                    && this.MaxRatingJatekos == st.MaxRatingJatekos
                    && this.JatekosokSzama == st.JatekosokSzama && this.AvgRatingLeaguename == this.AvgRatingLeaguename;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }




}

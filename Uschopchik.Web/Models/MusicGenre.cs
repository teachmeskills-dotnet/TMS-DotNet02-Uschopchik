using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uschopchik.Web.Models
{
    public class MusicGenre
    {
        public int music_genre_id { get; set; }
        public int music_genre_parent_id { get; set; }
        public string music_genre_name { get; set; }
        public string music_genre_name_extended { get; set; }
        public string music_genre_vanity { get; set; }
    }
}

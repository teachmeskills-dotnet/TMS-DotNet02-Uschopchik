using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uschopchik.Web.Models
{
    public class Track
    {
        public int track_id { get; set; }
        public string track_name { get; set; }
        public IList<object> track_name_translation_list { get; set; }
        public int track_rating { get; set; }
        public int commontrack_id { get; set; }
        public int instrumental { get; set; }
        public int Explicit { get; set; }
        public int has_lyrics { get; set; }
        public int has_subtitles { get; set; }
        public int has_richsync { get; set; }
        public int num_favourite { get; set; }
        public int album_id { get; set; }
        public string album_name { get; set; }
        public int artist_id { get; set; }
        public string artist_name { get; set; }
        public string track_share_url { get; set; }
        public string track_edit_url { get; set; }
        public int restricted { get; set; }
        public DateTime updated_time { get; set; }
        public PrimaryGenres primary_genres { get; set; }
    }
}

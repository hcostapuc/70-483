using System.ComponentModel.DataAnnotations;

namespace MusicTracks.Models
{
    public class MusicTrack
    {
        public int ID { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        /*CTO: this attribute is used to provide the correct validation behaviors*/
        [Range(20,600)]
        public int Length { get; set; }
    }
}

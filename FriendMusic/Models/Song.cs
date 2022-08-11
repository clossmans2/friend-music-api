using System.ComponentModel.DataAnnotations.Schema;

namespace FriendMusic.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        [Column("Title")]
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Length { get; set; }
        public string KeySignature { get; set; }
        public string AlbumTitle { get; set; }


        // Navigation properties
        public virtual ICollection<PlaylistSong> AppearsOnPlaylists { get; set; }
    }
}

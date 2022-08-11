using FriendMusic.DTO;

namespace FriendMusic.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // Not Stored property
        public int SongCount => Songs?.Count ?? 0;
        public int LikesCount => Likes?.Count ?? 0;

        // Navigation properties
        public virtual ICollection<PlaylistSong> Songs { get; set; }
        public virtual ICollection<OwnedPlaylist> Owners { get; set; }
        public virtual ICollection<LikedPlaylist> Likes { get; set; }

        public Playlist() { }

        public Playlist(PlaylistDTO dto)
        {
            this.Name = dto.Name;
            this.Description = dto.Description;
            this.Songs = new List<PlaylistSong>();
            this.Owners = new List<OwnedPlaylist>();
            this.Likes = new List<LikedPlaylist>();
        }
    }
}

namespace FriendMusic.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        // Navigation properties
        public virtual ICollection<OwnedPlaylist> OwnedPlaylists { get; set; }
        public virtual ICollection<LikedPlaylist> LikedPlaylists { get; set; }
    }
}

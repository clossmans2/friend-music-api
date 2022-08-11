namespace FriendMusic.Models
{
    public class OwnedPlaylist
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }

    }
}

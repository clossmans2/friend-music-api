namespace FriendMusic.Models
{
    public class LikedPlaylist
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}

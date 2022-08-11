using FriendMusic.Models;

namespace FriendMusic.DTO
{
    public class PlaylistDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int SongCount { get; set; }
        public int LikesCount { get; set; }

        public List<Person> Owners { get; set; }
        public List<Person> Likes { get; set; }
        public List<Song> Songs { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

using FriendMusic.Models;

namespace FriendMusic.Data
{
    public class FMContext : DbContext
    {
        public FMContext(DbContextOptions<FMContext> options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PlaylistSong>()
                .HasKey(ps => ps.Id);

            builder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.Songs)
                .HasForeignKey(ps => ps.PlaylistId);

            builder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.AppearsOnPlaylists)
                .HasForeignKey(ps => ps.SongId);

            builder.Entity<LikedPlaylist>()
                .HasKey(ps => ps.Id);

            builder.Entity<LikedPlaylist>()
                .HasOne(lp => lp.Person)
                .WithMany(p => p.LikedPlaylists)
                .HasForeignKey(lp => lp.PersonId);

            builder.Entity<LikedPlaylist>()
                .HasOne(lp => lp.Playlist)
                .WithMany(p => p.Likes)
                .HasForeignKey(lp => lp.PlaylistId);

            builder.Entity<OwnedPlaylist>()
                .HasKey(ps => ps.Id);

            builder.Entity<OwnedPlaylist>()
                .HasOne(op => op.Person)
                .WithMany(p => p.OwnedPlaylists)
                .HasForeignKey(op => op.PersonId);

            builder.Entity<OwnedPlaylist>()
                .HasOne(op => op.Playlist)
                .WithMany(p => p.Owners)
                .HasForeignKey(op => op.PlaylistId);

            //builder.Entity<OwnedPlaylist>(ownedplaylist =>
            //{
            //    ownedplaylist.HasKey(ps => ps.Id);

            //    ownedplaylist.HasOne(op => op.Person)
            //    .WithMany(p => p.OwnedPlaylists)
            //    .HasForeignKey(op => op.PersonId);

            //    ownedplaylist.HasOne(op => op.Playlist)
            //    .WithMany(p => p.Owners)
            //    .HasForeignKey(op => op.PlaylistId);
            //});

        }
    }
}

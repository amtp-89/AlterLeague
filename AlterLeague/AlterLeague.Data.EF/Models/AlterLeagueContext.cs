using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlterLeague.Data.EF.Models
{
    public partial class AlterLeagueContext : DbContext
    {
        public AlterLeagueContext()
        {
        }

        public AlterLeagueContext(DbContextOptions<AlterLeagueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameTeam> GameTeam { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerGame> PlayerGame { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamPlayer> TeamPlayer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AlterLeague;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(50);

                entity.Property(e => e.Loser).HasColumnName("loser");

                entity.Property(e => e.Played).HasColumnName("played");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasMaxLength(5);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Winner).HasColumnName("winner");
            });

            modelBuilder.Entity<GameTeam>(entity =>
            {
                entity.ToTable("game_team");

                entity.Property(e => e.GameTeamId).HasColumnName("game_team_id");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.TeamId).HasColumnName("teamId");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameTeam)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_game_team_game");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.GameTeam)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_game_team_team");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("player");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.Birth)
                    .HasColumnName("birth")
                    .HasColumnType("date");

                entity.Property(e => e.Losses).HasColumnName("losses");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Ties).HasColumnName("ties");

                entity.Property(e => e.Wins).HasColumnName("wins");
            });

            modelBuilder.Entity<PlayerGame>(entity =>
            {
                entity.ToTable("player_game");

                entity.Property(e => e.PlayerGameId)
                    .HasColumnName("player_game_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.PlayerGame)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_player_game_game");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerGame)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_player_game_player");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.TeamId).HasColumnName("teamId");

                entity.Property(e => e.Losses).HasColumnName("losses");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Ties).HasColumnName("ties");

                entity.Property(e => e.Wins).HasColumnName("wins");
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.ToTable("team_player");

                entity.Property(e => e.TeamPlayerId).HasColumnName("team_player_id");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.TeamId).HasColumnName("teamId");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TeamPlayer)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_team_player_player");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamPlayer)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_team_player_team");
            });
        }
    }
}

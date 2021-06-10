using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data
{
    public class PlayersDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Player> Jatekosok { get; set; }
        public DbSet<Team> Csapatok { get; set; }
        public DbSet<League> Liga { get; set; }
        public PlayersDbContext(DbContextOptions<PlayersDbContext> opt) : base(opt)
        {

        }

        public PlayersDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    //UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|Player.mdf;integrated security=True;MultipleActiveResultSets=True");
                    //UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AuthTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    UseSqlServer(@"Server=tcp:mlsz.database.windows.net,1433;Initial Catalog=MlszDatabase;Persist Security Info=False;User ID=hegedus.mate;Password=Queen2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", x => x.MigrationsAssembly("ApiApp"));
                //Server=tcp:mlsz.database.windows.net,1433;Initial Catalog=MlszDatabase;Persist Security Info=False;User ID=hegedus.mate;Password=Queen2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;


            }
        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<IdentityRole>().HasData(
              new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" },
              new { Id = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "Customer", NormalizedName = "CUSTOMER" }
          );

            var appUser = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "hegedus.mate@stud.uni-obuda.hu",
                NormalizedEmail = "hegedus.mate@stud.uni-obuda.hu",
                EmailConfirmed = true,
                UserName = "hegedus.mate@stud.uni-obuda.hu",
                NormalizedUserName = "hegedus.mate@stud.uni-obuda.hu",
                SecurityStamp = string.Empty
            };

            appUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Almafa123!");

            modelbuilder.Entity<IdentityUser>().HasData(appUser);

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
            });


            modelbuilder.Entity<Player>(entity =>
            {
                entity
                .HasOne(Player => Player.Csapat)
                .WithMany(Team => Team.Jatekosok)
                .HasForeignKey(Player => Player.TeamID)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelbuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(Team => Team.League)
                .WithMany(League => League.Teams)
                .HasForeignKey(Team => Team.LeagueID)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}

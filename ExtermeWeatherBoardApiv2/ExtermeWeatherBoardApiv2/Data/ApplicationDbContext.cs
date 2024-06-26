﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExtremeWeatherBoardApiv2.Models;

namespace ExtermeWeatherBoardApiv2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserData>()
                   .HasMany(u => u.ReceivedMessages)
                   .WithOne(m => m.Receiver)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<AdminUserData>()
                   .HasMany(a => a.ReceivedMessages)
                   .WithOne(m => m.AdminReceiver)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<UserData>()
                .HasMany(u => u.SentMessages)
                .WithOne(m => m.Sender)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AdminUserData>()
                .HasMany(a => a.SentMessages)
                .WithOne(m => m.AdminSender)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.AdminSender)
                .WithMany(a => a.SentMessages)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.AdminReceiver)
                .WithMany(a => a.ReceivedMessages)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.CreatorAdminUser)
                .WithMany(au => au.Categories)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<SubCategory>()
                .HasOne(s => s.SubCategoryAdminUserData)
                .WithMany(au => au.SubCategories)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<SubCategory>()
                .HasOne(s => s.ParentCategory)
                .WithMany(c => c.SubCategories)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AdminUserData>()
                   .HasMany(a => a.SubCategories)
                   .WithOne(s => s.SubCategoryAdminUserData)
                   .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AdminUserData>()
                    .HasMany(a => a.DiscussionThreads)
                    .WithOne(a => a.DiscussionThreadAdminUserData)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DiscussionThread>()
                    .HasMany(d => d.Comments)
                    .WithOne(c => c.CommentThread)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AdminUserData>()
                    .HasMany(a => a.Comments)
                    .WithOne(c => c.CommentAdminUserData)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>()
                    .HasOne(c => c.CommentThread)
                    .WithMany(dt => dt.Comments)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>()
                    .HasOne(c => c.CommentAdminUserData)
                    .WithMany(u => u.Comments)
                    .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<UserData> UserDatas { get; set; } = default!;
        public DbSet<AdminUserData> AdminUserDatas { get; set; } = default!;
        public DbSet<ExtremeWeatherBoardApiv2.Models.AdminLog> AdminLogs { get; set; } = default!;
        public DbSet<Message> Messages { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<SubCategory> SubCategories { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; } = default!;
        public DbSet<DiscussionThread> DiscussionThreads { get; set; } = default!;
    }
}

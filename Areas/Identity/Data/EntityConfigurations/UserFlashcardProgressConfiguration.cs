﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuizletClone.Models;

namespace QuizletClone.Areas.Identity.Data.EntityConfigurations
{
    public class UserFlashcardProgressConfiguration : IEntityTypeConfiguration<UserFlashcardProgress>
    {
        public void Configure(EntityTypeBuilder<UserFlashcardProgress> builder)
        {
            // Khai báo key cho UserFlashcardProgress
            builder.HasKey(x => new
            {
                x.UserId,
                x.FlashcardId,
            });

            builder.HasOne(x => x.User)
             .WithMany()
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Flashcard)
             .WithMany()
             .HasForeignKey(x => x.FlashcardId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

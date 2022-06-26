using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Mapping
{
	public class UserRefreshTokenMapping : IEntityTypeConfiguration<UserRefreshToken>
	{
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("DATE");
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).HasColumnType("DATE");
            builder.Property(p => p.IsDeleted).HasColumnType("BOOLEAN").IsRequired();

            builder.HasOne<User>(u => u.User)
                   .WithOne(p => p.UserRefreshToken)
                   .HasForeignKey<UserRefreshToken>
                (a => a.UserId).HasConstraintName("FK_RefreshToken_User");

            builder.ToTable("UserRefreshTokens");
        }
    }
}


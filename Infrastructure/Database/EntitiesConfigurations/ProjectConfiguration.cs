using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntitiesConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne<ProjectTask>()
                   .WithMany()
                   .HasPrincipalKey(task=>task.ProjectId)
                   .HasForeignKey(x=>x.Id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

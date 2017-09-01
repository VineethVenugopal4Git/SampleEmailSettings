using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleEmailSettings.Entities;

namespace SampleEmailSettings.Data
{
    public class EmailDbContext:DbContext
    {
        private IConfigurationRoot _config;
        public EmailDbContext(IConfigurationRoot config, DbContextOptions<EmailDbContext>options)
            :base(options)
        {
            _config = config;
        }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:SqlServer"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SampleEmailSettings.Data;

namespace SampleEmailSettings.Migrations
{
    [DbContext(typeof(EmailDbContext))]
    [Migration("20170823074632_TemplateMigration")]
    partial class TemplateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleEmailSettings.Entities.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Salutation");

                    b.Property<string>("Signature");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("EmailTemplates");
                });
        }
    }
}

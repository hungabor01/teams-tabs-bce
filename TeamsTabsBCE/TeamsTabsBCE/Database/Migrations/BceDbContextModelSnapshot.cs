﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamsTabsBCE.Database.Core;

#nullable disable

namespace TeamsTabsBCE.Database.Migrations
{
    [DbContext(typeof(BceDbContext))]
    partial class BceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("TeamsTabsBCE.Database.Core.Entities.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("TeamsTabsBCE.Database.Core.Entities.TaskIdentifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("List")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Step")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Week")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Week", "List", "Step")
                        .IsUnique();

                    b.ToTable("TaskIdentifiers");
                });

            modelBuilder.Entity("TeamsTabsBCE.Database.Core.Entities.TaskResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Result")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskIdentifierId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TaskIdentifierId");

                    b.HasIndex("UserEmail", "TaskIdentifierId")
                        .IsUnique();

                    b.ToTable("TaskResult");
                });

            modelBuilder.Entity("TeamsTabsBCE.Database.Core.Entities.TeamsConversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConversationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TaskIdentifierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TaskIdentifierId")
                        .IsUnique();

                    b.ToTable("TeamsConversation");
                });

            modelBuilder.Entity("TeamsTabsBCE.Database.Core.Entities.TaskResult", b =>
                {
                    b.HasOne("TeamsTabsBCE.Database.Core.Entities.TaskIdentifier", "TaskIdentifier")
                        .WithMany("TaskResults")
                        .HasForeignKey("TaskIdentifierId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TaskIdentifier");
                });

            modelBuilder.Entity("TeamsTabsBCE.Database.Core.Entities.TeamsConversation", b =>
                {
                    b.HasOne("TeamsTabsBCE.Database.Core.Entities.TaskIdentifier", "TaskIdentifier")
                        .WithOne("TeamsConversation")
                        .HasForeignKey("TeamsTabsBCE.Database.Core.Entities.TeamsConversation", "TaskIdentifierId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TaskIdentifier");
                });

            modelBuilder.Entity("TeamsTabsBCE.Database.Core.Entities.TaskIdentifier", b =>
                {
                    b.Navigation("TaskResults");

                    b.Navigation("TeamsConversation");
                });
#pragma warning restore 612, 618
        }
    }
}

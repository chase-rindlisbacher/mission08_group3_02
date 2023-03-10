// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mission08_group3_02.Models;

namespace mission08_group3_02.Migrations
{
    [DbContext(typeof(TaskAppContext))]
    partial class TaskAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("mission08_group3_02.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("mission08_group3_02.Models.TaskResponse", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            CategoryId = 1,
                            Completed = false,
                            DueDate = new DateTime(1999, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quadrant = 1,
                            Task = "Clean Kitchen"
                        },
                        new
                        {
                            TaskId = 2,
                            CategoryId = 2,
                            Completed = false,
                            DueDate = new DateTime(2000, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quadrant = 2,
                            Task = "Do Homework"
                        },
                        new
                        {
                            TaskId = 3,
                            CategoryId = 3,
                            Completed = false,
                            DueDate = new DateTime(2001, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quadrant = 3,
                            Task = "Talk to Boss"
                        },
                        new
                        {
                            TaskId = 4,
                            CategoryId = 4,
                            Completed = false,
                            DueDate = new DateTime(2002, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quadrant = 4,
                            Task = "Church"
                        });
                });

            modelBuilder.Entity("mission08_group3_02.Models.TaskResponse", b =>
                {
                    b.HasOne("mission08_group3_02.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

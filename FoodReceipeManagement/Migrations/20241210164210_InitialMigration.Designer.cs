﻿// <auto-generated />
using FoodReceipeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodReceipeManagement.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241210164210_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodReceipeManagement.Core.Entities.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IngredientId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredient", (string)null);

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Name = "Apples"
                        },
                        new
                        {
                            IngredientId = 2,
                            Name = "Sugar"
                        },
                        new
                        {
                            IngredientId = 3,
                            Name = "Cinnamon"
                        },
                        new
                        {
                            IngredientId = 4,
                            Name = "Pie Dough"
                        },
                        new
                        {
                            IngredientId = 5,
                            Name = "Butter"
                        });
                });

            modelBuilder.Entity("FoodReceipeManagement.Core.Entities.Models.MeasurementUnit", b =>
                {
                    b.Property<int>("MeasurementUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeasurementUnitId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MeasurementUnitId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MeasurementUnit", (string)null);

                    b.HasData(
                        new
                        {
                            MeasurementUnitId = 1,
                            Name = "Ounce"
                        },
                        new
                        {
                            MeasurementUnitId = 2,
                            Name = "Tablespoon"
                        },
                        new
                        {
                            MeasurementUnitId = 3,
                            Name = "Teaspoon"
                        },
                        new
                        {
                            MeasurementUnitId = 4,
                            Name = "Cups"
                        },
                        new
                        {
                            MeasurementUnitId = 5,
                            Name = "Cup"
                        });
                });

            modelBuilder.Entity("FoodReceipeManagement.Core.Entities.Models.Receipe", b =>
                {
                    b.Property<int>("ReceipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceipeId"));

                    b.Property<int>("CookingTime")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReceipeId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Receipes", (string)null);

                    b.HasData(
                        new
                        {
                            ReceipeId = 1,
                            CookingTime = 60,
                            Description = "Bake and cool the pie, and then top with vanilla ice cream for the ultimate dessert.",
                            Name = "Apple Pie"
                        });
                });

            modelBuilder.Entity("FoodReceipeManagement.Core.Entities.Models.ReceipeIngredient", b =>
                {
                    b.Property<int>("ReceipeIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceipeIngredientId"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("MeasurementUnitId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("ReceipeId")
                        .HasColumnType("int");

                    b.HasKey("ReceipeIngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("MeasurementUnitId");

                    b.HasIndex("ReceipeId");

                    b.ToTable("ReceipeIngredients", (string)null);

                    b.HasData(
                        new
                        {
                            ReceipeIngredientId = 1,
                            IngredientId = 1,
                            MeasurementUnitId = 4,
                            Quantity = 6.0,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeIngredientId = 2,
                            IngredientId = 2,
                            MeasurementUnitId = 5,
                            Quantity = 0.75,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeIngredientId = 3,
                            IngredientId = 3,
                            MeasurementUnitId = 3,
                            Quantity = 1.0,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeIngredientId = 4,
                            IngredientId = 4,
                            MeasurementUnitId = 1,
                            Quantity = 14.1,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeIngredientId = 5,
                            IngredientId = 5,
                            MeasurementUnitId = 2,
                            Quantity = 1.0,
                            ReceipeId = 1
                        });
                });

            modelBuilder.Entity("FoodReceipeManagement.Core.Entities.Models.ReceipeInstruction", b =>
                {
                    b.Property<int>("ReceipeInstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceipeInstructionId"));

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstructionOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ReceipeId")
                        .HasColumnType("int");

                    b.HasKey("ReceipeInstructionId");

                    b.HasIndex("ReceipeId");

                    b.ToTable("ReceipeInstructions", (string)null);

                    b.HasData(
                        new
                        {
                            ReceipeInstructionId = 1,
                            Instruction = "Gather the ingredients. Preheat the oven to 450 degrees F (230 degrees C)",
                            InstructionOrderId = 1,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeInstructionId = 2,
                            Instruction = "Line a 9-inch pie dish with one pastry crust; set second one aside.",
                            InstructionOrderId = 2,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeInstructionId = 3,
                            Instruction = "Combine 3/4 cup sugar and cinnamon in a small bowl. Add more sugar if your apples are tart",
                            InstructionOrderId = 3,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeInstructionId = 4,
                            Instruction = "Layer apple slices in the prepared pie dish, sprinkling each layer with cinnamon-sugar mixture",
                            InstructionOrderId = 4,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeInstructionId = 5,
                            Instruction = "Dot top layer with small pieces of butter. Cover with top crust",
                            InstructionOrderId = 5,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeInstructionId = 6,
                            Instruction = "Bake pie on the lowest rack of the preheated oven for 10 minutes. Reduce oven temperature to 350 degrees F (175 degrees C) and continue baking until golden brown and filling bubbles, 30 to 35 minutes more",
                            InstructionOrderId = 6,
                            ReceipeId = 1
                        },
                        new
                        {
                            ReceipeInstructionId = 7,
                            Instruction = "Serve warm or cold.",
                            InstructionOrderId = 7,
                            ReceipeId = 1
                        });
                });

            modelBuilder.Entity("FoodReceipeManagement.Core.Entities.Models.ReceipeIngredient", b =>
                {
                    b.HasOne("FoodReceipeManagement.Core.Entities.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodReceipeManagement.Core.Entities.Models.MeasurementUnit", "MeasurementUnit")
                        .WithMany()
                        .HasForeignKey("MeasurementUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodReceipeManagement.Core.Entities.Models.Receipe", "Receipe")
                        .WithMany("ReceipeIngredients")
                        .HasForeignKey("ReceipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("MeasurementUnit");

                    b.Navigation("Receipe");
                });

            modelBuilder.Entity("FoodReceipeManagement.Core.Entities.Models.ReceipeInstruction", b =>
                {
                    b.HasOne("FoodReceipeManagement.Core.Entities.Models.Receipe", "Receipe")
                        .WithMany("ReceipeInstructions")
                        .HasForeignKey("ReceipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receipe");
                });

            modelBuilder.Entity("FoodReceipeManagement.Core.Entities.Models.Receipe", b =>
                {
                    b.Navigation("ReceipeIngredients");

                    b.Navigation("ReceipeInstructions");
                });
#pragma warning restore 612, 618
        }
    }
}

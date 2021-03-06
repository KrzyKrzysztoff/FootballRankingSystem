// <auto-generated />
using System;
using FootballRankingSystemAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballRankingSystemAPI.Migrations
{
    [DbContext(typeof(RankingDbContext))]
    [Migration("20210824085748_Change realtion between MatchResult and Team")]
    partial class ChangerealtionbetweenMatchResultandTeam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballRankingSystemAPI.Entities.Confederation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Confederation");
                });

            modelBuilder.Entity("FootballRankingSystemAPI.Entities.MatchResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoalsScoredByLoseTeam")
                        .HasColumnType("int");

                    b.Property<int>("GoalsScoredByWinTeam")
                        .HasColumnType("int");

                    b.Property<bool>("IsDraw")
                        .HasColumnType("bit");

                    b.Property<string>("TeamLostOrDrawName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamWinOrDrawName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MatchResult");
                });

            modelBuilder.Entity("FootballRankingSystemAPI.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Chance")
                        .HasColumnType("float");

                    b.Property<int>("ConfederationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("RankingPlace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConfederationId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("MatchResultTeam", b =>
                {
                    b.Property<int>("MatchResultId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("MatchResultId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("MatchResultTeam");
                });

            modelBuilder.Entity("FootballRankingSystemAPI.Entities.Team", b =>
                {
                    b.HasOne("FootballRankingSystemAPI.Entities.Confederation", "Confederation")
                        .WithMany()
                        .HasForeignKey("ConfederationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Confederation");
                });

            modelBuilder.Entity("MatchResultTeam", b =>
                {
                    b.HasOne("FootballRankingSystemAPI.Entities.MatchResult", null)
                        .WithMany()
                        .HasForeignKey("MatchResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballRankingSystemAPI.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

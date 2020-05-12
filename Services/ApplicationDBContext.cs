using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecruitmentPortalApp.Models;

namespace RecruitmentPortalApp.Services
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            Database.Migrate();

        }

        public virtual DbSet<ApplicationsModel> Applications { get; set; }
        public virtual DbSet<AnswersModel> Answers { get; set; }
        public virtual DbSet<ApplicantResponsesModel> ApplicantResponses { get; set; }
        public virtual DbSet<JobsModel> Jobs { get; set; }
        public virtual DbSet<JobStagesModel> JobStages { get; set; }
        public virtual DbSet<OrganizationDocsModel> OrganizationDocuments { get; set; }
        public virtual DbSet<ProfilesModel> Profiles { get; set; }
        public virtual DbSet<QuestionsModel> Questions { get; set; }
        public virtual DbSet<ScoreBoardsModel> ScoreBoards { get; set; }
        public virtual DbSet<StaffDocsModel> StaffDocuments { get; set; }
        public virtual DbSet<StagesModel> Stages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<JobStagesModel>().HasKey(sc => new { sc.JobId, sc.StageId });
            #region "Seed Data"
            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = "1";

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Applicant", NormalizedName = "APPLICANT" },
                new { Id = "3", Name = "Onboarding", NormalizedName = "ONBOARDING" },
                new { Id = "4", Name = "Staff", NormalizedName = "STAFF" }
            );
           
            var hasher = new PasswordHasher<UserModel>();
            builder.Entity<UserModel>().HasData(new UserModel
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "RECRUITMENT"),
                SecurityStamp = string.Empty,
                
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            #endregion
        }
    }
}

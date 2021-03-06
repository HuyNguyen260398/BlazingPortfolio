namespace Infrastructure.SqliteDb;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Archievement> Archievements { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Seed Data
        List<Archievement> archievementsToSeed = new()
        {
            new Archievement { ArchievementId = 1, Name = "Happy Clients", Count = 111 },
            new Archievement { ArchievementId = 2, Name = "Projects Finished", Count = 333 },
            new Archievement { ArchievementId = 4, Name = "Certificates Archieved", Count = 555 },
            new Archievement { ArchievementId = 3, Name = "Awards Won", Count = 777 }
        };

        List<Image> imagesToSeed = new()
        {
            new Image
            {
                ImageId = 1,
                ImageGuid = Guid.NewGuid().ToString(),
                NewImageExtension = ".png",
                NewImageBase64Content = String.Empty,
                OldImagePath = String.Empty,
                RelativeImagePath = String.Empty,
                ImageFor = "services",
                Tooltip = "service_1_img"
            },
            new Image
            {
                ImageId = 2,
                ImageGuid = Guid.NewGuid().ToString(),
                NewImageExtension = ".png",
                NewImageBase64Content = String.Empty,
                OldImagePath = String.Empty,
                RelativeImagePath = String.Empty,
                ImageFor = "services",
                Tooltip = "service_2_img"
            },
            new Image
            {
                ImageId = 3,
                ImageGuid = Guid.NewGuid().ToString(),
                NewImageExtension = ".png",
                NewImageBase64Content = String.Empty,
                OldImagePath = String.Empty,
                RelativeImagePath = String.Empty,
                ImageFor = "services",
                Tooltip = "service_3_img"
            },
            new Image
            {
                ImageId = 4,
                ImageGuid = Guid.NewGuid().ToString(),
                NewImageExtension = ".png",
                NewImageBase64Content = String.Empty,
                OldImagePath = String.Empty,
                RelativeImagePath = String.Empty,
                ImageFor = "services",
                Tooltip = "service_4_img"
            }
        };

        List<Post> postsToSeed = new()
        {
            new Post
            {
                PostId = 1,
                Title = "Post 1",
                ThumbnailPath = String.Empty,
                ImageId = 1,
                Excerpt = "Excerpt 1",
                Content = "Content 1",
                IsPublished = true,
                PublishDate = DateTime.Now.Date,
            },
            new Post
            {
                PostId = 2,
                Title = "Post 2",
                ThumbnailPath = String.Empty,
                ImageId = 2,
                Excerpt = "Excerpt 2",
                Content = "Content 2",
                IsPublished = true,
                PublishDate = DateTime.Now.Date,
            },
            new Post
            {
                PostId = 3,
                Title = "Post 3",
                ThumbnailPath = String.Empty,
                ImageId = 3,
                Excerpt = "Excerpt 3",
                Content = "Content 3",
                IsPublished = true,
                PublishDate = DateTime.Now.Date,
            },
            new Post
            {
                PostId = 4,
                Title = "Post 4",
                ThumbnailPath = String.Empty,
                Excerpt = "Excerpt 4",
                Content = "Content 4",
                IsPublished = true,
                PublishDate = DateTime.Now.Date,
            }
        };

        List<Service> servicesToSeed = new()
        {
            new Service
            {
                ServiceId = 1,
                Name = "Web Developement",
                Description = "Building web apps with DotNet",
                DisplayIcon = "Icons.Filled.DesktopWindows"
            },
            new Service
            {
                ServiceId = 2,
                Name = "DevOps",
                Description = "Upscaling apps using DevOps stacks",
                DisplayIcon = "Icons.Filled.CloudSync"
            },
            new Service
            {
                ServiceId = 3,
                Name = "Data Analysist",
                Description = "Visualizing data by Power Bi",
                DisplayIcon = "Icons.Filled.QueryStats"
            }
        };

        List<Skill> skillsToSeed = new()
        {
            new Skill { SkillId = 1, Name = "C#", YearsOfExperience = 3, ScorePercentage = 0.9m },
            new Skill { SkillId = 2, Name = "SQL", YearsOfExperience = 1, ScorePercentage = 0.5m },
            new Skill { SkillId = 3, Name = "DotNet", YearsOfExperience = 2, ScorePercentage = 0.7m },
            new Skill { SkillId = 4, Name = "Blazor", YearsOfExperience = 2, ScorePercentage = 0.7m }
        };

        List<User> usersToSeed = new()
        {
            new User
            {
                UserId = 1,
                FirstName = "Huy",
                LastName = "Nguyen",
                DoB = new DateTime(1998, 03, 26).Date,
                Gender = "Male",
                Email = "huynguyen260398@gmail.com",
                Password = "Pas$w0rd",
                Phone = "(+84)903336493",
                Address = "HCM City, Viet Nam",
                Study = "University of Greenwich",
                Degree = "Bachelor of Computer Science",
                Interests = "Building websites",
                Intro = "I am a Web Developer, and I'm very passionate and dedicated to my work. With 2 years experience as a senior Web developer, I have acquired the skills and knowledge necessary to make your project a success.",
                AvatarImagePath = "uploads/avatar.jpg",
                BackgroundImagePath = "uploads/ocean_background.jpg"
            }
        };

        modelBuilder.Entity<Archievement>().HasData(archievementsToSeed);
        modelBuilder.Entity<Image>().HasData(imagesToSeed);
        modelBuilder.Entity<Post>().HasData(postsToSeed);
        modelBuilder.Entity<Service>().HasData(servicesToSeed);
        modelBuilder.Entity<Skill>().HasData(skillsToSeed); ;
        modelBuilder.Entity<User>().HasData(usersToSeed);
    }
}

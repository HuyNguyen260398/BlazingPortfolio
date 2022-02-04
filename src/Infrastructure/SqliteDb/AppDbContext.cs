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
            new Archievement { ArchievementId = 3, Name = "Awards Won", Count = 777 },
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
                RelativeImagePath = String.Empty
            },
            new Image
            {
                ImageId = 2,
                ImageGuid = Guid.NewGuid().ToString(),
                NewImageExtension = ".png",
                NewImageBase64Content = String.Empty,
                OldImagePath = String.Empty,
                RelativeImagePath = String.Empty
            },
            new Image
            {
                ImageId = 3,
                ImageGuid = Guid.NewGuid().ToString(),
                NewImageExtension = ".png",
                NewImageBase64Content = String.Empty,
                OldImagePath = String.Empty,
                RelativeImagePath = String.Empty
            }
        };

        List<Post> postsToSeed = new()
        {
            new Post
            {
                PostId = 1,
                Title = "Post 1",
                ThumbnailPath = String.Empty,
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
                Excerpt = "Excerpt 3",
                Content = "Content 3",
                IsPublished = true,
                PublishDate = DateTime.Now.Date,
            },
        };

        List<Service> servicesToSeed = new()
        {
            new Service
            {
                ServiceId = 1,
                Name = "Web Developement",
                Description = "Building web apps with DotNet",
                SvgPath = "uploads/code.svg"
            },
            new Service
            {
                ServiceId = 2,
                Name = "DevOps",
                Description = "Upscaling apps using DevOps stacks",
                SvgPath = "uploads/telegram.svg"
            },
            new Service
            {
                ServiceId = 3,
                Name = "Data Analysist",
                Description = "Visualizing data by Power Bi",
                SvgPath = "uploads/creativity.svg"
            }
        };

        List<User> usersToSeed = new()
        {
            new User
            {
                UserId = 1,
                FirstName = "Huy",
                LastName = "Nguyen",
                DoB = new DateTime(1998, 03, 26).Date,
                Email = "huynguyen260398@gmail.com",
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
        modelBuilder.Entity<User>().HasData(usersToSeed);
    }
}

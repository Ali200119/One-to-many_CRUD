using System;
using Fiorello.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Data
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Slider> Sliders { get; set; }
		public DbSet<SliderInfo> SliderInfo { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Instagram> Instagrams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }




        #region Seed Data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>().HasQueryFilter(b => !b.SoftDelete);
            modelBuilder.Entity<BlogPost>().HasQueryFilter(bp => !bp.SoftDelete);
            modelBuilder.Entity<Slider>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<SliderInfo>().HasQueryFilter(si => !si.SoftDelete);
            modelBuilder.Entity<Expert>().HasQueryFilter(e => !e.SoftDelete);
            modelBuilder.Entity<SocialMedia>().HasQueryFilter(sm => !sm.SoftDelete);
            modelBuilder.Entity<Person>().HasQueryFilter(p => !p.SoftDelete);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.SoftDelete);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.SoftDelete);







            modelBuilder.Entity<Slider>().HasData(
                new Slider { Id = 1, Image = "h3-slider-background.jpg", SoftDelete = false },
                new Slider { Id = 2, Image = "h3-slider-background-2.jpg", SoftDelete = false },
                new Slider { Id = 3, Image = "h3-slider-background-3.jpg", SoftDelete = false }
            );

            modelBuilder.Entity<SliderInfo>().HasData(
                new SliderInfo { Id = 1, Title = "<h1>Send <span>flowers</span> like</h1><h1>you mean it</h1>", Description = "Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will make it special cursus a sit amet mauris.", SignatureImage = "h2-sign-img.png", SoftDelete = false }
            );

            modelBuilder.Entity<About>().HasData(
                new About { Id = 1, VideoCover = "h3-video-img.jpg", Title = "<h1>Suprise Your <span>Valentine!</span> Let us arrange a smile.</h1>", Description = "Where flowers are our inspiration to create lasting memories. Whatever the occasion...", SoftDelete = false }
            );

            modelBuilder.Entity<Advantage>().HasData(
                new Advantage { Id = 1, Icon = "h1-custom-icon.png", Description = "Hand picked just for you.", SoftDelete = false, AboutId = 1 },
                new Advantage { Id = 2, Icon = "h1-custom-icon.png", Description = "Unique flower arrangements.", SoftDelete = false, AboutId = 1 },
                new Advantage { Id = 3, Icon = "h1-custom-icon.png", Description = "Best way to say you care.", SoftDelete = false, AboutId = 1 }
            );

            modelBuilder.Entity<Expert>().HasData(
                new Expert { Id = 1, Title = "Flower Experts", Description = "A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you.", SoftDelete = false }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Image = "h3-team-img-1.png", Name = "CRYSTAL BROOKS", Position = "Florist", SoftDelete = false, ExpertId = 1 },
                new Person { Id = 2, Image = "h3-team-img-2.png", Name = "SHIRLEY HARRIS", Position = "Manager", SoftDelete = false, ExpertId = 1 },
                new Person { Id = 3, Image = "h3-team-img-3.png", Name = "BEVERLY CLARK", Position = "Florist", SoftDelete = false, ExpertId = 1 },
                new Person { Id = 4, Image = "h3-team-img-4.png", Name = "AMANDA WATKINS", Position = "Florist", SoftDelete = false, ExpertId = 1 }
            );

            modelBuilder.Entity<Subscribe>().HasData(
                new Subscribe { Id = 1, Title = "Join The Colorful Bunch!", BackgroundImage = "h3-background-img.jpg", SoftDelete = false }
            );

            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Title = "From our Blog", Description = "A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you.", SoftDelete = false }
            );

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost { Id = 1, Image = "blog-feature-img-1.jpg", Date = new DateTime(2019, 12, 29), Title = "Flower Power", Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", SoftDelete = false, BlogId = 1 },
                new BlogPost { Id = 2, Image = "blog-feature-img-3.jpg", Date = new DateTime(2019, 10, 15), Title = "Local Florists", Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", SoftDelete = false, BlogId = 1 },
                new BlogPost { Id = 3, Image = "blog-feature-img-4.jpg", Date = new DateTime(2019, 08, 10), Title = "Flower Beauty", Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", SoftDelete = false, BlogId = 1 }
            );

            modelBuilder.Entity<Quote>().HasData(
                new Quote { Id = 1, Image = "testimonial-img-1.png", Description = "Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus lingua.", Name = "Anna Barnes", Position = "Florist", SoftDelete = false },
                new Quote { Id = 2, Image = "testimonial-img-2.png", Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget.", Name = "Jasmine White", Position = "Florist", SoftDelete = false }
            );

            modelBuilder.Entity<Instagram>().HasData(
                new Instagram { Id = 1, Image = "instagram1.jpg", SoftDelete = false },
                new Instagram { Id = 2, Image = "instagram2.jpg", SoftDelete = false },
                new Instagram { Id = 3, Image = "instagram3.jpg", SoftDelete = false },
                new Instagram { Id = 4, Image = "instagram4.jpg", SoftDelete = false },
                new Instagram { Id = 5, Image = "instagram5.jpg", SoftDelete = false },
                new Instagram { Id = 6, Image = "instagram6.jpg", SoftDelete = false },
                new Instagram { Id = 7, Image = "instagram7.jpg", SoftDelete = false },
                new Instagram { Id = 8, Image = "instagram8.jpg", SoftDelete = false }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Popular", SoftDelete = false },
                new Category { Id = 2, Name = "Winter", SoftDelete = false },
                new Category { Id = 3, Name = "Various", SoftDelete = false },
                new Category { Id = 4, Name = "Exotic", SoftDelete = false },
                new Category { Id = 5, Name = "Greens", SoftDelete = false },
                new Category { Id = 6, Name = "Cactuses", SoftDelete = false }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "1MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 6, SoftDelete = false },
                new Product { Id = 2, Name = "2MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 4, SoftDelete = false },
                new Product { Id = 3, Name = "3MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 3, SoftDelete = false },
                new Product { Id = 4, Name = "4MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 1, SoftDelete = false },
                new Product { Id = 5, Name = "5MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 2, SoftDelete = false },
                new Product { Id = 6, Name = "6MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 2, SoftDelete = false },
                new Product { Id = 7, Name = "7MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 4, SoftDelete = false },
                new Product { Id = 8, Name = "8MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 5, SoftDelete = true },
                new Product { Id = 9, Name = "9MAJESTY PALM", Description = "Lorem ipsum", Price = 259, Count = 20, CategoryId = 5, SoftDelete = false }
            );

            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { Id = 1, Name = "shop-14-img.jpg", IsMain = true, ProductId = 1, SoftDelete = false },
                new ProductImage { Id = 2, Name = "shop-13-img.jpg", IsMain = false, ProductId = 1, SoftDelete = false },
                new ProductImage { Id = 3, Name = "shop-12-img.jpg", IsMain = false, ProductId = 1, SoftDelete = false },
                new ProductImage { Id = 4, Name = "shop-13-img.jpg", IsMain = false, ProductId = 2, SoftDelete = false },
                new ProductImage { Id = 5, Name = "shop-14-img.jpg", IsMain = true, ProductId = 2, SoftDelete = false },
                new ProductImage { Id = 6, Name = "shop-11-img.jpg", IsMain = true, ProductId = 3, SoftDelete = false },
                new ProductImage { Id = 7, Name = "shop-10-img.jpg", IsMain = false, ProductId = 3, SoftDelete = false },
                new ProductImage { Id = 8, Name = "shop-9-img.jpg", IsMain = false, ProductId = 3, SoftDelete = false },
                new ProductImage { Id = 9, Name = "shop-11-img.jpg", IsMain = true, ProductId = 4, SoftDelete = false },
                new ProductImage { Id = 10, Name = "shop-12-img.jpg", IsMain = false, ProductId = 4, SoftDelete = false },
                new ProductImage { Id = 11, Name = "shop-10-img.jpg", IsMain = true, ProductId = 5, SoftDelete = false },
                new ProductImage { Id = 12, Name = "shop-13-img.jpg", IsMain = false, ProductId = 5, SoftDelete = false },
                new ProductImage { Id = 13, Name = "shop-9-img.jpg", IsMain = true, ProductId = 6, SoftDelete = false },
                new ProductImage { Id = 14, Name = "shop-14-img.jpg", IsMain = false, ProductId = 6, SoftDelete = false },
                new ProductImage { Id = 15, Name = "shop-8-img.jpg", IsMain = true, ProductId = 7, SoftDelete = false },
                new ProductImage { Id = 16, Name = "shop-11-img.jpg", IsMain = false, ProductId = 7, SoftDelete = false },
                new ProductImage { Id = 17, Name = "shop-9-img.jpg", IsMain = false, ProductId = 7, SoftDelete = false },
                new ProductImage { Id = 18, Name = "shop-7-img.jpg", IsMain = true, ProductId = 8, SoftDelete = false },
                new ProductImage { Id = 19, Name = "shop-10-img.jpg", IsMain = false, ProductId = 8, SoftDelete = false },
                new ProductImage { Id = 20, Name = "shop-14-img.jpg", IsMain = true, ProductId = 9, SoftDelete = false },
                new ProductImage { Id = 21, Name = "shop-8-img.jpg", IsMain = false, ProductId = 9, SoftDelete = false }
            );

            modelBuilder.Entity<Setting>().HasData(
                new Setting { Id = 1, Key = "Header Logo", Value = "logo.png" },
                new Setting { Id = 2, Key = "Phone", Value = "994501248723" },
                new Setting { Id = 3, Key = "Email", Value = "CodeAcademy@gmail.az" },
                new Setting { Id = 4, Key = "Payment", Value = "footer-bottom-1.png" }
            );

            modelBuilder.Entity<SocialMedia>().HasData(
                new SocialMedia { Id = 1, Name = "LINKEDIN" },
                new SocialMedia { Id = 2, Name = "FACEBOOK" }
            );
        }

        #endregion
    }
}
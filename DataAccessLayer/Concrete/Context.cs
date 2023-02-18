using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        //Veritabanı bağlantısı icin entityframework 4 adet paketini dağil ettikten sonra bu sınıfı oluşturduk
        //aşağıdaki kod veri tabanı bağlantı kodudur DbContext den miras alır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=UTNTB;database=CoreBlogDb; integrated security=true;");
        }

        /*
         * Not: Çok Katmanlı Mimaride her katman bir projedir ve bu projelerin birbirlerini referans etmeleri gerekir
         * EntityLayer Katmanı hicbir katmanı referans almaz
         * DataAccessLayer Katmanı EntityLayer Katmanını referans alır
         * BussinessLayer Katmanı EntityLayer ve DataAccessLayer Katmanını referans alır
         * UI Katmanı tüm katmanları referans alır.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}

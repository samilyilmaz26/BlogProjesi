using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjesi.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {

        }
        public DbSet<Makaleler> Makale { get; set; }
        public DbSet<Users> User { get; set; }
        public class Makaleler
        {
            public Makaleler()
            {
                this.Tarih = DateTime.Now;
            }
            public int Id { get; set; }
            public string  Yazar { get; set; }
            public string  Baslik { get; set; }
            public string  Detay{ get; set; }
            public DateTime Tarih  { get; set; }
        }
        public class Users
        {
            [Key]
            public string  Email { get; set; }
            public string  Password { get; set; }
        }

    }
}

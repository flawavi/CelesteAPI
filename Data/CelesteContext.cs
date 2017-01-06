using System;
using System.Linq;
using Celeste.Models;
using Microsoft.EntityFrameworkCore;

/*
    Author: Fletcher Watson
    Class: CelesteContext
    Purpose: Defines name of the session with the database - which inherits from DbContext - and the tables represented in the database.
    Sets any properties on them upon model creation.
*/

namespace Celeste.Data
{
    //The CelesteContext class is the middle man that defines what entity framework will be working with the database. It inherits from DbContext, which represents a session with the databse
    public class CelesteContext : DbContext
    {
        //Method: The CelesteContext() is a constructor function that accepts an argument of type DbContextOptions<CelesteContext>, which is passed to the parent class.
        public CelesteContext(DbContextOptions<CelesteContext> options)
            : base(options)
        { }
        public DbSet<CelesteHost> CelesteHost {get;set;}
        public DbSet<Explorer> Explorer {get;set;}
        public DbSet<Questions> Questions {get;set;}
        public DbSet<Answers> Answers {get;set;}
        public DbSet<Journey> Journey {get;set;}
        public DbSet<ExplorerJourney> ExplorerJourney {get;set;}

        //Method: OnModelCreating() accepts one argument of type ModelBuilder and specifies exactly what properties will be included on each model as its table is created in the db.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Explorer>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<ExplorerJourney>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("now()");
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Celeste.Models;

/*
    Author: Fletcher Watson
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
        public DbSet<Journey> Journey {get;set;}
        public DbSet<QandA> QandA {get;set;}
        public DbSet<User> User {get;set;}
        public DbSet<CelesteHost> CelesteHost {get;set;}
        public DbSet<UserJourney> UserJourney {get;set;}
        public DbSet<UserResponse> UserResponse {get;set;}

        //Method: OnModelCreating() accepts one argument of type ModelBuilder and specifies exactly what properties will be included on each model as its table is created in the db.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<Journey>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<UserJourney>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
                
            modelBuilder.Entity<UserResponse>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        }
    }
}
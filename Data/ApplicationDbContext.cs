﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication10Jan20Country.Models;

namespace WebApplication10Jan20Country.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
	}
}
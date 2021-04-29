﻿using BeekeepingStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeekeepingStore.AppDbContext
{
    public class BeekeepingDbContext : IdentityDbContext<IdentityUser>
    {
        public BeekeepingDbContext(DbContextOptions<BeekeepingDbContext> options):
        base(options)
        {

        }
        public DbSet<Make > Makes { get; set; }
        public DbSet <Model>  Models{ get; set; }
       
    }
}

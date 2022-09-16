using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Champions.Model;

    public class RazorCrudChampionContext : DbContext
    {
        public RazorCrudChampionContext (DbContextOptions<RazorCrudChampionContext> options)
            : base(options)
        {
        }

        public DbSet<Champions.Model.Champion> Champion { get; set; } = default!;
    }

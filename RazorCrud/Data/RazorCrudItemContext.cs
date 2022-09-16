using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Items.Model;

    public class RazorCrudItemContext : DbContext
    {
        public RazorCrudItemContext (DbContextOptions<RazorCrudItemContext> options)
            : base(options)
        {
        }

        public DbSet<Items.Model.Item> Item { get; set; } = default!;
    }

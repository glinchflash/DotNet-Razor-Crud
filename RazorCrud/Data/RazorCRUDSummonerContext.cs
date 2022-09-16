using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Summoners.Model;

    public class RazorCRUDSummonerContext : DbContext
    {
        public RazorCRUDSummonerContext (DbContextOptions<RazorCRUDSummonerContext> options)
            : base(options)
        {
        }

        public DbSet<Summoners.Model.Summoner> Summoner { get; set; } = default!;
    }

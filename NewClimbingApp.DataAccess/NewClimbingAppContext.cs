using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess;

public class NewClimbingAppContext : DbContext
{
    public NewClimbingAppContext(DbContextOptions<NewClimbingAppContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }

    public DbSet<Route> Routes { get; set; }

    public DbSet<Ascent> Ascents { get; set; }

    public DbSet<Crag> Crags { get; set; }
}

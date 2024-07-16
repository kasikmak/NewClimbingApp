using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewClimbingApp.DataAccess;

public class NewClimbingAppContextFactory : IDesignTimeDbContextFactory<NewClimbingAppContext>
{
    public NewClimbingAppContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NewClimbingAppContext>();
        optionsBuilder.UseSqlServer("Server=tcp:climbing-app.database.windows.net,1433;Initial Catalog=ClimbingAppDB;Persist Security Info=False;User ID=kasikmak;Password=ph0hUFTO7tSGO;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        return new NewClimbingAppContext(optionsBuilder.Options);
    }
}
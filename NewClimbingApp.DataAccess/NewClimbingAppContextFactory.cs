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
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-KSU5O1R\\SQLEXPRESS;Initial Catalog=NewClimbingApp;Integrated Security=True;Trust Server Certificate=True");
        return new NewClimbingAppContext(optionsBuilder.Options);
    }
}
//Data Source = DESKTOP - KSU5O1R\SQLEXPRESS;Initial Catalog = NewClimbingApp; Integrated Security = True
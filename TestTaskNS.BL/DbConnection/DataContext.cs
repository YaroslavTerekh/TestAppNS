using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.BL.DbConnection;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }


    public DbSet<Announcement> Announcements { get; set; }
}

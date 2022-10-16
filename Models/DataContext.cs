using Microsoft.EntityFrameworkCore;

namespace demo.Models
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  }
}
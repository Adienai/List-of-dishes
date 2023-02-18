using Microsoft.EntityFrameworkCore;

namespace Menu.DLL.Data
{
    public class AppDBContext: DbContext
    {
        AppDBContext(DbContextOptions<AppDBContext> options) : base(options){ }
    }
}

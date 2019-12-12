using Microsoft.EntityFrameworkCore.Design;

namespace ContosoUniversityApi.Context
{
    public class ContosoUniversityContextFactory : IDesignTimeDbContextFactory<ContosoUniversityContext>
    {
        public ContosoUniversityContext CreateDbContext(string[] args)
        {
            return new ContosoUniversityContext();
        }
    }
}
using RailLate.Infrastructure.DatabaseContext;
using RailLate.Test.Integration.Infrastructure;

namespace RailLate.Test.Integration;

public class AgencyIntegrationTests : IntegrationTest
{
    private readonly EfContext _dbContext;
    
    public AgencyIntegrationTests()
    {
        _dbContext = GetContext();
        SeedData();
    }
    
    [Fact]
    public void Test()
    {
        
    }
}
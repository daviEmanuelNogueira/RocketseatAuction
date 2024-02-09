using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly RocketseateAuctionDbContext _dbContext;
    public UserRepository(RocketseateAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }
    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}

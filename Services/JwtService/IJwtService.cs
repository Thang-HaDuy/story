using App.Models;

public interface IJwtService
{
    string GenerateToken(AppUser user);
}
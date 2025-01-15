using Microsoft.AspNetCore.Identity;

namespace ERP_INES.Data.Modules.Auth.Repository.Interfaces;

public interface ITokenRepository
{
    string CreateJwtToken(IdentityUser user, List<string> roles);
}
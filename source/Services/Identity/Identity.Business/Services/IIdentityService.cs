using Identity.Business.Models;

namespace Identity.Business.Services
{
    public interface IIdentityService
    {
        IdentityModel GetIdentity();
    }
}

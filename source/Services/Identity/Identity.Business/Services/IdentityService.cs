using Identity.Business.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Identity.Business.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IdentityModel GetIdentity()
        {
            string authorizationHeader = _context.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = authorizationHeader.Split(' ')[1];
                var paresedToken = tokenHandler.ReadJwtToken(token);

                var name = paresedToken.Claims
                    .Where(c => c.Type == "name")
                    .FirstOrDefault();
                var Id = paresedToken.Claims
                    .Where(c => c.Type == "Id")
                    .FirstOrDefault();

                return new IdentityModel()
                {
                    FullName = name.Value,
                    Id = long.Parse(Id.Value)
                };
            }
            return null;
        }
    }
}

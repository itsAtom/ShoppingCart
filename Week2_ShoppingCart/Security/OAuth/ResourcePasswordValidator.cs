using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System;
using Week2_ShoppingCart.Models;
using System.Threading.Tasks;

namespace Week2_ShoppingCart.Security.OAuth
{
    public class ResourcePasswordValidator: IResourceOwnerPasswordValidator
    {
        private readonly ShoppingCartContext _context;

        public ResourcePasswordValidator(ShoppingCartContext context)
        {
            _context = context;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Email == context.UserName);
                if (customer != null)
                {
                    if (customer.Password == context.Password)
                    {
                        context.Result = new GrantValidationResult(
                            subject: customer.Id.ToString(),
                            authenticationMethod: "database",
                            claims: GetUserClaims(customer));

                        return;
                    }

                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant,
                        "Incorrect password");
                    return;
                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant,
                    "User does not exist.");
                return;
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant,
                    "Invalid username or password");
            }
        }

        public static Claim[] GetUserClaims(Customer customer)
        {
            return new Claim[]
            {
                new Claim(JwtClaimTypes.Id, customer.Id.ToString() ?? ""),
                new Claim(JwtClaimTypes.Name, (
                    !string.IsNullOrEmpty(customer.Firstname) && !string.IsNullOrEmpty(customer.Lastname))
                    ? (customer.Firstname + " " + customer.Lastname)
                    : String.Empty),
                new Claim(JwtClaimTypes.GivenName, customer.Firstname  ?? string.Empty),
                new Claim(JwtClaimTypes.FamilyName, customer.Lastname  ?? string.Empty),
                new Claim(JwtClaimTypes.Email, customer.Email  ?? string.Empty)
            };
        }
    }
}
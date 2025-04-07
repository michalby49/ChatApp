using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ChatApp.Core.Models;
using ChatApp.Core.Queries;
using Microsoft.Extensions.Configuration;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
{
    private readonly IConfiguration _configuration;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public LoginUserQueryHandler(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        SecurityToken token;
        JwtSecurityTokenHandler tokenHandler;

        try
        {

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.UserName)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            token = tokenHandler.CreateToken(tokenDescriptor);
        }
        catch (Exception)
        {

            throw;
        }

        return tokenHandler.WriteToken(token);
    }
}
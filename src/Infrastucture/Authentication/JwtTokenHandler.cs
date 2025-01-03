using Core.Dtos;
using Core.Exceptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastucture.Authentication
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly JwtOption jwtOption;
        public JwtTokenHandler(IOptions<JwtOption> jwtOption)
        {
            this.jwtOption = jwtOption.Value;
        }
        public JwtSecurityToken GenerateAccessToken(ParticipantDto participantDto)
        {
            if (string.IsNullOrWhiteSpace(jwtOption.Audience) ||
                string.IsNullOrWhiteSpace(jwtOption.Issuer) ||
                string.IsNullOrWhiteSpace(jwtOption.SecretKey) || 
                jwtOption.ExpirationInMunutes <= 0)
            {
                throw new ArgumentException("Invalid JWT configuration. Ensure all required fields are set.");
            }
            if (participantDto == null)
            {
                throw new ArgumentNullException(nameof(participantDto), "User cannot be null");
            }
            if(string.IsNullOrWhiteSpace(participantDto.Username))
            {
                throw new ArgumentException(nameof(participantDto), "Username cannot be null");
            }
            if(string.IsNullOrWhiteSpace(jwtOption.SecretKey))
            {
                throw new ArgumentException(nameof(jwtOption), "Security cannnot be null or empty");
            }
            var claim = new List<Claim>
            {
                new Claim(CustomClaimNames.Username, participantDto.Username)
            };
            var authSingingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOption.SecretKey));
            var token = new JwtSecurityToken(
                issuer: jwtOption.Issuer,
                audience: jwtOption.Audience,
                expires: DateTime.UtcNow.AddMinutes(jwtOption.ExpirationInMunutes),
                claims: claim,
               signingCredentials: new SigningCredentials(
                key: authSingingKey,
                algorithm: SecurityAlgorithms.HmacSha256));

            return token;
        }
        public string GenerateRefreshToken()
        {
            byte[] bytes = new byte[64];
            using var randomGenereator = RandomNumberGenerator.Create();
            randomGenereator.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}

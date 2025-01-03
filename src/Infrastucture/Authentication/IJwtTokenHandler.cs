using Core.Dtos;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastucture.Authentication
{
    public interface IJwtTokenHandler 
    {
        JwtSecurityToken GenerateAccessToken(ParticipantDto participantDto);
        string GenerateRefreshToken();
    }
}

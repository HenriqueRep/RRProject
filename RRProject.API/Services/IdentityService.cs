using Microsoft.AspNetCore.Identity;
using RRProject.API.Entities;
using RRProject.API.Interfaces;
using RRProject.API.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace RRProject.API.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UsuarioCadastroResponse> CadastroUsuario(UsuarioCadastroRequest usuarioCadastro)
        {
            var identityUser = new IdentityUser
            {
                UserName = usuarioCadastro.Usuario
            };

            var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);
            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(identityUser, false);
            }
            var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);
            if (!result.Succeeded && result.Errors.Count() > 0)
            {
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));
            }
            return usuarioCadastroResponse;
        }

        public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Usuario, usuarioLogin.Senha, false, true);
            if (result.Succeeded)
                return await GerarToken(usuarioLogin.Usuario);

            var usuarioLoginResponse = new UsuarioLoginResponse(result.Succeeded);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                }
                else
                {
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
                }
            }
            return usuarioLoginResponse;
        }
        public async Task<UsuarioLogoutResponse> Logout()
        {
            await _signInManager.SignOutAsync();
            return new UsuarioLogoutResponse(sucesso: true);
        }

        private async Task<UsuarioLoginResponse> GerarToken(string usuario)
        {
            var user = await _userManager.FindByNameAsync(usuario);
            var tokenClaims = await ObterClaims(user);

            var dataExpiracao = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: _jwtOptions.SigningCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new UsuarioLoginResponse
                (
                userid : user.Id,
                usuario : user.NormalizedUserName,
                sucesso: true,
                token: token,
                dataExpiracao: dataExpiracao
                );
        }

        private async Task<IList<Claim>> ObterClaims(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach(var role in roles)
            {
                claims.Add(new Claim("role", role));
            }
            return claims;
        }

        public async Task<List<string>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userNames = new List<string>();
            foreach (var user in users)
            {
                userNames.Add(user.UserName);
            }
            return userNames;
        }
    }
}

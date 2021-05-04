using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Models;
using Microsoft.IdentityModel.Tokens;
using Models.ModelView;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace PontoEletronicoWeb.Server.Service
{
    public static class TokenService
    {
        public static string GenerateToken(Autentifica aut)
        { 
            var key = Encoding.ASCII.GetBytes("fwergweqfklbnnjiijbhucfyt58918/*4/ogihdfg$¨&$%¨&@¨*$)(¨%*$*#");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]//Definimos o que vamos deixar disponivel para a api,
                {                                       //Será utilizado nos controlers ná Autorização 
                    new Claim(ClaimTypes.Name, aut.Empresa.ToString()),
                }),

                //Expires => Data de expiração do tolken
                Expires = DateTime.UtcNow.AddHours(2),

                //SigningCredentials => Informamnos a chave e o tipo da incriptação
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };



            //JwtSecurityTokenHandler => è o cara que gera o Token
            var tokenHandler = new JwtSecurityTokenHandler();

            //Criando o Token de acordo com a definição do token descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //Escrevendo o token => Tranformando na string
            return tokenHandler.WriteToken(token);
        }
    }
}

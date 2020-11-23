using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAppApi.Data
{
    public class AuthOptions
    {
        public const string ISSUER = "whaterverdoesnotmatter";
        public const string AUDIENCE = "https://localhost:5001";
        const string KEY = "mysupersecretkey_blabla!super";
        public const int LIFETIME = 360;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

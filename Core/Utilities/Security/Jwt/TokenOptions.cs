using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }//hedef kitle
        public string Issuer { get; set; }//yayınlayıcı
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}

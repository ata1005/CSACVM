using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Utilidades {

    public class Hasher {
        public static string GenerateHash(string pass) {
            byte[] salt = Encoding.ASCII.GetBytes("_b2gaF_");
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256/8));
            return hashed;
        }
    }
}

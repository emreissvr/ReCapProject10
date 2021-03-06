using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {

        // burası verdiğimiz password'ün hashini oluşturmaya yarıyor
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passworSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passworSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // sonradan sisteme girmek isteyen kullanıcının verdiği password'ün bizim veri kayanğımızdaki passwordhash ilgili salta göre eşleşip eşleşmediğini döndüren fonksiyontur.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }


    }
}

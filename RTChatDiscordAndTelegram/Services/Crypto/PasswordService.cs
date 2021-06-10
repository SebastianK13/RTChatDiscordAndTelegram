using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RTChatDiscordAndTelegram.Services.Crypto
{
    public class PasswordService
    {
        private byte[] Salt;
        private byte[] HashedPsswrd;
        private byte[] FinalHash = new byte[36];

        public string HashPassword(string password) 
        {
            PrepareSalt();
            PBKDF2(password);
            return SaltAndHashCombining();
        }

        private void PrepareSalt() =>
            new RNGCryptoServiceProvider().GetBytes(Salt = new byte[16]);
        private void PBKDF2(string password) =>
            HashedPsswrd = new Rfc2898DeriveBytes(password, Salt, 100000).GetBytes(20);
        private string SaltAndHashCombining()
        {
            Array.Copy(Salt, 0,FinalHash, 0, 16);
            Array.Copy(HashedPsswrd, 0, FinalHash, 16, 20);

            return Convert.ToBase64String(FinalHash);
        }
        public bool CompareHashes(string psswdHash, string password)
        {
            FinalHash = Convert.FromBase64String(psswdHash);
            Salt = new byte[16];
            Array.Copy(FinalHash, 0, Salt, 0, 16);
            HashedPsswrd = new Rfc2898DeriveBytes(password, Salt, 100000).GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (FinalHash[i + 16] != HashedPsswrd[i])
                    return false;

            return true;
        }
    }
}

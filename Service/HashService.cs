using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Sistema_Login.Service
{
    public static class HashService
    {
        public static byte[] GerarHashBytes(string senha)
        {
            using (SHA256  sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(senha));
            }
        }
    }
}
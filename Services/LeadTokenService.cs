using System.Security.Cryptography;
using System.Text;

namespace Paradise.Services
{
    public class LeadTokenService
    {
        public string GenerateToken(string email)
        {
            string data = $"{email}|{DateTime.UtcNow:O}";
            string hash = Hash(data);
            string token = ConvertToAlphanumeric(hash);
            return token;
        }

        public string Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private string ConvertToAlphanumeric(string input)
        {
            // Remove any characters that are not letters or digits
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result.Append(c);
                }
            }

            // Convert to uppercase
            string alphanumeric = result.ToString().ToUpper();

            // Optional: If you want to ensure a fixed length, you can truncate or pad the result
            // int desiredLength = 16; // Example length
            // alphanumeric = alphanumeric.PadRight(desiredLength, '0').Substring(0, desiredLength);

            return alphanumeric;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopManagementSystem
{
    public class PasswordGenerator
    {
        static List<char> chars = new List<char>();
        public string GeneratePassword()
        {
            AddChars(ref chars);
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            int length = 16;
            int j = 0;

            while (j < length)
            {
                stringBuilder.Append(chars[random.Next(0, chars.Count)]);
                j++;
            }

            return stringBuilder.ToString();
        }
        static void AddChars(ref List<char> chars)
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                chars.Add(c);
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                chars.Add(c);
            }
            for (char c = '0'; c <= '9'; c++)
            {
                chars.Add(c);
            }
            for (char c = '!'; c <= '/'; c++)
            {
                chars.Add(c);
            }
            for (char c = ':'; c <= '@'; c++)
            {
                chars.Add(c);
            }
            for (char c = '['; c <= '`'; c++)
            {
                chars.Add(c);
            }
            for (char c = '{'; c <= '~'; c++)
            {
                chars.Add(c);
            }
        }
    }
}

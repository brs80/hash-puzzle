using System;
using System.Linq;
using System.Security.Cryptography;
class Program
{
    public static void Main(String[] args)
    {

        string[] values = new string[1000];
        string key = RandomString(7, "acegikoprs"); // the first seven letters

        ulong hashCode = 0;
        while (hashCode != (ulong) 675217408078)
        {
            key = RandomString(7, "acegikoprs");
            hashCode = HashFunction(key, values);
            Console.WriteLine(hashCode);
            Console.WriteLine(key);
        }
        if(hashCode == 675217408078)
        {
            Console.WriteLine(key);
        }
    }
   

    // Defining the hash function 
    static ulong HashFunction(string s, string[] array)
    {
        ulong total = 7;
        char[] c;
        c = s.ToCharArray();

        for (int k = 0; k <= c.GetUpperBound(0); k++)
        {
                total = (total * (ulong) 37 + (ulong) IndexOf(s, c[k]));
        }
        return total;
    }

    private static int IndexOf(string s, char v)
    {
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == v)
                return i+1;
        }
        return 0; // if not found return first index
    }

    private static string RandomString(int length, string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
    {       
        var outOfRange = byte.MaxValue + 1 - (byte.MaxValue + 1) % alphabet.Length;

        return string.Concat(
            Enumerable
                .Repeat(0, int.MaxValue)
                .Select(e => RandomByte())
                .Where(randomByte => randomByte < outOfRange)
                .Take(length)
                .Select(randomByte => alphabet[randomByte % alphabet.Length])
        );
    }

    static byte RandomByte()
    {
        using (var randomizationProvider = new RNGCryptoServiceProvider())
        {
            var randomBytes = new byte[1];
            randomizationProvider.GetBytes(randomBytes);
            return randomBytes.Single();
        }   
    }

}

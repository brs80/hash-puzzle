using System;
using System.Linq;
using System.Security.Cryptography;

class Program
{
    public static void Main(String[] args)
    {
        string key = RandomString(7, "acegikoprs"); // randomly guessed string
        long hashCode = 0;

        while (hashCode != Convert.ToInt64(675217408078)) 
        {
            key = RandomString(7, "acegikoprs"); // get a random string for guessing 
            hashCode = HashFunction(key); // replicate the hashcode for this
            Console.WriteLine(hashCode);
            Console.WriteLine(key);
        }
        // we found a string that matches
        if(hashCode == Convert.ToInt64(675217408078))
        {
            Console.WriteLine(key); // print out the string that matches the hashcode
        }
    }
   

    // Defining the hash function 
    static long HashFunction(string s)
    {
        long total = 7;
        char[] c = s.ToCharArray();
        string letters = "acegikoprs";
        for (int k = 0; k <= c.GetUpperBound(0); k++)
        {
                total = (total * Convert.ToInt64(37) + Convert.ToInt64(IndexOf(letters, c[k])));
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
        return -1; // if not found return first index
    }

    private static string RandomString(int length, string alphabet = "acegikoprs")
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
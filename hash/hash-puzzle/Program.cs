using System;
using System.Linq;
class Program
{
    public static void Main(String[] args)
    {

        string[] values = new string[1000];

        string letters = "acegikoprs";
        string key = "acegiko"; // the first seven letters

        ulong hashCode = 0;
        while (hashCode != 675217408078)
        {
            hashCode = HashFunction(key, values);
            key = RandomString(7);
            Console.WriteLine(hashCode);
        }
    }
    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "acegikoprs";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    // Defining the hash function 
    static ulong HashFunction(string s, string[] array)
    {
        ulong total = 7;
        char[] c;
        c = s.ToCharArray();

        for (int k = 0; k <= c.GetUpperBound(0); k++)
        {
            total = (total * 37 + IndexOf(s, c[k]));
        }

        return total;
    }

    private static char IndexOf(string s, char v)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == v)
                return s[i];
        }
        return s[s.Length]; // if not found return last index 
    }
}
using System;
using System.Linq;
class Program
{
    public static void Main(String[] args)
    {

        string[] values = new string[1000];
        string key = RandomString(7); // the first seven letters

        ulong hashCode = 0;
        while (hashCode != 675217408078)
        {
            key = RandomString(7);
            hashCode = HashFunction(key, values);
            Console.WriteLine(hashCode);
        }
        if(hashCode == 675217408078)
        {
            Console.WriteLine(key);
        }
    }
    private static Random random = new Random(DateTime.Now.Millisecond);
    public static string RandomString(int length)
    {
        const string chars = "acegikoprs";
        random = new Random(DateTime.Now.Millisecond);
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
}
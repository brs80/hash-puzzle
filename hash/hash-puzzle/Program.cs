using System;

class Program
{
    public static void Main(String[] args)
    {

        string[] values = new string[1000];

        string letters = "acegikoprs";
        string key = "acegiko"; // the first seven letters

        long hashCode = 0;
        while (hashCode != 675217408078)
        {
            hashCode = HashFunction(key, values);
            
            Console.WriteLine(hashCode);
        }

    }

    // Defining the hash function 
    static long HashFunction(string s, string[] array)
    {
        int total = 12;
        char[] c;
        c = s.ToCharArray();

        for (int k = 0; k <= c.GetUpperBound(0); k++)
        {
            total = (total * 37) + IndexOf(s, c[k]);
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
        return s[1]; // if not found return last index 
    }
}
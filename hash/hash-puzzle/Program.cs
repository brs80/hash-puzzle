using System;

class Program
{
    public static void Main(String[] args)
    {


        string[] values = new string[1000];

        string key = "acegikoprs";

        int hashCode;

        hashCode = HashFunction(key, values);

        Console.WriteLine(hashCode);

    }

    // Defining the hash function 
    static int HashFunction(string s, string[] array)
    {
        int total = 7;
        char[] c;
        c = s.ToCharArray();

        for (int k = 0; k <= c.GetUpperBound(0); k++)
        {
            total = (total * 37) + IndexOf(s, c[k]);
        }

        return total;
    }

    private static int IndexOf(string s, char v)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == v)
                return i;
        }
        return 999; // if not found return last index 
    }
}
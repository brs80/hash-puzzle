# hash-puzzle
Should be noted this program doesn't hold real usage.
It was a best shot at trying to solve: 

      Find a 7 letter string of characters that contains only letters from

      acegikoprs

      such that the gen_hash(the_string) is

      675217408078

      if hash is defined by the following pseudo-code:


      Int64 gen_hash (String s) {
          Int64 h = 7
          String letters = "acegikoprs"
          for(Int32 i = 0; i < s.length; i++) {
              h = (h * 37 + letters.indexOf(s[i]))
          }
          return h
      }


# why it doesn't work
Many strings can hash to the same hashcode.
Also there are 4,782,969 (9^7) possible strings with the given set. 
using the performance equation it would **roughly** take
                        

             Seconds per program = (instructions per string * possible strings) 
                                   (~100 * 4782969) * 1  * (1/3600000)
            

So it will take well over a few minutes to run
The answer could also be wrong causing the loop to exit with the first matching string

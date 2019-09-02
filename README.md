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
                        

        Seconds per program = (instructions * possible strings)  *  cycles per instruction          cycles per second (Hz)
                              (~100         * 4782969)           *  2?                         *    ~(1/3600000)
            
          
The output could also not be the correct string

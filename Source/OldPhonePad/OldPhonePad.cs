using System;
using System.Text;

namespace IronSoftware.CodingChallenge
{
    public static class OldPhonePadSolver
    {
        
        public static string OldPhonePad(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var output = new StringBuilder();
            char current = '\0';
            int count = 0;

            foreach (char c in input)
            {
                if (c == '#')
                    break;

                if (c == ' ')
                {
                    // Commit current sequence on space
                    AddChar(output, current, count);
                    current = '\0';
                    count = 0;
                }
                else if (c == '*')
                {
                    // Commit any pending key before backspacing
                    AddChar(output, current, count);
                    current = '\0';
                    count = 0;

                    // Now delete last character from output
                    if (output.Length > 0)
                        output.Length--;
                }
                else if (c >= '2' && c <= '9')
                {
                    if (c == current)
                    {
                        count++;
                    }
                    else
                    {
                        // Commit previous key sequence
                        AddChar(output, current, count);
                        current = c;
                        count = 1;
                    }
                }
                // Ignore unsupported characters (e.g., '0', '1')
            }

            // Commit any final pending sequence
            AddChar(output, current, count);
            return output.ToString();
        }

        
        static void AddChar(StringBuilder sb, char key, int presses)
        {
            if (key == '\0' || presses == 0) return;

            string letters = key switch
            {
                '2' => "ABC",
                '3' => "DEF",
                '4' => "GHI",
                '5' => "JKL",
                '6' => "MNO",
                '7' => "PQRS",
                '8' => "TUV",
                '9' => "WXYZ",
                _ => ""
            };

            if (!string.IsNullOrEmpty(letters))
            {
                sb.Append(letters[(presses - 1) % letters.Length]);
            }
        }
    }
}
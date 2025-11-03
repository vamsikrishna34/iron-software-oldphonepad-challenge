using System.Text;

public class OldPhonePad
{
    // Converts old phone keypresses like "4433555 555666#" into "HELLO"
    public static string OldPhonePad(string input)
    {
        if (input == null) return ""; // simple null guard

        var output = new StringBuilder();
        char current = '\0';
        int count = 0;

        foreach (char c in input)
        {
            if (c == '#')
                break; // stop immediately

            if (c == ' ')
            {
                // space ends the current key sequence
                AddChar(output, current, count);
                current = '\0';
                count = 0;
            }
            else if (c == '*')
            {
                // backspace: remove last char
                if (output.Length > 0)
                    output.Length--;
                current = '\0';
                count = 0;
            }
            else if (c >= '2' && c <= '9')
            {
                if (c == current)
                {
                    count++;
                }
                else
                {
                    // finish previous key
                    AddChar(output, current, count);
                    current = c;
                    count = 1;
                }
            }
        }

        // handle last sequence
        AddChar(output, current, count);
        return output.ToString();
    }

    // helper: turn key + press count into letter
    static void AddChar(StringBuilder sb, char key, int presses)
    {
        if (key == '\0' || presses == 0) return;

        string letters = "";
        switch (key)
        {
            case '2': letters = "ABC"; break;
            case '3': letters = "DEF"; break;
            case '4': letters = "GHI"; break;
            case '5': letters = "JKL"; break;
            case '6': letters = "MNO"; break;
            case '7': letters = "PQRS"; break;
            case '8': letters = "TUV"; break;
            case '9': letters = "WXYZ"; break;
        }

        if (letters != "")
        {
            // cycle with modulo (e.g. 4 presses on '2' → 'A')
            sb.Append(letters[(presses - 1) % letters.Length]);
        }
    }
}
using System.Text;

namespace Api;
public static class TextProcessor
{
    public static string GenerateText(int length)
    {
        var random = new Random();
        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        var word = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            var letter = random.Next(alphabet.Length);
            word.Append(alphabet[letter]);
        }

        word.Append('\n');

        return word.ToString();
    }
}
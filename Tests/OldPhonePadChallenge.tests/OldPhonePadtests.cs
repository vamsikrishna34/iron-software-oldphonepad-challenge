using Xunit;
using IronSoftware.CodingChallenge;

public class OldPhonePadTests
{
    [Theory]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TURING")] // Correct output
    public void ReturnsCorrectOutput(string input, string expected)
    {
        var result = OldPhonePadSolver.OldPhonePad(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ThrowsOnNullInput()
    {
        Assert.Throws<ArgumentNullException>(() => OldPhonePadSolver.OldPhonePad(null));
    }
}
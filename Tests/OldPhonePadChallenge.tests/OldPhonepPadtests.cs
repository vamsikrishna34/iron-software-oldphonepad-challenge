using Xunit;

public class OldPhonePadTests
{
    [Theory]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TVRING")]
    public void TestOldPhonePad(string input, string expected)
    {
        Assert.Equal(expected, OldPhonePad.OldPhonePad(input));
    }

    [Fact]
    public void HandlesNull()
    {
        Assert.Equal("", OldPhonePad.OldPhonePad(null));
        // OR: Assert.Throws<...> if you throw
    }
}
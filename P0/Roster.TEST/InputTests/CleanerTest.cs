using Roster.APP.Inputs;
namespace Roster.TEST.InputTests;

public class CleanerTests
{
    [Theory]
    [InlineData("string", "String")]
    [InlineData("sTrIng", "String")]
    [InlineData("String", "String")]
    [InlineData("STRING", "String")]
    [InlineData("STRING  ", "String")]
    [InlineData("  STRING", "String")]
    [InlineData(" STRING ", "String")]
    public void TestToMakeSureStringReturnsTrimmedAndCapitalFirstLetter(string str, string expected)
    {
        string actual = Cleaner.Clean(str);
        Assert.Equal(expected, actual);
    }
}

public class InputValidationTests
{
    
}
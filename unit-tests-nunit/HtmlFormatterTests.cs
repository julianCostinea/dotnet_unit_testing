namespace unit_tests_nunit;

[TestFixture]
public class HtmlFormatterTests
{
    [Test]
    public void FormatAsBold_WhenCalled_ReturnsStringEnclosedWithStrongElementTags()
    {
        var formatter = new unit_tests_web_api.Fundamentals.HtmlFormatter();
        
        var result = formatter.FormatAsBold("abc");
        
        // Specific
        Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);
        
        // More General
        Assert.That(result, Does.StartWith("<strong>"));
        Assert.That(result, Does.EndWith("</strong>"));
        Assert.That(result, Does.Contain("abc"));
    }
}
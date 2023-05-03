using unit_tests_web_api.Fundamentals;

namespace unit_tests_nunit;

[TestFixture]
public class DemeritPointsCalculatorTests
{
    private DemeritPointsCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new DemeritPointsCalculator();
    }

    [Test]
    [TestCase(-1)]
    [TestCase(301)]
    public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int speed)
    {
        Assert.That(() => _calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(64, 0)]
    [TestCase(65, 0)]
    [TestCase(66, 0)]
    [TestCase(70, 1)]
    [TestCase(75, 2)]
    public void CalculateDemeritPoints_WhenCalled_ReturnsDemeritPoints(int speed, int expectedResult)
    {
        var result = _calculator.CalculateDemeritPoints(speed);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
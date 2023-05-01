namespace unit_tests_nunit;

[TestFixture]
public class CustomerControllerTests
{
    [Test]
    public void GetCustomer_IdIsZero_ReturnsNotFound()
    {
        var controller = new CustomerController();
        
        var result = controller.GetCustomer(0);
        
        //Not found
        Assert.That(result, Is.TypeOf<NotFound>());
        
        //Not found or one of its derivatives
        // Assert.That(result, Is.InstanceOf<NotFound>());
    }
}
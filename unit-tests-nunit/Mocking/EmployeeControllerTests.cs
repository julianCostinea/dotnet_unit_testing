using Moq;
using unit_tests_web_api.Mocking;

namespace unit_tests_nunit.Mocking;

[TestFixture]
public class EmployeeControllerTests
{
    [Test]
    public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
    {
        var storage = new Mock<IEmployeeStorage>();
        var controller = new EmployeeController(storage.Object);

        controller.DeleteEmployee(1);

        storage.Verify(s => s.DeleteEmployee(1));
    }
}
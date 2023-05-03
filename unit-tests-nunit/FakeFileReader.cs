using unit_tests_web_api.Mocking;

namespace unit_tests_nunit;

public class FakeFileReader : IFileReader
{
    public string Read(string path)
    {
        return "";
    }
}
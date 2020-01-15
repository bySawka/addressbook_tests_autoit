using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class TestBase
    {
        public ApplicationManager app;

        [OneTimeSetUpAttribute]
        public void InitApplication()
        {
            app = new ApplicationManager();
        }

        [OneTimeTearDownAttribute]
        public void stopApplication()
        {
            app.Stop();
        }

    }
}

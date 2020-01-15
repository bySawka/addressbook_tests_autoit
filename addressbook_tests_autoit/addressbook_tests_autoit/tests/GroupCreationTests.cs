using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
  
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            app.Groups.Add(newGroup);
     
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);

            oldGroups.Sort();
            newGroups.Sort();

            System.Console.Out.WriteLine("oldGroups");
            foreach (var t in oldGroups)
            {
                System.Console.Out.WriteLine(t.Name);
            }
            System.Console.Out.WriteLine("newGroups");

            foreach (var t in newGroups)
            {
                System.Console.Out.WriteLine(t.Name);
            }
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}

﻿using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
  
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.AddGroupIfNotExist();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
          
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
        
            Assert.AreEqual(oldGroups, newGroups);
            
        }
    }
}

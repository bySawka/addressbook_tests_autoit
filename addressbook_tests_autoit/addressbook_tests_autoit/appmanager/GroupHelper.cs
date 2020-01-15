using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {

        public static string GROUPWINTITLE ="Group editor";
        public static string GROUPWINDELETETITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void AddGroupIfNotExist()
        {
            if (GetGroupsCount() == 1)
            {
                this.Add(new GroupData()
                {
                    Name = "AddGroupIfNotExist"
                });
            }
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            int count = GetGroupsCount();
            for (int i = 0; i < count; i++)
            {

                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                                                                 "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                { Name = item });
            }

            CloseGroupsDialog();
            return list;
        }

        public int GetGroupsCount()
        {
            OpenGroupsDialog();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                                                 "GetItemCount", "#0", "");
            return int.Parse(count);
        }

        public void Remove(int index)
        {
            OpenGroupsDialog();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51","Select", 
                                    "#0|#"+ (index), "");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(GROUPWINDELETETITLE);
            aux.ControlClick(GROUPWINDELETETITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlClick(GROUPWINDELETETITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            //    CloseGroupsDialog();
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialog();
        }

        public void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupsDialog()
        {
            if (aux.WinActive(GROUPWINTITLE) == 0)
            {
                aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
                aux.WinWait(GROUPWINTITLE);
            }
        }
    }
}
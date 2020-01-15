using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private AutoItX3 aux;

        public static string WINTITLE = "Free Address Book";

        private GroupHelper groupHelper;

        public GroupHelper Groups { get => groupHelper; }
        public AutoItX3 Aux { get => aux; }

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"F:\САНЬКА\Курсы\AdressBook\AddressBook.exe","", aux.SW_SHOW);
            WinWaitActivate();

            groupHelper = new GroupHelper(this);
        }

        private void WinWaitActivate()
        {
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EQFriends
{
    [Serializable]
    public class EQFriendsDataSet
    {
        protected string eqFolder = String.Empty;
        public string EQFolder
        {
            get { return eqFolder; }
            set { eqFolder = value; }
        }

        protected string eqServer = String.Empty;
        public string EQServer
        {
            get { return eqServer; }
            set { eqServer = value; }
        }

        protected bool doBackup = true;
        public bool DoBackup
        {
            get { return doBackup; }
            set { doBackup = value; }
        }

        protected int selectedTabIndex = 0;
        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set { selectedTabIndex = value; }
        }
    }
}

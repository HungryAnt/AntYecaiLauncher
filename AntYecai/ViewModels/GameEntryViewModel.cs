using System;
using System.Diagnostics;
using AntYecai.Foundation;

namespace AntYecai.ViewModels
{
    public class GameEntryViewModel : NotificationObject
    {
        private String _loginName;

        public String LoginName
        {
            get { return _loginName; }
            set
            {
                _loginName = value;
                RaisePropertyChanged("LoginName");
            }
        }

        public String UserId { get; set; }

        public void Enter()
        {
            // Directory.SetCurrentDirectory("D:\\dev\\ruby\\ruby-game\\output0-7-1");
            Process.Start(String.Format("yecaigame_0_7_1_beta.exe {0}", UserId));
        }
    }
}

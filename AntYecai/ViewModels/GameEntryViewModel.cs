using System;
using System.Diagnostics;
using System.IO;
using AntYecai.Foundation;
using AntYecai.Tools;

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

        public String ScreenMode { get; set; }

        public void Enter()
        {
            if (!File.Exists(GameConfig.RubyGameFileName))
            {
                MessageBoxUtil.ShowError(String.Format("未找到游戏文件:{0}", GameConfig.RubyGameFileName));
                return;
            }
            Process.Start(String.Format("{0} {1} {2}", GameConfig.RubyGameFileName, UserId, ScreenMode));
        }
    }
}

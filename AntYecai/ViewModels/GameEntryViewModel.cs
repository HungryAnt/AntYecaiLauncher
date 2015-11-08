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

        private Process _processRubyGame;

        public void Enter()
        {
            if (!IsRubyGameExit())
            {
                MessageBoxUtil.ShowError("游戏已经启动！");
                return;
            }

            if (!File.Exists(GameConfig.RubyGameFileName))
            {
                MessageBoxUtil.ShowError(String.Format("未找到游戏文件:{0}", GameConfig.RubyGameFileName));
                return;
            }
//            Directory.SetCurrentDirectory("D:\\\\dev\\ruby\\ruby-game\\output0-8-0");
            _processRubyGame = Process.Start(GameConfig.RubyGameFileName, String.Join(" ", UserId, ScreenMode));
        }

        public bool IsRubyGameExit()
        {
            if (_processRubyGame == null)
            {
                return true;
            }
            return _processRubyGame.HasExited;
        }
    }
}

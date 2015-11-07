using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using AntYecai.Foundation;
using AntYecai.Models;

namespace AntYecai.ViewModels
{
    public class FriendlyLinkPanelViewModel : NotificationObject
    {
        public FriendlyLinkPanelViewModel()
        {
            InitFriendlyLinks();
        }

        private void InitFriendlyLinks()
        {
            FriendlyLinks.Add(new FriendlyLink()
                {
                    Header = "论坛",
                    ImagePath = "/AntYecai;component/Images/yecai.jpg",
                    Url = GameConfig.ForumUrl
                });
            FriendlyLinks.Add(new FriendlyLink()
                {
                    Header = "新闻动态",
                    ImagePath = "/AntYecai;component/Images/yecai.jpg",
                    Url = GameConfig.News
                });
            FriendlyLinks.Add(new FriendlyLink()
                {
                    Header = "QQ群",
                    ImagePath = "/AntYecai;component/Images/qq.jpg",
                    Url = GameConfig.QQqunUrl
                });
            FriendlyLinks.Add(new FriendlyLink()
                {
                    Header = "空雅百货店",
                    ImagePath = "/AntYecai;component/Images/shop.png",
                    Url = GameConfig.ShopUrl
                });
//            FriendlyLinks.Add(new FriendlyLink()
//                {
//                    Header = "纯卖萌",
//                    ImagePath = "/AntYecai;component/Images/meng.jpg",
//                    Url = GameConfig.ForumUrl
//                });
//            FriendlyLinks.Add(new FriendlyLink()
//                {
//                    Header = "纯卖萌",
//                    ImagePath = "/AntYecai;component/Images/meng2.jpg",
//                    Url = GameConfig.ForumUrl
//                });
            FriendlyLinks.Add(new FriendlyLink()
                {
                    Header = "火拼俄罗斯",
                    ImagePath = "/AntYecai;component/Images/tetris.png",
                    Url = GameConfig.TetrisGameUrl
                });
        }

        private ObservableCollection<FriendlyLink> _friendlyLinks = new ObservableCollection<FriendlyLink>();

        public ObservableCollection<FriendlyLink> FriendlyLinks
        {
            get { return _friendlyLinks; }
            set
            {
                _friendlyLinks = value;
                RaisePropertyChanged("FriendlyLinks");
            }
        }
        
    }
}

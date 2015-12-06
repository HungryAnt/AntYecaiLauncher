using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntYecai.Foundation;
using AntYecai.Models;

namespace AntYecai.ViewModels
{
    public class RankingListViewModel : NotificationObject
    {
        private String _rankType;

        public String RankType
        {
            get { return _rankType; }
            set
            {
                _rankType = value;
                RaisePropertyChanged("RankType");
            }
        }

        private List<RankInfo> _rankInfos;

        public List<RankInfo> RankInfos
        {
            get { return _rankInfos; }
            set
            {
                _rankInfos = value;
                RaisePropertyChanged("RankInfos");
            }
        }

    }
}

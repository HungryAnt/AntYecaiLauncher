using System;

namespace AntYecai
{
    public static class GameConfig
    {
        public const String RubyGameFileName = "yecaigame_0_8_0_beta.exe";

        public const String ApiServerEndpoint = "http://180.76.156.183:8001";
        // public const String ApiServerEndpoint = "http://localhost:8001";

        public const String Version = "Ant野菜部落启动器-v0.2";
        public const String HomePageUrl = "http://www.yecaibuluo.com/";
        public const String ForumUrl = "http://www.yecaibuluo.com/bbs/forum.php";
        public const String News = "http://www.yecaibuluo.com/bbs/forum.php?mod=forumdisplay&fid=2";
        public const String QQqunUrl = "http://www.yecaibuluo.com/bbs/forum.php?mod=viewthread&tid=74";

        public const String ShopUrl = ApiServerEndpoint + "/link/shop";
        public const String TetrisGameUrl = ApiServerEndpoint + "/link/tetris";
        public const String Hao123Url = ApiServerEndpoint + "/link/hao123";
        public const String ActualHao123Url = @"http://www.hao123.com/?tn=92775474_hao_pg";
    }
}

using System;

namespace AntYecai
{
    public static class GameConfig
    {
        public const String ApiServerEndpoint = "http://localhost:8001";

        public const String Version = "game center版本-v0.1";
        public const String HomePageUrl = "http://www.yecaibuluo.com/";
        public const String ForumUrl = "http://www.yecaibuluo.com/bbs/forum.php";
        public const String News = "http://www.yecaibuluo.com/bbs/forum.php?mod=forumdisplay&fid=2";
        public const String QQqunUrl = "http://www.yecaibuluo.com/bbs/forum.php?mod=viewthread&tid=74";

        public const String ShopUrl = ApiServerEndpoint + "/link/shop";
        public const String TetrisGameUrl = ApiServerEndpoint + "/link/tetris";
    }
}

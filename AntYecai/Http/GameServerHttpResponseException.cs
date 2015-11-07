using System;

namespace AntYecai.Http
{
    public class GameServerHttpResponseException : ApplicationException
    {
        public GameServerErrorInfo GameServerErrorInfo { get; private set; }

        public GameServerHttpResponseException(GameServerErrorInfo gameServerErrorInfo)
            : base(gameServerErrorInfo.Message)
        {
            GameServerErrorInfo = gameServerErrorInfo;
        }
    }
}

using System;

namespace NiumaCore.Auth
{
    /// <summary>
    /// 登录结果。
    /// </summary>
    [Serializable]
    public readonly struct LoginResult
    {
        public readonly bool Succeeded;
        public readonly AuthToken Token;
        public readonly string Message;

        public LoginResult(bool succeeded, AuthToken token, string message)
        {
            Succeeded = succeeded;
            Token = token;
            Message = message;
        }

        public static LoginResult Success(AuthToken token)
        {
            return new LoginResult(true, token, null);
        }

        public static LoginResult Fail(string message)
        {
            return new LoginResult(false, null, message);
        }
    }
}


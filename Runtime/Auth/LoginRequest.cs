using System;

namespace NiumaCore.Auth
{
    /// <summary>
    /// 登录请求。
    /// Password 字段只用于提交给认证服务，不应被本地持久化。
    /// </summary>
    [Serializable]
    public sealed class LoginRequest
    {
        public string Account;

        /// <summary>
        /// 明文密码只允许用于本次登录请求，不参与 Unity 序列化，避免 JsonUtility.ToJson 误打到日志。
        /// </summary>
        [NonSerialized]
        public string Password;

        public string DeviceId;

        public LoginRequest(string account, string password, string deviceId = null)
        {
            Account = account;
            Password = password;
            DeviceId = deviceId;
        }
    }
}

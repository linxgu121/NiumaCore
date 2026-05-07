using System;

namespace NiumaCore.Auth
{
    /// <summary>
    /// 登录令牌。
    /// 客户端只保存 Token，不保存密码或服务器密钥。
    /// </summary>
    [Serializable]
    public sealed class AuthToken
    {
        /// <summary>
        /// 后端返回的玩家账号唯一标识。
        /// </summary>
        public string UserId;

        /// <summary>
        /// 玩家展示名，不作为登录凭证使用。
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// 访问令牌，用于调用需要登录态的接口。
        /// </summary>
        public string AccessToken;

        /// <summary>
        /// 刷新令牌，用于访问令牌过期后的续期。
        /// </summary>
        public string RefreshToken;

        /// <summary>
        /// 访问令牌过期时间，使用 UTC Unix 秒级时间戳，避免序列化 DateTime。
        /// </summary>
        public long ExpireAtUnixSeconds;

        /// <summary>
        /// 运行期便捷访问属性，不参与 Unity 字段序列化。
        /// </summary>
        public DateTime ExpireAtUtc => DateTimeOffset.FromUnixTimeSeconds(ExpireAtUnixSeconds).UtcDateTime;

        /// <summary>
        /// 当前访问令牌是否存在且未过期。
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(AccessToken) && DateTimeOffset.UtcNow.ToUnixTimeSeconds() < ExpireAtUnixSeconds;
    }
}

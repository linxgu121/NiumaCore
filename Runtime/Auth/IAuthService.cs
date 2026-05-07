using System;
using System.Threading;
using System.Threading.Tasks;

namespace NiumaCore.Auth
{
    /// <summary>
    /// 认证服务接口。
    /// 负责登录、登出、刷新 Token 和查询当前登录状态。
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 认证状态变化事件。
        /// UI、云存档协调器和网络鉴权层可以监听该事件更新表现或刷新依赖状态。
        /// </summary>
        event Action<AuthState> StateChanged;

        /// <summary>
        /// 当前认证状态。
        /// </summary>
        AuthState State { get; }

        /// <summary>
        /// 当前登录令牌，未登录或登录失败时可以为空。
        /// </summary>
        AuthToken CurrentToken { get; }

        /// <summary>
        /// 使用账号密码或设备信息发起登录。
        /// </summary>
        Task<LoginResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 使用刷新令牌续期登录状态。
        /// </summary>
        Task<LoginResult> RefreshTokenAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 清除本地登录态并通知状态变化。
        /// </summary>
        void Logout();
    }
}

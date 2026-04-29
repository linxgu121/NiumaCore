using NiumaCore.Config;
using NiumaCore.Event;
using NiumaCore.Input;
using NiumaCore.Save;

namespace NiumaCore.Module
{
    /// <summary>
    /// 定义游戏上下文类，用于在模块之间传递和共享游戏状态和信息
    /// 游戏上下文包含了游戏的核心服务和资源，例如事件总线、配置服务、保存服务、输入阻止器等，模块可以通过游戏上下文访问这些服务和资源，以便在游戏逻辑中进行相应的处理和决策
    /// 游戏上下文还可以包含其他模块需要共享的状态和信息，例如当前的游戏阶段、当前的关卡信息、当前的角色状态等
    /// 以便模块可以根据这些状态和信息进行相应的处理和决策，例如在角色模块中根据当前的角色状态进行相应的处理，在关卡模块中根据当前的关卡信息进行相应的处理等
    /// </summary>
    public sealed class GameContext
    {
        /// <summary>
        /// 事件总线
        /// </summary>
        public IEventBus EventBus { get; }
        /// <summary>
        /// 配置服务
        /// </summary>
        public IConfigService ConfigService { get; }
        /// <summary>
        /// 保存服务
        /// </summary>
        public ISaveService SaveService { get; }
        /// <summary>
        /// 输入阻止器，用于在特定情况下阻止玩家的输入，例如在对话框打开时阻止玩家的移动输入，在战斗中阻止玩家的技能输入等，以确保游戏逻辑的正确性和玩家体验的一致性
        /// </summary>
        public IGameplayInputBlocker GameplayInputBlocker { get; }

        /// <summary>
        /// 构造函数，接受游戏上下文所需的核心服务和资源作为参数，并将它们赋值给相应的属性，以便模块可以通过游戏上下文访问这些服务和资源
        /// </summary>
        public GameContext(
            IEventBus eventBus,
            IConfigService configService = null,
            ISaveService saveService = null,
            IGameplayInputBlocker gameplayInputBlocker = null)
        {
            EventBus = eventBus;
            ConfigService = configService;
            SaveService = saveService;
            GameplayInputBlocker = gameplayInputBlocker;
        }
    }
}

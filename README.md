# NiumaCore

## 模块定位
NiumaCore 是整个项目的公共协议层，负责沉淀跨模块共享的接口、DTO、事件总线、GameContext、存档/网络/认证等基础契约。它不直接实现具体玩法，不依赖场景对象，也不应该反向引用任何业务模块。

## 框架设计思路
- Core 只定义协议，不承载具体业务实现。
- 业务模块通过接口注册到 GameContext，调用方优先依赖接口而不是具体 MonoBehaviour。
- 事件总线保留 Immediate / Deferred 信道语义，持续状态优先走数据快照，瞬时表现再走事件。
- Save/Auth/Cloud 等能力以可插拔接口预留，避免早期实现绑定死本地文件或具体服务器。

## 核心流程
1. 全局 Bootstrap 创建 GameContext。
2. 各模块 Controller 初始化自身 Service。
3. Controller 将 Query / Command / Service 注册到 GameContext。
4. 模块之间通过接口、快照、请求对象协作。
5. 存档、网络、UI 等横切能力只读取稳定协议，不直接读取内部运行时对象。

## 模块用法
- 新模块需要公共接口时，优先放在本模块或自身模块内；只有跨多个模块稳定复用的协议才上移到 NiumaCore。
- 不要在 Core 中引用 Unity 场景对象、具体业务模块或表现层对象。
- 注册服务时保持接口粒度清晰：Query 给 UI/条件查询，Command 给业务命令，Service 给根控制器和存档。

## 场景使用方法
推荐放置方式：`Bootstrap/GameRoot` 一个全局物体承载项目启动脚本和 GameContext。

- `GameRoot`：挂项目自己的模块启动器或 Bootstrap 脚本，负责创建 GameContext，并按顺序初始化各 Niuma 模块。
- `GameRoot/Systems`：建议把各模块根物体作为子物体，例如 `SceneRoot`、`SaveRoot`、`UIRoot`、`AudioRoot`，便于查找和折叠管理。
- Core 本身通常不需要挂 MonoBehaviour；它提供接口、DTO、事件总线和 GameContext。
- 业务脚本需要跨模块能力时，从 GameContext 取接口，例如 `IInventoryService`、`IQuestService`、`ISceneService`，不要直接 Find 其他模块内部组件。
- 单模块测试场景可以临时手动绑定引用；正式场景建议统一由 Bootstrap 注入，避免场景切换后引用丢失。

## 协作边界
Core 是底座，不是工具箱垃圾桶。任何上移到 Core 的类型都应具备长期稳定性，字段名一旦进入存档或网络协议，不应随意重命名。



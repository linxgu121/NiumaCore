using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NiumaCore.Save
{
    /// <summary>
    /// 本地存档服务。
    /// 本地存档是基础能力，云同步失败不应影响本地保存。
    /// </summary>
    public interface ILocalSaveService
    {
        /// <summary>
        /// 查询指定存档槽是否存在。
        /// </summary>
        Task<bool> ExistsAsync(string slotId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 保存载荷到本地。
        /// 存档槽 ID 以 payload.Metadata.SlotId 为准，避免参数与元数据不一致。
        /// </summary>
        Task SaveAsync(SavePayload payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// 从本地读取指定存档槽。
        /// </summary>
        Task<SaveLoadResult> LoadAsync(string slotId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除指定本地存档槽。
        /// </summary>
        Task<bool> DeleteAsync(string slotId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取本地存档槽列表。
        /// </summary>
        Task<IReadOnlyList<SaveSlotMetadata>> ListSlotsAsync(CancellationToken cancellationToken = default);
    }
}

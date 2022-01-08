using System;
using System.Threading.Tasks;

namespace DefaultNamespace
{
    public interface ILoadingOperation
    {
        string Description { get; }
        Task Load(Action<float> onProgress);
    }
}
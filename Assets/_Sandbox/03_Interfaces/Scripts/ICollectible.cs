using UnityEngine;

namespace Sandbox.Task03
{
    public interface ICollectible
    {
        bool IsCollected { get; }

        void Collect();
    }
}

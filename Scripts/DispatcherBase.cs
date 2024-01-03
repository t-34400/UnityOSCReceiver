#nullable enable

using UnityEngine;
using OSCPacket;

namespace OSCReceiver
{
    public interface IDispatcher
    {
        public void Dispatch(Packet packet);
    }

    public abstract class DispatcherBase : MonoBehaviour, IDispatcher
    {
        public abstract void Dispatch(Packet packet);
    }
}
#nullable enable

using UnityEngine;
using OSCPacket;

namespace OSCReceiver
{
    public class LogDispatcher : DispatcherBase
    {
        public override void Dispatch(Packet packet)
        {
            Debug.Log($"Received: {packet}");
        }
    }
}
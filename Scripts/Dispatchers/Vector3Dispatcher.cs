#nullable enable

using UnityEngine;
using UnityEngine.Events;
using OSCPacket;

namespace OSCReceiver
{
    public class Vector3Dispatcher : DispatcherBase
    {
        [SerializeField] private string address = "";
        [SerializeField] private UnityEvent<Vector3> handler = default!;

        public override void Dispatch(Packet packet)
        {
            var packetAddress = packet.address;
            if (packet.arguments.Length >= 3
                && packetAddress.Equals(address)
                && packet.arguments[0].value is float X
                && packet.arguments[0].value is float y
                && packet.arguments[0].value is float z)
            {
                handler.Invoke(new (X, y, z));
            }
        }
    }
}
#nullable enable

using UnityEngine;
using UnityEngine.Events;
using OSCPacket;

namespace OSCReceiver
{
    public class EulerAnglesDispatcher : DispatcherBase
    {
        [SerializeField] private string address = "";
        [SerializeField] private UnityEvent<Quaternion> handler = default!;

        public override void Dispatch(Packet packet)
        {
            var packetAddress = packet.address;
            if (packet.arguments.Length >= 3
                && packetAddress.Equals(address)
                && packet.arguments[0].value is float x
                && packet.arguments[1].value is float y
                && packet.arguments[2].value is float z)
            {
                handler.Invoke(Quaternion.Euler(x, y, z));
            }
        }
    }
}
#nullable enable

using UnityEngine;
using UnityEngine.Events;
using OSCPacket;

namespace OSCReceiver
{
    public class FloatDispatcher : DispatcherBase
    {
        [SerializeField] private string address = "";
        [SerializeField] private UnityEvent<float> handler = default!;

        public override void Dispatch(Packet packet)
        {
            var packetAddress = packet.address;
            if (packet.arguments.Length > 0
                && packetAddress.Equals(address)
                && packet.arguments[0].value is float value)
            {
                handler.Invoke(value);
            }
        }
    }
}
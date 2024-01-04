#nullable enable

using UnityEngine;
using UnityEngine.Events;
using OSCPacket;

namespace OSCReceiver
{
    public class QuaternionDispatcher : DispatcherBase
    {
        [SerializeField] private string address = "";
        [SerializeField] private Order order = Order.XYZW;
        [SerializeField] private UnityEvent<Quaternion> handler = default!;

        public override void Dispatch(Packet packet)
        {
            var packetAddress = packet.address;
            if (packet.arguments.Length >= 4
                && packetAddress.Equals(address)
                && packet.arguments[0].value is float x_0
                && packet.arguments[1].value is float x_1
                && packet.arguments[2].value is float x_2
                && packet.arguments[3].value is float x_3)
            {
                switch (order)
                {
                    case Order.XYZW:
                        {
                            handler.Invoke(new(x_0, x_1, x_2, x_3));
                            break;
                        }
                    case Order.WXYZ:
                        {
                            handler.Invoke(new(x_1, x_2, x_3, x_0));
                            break;
                        }
                }
            }
        }

        private enum Order
        {
            XYZW,
            WXYZ
        }
    }
}
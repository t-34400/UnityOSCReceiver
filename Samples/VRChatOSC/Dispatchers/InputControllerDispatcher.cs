#nullable enable

using System.Linq;
using UnityEngine;
using OSCPacket;

namespace OSCReceiver.VRChatOSC
{
    public class InputControllerDispatcher : DispatcherBase
    {
        private const string INPUT_ADDRESS_PREFIX = "/input/";

        [SerializeField] private InputAxisControllerEvent inputAxisControllerEvent = default!;
        [SerializeField] private InputButtonControllerEvent inputButtonControllerEvent = default!;

        public override void Dispatch(Packet packet)
        {
            var address = packet.address;
            if(packet.arguments.Length > 0 && address.StartsWith(INPUT_ADDRESS_PREFIX))
            {
                var command = address.Substring(INPUT_ADDRESS_PREFIX.Length);
                
                var argument = packet.arguments.FirstOrDefault();
                if(argument.value is int intValue)
                {
                    var isOn = intValue == 1;
                    inputButtonControllerEvent.InvokeInputButtonEvent(command, isOn);
                }
                else if(argument.value is float floatValue)
                {
                    inputAxisControllerEvent.InvokeInputAxisEvent(command, floatValue);
                }
            }
        }
    }
}
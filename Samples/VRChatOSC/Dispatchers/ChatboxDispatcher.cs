#nullable enable

using System.Linq;
using UnityEngine;
using OSCPacket;

namespace OSCReceiver.VRChatOSC
{
    public class ChatboxDispatcher : DispatcherBase
    {
        private const string CHATBOX_INPUT_ADDRESS = "/chatbox/input";
        private const string CHATBOX_TYPING_ADDRESS = "/chatbox/typing";

        [SerializeField] private ChatboxEvent chatboxEvent = default!;

        public override void Dispatch(Packet packet)
        {
            var address = packet.address;
            if (packet.arguments.Length >= 3
                && address.Equals(CHATBOX_INPUT_ADDRESS)
                && packet.arguments[0].value is string input
                && packet.arguments[1].value is bool sendImmediately
                && packet.arguments[2].value is bool showNotification)
            {
                chatboxEvent.InvokeInputChatboxEvent(input, sendImmediately, showNotification);
            }
            else if (packet.arguments.Length >= 1
                    && address.Equals(CHATBOX_TYPING_ADDRESS)
                    && packet.arguments[0].value is bool isOn)
            {
                chatboxEvent.InvokeToggleTypingIndicatorEvent(isOn);
            }
        }
    }
}
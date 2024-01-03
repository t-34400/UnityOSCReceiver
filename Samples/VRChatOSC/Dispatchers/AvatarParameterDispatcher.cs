#nullable enable

using System.Linq;
using UnityEngine;
using OSCPacket;

namespace OSCReceiver.VRChatOSC
{
    public class AvatarParameterDispatcher : DispatcherBase
    {
        private const string AVATAR_PARAM_ADDRESS_PREFIX = "/avatar/parameters/";

        [SerializeField] private AvatarParameterEvent avatarParameterEvent = default!;

        public override void Dispatch(Packet packet)
        {
            var address = packet.address;
            if (packet.arguments.Length > 0 && address.StartsWith(AVATAR_PARAM_ADDRESS_PREFIX))
            {
                var command = address.Substring(AVATAR_PARAM_ADDRESS_PREFIX.Length);
                
                var argument = packet.arguments.FirstOrDefault();
                if (argument.value is int intValue)
                {
                    avatarParameterEvent.InvokeUpdateAvatarParameterEvent(command, intValue);
                }
                else if (argument.value is bool boolValue)
                {
                    avatarParameterEvent.InvokeUpdateAvatarParameterEvent(command, boolValue);
                }
                else if (argument.value is float floatValue)
                {
                    avatarParameterEvent.InvokeUpdateAvatarParameterEvent(command, floatValue);
                }
            }
        }
    }
}
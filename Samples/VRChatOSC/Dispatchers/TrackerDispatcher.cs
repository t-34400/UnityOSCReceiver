#nullable enable

using System;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using OSCPacket;

namespace OSCReceiver.VRChatOSC
{
    public class TrackerDispatcher : DispatcherBase
    {
        private const string TRACKER_ADDRESS_PREFIX = "/tracking/trackers/";
        private const string POSITION_COMMAND_ADDRESS_SUFFIX = "position";
        private const string ROTATION_COMMAND_ADDRESS_SUFFIX = "rotation";

        [SerializeField] private TrackerEvent trackerEvent = default!;

        public override void Dispatch(Packet packet)
        {
            var address = packet.address;
            if (packet.arguments.Length >= 3 
                && address.StartsWith(TRACKER_ADDRESS_PREFIX)
                && packet.arguments[0].value is float x
                && packet.arguments[1].value is float y
                && packet.arguments[2].value is float z)
            {
                var idEndIndex = address.IndexOf('/', TRACKER_ADDRESS_PREFIX.Length);
                if (idEndIndex < 0)
                {
                    return;
                }
                
                var idString = address.Substring(TRACKER_ADDRESS_PREFIX.Length, idEndIndex);
                var command = address.Substring(idEndIndex + 1);

                if (!TryGetTrackerId(idString, out int trackerId))
                {
                    return;
                }

                if (command.Equals(POSITION_COMMAND_ADDRESS_SUFFIX))
                {
                    trackerEvent.InvokeUpdatePositionEvent(trackerId, new (x, y, z));
                }
                else if (command.Equals(ROTATION_COMMAND_ADDRESS_SUFFIX))
                {
                    trackerEvent.InvokeUpdateRotationEvent(trackerId, Quaternion.Euler(x, y, z));
                }
            }
        }

        private static bool TryGetTrackerId(string idString, out int trackerId)
        {
            trackerId = -1;

            if (idString.Equals("head"))
            {
                trackerId = 0;
                return true;
            }

            return Int32.TryParse(idString, out trackerId);
        }
    }
}
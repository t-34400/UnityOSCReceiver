#nullable enable

using System;
using UnityEngine;

namespace OSCReceiver.VRChatOSC
{
    [CreateAssetMenu(fileName = "TrackerEvent", menuName = "OSC Receiver/VRChat/Events/Tracker Event")]
    public class TrackerEvent : ScriptableObject
    {
        /// <summary>
        /// Update the world-space position of your OSC tracker. Head index is zero.
        /// </summary>
        public event Action<int, Vector3>? UpdatePosition;

        /// <summary>
        /// Update the world-space rotation of your OSC tracker. Head index is zero.
        /// </summary>
        public event Action<int, Quaternion>? UpdateRotation;

        internal void InvokeUpdatePositionEvent(int trackerId, Vector3 position) => UpdatePosition?.Invoke(trackerId, position);
        internal void InvokeUpdateRotationEvent(int trackerId, Quaternion rotation) => UpdateRotation?.Invoke(trackerId, rotation);
    }
}
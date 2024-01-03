#nullable enable

using System;
using UnityEngine;

namespace OSCReceiver.VRChatOSC
{
    [CreateAssetMenu(fileName = "AvatarParameterEvent", menuName = "OSC Receiver/VRChat/Events/Avatar Parameter Event")]
    public class AvatarParameterEvent : ScriptableObject
    {
        /// <summary>
        /// Drive an integer parameter on your Avatar.
        /// </summary>
        public event Action<string, int>? UpdateAvatarIntParameter;

        /// <summary>
        /// Drive a boolean parameter on your Avatar.
        /// </summary>
        public event Action<string, bool>? UpdateAvatarBoolParameter;

        /// <summary>
        /// Drive a floating point parameter on your Avatar.
        /// </summary>
        public event Action<string, float>? UpdateAvatarFloatParameter;

        internal void InvokeUpdateAvatarParameterEvent(string command, int parameter) => UpdateAvatarIntParameter?.Invoke(command, parameter);
        internal void InvokeUpdateAvatarParameterEvent(string command, bool parameter) => UpdateAvatarBoolParameter?.Invoke(command, parameter);
        internal void InvokeUpdateAvatarParameterEvent(string command, float parameter) => UpdateAvatarFloatParameter?.Invoke(command, parameter);
    }
}
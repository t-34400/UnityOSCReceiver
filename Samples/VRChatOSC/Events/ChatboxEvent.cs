#nullable enable

using System;
using UnityEngine;

namespace OSCReceiver.VRChatOSC
{
    [CreateAssetMenu(fileName = "ChatboxEvent", menuName = "OSC Receiver/VRChat/Events/Chatbox Event")]
    public class ChatboxEvent : ScriptableObject
    {
        /// <summary>
        /// s b n: Input text into the chatbox. If b is True, send the text in s immediately, bypassing the keyboard. If b is False, open the keyboard and populate it with the provided text. n is an additional bool parameter that when set to False will not trigger the notification SFX (defaults to True if not specified).
        /// </summary>
        public event Action<string, bool, bool>? InputChatbox;

        /// <summary>
        /// Toggle the typing indicator on or off.
        /// </summary>
        public event Action<bool>? ToggleTypingIndicator;

        internal void InvokeInputChatboxEvent(string input, bool sendImmediately, bool showNotification)
        {
            InputChatbox?.Invoke(input, sendImmediately, showNotification);
        }

        internal void InvokeToggleTypingIndicatorEvent(bool isOn)
        {
            ToggleTypingIndicator?.Invoke(isOn);
        }
    }
}
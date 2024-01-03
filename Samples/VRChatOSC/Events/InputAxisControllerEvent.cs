#nullable enable

using System;
using UnityEngine;

namespace OSCReceiver.VRChatOSC
{
    [CreateAssetMenu(fileName = "InputAxisControllerEvent", menuName = "OSC Receiver/VRChat/Events/Input Axis Controller Event")]
    public class InputAxisControllerEvent : ScriptableObject
    {
        /// <summary>
        /// Move forwards (1) or Backwards (-1)
        /// </summary>
        public event Action<float>? Vertical;

        /// <summary>
        /// Move right (1) or left (-1)
        /// </summary>
        public event Action<float>? Horizontal;

        /// <summary>
        /// Look Left and Right. Smooth in Desktop, VR will do a snap-turn when the value is 1 if Comfort Turning is on.
        /// </summary>
        public event Action<float>? LookHorizontal;

        /// <summary>
        /// Use held item - not sure if this works
        /// </summary>
        public event Action<float>? UseAxisRight;

        /// <summary>
        /// Grab item - not sure if this works
        /// </summary>
        public event Action<float>? GrabAxisRight;

        /// <summary>
        /// Move a held object forwards (1) and backwards (-1)
        /// </summary>
        public event Action<float>? MoveHoldFB;

        /// <summary>
        /// Spin a held object Clockwise or Counter-Clockwise
        /// </summary>
        public event Action<float>? SpinHoldCwCcw;

        /// <summary>
        /// Spin a held object Up or Down
        /// </summary>
        public event Action<float>? SpinHoldUD;

        /// <summary>
        /// Spin a held object Left or Right
        /// </summary>
        public event Action<float>? SpinHoldLR;

        internal void InvokeInputAxisEvent(string command, float value)
        {
            switch(command)
            {
                case "Vertical":
                    {
                        Vertical?.Invoke(value);
                        break;
                    }
                case "Horizontal":
                    {
                        Horizontal?.Invoke(value);
                        break;
                    }
                case "LookHorizontal":
                    {
                        LookHorizontal?.Invoke(value);
                        break;
                    }
                case "UseAxisRight":
                    {
                        UseAxisRight?.Invoke(value);
                        break;
                    }
                case "GrabAxisRight":
                    {
                        GrabAxisRight?.Invoke(value);
                        break;
                    }
                case "MoveHoldFB":
                    {
                        MoveHoldFB?.Invoke(value);
                        break;
                    }
                case "SpinHoldCwCcw":
                    {
                        SpinHoldCwCcw?.Invoke(value);
                        break;
                    }
                case "SpinHoldUD":
                    {
                        SpinHoldUD?.Invoke(value);
                        break;
                    }
                case "SpinHoldLR":
                    {
                        SpinHoldLR?.Invoke(value);
                        break;
                    }
            };
        }
    }
}
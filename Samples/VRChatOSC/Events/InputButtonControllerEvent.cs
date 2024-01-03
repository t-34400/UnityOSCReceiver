#nullable enable

using System;
using UnityEngine;

namespace OSCReceiver.VRChatOSC
{
    [CreateAssetMenu(fileName = "InputButtonControllerEvent", menuName = "OSC Receiver/VRChat/Events/Input Button Controller Event")]
    public class InputButtonControllerEvent : ScriptableObject
    {
        /// <summary>
        /// Move forward while this is true.
        /// </summary>
        public event Action<bool>? MoveForward;

        /// <summary>
        /// Move backwards while this is true.
        /// </summary>
        public event Action<bool>? MoveBackward;

        /// <summary>
        /// Strafe left while this is true.
        /// </summary>
        public event Action<bool>? MoveLeft;

        /// <summary>
        /// Strafe right while this is true.
        /// </summary>
        public event Action<bool>? MoveRight;

        /// <summary>
        /// Turn to the left while this is true. Smooth in Desktop, VR will do a snap-turn if Comfort Turning is on.
        /// </summary>
        public event Action<bool>? LookLeft;

        /// <summary>
        /// Turn to the right while this is true. Smooth in Desktop, VR will do a snap-turn if Comfort Turning is on.
        /// </summary>
        public event Action<bool>? LookRight;

        /// <summary>
        /// Jump if the world supports it.
        /// </summary>
        public event Action<bool>? Jump;

        /// <summary>
        /// Walk faster if the world supports it.
        /// </summary>
        public event Action<bool>? Run;

        /// <summary>
        /// Snap-Turn to the left - VR Only.
        /// </summary>
        public event Action<bool>? ComfortLeft;

        /// <summary>
        /// Snap-Turn to the right - VR Only.
        /// </summary>
        public event Action<bool>? ComfortRight;

        /// <summary>
        /// Drop the item held in your right hand - VR Only.
        /// </summary>
        public event Action<bool>? DropRight;

        /// <summary>
        /// Use the item highlighted by your right hand - VR Only.
        /// </summary>
        public event Action<bool>? UseRight;

        /// <summary>
        /// Grab the item highlighted by your right hand - VR Only.
        /// </summary>
        public event Action<bool>? GrabRight;

        /// <summary>
        /// Drop the item held in your left hand - VR Only.
        /// </summary>
        public event Action<bool>? DropLeft;

        /// <summary>
        /// Use the item highlighted by your left hand - VR Only.
        /// </summary>
        public event Action<bool>? UseLeft;

        /// <summary>
        /// Grab the item highlighted by your left hand - VR Only.
        /// </summary>
        public event Action<bool>? GrabLeft;

        /// <summary>
        /// Turn on Safe Mode.
        /// </summary>
        public event Action<bool>? PanicButton;

        /// <summary>
        /// Toggle QuickMenu On/Off. Will toggle upon receiving true if it's currently false.
        /// </summary>
        public event Action<bool>? QuickMenuToggleLeft;

        /// <summary>
        /// Toggle QuickMenu On/Off. Will toggle upon receiving true if it's currently false.
        /// </summary>
        public event Action<bool>? QuickMenuToggleRight;

        /// <summary>
        /// Toggle Voice - the action will depend on whether "Toggle Voice" is turned on in your Settings. If so, then changing from false to true will toggle the state of mute. If "Toggle Voice" is turned off, then it functions like Push-To-Mute - false is muted, true is unmuted.
        /// </summary>
        public event Action<bool>? Voice;

        internal void InvokeInputButtonEvent(string command, bool isOn)
        {
            switch(command)
            {
                case "MoveForward":
                    {
                        MoveForward ?.Invoke(isOn);
                        break;
                    }
                case "MoveBackward":
                    {
                        MoveBackward?.Invoke(isOn);
                        break;
                    }
                case "MoveLeft":
                    {
                        MoveLeft?.Invoke(isOn);
                        break;
                    }
                case "MoveRight":
                    {
                        MoveRight?.Invoke(isOn);
                        break;
                    }
                case "LookLeft":
                    {
                        LookLeft?.Invoke(isOn);
                        break;
                    }
                case "LookRight":
                    {
                        LookRight?.Invoke(isOn);
                        break;
                    }
                case "Jump":
                    {
                        Jump?.Invoke(isOn);
                        break;
                    }
                case "Run":
                    {
                        Run?.Invoke(isOn);
                        break;
                    }
                case "ComfortLeft":
                    {
                        ComfortLeft?.Invoke(isOn);
                        break;
                    }
                case "ComfortRight":
                    {
                        ComfortRight?.Invoke(isOn);
                        break;
                    }
                case "DropRight":
                    {
                        DropRight?.Invoke(isOn);
                        break;
                    }
                case "UseRight":
                    {
                        UseRight?.Invoke(isOn);
                        break;
                    }
                case "GrabRight":
                    {
                        GrabRight?.Invoke(isOn);
                        break;
                    }
                case "DropLeft":
                    {
                        DropLeft?.Invoke(isOn);
                        break;
                    }
                case "UseLeft":
                    {
                        UseLeft?.Invoke(isOn);
                        break;
                    }
                case "GrabLeft":
                    {
                        GrabLeft?.Invoke(isOn);
                        break;
                    }
                case "PanicButton":
                    {
                        PanicButton?.Invoke(isOn);
                        break;
                    }
                case "QuickMenuToggleLeft":
                    {
                        QuickMenuToggleLeft?.Invoke(isOn);
                        break;
                    }
                case "QuickMenuToggleRight":
                    {
                        QuickMenuToggleRight?.Invoke(isOn);
                        break;
                    }
                case "Voice":
                    {
                        Voice?.Invoke(isOn);
                        break;
                    }
            };
        }
    }
}
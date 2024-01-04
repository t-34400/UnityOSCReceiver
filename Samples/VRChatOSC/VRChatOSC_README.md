# VRChatOSC
A Unity sample for handling OSC input with VRChat compatibility.

## Usage
1. Download [OSCReceiver.unitypackage](../../OSCReceiver.unitypackage) and [import it into the Unity Editor](https://docs.unity3d.com/Manual/AssetPackagesImport.html).
2. Add the `Assets/OSCReceiver/Samples/Prefabs/OSCReceiver` prefab to the scene.
3. Create [Event Handlers](#event-handlers) and attach them to objects in the scene.
4. Attach the events from `Assets/OSCReceiver/Samples/ScriptableObjects` to the event handlers.

## Event Handlers
1. Create a class that inherits from MonoBehaviour, define the event classes from `Assets/OSCReceiver/Samples/Scripts/Events` in a [serializable format](https://docs.unity3d.com/2021.3/Documentation/Manual/script-Serialization.html).
    - [AvatarParameterEvent](./Events/AvatarParameterEvent.cs): Class that triggers an event when receiving an [Avatar parameter message](https://docs.vrchat.com/docs/osc-avatar-parameters).
    - [InputAxisControllerEvent](./Events/InputAxisControllerEvent.cs): Class that triggers an event when receiving an [Input Controller Axis message](https://docs.vrchat.com/docs/osc-as-input-controller).
    - [InputButtonControllerEvent](./Events/InputButtonControllerEvent.cs): Class that triggers an event when receiving an [Input Controller Button message](https://docs.vrchat.com/docs/osc-as-input-controller).
    - [ChatboxEvent](./Events/ChatboxEvent.cs): Class that triggers an event when receiving a [Chatbox message](https://docs.vrchat.com/docs/osc-as-input-controller).
    - [TrackerEvent](./Events/TrackerEvent.cs): Class that triggers an event when receiving a [Tracker message](https://docs.vrchat.com/docs/osc-as-input-controller).
2. Register and unregister listeners for each event class at appropriate timings.

Refer to the classes in `Assets/OSCReceiver/Samples/Scripts/Views` for implementation samples.

## Sample Scene
`Assets/OSCReceiver/Samples/Scenes/VRChatSample` contains a sample scene for controlling a player and simulating Chatbox input using OSC messages.

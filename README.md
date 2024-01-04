# UnityOSCReceiver
A Unity OSC receiver library and a sample implementation for handling VRChat OSC input.

## Prerequisites
Refer to the official [OpenSoundControl Specification 1.0](https://opensoundcontrol.stanford.edu/spec-1_0.html) for detailed OSC specifications.

## Environment
Unity Editor that can compile C#8 or later (if using an earlier version, update the switch statements accordingly).

## Supported Type Formats
- Standard Formats
    - int32
    - float32
    - OSC-string
    - OSC-blob
- Non-Standard Formats
    - True
    - False

## Usage
1. Download [OSCReceiver.unitypackage](./OSCReceiver.unitypackage) and [import it into the Unity Editor](https://docs.unity3d.com/Manual/AssetPackagesImport.html).
2. Attach the OSCReceiver component to any GameObject.
3. Attach any Dispatcher component to any GameObject and add it to the Dispatchers in the OSCReceiver component.

### About Dispatchers
- [Basic Dispatchers](./Scripts/Dispatchers/)
    - Converts input arguments for the specified OSC address to basic data types (`bool`, `int`, `float`, `string`, `Vector3`, `Quaternion`) and dispatches them as UnityEvents.
    - Specify the OSC address to process in the address field.
    - Register the actual processing in the inspector under the handler.
    - Notes:
        - `BoolDispatcher`, `IntDispatcher`, `FloatDispatcher`, `StringDispatcher` dispatch events if the first argument corresponds to the respective data type.
        - `Vector3Dispatcher` dispatches an event if the first three arguments are all Float32, creating a Vector3 with `x`, `y`, `z`.
        - `EulerAnglesDispatcher` dispatches an event if the first three arguments are all Float32, creating a Quaternion with Euler angles (`x`, `y`, `z` in degrees).
        - `QuaternionDispatcher` dispatches an event if the first four arguments are all Float32, creating a Quaternion with specified elements.
            - The order of elements can be specified in the inspector.
- `LogDispatcher`
    - Displays the received OSC address and arguments in the editor's log.
- Custom Dispatchers
    - By inheriting from the [DispatcherBase](./Scripts/DispatcherBase.cs) abstract class, you can define any dispatcher.
        - The abstract method `void Dispatch(Packet packet)` is called on the frame after receiving the OSC packet if attached to the OSCReceiver.
        - `packet.address` contains the OSC address (string).
        - `packet.arguments` contains the arguments.
            - `argument.type` contains the data type of the argument.
            - `argument.value` contains the argument value casted to an object.

## VRChatOSC
A sample for processing VRChat OSC input.
Refer to [VRChatOSC_README](./Samples/VRChatOSC/VRChatOSC_README.md) for usage details.

## License
[MIT License](./LICENSE)

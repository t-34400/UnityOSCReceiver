# VRChatOSC
Unity上でVRChat対応のOSC入力を処理するサンプル．

## 使い方
1. [OSCReceiver.unitypackage](../../OSCReceiver.unitypackage)をダウンロードし，[Unity Editorにインポート](https://docs.unity3d.com/Manual/AssetPackagesImport.html)する．
2. `Assets/OSCReceiver/Samples/Prefabs/OSCReceiver`プレハブをシーンに追加する．
3. [イベントハンドラ](#イベントハンドラ)を作成し，シーンのオブジェクトにアタッチする．
4. `Assets/OSCReceiver/Samples/ScriptableObjects`のイベントをイベントハンドラにアタッチする．

## イベントハンドラ
1. MonoBehaviourを継承したクラスを作成し，`Assets/OSCReceiver/Samples/Scripts/Events`のイベントクラスを[シリアライズ可能な形式](https://docs.unity3d.com/2021.3/Documentation/Manual/script-Serialization.html)で定義する．
    - [AvatarParameterEvent](./Events/AvatarParameterEvent.cs): [Avatar parameterメッセージ](https://docs.vrchat.com/docs/osc-avatar-parameters)を受け取った際にイベントを発行するクラス
    - [InputAxisControllerEvent](./Events/InputAxisControllerEvent.cs): [Input ControllerのAxisメッセージ](https://docs.vrchat.com/docs/osc-as-input-controller)を受け取った際にイベントを発行するクラス
    - [InputButtonControllerEvent](./Events/InputButtonControllerEvent.cs): [Input ControllerのButtonメッセージ](https://docs.vrchat.com/docs/osc-as-input-controller)を受け取った際にイベントを発行するクラス
    - [ChatboxEvent](./Events/ChatboxEvent.cs): [Chatboxメッセージ](https://docs.vrchat.com/docs/osc-as-input-controller)を受け取った際にイベントを発行するクラス
    - [TrackerEvent](./Events/TrackerEvent.cs): [Trackerメッセージ](https://docs.vrchat.com/docs/osc-as-input-controller)を受け取った際にイベントを発行するクラス
2. 各イベントクラスのeventのリスナーを適当なタイミングで登録・解除する．

実装サンプルとして，`Assets/OSCReceiver/Samples/Scripts/Views`内のクラスを参照すること．

## サンプルシーン
`Assets/OSCReceiver/Samples/Scenes/VRChatSample`に，OSC形式でPlayerコントロールとChatbox入力を行うサンプルシーンが用意してある．

## ライセンス
[MITライセンス](../../LICENSE)
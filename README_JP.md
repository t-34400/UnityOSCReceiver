# UnityOSCReceiver
Unity OSCレシーバー・ライブラリーと，VRChat OSC入力を処理するサンプル実装．

## 事前知識
OSCの詳しい仕様については，公式の[OpenSoundControl Specification 1.0](https://opensoundcontrol.stanford.edu/spec-1_0.html)を確認すること．

## 実行環境
C#8以降がコンパイルできるUnity Editor（それ以前のバージョンを使う場合は，switch式を書き直すこと）

## 対応タイプフォーマット
- 標準フォーマット
    - int32
    - float32
    - OSC-string
    - OSC-blob
- 非標準フォーマット
    - True
    - False

## 使い方
1. [OSCReceiver.unitypackage](./OSCReceiver.unitypackage)をダウンロードし，[Unity Editorにインポート](https://docs.unity3d.com/Manual/AssetPackagesImport.html)する．
2. OSCReceiverコンポーネントを任意のGameObjectにアタッチする．
3. 任意のDispactherコンポーネントを任意のGameObjectにアタッチし，OSCReceiverコンポーネントのDispatchersに追加する．

### Dispatcherについて
- [基本Dispatcher](./Scripts/Dispatchers/)
    - 指定したOSCアドレスへの入力の引数を，基本データタイプ(`bool`, `int`, `float`, `string`，`Vector3`, `Quaternion`)に変換しUnityEventとして発行する．
    - addressに処理を行うOSCアドレスを指定する．
    - 実際の処理をインスペクタからhandlerに登録する．
    - 補足事項:
        - `BoolDispatcher`，`IntDispatcher`，`FloatDispatcher`，`StringDispatcher`は，最初の引数が対応するデータタイプの場合イベントを発行する．
        - `Vector3Dispatcher`は，先頭の引数3つがすべてFloat32の場合にそれぞれを`x`,`y`,`z`としてVector3を生成しイベントを発行する．
        - `EulerAnglesDispatcher`は，先頭の引数3つがすべてFloat32の場合にそれぞれをオイラー角(deg)`x`,`y`,`z`としてQuaternionを生成しイベントを発行する．
        - `QuaternionDispatcher`は，先頭の引数4つがすべてFloat32の場合にそれぞれを要素とするQuaternionを生成しイベントを発行する．
            - 要素の順番はインスペクタの`order`で指定できる．
- `LogDispatcher`
    - 受信したOSCのアドレスと引数をエディタのログに表示する．
- カスタムDispatcher
    - [DispatcherBase](./Scripts/DispatcherBase.cs)抽象クラスを継承することで，任意のDispatcherを定義することができる．
        - 抽象メソッド`void Dispatch(Packet packet)`は，OSCReceiverにアタッチされている場合，OSCパケットを受信した次のフレームで呼び出される．
        - `packet.address`には，OSCアドレス(string)が格納される．
        - `packet.arguments`には，引数が格納される．
            - `argument.type`には，引数のデータタイプが格納される．
            - `argument.value`には，引数の値がobjectにアップキャストされて格納される．

## VRChatOSC
VRChat対応のOSC入力を処理するサンプル．
使い方は，[VRChatOSC_README_JP](./Samples/VRChatOSC/VRChatOSC_README_JP.md)を参照すること．

## ライセンス
[MITライセンス](./LICENSE)
#nullable enable

using System.Collections;
using OSCReceiver.VRChatOSC;
using UnityEngine;
using UnityEngine.Events;

public class ChatboxController : MonoBehaviour
{
    [SerializeField] private ChatboxEvent chatboxEvent = default!;
    [SerializeField] private GameObject typingIndicator = default!;
    [SerializeField] private GameObject chatbox = default!;
    [SerializeField] private float hideChatboxDelay = 1.0f;
    [SerializeField] private UnityEvent<string> sendChatInput = default!;

    private IEnumerator? currentCoroutine = null;

    private void OnEnable()
    {
        chatboxEvent.InputChatbox += InputChatbox;
        chatboxEvent.ToggleTypingIndicator += ToggleTypingIndicator;
    }

    private void OnDisable()
    {
        chatboxEvent.InputChatbox -= InputChatbox;
        chatboxEvent.ToggleTypingIndicator -= ToggleTypingIndicator;
    }

    private void ToggleTypingIndicator(bool isOn) => typingIndicator.SetActive(isOn);
    private void InputChatbox(string input, bool _, bool __)
    {
        sendChatInput.Invoke(input);

        chatbox.SetActive(true);
        typingIndicator.SetActive(false);

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = HideChatboxCoroutine();
        StartCoroutine(currentCoroutine);
    }

    private IEnumerator HideChatboxCoroutine()
    {
        yield return new WaitForSeconds(hideChatboxDelay);
        chatbox.SetActive(false);
        currentCoroutine = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueDisplay : MonoBehaviour
{
    [Header("Scriptable Object Info")]
    [SerializeField] private DialogueSO _dialogueSO;
    [SerializeField] private Transform _uiModelObject;
    [SerializeField] private TextMeshProUGUI _uiName;
    [SerializeField] private TextMeshProUGUI _uiDialogue;
    [SerializeField] private float _typeSpeed;

    [Header("Buttons Info")]
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _endButton;
    [SerializeField] private GameObject _skipButton;

    private int _currentDialogue = 0;

    void Start()
    {
        UpdateDialogue();
    }

    private void UpdateDialogue()
    {
        foreach (Transform child in _uiModelObject.transform)
            Destroy(child.gameObject);

        Instantiate(_dialogueSO._dialogueSections[_currentDialogue]._soModel, _uiModelObject.position, _uiModelObject.rotation, _uiModelObject);

        _uiName.text = _dialogueSO._dialogueSections[_currentDialogue]._soName;

        StopAllCoroutines();
        StartCoroutine(TypeDialogue(_dialogueSO._dialogueSections[_currentDialogue]._soDialogue));

    }

    public void Next()
    {
        ++_currentDialogue;

        UpdateDialogue();
    }

    public void Skip()
    {
        StopAllCoroutines();

        _uiDialogue.text = _dialogueSO._dialogueSections[_currentDialogue]._soDialogue;

        if (IsEndOfDiagloue())
            EndDialogue();
        else
            UpdateButtons(true, false, false);
    }

    private void UpdateButtons(bool nextButton, bool skipButton, bool endButton)
    {
        _nextButton.SetActive(nextButton);
        _skipButton.SetActive(skipButton);
        _endButton.SetActive(endButton);
    }

    public void End()
    {
        Debug.Log("End of text");
    }

    private bool IsEndOfDiagloue()
    {
        return _currentDialogue >= _dialogueSO._dialogueSections.Length - 1;
    }

    private void EndDialogue()
    {
        StopAllCoroutines();

        UpdateButtons(false, false, true);
    }

    private IEnumerator TypeDialogue(string dialogue)
    {
        _uiDialogue.text = string.Empty;

        UpdateButtons(false, true, false);

        foreach (char letter in dialogue.ToCharArray())
        {
            _uiDialogue.text += letter;
            yield return new WaitForSeconds(_typeSpeed);
        }

        if (IsEndOfDiagloue())
            EndDialogue();
        else
            UpdateButtons(true, false, false);
    }
}

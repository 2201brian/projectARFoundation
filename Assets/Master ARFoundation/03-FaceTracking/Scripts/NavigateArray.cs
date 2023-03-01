using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NavigateArray : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _nextButton;

    public UnityAction<int> OnMove;

    private int _currentIndex;
    private int _arrayLength;
    private bool _isLoop;

    public void Initialize(int arrayLength, bool isLoop, UnityAction<int> callback)
    {
        _currentIndex = 0;
        _arrayLength = arrayLength;
        _isLoop = isLoop;
        OnMove = callback;

        _backButton.onClick.AddListener(MoveBack);
        _nextButton.onClick.AddListener(MoveNext);

        CheckButtonState();
    }

    private void MoveBack() 
    {
        _currentIndex--;

        if (_currentIndex < 0) 
        {
            _currentIndex = _isLoop ? _arrayLength-1 : 0;
        }

        CheckButtonState();

        OnMove.Invoke(_currentIndex);
    }

    private void MoveNext() 
    {
        _currentIndex++;

        if (_currentIndex >= _arrayLength)
        {
            _currentIndex = _isLoop ? 0 : _arrayLength-1;
        }

        CheckButtonState();

        OnMove.Invoke(_currentIndex);
    }

    private void CheckButtonState() 
    {
        if (_isLoop) return;

        _backButton.interactable = _currentIndex != 0;
        _nextButton.interactable = _currentIndex != _arrayLength - 1;
    }
}

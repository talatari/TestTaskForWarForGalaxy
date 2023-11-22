using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class UIJoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    // [SerializeField] private Image _joystickArea;
    [SerializeField] private Image _joystickBackground;
    [SerializeField] private Image _joystick;
    [SerializeField] private Color _inActiveJoystickColor;
    [SerializeField] private Color _activeJoystickColor;
    
    private Vector2 _joystickBackgroundStartPosition;
    protected Vector2 _inputVector;
    private bool _isJoystickActive;

    private void Start() => 
        _joystickBackgroundStartPosition = _joystickBackground.rectTransform.anchoredPosition;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;
        int ratio = 2;
        float maxBorderInput = 1f;
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = joystickPosition.x * ratio / _joystickBackground.rectTransform.sizeDelta.x;
            joystickPosition.y = joystickPosition.y * ratio / _joystickBackground.rectTransform.sizeDelta.y;

            _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);

            _inputVector = _inputVector.magnitude > maxBorderInput ? _inputVector.normalized : _inputVector;

            _joystick.rectTransform.anchoredPosition = new Vector2(
                _inputVector.x * (_joystickBackground.rectTransform.sizeDelta.x / ratio),
                _inputVector.y * (_joystickBackground.rectTransform.sizeDelta.y / ratio));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickEffect();
        
        // Vector2 joystickBackgroundPosition;
        //
        // if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //         _joystickArea.rectTransform, eventData.position, null, out joystickBackgroundPosition))
        // {
        //     _joystickBackground.rectTransform.anchoredPosition = new Vector2(
        //         joystickBackgroundPosition.x, joystickBackgroundPosition.y);
        // }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickBackground.rectTransform.anchoredPosition = _joystickBackgroundStartPosition;
        
        ClickEffect();
        
        _inputVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
    
    private void ClickEffect()
    {
        if (_isJoystickActive)
        {
            _joystick.color = _inActiveJoystickColor;
            _isJoystickActive = false;
        }
        else
        {
            _joystick.color = _activeJoystickColor;
            _isJoystickActive = true;
        }
    }
}
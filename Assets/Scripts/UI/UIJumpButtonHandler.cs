using UnityEngine;
using UnityEngine.EventSystems;

public class UIJumpButtonHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PlayerJumpHandler _playerJumpHandler;

    public void OnPointerDown(PointerEventData eventData) => _playerJumpHandler.HandleJump();
}
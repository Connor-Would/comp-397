using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{
 private InputAction openMenu;
 [SerializeField] private GameObject menuPanel;
 //[SerializeField] private Slider mouseSensSlider;
 [SerializeField] private bool isMenu;
  void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;
        //mouseSensSlider.onValueChanged.AddListener(delegate {OnValueChanged(mouseSensSlider.value);});
    }
    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;
        //mouseSensSlider.onValueChanged.RemoveListener(delegate {OnValueChanged(mouseSensSlider.value);});
    }
    private void ToggleMenu(InputAction.CallbackContext context)
    {
        isMenu = !isMenu;
        menuPanel.SetActive(isMenu);
        if (isMenu) {
            GetComponent<PlayerInput>().enabled = false;
            InputSystem.actions.FindActionMap("Player").Disable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else {
            GetComponent<PlayerInput>().enabled = true;
            InputSystem.actions.FindActionMap("Player").Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    /* private void OnValueChanged(float m)
        {
            Debug.Log($"Mouse Sens from menu - {m}");
            //a downside is that if a meta file corruption, rename, or move occurs, the reference will break
        }*/
}
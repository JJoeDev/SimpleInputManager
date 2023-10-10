using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : MonoBehaviour
{
    private static inputManager _instance;
    public static inputManager Instance { get { return _instance; } }

    private PlayerInputs actions;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        actions = new PlayerInputs();
    }

    private void OnEnable() => actions.Enable();
    private void OnDisable() => actions.Disable();

    public Vector2 onMove() => actions.player.move.ReadValue<Vector2>().normalized;
    public InputAction onDash() => actions.player.dash;
}

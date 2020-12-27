using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Ui _ui = default;

    [SerializeField]
    private PlayerMotor _playerMotor = default;

    [SerializeField]
    private MouseLook _mouseLook = default;

    private void Start()
    {
        _ui.StartFlash();
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        _mouseLook.Tick(dt);
        _playerMotor.Tick(dt);
    }

    public void ResetAt(Transform t)
    {
        _mouseLook.ResetAt(t, null);
        _playerMotor.ResetAt(t);
    }
}

using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem muzzleFlash;

    private CharacterInput inputActions;

    private void Awake()
    {
        // Instantiate the generated input class
        inputActions = new CharacterInput();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        // Subscribe to the Shoot action event
        inputActions.Player.Shoot.performed += OnShoot;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        inputActions.Player.Shoot.performed -= OnShoot;
        inputActions.Player.Disable();
    }

    private void OnShoot(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        FireWeapon();
    }

    private void FireWeapon()
    {
        // Play the muzzle flash particle effect
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // Add shooting logic here (e.g., Raycast or Instantiate bullet prefab)
    }
}
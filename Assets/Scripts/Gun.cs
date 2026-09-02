using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f; // how far the gun can shoot

    public Camera fpsCam;

    private CharacterInput controls;

    private void Awake()
    {
        controls = new CharacterInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controls.Player.Shoot.triggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, 
            fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target enemy = hit.transform.GetComponent<Target>();

            if (enemy != null)
            {
                // Push direction is the camera's forward vector (or -hit.normal)
                Vector3 pushDirection = fpsCam.transform.forward;

                // Pass damage (25), push direction, and knockback force strength (15)
                enemy.TakeDamage(25f, pushDirection, 15f);
            }
            Debug.DrawRay(fpsCam.transform.position,
                fpsCam.transform.forward * hit.distance, Color.red, 1f);
        } else
        {
            Debug.DrawRay(fpsCam.transform.position,
                fpsCam.transform.forward * range, Color.red, 1f);
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}

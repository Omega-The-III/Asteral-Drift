using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private BaseGunBarrel[] weapons = new BaseGunBarrel[2];

    [SerializeField] private float playerSpeed;
    [SerializeField] private float yOffset = 0.5f; // Use this value to put the player a bit higher

    private Vector3 targetPosition;
    private Vector3 direction;

    private bool mousePointer;

    private void Awake()
    {
        GlobalReferenceManager.PlayerScript = this;
        GlobalReferenceManager.PlayerPosition = transform;
    }

    private void Start()
    {
        targetPosition = transform.position;
    }

    // Controls
    private void Update()
    {
        mousePointer = EventSystem.current.IsPointerOverGameObject();

        if (Input.GetMouseButton(0))
        {
            targetPosition = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0);
            targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);
            targetPosition.y += yOffset;
            targetPosition.z = 0;
        }
    }

    // Moving and shooting
    private void FixedUpdate()
    {
        // Moving
        direction = targetPosition - transform.position;

        // Check if the player is close enough to the desired position
        if (direction.magnitude > playerSpeed * Time.deltaTime)
        {
            direction.Normalize();
            transform.Translate(direction * playerSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = targetPosition;
        }
    }

    public void InscreaseShootingSpeed(float amount)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].IncreaseShootingSpeed(amount);
        }
    }
}
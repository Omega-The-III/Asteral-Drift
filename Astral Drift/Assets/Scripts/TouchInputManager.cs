using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchInputManager : MonoBehaviour
{
    // Position of the circle.
    private Vector2 objectPosition;
    private float width;
    private float height;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
        //height = 2f * cam.orthographicSize;
        //width = height * cam.aspect;

        objectPosition = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GamePaused == false)
        {
            // If the touchCount is greater than zero, that means we are touching the screen.
            if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                // Begin touch
                Touch touch = Input.GetTouch(0);

                // Move the circle if the finger is moving over the screen.
                //if (touch.phase == TouchPhase.Moved)
                //{
                // Get the vector position of the finger touching.
                Vector2 pos = touch.position;
                pos.x = 2.81f * (pos.x - width) / width;
                pos.y = 5 * (pos.y - height) / height;
                // Assign the position of the object to the position of the finger.
                objectPosition = new Vector2(pos.x, pos.y);

                // Move the object.
                transform.position = objectPosition;
                //}
            }
        }
    }
}

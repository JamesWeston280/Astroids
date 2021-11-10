using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform myTransform;
    float speed = 0.1f;

    //wrap around
    Vector3 TopleftOfScreen;
    Vector3 BottomRightOfScreen;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.transform;

        TopleftOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        BottomRightOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        myTransform.position += movement;

        //wrap around code
        Vector3 currentPos = myTransform.position;

        if (currentPos.x < TopleftOfScreen.x) currentPos.x = BottomRightOfScreen.x;
        if (currentPos.x > BottomRightOfScreen.x) currentPos.x = TopleftOfScreen.x;
        if (currentPos.y < TopleftOfScreen.y) currentPos.y = BottomRightOfScreen.y;
        if (currentPos.y > BottomRightOfScreen.y) currentPos.y = TopleftOfScreen.y;
        myTransform.position = currentPos;

    }
}

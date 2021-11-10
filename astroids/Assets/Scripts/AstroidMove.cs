using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMove: MonoBehaviour
{
    //need to moce
    Vector3 velocity;
    Transform myTransform;

    //need to bounce
    Vector3 topLeftOfScreen;
    Vector3 BottomRightOfScreen;

    //the player (Rocket) transform, check for collision
    Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.transform;
        System.Random ranNumGen = new System.Random();

        topLeftOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        BottomRightOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        print("screen extents" + topLeftOfScreen.ToString() + " " + topLeftOfScreen.ToString());

        //random velocity
        float velocityX = ranNumGen.Next(5,10) / 100f;
        float velocityY = ranNumGen.Next(5, 10) / 100f;
        velocity = new Vector3(velocityX, velocityY, 0);

        playerTransform = GameObject.Find("spaceShip").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myTransform.position += velocity;

        Vector3 currentPos = myTransform.position;

        if (currentPos.x < topLeftOfScreen.x || currentPos.x > BottomRightOfScreen.x)
        {
            velocity.x *= -1;
        }

        if (currentPos.y < topLeftOfScreen.y || currentPos.y > BottomRightOfScreen.y)
        {
            velocity.y *= -1;
        }

        if (collidesWithPlayer())
        {
            print("collision!");
        }   
    }


    bool collidesWithPlayer()
    {
        Vector3 playerPos = playerTransform.position;
        Vector3 thisAstroidPos = myTransform.position;

        float distance = Vector3.Distance(thisAstroidPos, playerPos);
        if (distance < 1f) return true;

        return false;
    }

}

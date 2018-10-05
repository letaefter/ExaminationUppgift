using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [Range(-720f, 720f)]
    public float turnRate = 145;
    public Transform spaceshipTransform;
    float growthOfTurnRate = 30f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BorderGuard();
        DrivingSpeedTurningAndMore();

    }
    void BorderGuard()
    {
        //if you leave the coordinates which are covered by the camera you will be sent to the opposite coordinates on that vector
        float SpaceshipValueOfX = transform.position.x;
        float SpaceshipValueOfY = transform.position.y;
        if (SpaceshipValueOfX > 32f)
        {
            transform.Translate(-64f, 0f, 0f, Space.World);
        }
        else if (SpaceshipValueOfX < -32f)
        {
            transform.Translate(64f, 0f, 0f, Space.World);
        }
        if (SpaceshipValueOfY > 18f)
        {
            transform.Translate(0f, -36f, 0f, Space.World);
        }
        else if (SpaceshipValueOfY < -18f)
        {
            transform.Translate(0f, 36f, 0f, Space.World);
        }
    }
    void DrivingSpeedTurningAndMore()
    {
        growthOfTurnRate = 50f;
        transform.Translate(0f, 10f * Time.deltaTime, 0f, Space.Self);
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                turnRate = 145;
            }
            turnRate = turnRate + (growthOfTurnRate * Time.deltaTime);
            transform.Rotate(0f, 0f, turnRate * Time.deltaTime);
            if (Input.GetKey(KeyCode.A) && turnRate >= 475)
            {
                turnRate = 475;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                turnRate = 145;
            }
            turnRate = turnRate + (growthOfTurnRate * Time.deltaTime);
            transform.Rotate(0f, 0f, -turnRate * Time.deltaTime);
            if (Input.GetKey(KeyCode.D) && turnRate >= 475)
            {
                turnRate = 475;
            }
        }
        if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false)
        {
            float turnRatesDecayRate = 90;
            if (turnRate <= 290)
            {
                turnRatesDecayRate = 90;
            }
            else if (turnRate > 290)
            {
                turnRatesDecayRate = 200;
            }
            turnRate = turnRate - (turnRatesDecayRate * Time.deltaTime);
            if (turnRate <= 145)
            {
                turnRate = 145;
            }
        }
    }

}

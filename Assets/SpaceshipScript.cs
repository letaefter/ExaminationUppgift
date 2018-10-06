using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [Range(-720f, 720f)]
    public float turnRate = 145;
    float growthOfTurnRate = 30f;
    public float baseSpeed = 10f;
    public Transform Transform;
    //the names vvvvvv correspond to the names of the sprites in unity and every unique callsign should be assigned the same color.
    public SpriteRenderer cockpitWindow;
    public SpriteRenderer undercarriageTriangle;
    public SpriteRenderer undercarriageTriangle1;
    public SpriteRenderer hexagonFuselage;
    public SpriteRenderer hexagonFuselage1;
    public SpriteRenderer hexagonFuselage2;
    public SpriteRenderer hexagonFuselage3;
    public SpriteRenderer hexagonFuselage4;
    public Color colorHexagonFuselage;
    public Color colorUndercarriageTriangle;
    public Color colorCockpitWindow;
    //not anymore ^^^^^^^^^ do they

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
        //nedan så sätter jag så att skeppets X och Y coordinater mäts av två variabler.
        //själva skeppet är ett child till kameran och därför mäts koordinaterna ifrån kamerans position
        float SpaceshipValueOfX = transform.position.x;
        float SpaceshipValueOfY = transform.position.y;
        //nedan så säger jag att om skeppets X koordinat är större än kamerans gränser så ska den skickas till andra sidan av kameran dock med samma Y koordinat
        //kamerans storlek är X = -32 till x = 32 och därför skickas man bak 64 på X och på y är den +-18 så man skickas 36 steg +-
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
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                baseSpeed = baseSpeed * 0.5f;
            }
        }
        if (Input.GetKey(KeyCode.S) == false)
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                baseSpeed = baseSpeed * 2f;
            }
        }
        transform.Translate(0f, baseSpeed * Time.deltaTime, 0f, Space.Self);
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                turnRate = 145;
                colorHexagonFuselage = new Color(0.1f, 0.55f, 0.1f, 1f);
                hexagonFuselage.color = colorHexagonFuselage;
                hexagonFuselage1.color = colorHexagonFuselage;
                hexagonFuselage2.color = colorHexagonFuselage;
                hexagonFuselage3.color = colorHexagonFuselage;
                hexagonFuselage4.color = colorHexagonFuselage;

                colorUndercarriageTriangle = new Color(0.2f, 0.75f, 0.1f, 1f);
                undercarriageTriangle.color = colorUndercarriageTriangle;
                undercarriageTriangle1.color = colorUndercarriageTriangle;

                colorCockpitWindow = new Color(0.2f, 0.99f, 0.6f, 1f);
                cockpitWindow.color = colorCockpitWindow;

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
                colorHexagonFuselage = new Color(0f, 0.075f, 0.65f, 1f);
                hexagonFuselage.color = colorHexagonFuselage;
                hexagonFuselage1.color = colorHexagonFuselage;
                hexagonFuselage2.color = colorHexagonFuselage;
                hexagonFuselage3.color = colorHexagonFuselage;
                hexagonFuselage4.color = colorHexagonFuselage;

                colorUndercarriageTriangle = new Color(0.1f, 0.2f, 0.9f, 1f);
                undercarriageTriangle.color = colorUndercarriageTriangle;
                undercarriageTriangle1.color = colorUndercarriageTriangle;

                colorCockpitWindow = new Color(0f, 0.6f, 0.95f, 1f);
                cockpitWindow.color = colorCockpitWindow;
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

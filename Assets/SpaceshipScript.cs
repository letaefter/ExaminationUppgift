using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    float timerCount = 1;
    float growthOfTurnRate;
    float minTurnRate;
    float maxTurnRate;
    public float turnRate = 145;
    public float baseSpeed = 10f;
    float determinesTurnRates;
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
        //variabeln determinesTurnRates är variabeln som allt som handlar om hur skeppet rör sig 
        //och den baseras baseras på vad man har valt för baseSpeed för sitt skepp
        determinesTurnRates = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        BorderGuard();
        DrivingSpeedTurningAndMore();
    }
    void Timer()
    {
        timerCount = timerCount + Time.deltaTime;

        {
            Debug.Log(timerCount);
        }
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
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                baseSpeed = baseSpeed * 0.5f;
                determinesTurnRates = baseSpeed * 2;
            }
        }
        if (Input.GetKey(KeyCode.S) == false)
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                baseSpeed = baseSpeed * 2f;
                determinesTurnRates = baseSpeed;
            }
        }
        growthOfTurnRate = determinesTurnRates * 5f;
        transform.Translate(0f, baseSpeed * Time.deltaTime, 0f, Space.Self);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                turnRate = 0f;
                determinesTurnRates = 0f;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                //om du håller in A eller D så ändras dessa två följande stycken vid första framen 
                //så att det blir rätt färg på skeppet och hur snabbt skeppet svänger åt vardera håll
                //det svänger snabbare till vänster än till höger, det baseras på skeppets bashastighet
                //så ett jätte långsamt skepp kommer inte svänga hur mycket grövre som helst

                //this color is green
                colorHexagonFuselage = new Color(0.1f, 0.55f, 0.1f, 1f);
                colorUndercarriageTriangle = new Color(0.1f, 0.75f, 0.2f, 1f);
                colorCockpitWindow = new Color(0.2f, 0.99f, 0.6f, 1f);
                turnRate = determinesTurnRates * 4.5f;

            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                //this color is blue
                colorHexagonFuselage = new Color(0f, 0.075f, 0.65f, 1f);
                colorUndercarriageTriangle = new Color(0.1f, 0.2f, 0.9f, 1f);
                colorCockpitWindow = new Color(0f, 0.6f, 0.95f, 1f);
                turnRate = determinesTurnRates * 15f;

            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0f, 0f, turnRate * Time.deltaTime, Space.Self);
                turnRate = turnRate + (growthOfTurnRate * Time.deltaTime);
                if (Input.GetKey(KeyCode.A) && turnRate >= determinesTurnRates * 15f)
                {
                    turnRate = determinesTurnRates * 15f;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    //this color is green
                    colorHexagonFuselage = new Color(0.1f, 0.55f, 0.1f, 1f);
                    colorUndercarriageTriangle = new Color(0.1f, 0.75f, 0.2f, 1f);
                    colorCockpitWindow = new Color(0.2f, 0.99f, 0.6f, 1f);
                    turnRate = determinesTurnRates * 4.5f;

                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0f, 0f, -turnRate * Time.deltaTime, Space.Self);
                turnRate = turnRate + (growthOfTurnRate * Time.deltaTime);
                if (Input.GetKey(KeyCode.D) && turnRate >= determinesTurnRates * 50f)
                {
                    turnRate = determinesTurnRates * 50f;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        //this color is blue
                        colorHexagonFuselage = new Color(0f, 0.075f, 0.65f, 1f);
                        colorUndercarriageTriangle = new Color(0.1f, 0.2f, 0.9f, 1f);
                        colorCockpitWindow = new Color(0f, 0.6f, 0.95f, 1f);
                    }
                    if (Input.GetKeyUp(KeyCode.D))
                    {
                        //this color is green
                        colorHexagonFuselage = new Color(0.1f, 0.55f, 0.1f, 1f);
                        colorUndercarriageTriangle = new Color(0.1f, 0.75f, 0.2f, 1f);
                        colorCockpitWindow = new Color(0.2f, 0.99f, 0.6f, 1f);

                    }
                }
            }
        }
        if (determinesTurnRates == 0f)
        {
            if (Input.GetKey(KeyCode.S))
            {
                determinesTurnRates = baseSpeed * 2f;
            }
            else if (Input.GetKey(KeyCode.S) == false)
            {
                determinesTurnRates = baseSpeed;
            }
        }
        //om man svänger höger eller vänster så ändras variablerna med färgerna till blå eller grön respektive
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            hexagonFuselage.color = colorHexagonFuselage;
            hexagonFuselage1.color = colorHexagonFuselage;
            hexagonFuselage2.color = colorHexagonFuselage;
            hexagonFuselage3.color = colorHexagonFuselage;
            hexagonFuselage4.color = colorHexagonFuselage;
            undercarriageTriangle.color = colorUndercarriageTriangle;
            undercarriageTriangle1.color = colorUndercarriageTriangle;
            cockpitWindow.color = colorCockpitWindow;
        }
        //if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false)
        {
            //om man inte svänger så höjs radien på din sväng graduellt, om turn raten är hög så sänks den snabbare
            //och den är som lägst 
            //float turnRatesDecayRate = 90;
            //if (turnRate <= 290)
            //{
            //    turnRatesDecayRate = 90;
            //}
            //else if (turnRate > 290)
            //{
            //    turnRatesDecayRate = 200;
            //}
            //turnRate = turnRate - (turnRatesDecayRate * Time.deltaTime);
            //if (turnRate <= 145)
            //{
            //    turnRate = 145;
            //}
        }
    }

}

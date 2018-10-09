using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    float timerCount = 1;
    float growthOfTurnRate;
    float timerExtra;
    public float turnRate = 145;
    public float baseSpeed;
    float determinesTurnRates;
    public Transform PerkTransfrom;
    float colorRNGhexagon;
    float colorRNGhexagon1;
    float colorRNGhexagon2;
    float colorRNGtriangle;
    float colorRNGtriangle1;
    float colorRNGtriangle2;
    float colorRNGcockpit;
    float colorRNGcockpit1;
    float colorRNGcockpit2;
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
        //och den baseras baseras på vad man har valt för baseSpeed för sitt skepp men ändras inte när 
        //basSpeed ändrar under spelets gång, utan den är baseSpeed's värde i början av spelet
        RNGSpawnStart();
        determinesTurnRates = baseSpeed;

    }
    void RNGSpawnStart()
    {
        //här randomiseras två variabler som representerar X och Y, X variabeln randomiseras mellan 32 till 96
        //och sedan subtraheras hela X's längd ifrån så effektivt är rangen ifrån -32f till 32f vilket är innanför synfältet och gränsen.
        //Samma med Y fast med Y's skalor.
        //sedan transformar jag Parenten till alla spritekomponenter på mitt skepp till koordinaterna som jag har fått
        //i Space.World som betyder att den utgår ifrån kamerans position därför kameran är parent till min Sprite som
        //är parent till resten av alla sprites i mitt skepp.
        float rngX;
        float rngY;
        rngX = Random.Range(32f, 96f);
        rngY = Random.Range(18f, 54f);
        rngX = rngX - 64f;
        rngY = rngY - 36f;
        PerkTransfrom.Translate(rngX, rngY, 10f, Space.World);
        baseSpeed = Random.Range(10f, 21f);    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        BorderGuard();
        DrivingSpeedTurningAndMore();
    }
    void Timer()
    {
        //sämst
        timerCount = timerCount + Time.deltaTime;
    }
    void BorderGuard()
    {
        //if you leave the coordinates which are covered by the camera you will be sent to the opposite coordinates on that vector
        //nedan så sätter jag så att skeppets X och Y koordinater mäts av två variabler.
        //själva skeppet är ett child till kameran och därför mäts koordinaterna ifrån kamerans position där x0 och y0 är mittpunkten
        float SpaceshipValueOfX = transform.position.x;
        float SpaceshipValueOfY = transform.position.y;
        //nedan så säger jag att om skeppets X koordinat är större än kamerans gränser så ska den skickas till andra sidan av kameran dock med samma Y koordinat
        //kamerans storlek är X = -32 till x = 32 och därför skickas man bak 64 på X och på y är den +-18 så man skickas 36 steg back eller fram
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
        hexagonFuselage.color = colorHexagonFuselage;
        hexagonFuselage1.color = colorHexagonFuselage;
        hexagonFuselage2.color = colorHexagonFuselage;
        hexagonFuselage3.color = colorHexagonFuselage;
        hexagonFuselage4.color = colorHexagonFuselage;
        undercarriageTriangle.color = colorUndercarriageTriangle;
        undercarriageTriangle1.color = colorUndercarriageTriangle;
        cockpitWindow.color = colorCockpitWindow;
        growthOfTurnRate = determinesTurnRates * 5f;
        transform.Translate(0f, baseSpeed * Time.deltaTime, 0f, Space.Self);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            colorRNGhexagon = Random.Range(0f, 1f);
            colorRNGhexagon1 = Random.Range(0f, 1f);
            colorRNGhexagon2 = Random.Range(0f, 1f);
            colorRNGtriangle = Random.Range(0f, 1f);
            colorRNGtriangle1 = Random.Range(0f, 1f);
            colorRNGtriangle2 = Random.Range(0f, 1f);
            colorRNGcockpit = Random.Range(0f, 1f);
            colorRNGcockpit1 = Random.Range(0f, 1f);
            colorRNGcockpit2 = Random.Range(0f, 1f);
            colorHexagonFuselage = new Color(colorRNGhexagon, colorRNGhexagon1, colorRNGhexagon2, 1f);
            colorUndercarriageTriangle = new Color(colorRNGtriangle, colorRNGtriangle1, colorRNGtriangle2, 1f);
            colorCockpitWindow = new Color(colorRNGcockpit, colorRNGcockpit1, colorRNGcockpit2, 1f);
        }
        //om man klickar på S så åker skeppet hälften så snabbt, om man släpper S så åker den lika snabbt igen,
        //variabel determinesTurnRates påverkas också av S därför den ska hela tiden vara baseSpeed's värde
        //som man har valt/som har blivit RNG:at i början av spelet
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
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            //this is a mix between the blue and green
            colorHexagonFuselage = new Color(0.05f, 0.28f, 0.38f, 1f);
            colorUndercarriageTriangle = new Color(0.1f, 0.48f, 0.55f, 1f);
            colorCockpitWindow = new Color(0.1f, 0.8f, 0.78f, 1f);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {

            //om du håller in A eller D så ändras dessa följande stycken vid första framen 
            //så att det blir rätt färg på skeppet och hur snabbt skeppet svänger åt vardera håll
            //det svänger snabbare till vänster än till höger, det baseras på skeppets bashastighet
            //så ett jätte långsamt skepp kommer inte svänga hur mycket grövre som helst
            if (Input.GetKeyDown(KeyCode.A))
            {
                //this color is green
                colorHexagonFuselage = new Color(0.1f, 0.55f, 0.1f, 1f);
                colorUndercarriageTriangle = new Color(0.1f, 0.75f, 0.2f, 1f);
                colorCockpitWindow = new Color(0.2f, 0.99f, 0.6f, 1f);
                turnRate = determinesTurnRates * 4.5f;
            }
            if (Input.GetKeyDown(KeyCode.D))
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
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false)
                {
                    if (Input.GetKey(KeyCode.A) && Input.GetKeyUp(KeyCode.D))
                    {
                        if (Input.GetKey(KeyCode.S))
                        {
                            determinesTurnRates = baseSpeed * 2;
                        }
                        else
                        {
                            determinesTurnRates = baseSpeed;
                        }
                        //this color is green
                        colorHexagonFuselage = new Color(0.1f, 0.55f, 0.1f, 1f);
                        colorUndercarriageTriangle = new Color(0.1f, 0.75f, 0.2f, 1f);
                        colorCockpitWindow = new Color(0.2f, 0.99f, 0.6f, 1f);
                        turnRate = determinesTurnRates * 4.5f;
                    }
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
                if (Input.GetKeyDown(KeyCode.A))
                {
                    //this color is blue
                    colorHexagonFuselage = new Color(0f, 0.075f, 0.65f, 1f);
                    colorUndercarriageTriangle = new Color(0.1f, 0.2f, 0.9f, 1f);
                    colorCockpitWindow = new Color(0f, 0.6f, 0.95f, 1f);
                }
                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) == false)
                {
                    if (Input.GetKey(KeyCode.D) && Input.GetKeyUp(KeyCode.A))
                    {
                        if (Input.GetKey(KeyCode.S))
                        {
                            determinesTurnRates = baseSpeed * 2;
                        }
                        else
                        {
                            determinesTurnRates = baseSpeed;
                        }
                        //this color is blue
                        colorHexagonFuselage = new Color(0f, 0.075f, 0.65f, 1f);
                        colorUndercarriageTriangle = new Color(0.1f, 0.2f, 0.9f, 1f);
                        colorCockpitWindow = new Color(0f, 0.6f, 0.95f, 1f);
                        turnRate = determinesTurnRates * 15f;
                    }
                }
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                {
                    turnRate = 0f;
                    determinesTurnRates = 0f;
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.D))
                    {
                        colorHexagonFuselage = new Color(0.05f, 0.28f, 0.38f, 1f);
                        colorUndercarriageTriangle = new Color(0.1f, 0.48f, 0.55f, 1f);
                        colorCockpitWindow = new Color(0.1f, 0.8f, 0.78f, 1f);
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    //variables for Timer()
    float realTimeTimer = 1;
    int timerVariable1 = 0;
    float timerVariable2 = 0f;
    int seconds = 0;
    int minutes = 0;
    string timerVariable7;
    string timerVariable8;
    //not anymore variables for Timer()
    float growthOfTurnRate;
    public float turnRate = 145;
    public float baseSpeed;
    float determinesTurnRates;
    float colorRhexagon = 1f;
    float colorGhexagon = 0.5f;
    float colorBhexagon = 0.6f;
    float colorRtriangle = 0.2f;
    float colorGtriangle = 0.35f;
    float colorBtriangle = 0.43f;
    float colorRcockpit = 0.76f;
    float colorGcockpit = 0.12f;
    float colorBcockpit = 0.3f;
    public float cameraY;
    public float cameraX;
    float baseCameraSize;
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
    public Camera CameraMain;
    public Transform PerkTransfrom;


    // Use this for initialization
    void Start()
    {
        //variabeln determinesTurnRates är variabeln som allt som handlar om hur skeppet rör sig 
        //och den baseras baseras på vad man har valt för baseSpeed för sitt skepp men ändras inte när 
        //basSpeed ändrar under spelets gång, utan den är baseSpeed's värde i början av spelet
        BorderGuardStart();
        TimerStart();
    }
    // Update is called once per frame
    void Update()
    {
        Timer();
        DrivingSpeedTurningAndMore();
        BorderGuard();
    }
    void TimerStart()
    {
        realTimeTimer = 0f;
        seconds = -1;
        timerVariable7 = "0";
        timerVariable8 = "0";
    }
    void Timer()
    {
        realTimeTimer = realTimeTimer + Time.deltaTime;
        if (realTimeTimer > timerVariable1)
        {
            seconds = seconds + 1;
            if (seconds - 1 >= 0)
            {
                timerVariable2 = seconds;
                if (timerVariable2 / 60f >= 0)
                {
                    minutes = Mathf.FloorToInt(timerVariable2 / 60f);
                }
                if (seconds - (60 * minutes) >= 10)
                {
                    timerVariable7 = null;
                }
                else
                {
                    timerVariable7 = "0";
                }
                if (minutes >= 10)
                {
                    timerVariable8 = null;
                }
                else
                {
                    timerVariable8 = "0";
                }
                if (minutes == 59 && seconds - (60 * minutes) == 59)
                {
                    Debug.LogError("YOU HAVE REACHED THE TIME LIMIT UNFORTUNATELY LOL");
                }
            }
            Debug.Log("Timer" + " " + timerVariable8 + "" + minutes + ":" + timerVariable7 + "" + (seconds - (60 * minutes)));
        }
        timerVariable1 = Mathf.CeilToInt(realTimeTimer);
    }
    void BorderGuardStart()
    {
        {
            //denna funktion måste kallas i Start om void BorderGuard() ska funka i Update.
            //kamerans storlek bestäms av variabeln baseCameraSize som jag har satt i Start() som 15f för jag orkar inte.
            //cameraY bestäms som att ha samma värde som camerans orthografiska storlek
            //cameraX bestäms med ett värde som är i skala med cameraY eftersom förhållander mellan camerans Y och X
            //är 16:9
            //rngX och rngY bestämmer vart skeppet ska spawna i början, den baseras på hur stor skärmen är (cameraX och cameraY)
            //baseSpeed rng:as mellan rimliga värden :)
        }
        baseCameraSize = 15f;
        CameraMain.orthographicSize = baseCameraSize;
        cameraY = CameraMain.orthographicSize;
        cameraX = cameraY * (16f / 9f);
        float rngX;
        float rngY;
        rngY = Random.Range(Neg(cameraY), cameraY);
        rngX = Random.Range(Neg(cameraX), cameraX);
        PerkTransfrom.Translate(rngX, rngY, 10f, Space.World);
        baseSpeed = Random.Range(10f, 25f);
        determinesTurnRates = baseSpeed;
        colorRhexagon = 0f;
        colorGhexagon = 0f;
        colorBhexagon = 0f;
    }
    void BorderGuard()
    {
        cameraY = cameraY + (Time.deltaTime / 2f);
        CameraMain.orthographicSize = cameraY;
        cameraX = cameraY * (16f / 9f);
        float shipY;
        float shipX;
        shipY = hexagonFuselage4.transform.position.y;
        shipX = hexagonFuselage4.transform.position.x;
        if (shipY > cameraY)
        {
            transform.Translate(0f, -2f * cameraY, 0f, Space.World);
        }
        if (shipY < Neg(cameraY))
        {
            transform.Translate(0f, 2f * cameraY, 0f, Space.World);
        }
        if (shipX > cameraX)
        {
            transform.Translate(-2f * cameraX, 0f, 0f, Space.World);
        }
        if (shipX < Neg(cameraX))
        {
            transform.Translate(2f * cameraX, 0f, 0f, Space.World);
        }
    }
    //gör en negativ version av ett positivt nummer....
    float Neg(float value)
    {
        float ret;
        ret = value - (2 * value);
        return ret;
    }
    void DrivingSpeedTurningAndMore()
    {
        baseSpeed = baseSpeed + (0.6f * Time.deltaTime); // ta bort hela den här linjen om du inte vill bli snabbare under spelets gång :)
        determinesTurnRates = baseSpeed;
        growthOfTurnRate = determinesTurnRates * 5f;
        transform.Translate(0f, baseSpeed * Time.deltaTime, 0f, Space.Self);
        colorRtriangle = colorRhexagon + 0.1f;
        colorGtriangle = colorGhexagon + 0.1f;
        colorBtriangle = colorBhexagon + 0.1f;
        colorRcockpit = colorRhexagon + 0.3f;
        colorGcockpit = colorGhexagon + 0.3f;
        colorBcockpit = colorBhexagon + 0.3f;
        colorHexagonFuselage = new Color(colorRhexagon, colorGhexagon, colorBhexagon, 1f);
        colorUndercarriageTriangle = new Color(colorRtriangle, colorGtriangle, colorBtriangle, 1f);
        colorCockpitWindow = new Color(colorRcockpit, colorGcockpit, colorBcockpit, 1f);
        hexagonFuselage.color = colorHexagonFuselage;
        hexagonFuselage1.color = colorHexagonFuselage;
        hexagonFuselage2.color = colorHexagonFuselage;
        hexagonFuselage3.color = colorHexagonFuselage;
        hexagonFuselage4.color = colorHexagonFuselage;
        undercarriageTriangle.color = colorUndercarriageTriangle;
        undercarriageTriangle1.color = colorUndercarriageTriangle;
        cockpitWindow.color = colorCockpitWindow;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            //om man håller in både A och D så blir ju skeppet en blandning mellan blå och grön mang
            turnRate = 0f;
            determinesTurnRates = 0f;
            colorRhexagon = 0.15f;
            colorGhexagon = 0.38f;
            colorBhexagon = 0.48f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            colorRhexagon = Random.Range(0f, 0.7f);
            colorGhexagon = Random.Range(0f, 0.7f);
            colorBhexagon = Random.Range(0f, 0.7f);
        }
        //om man klickar på S så åker skeppet hälften så snabbt, om man släpper S så åker den lika snabbt igen,
        //variabel determinesTurnRates påverkas också av S därför den ska hela tiden vara baseSpeed's värde
        //som man har valt/som har blivit RNG:at i början av spelet
        //variabeln determinesTurnRates är den variabeln som bestämmer hur snabbt skeppet svänger
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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //detta if kommandot gör så att om man klickar A en gång så ändras 
            //skeppets färg till grön genom att ändra variabler som motsvarar RGB för skeppets.
            //Den ändras också när man håller in A samtidigt som man släpper D därför 
            //annars kan man svänga vänster och fortfarande var blå och vice versa.
            //Det som faktiskt ändrar färgen är i första lagret av denna funktionen.
            //det förändrar också turnRate vilket är variabeln
            //som bestämmer hur snabbt man svänger.
            //om man svänger vänster så är turnRate mindre än åt höger.
            //som sagt är determinesTurnRates baserat på baseSpeed vid Start()
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A) && Input.GetKeyUp(KeyCode.D))
            {
                //this color is green
                colorRhexagon = 0.1f;
                colorGhexagon = 0.55f;
                colorBhexagon = 0.1f;
                turnRate = determinesTurnRates * 4.5f;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D) && Input.GetKeyUp(KeyCode.A))
            {
                //this color is blue
                colorRhexagon = 0f;
                colorGhexagon = 0.075f;
                colorBhexagon = 0.65f;
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

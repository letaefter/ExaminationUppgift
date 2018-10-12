using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    float asteroidX;
    float asteroidY;
    float cameraX;
    float cameraY;
    float asteroidNewY;
    float asteroidRNGSpeed;
    float asteroidRotate;
    int fastOrNo;
    float bonusSpeed;
    public SpriteRenderer asteroid;
    private Camera CameraMainAsteroid;
    // Use this for initialization
    public SpriteRenderer asteroidRend;
    public SpriteRenderer asteroidRend1;
    public SpriteRenderer asteroidRend2;
    public SpriteRenderer asteroidRend3;
    public SpriteRenderer asteroidRend4;
    public SpriteRenderer asteroidRend5;
    void Start()
    {
        CameraMainAsteroid = Camera.main;
        float rngColorR;
        float rngColorG;
        float rngColorB;
        rngColorR = Random.Range(0.025f, 0.25f);
        rngColorG = Random.Range(0.025f, 0.25f);
        rngColorB = Random.Range(0.052f, 0.25f);
        int rng1;
        rng1 = Random.Range(1, 3);
        asteroidRNGSpeed = Random.Range(1f, 75f);
        asteroidRotate = Random.Range(20f, 80f);
        asteroidX = asteroid.transform.position.x;
        asteroidRend.color  = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend1.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend2.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend3.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend4.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend5.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        if (rng1 == 1)
        {
            asteroidRotate = Neg(asteroidRotate);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Asteroid();
    }
    void Asteroid()
    {
        cameraY = CameraMainAsteroid.orthographicSize;
        cameraX = cameraY * (16f / 9f);
        asteroidX = asteroid.transform.position.x;
        asteroidY = asteroid.transform.position.y;
        asteroid.transform.Translate(asteroidRNGSpeed * Time.deltaTime, 0f, 0f, Space.World);
        asteroid.transform.Rotate(0f, 0f, asteroidRotate*Time.deltaTime);
        if (asteroidX > cameraX)
        {
            asteroidNewY = Random.Range(Neg(cameraY), cameraY);
            asteroid.transform.Translate(Neg(cameraX)*2f, Neg(asteroidY) + asteroidNewY, 0f, Space.World);
            fastOrNo = Random.Range(1, 6);
            if (fastOrNo == 1)
            {
                bonusSpeed = 0f;
            }
            else if (fastOrNo == 2)
            {
                bonusSpeed = 4f;
            }
            else if (fastOrNo == 3)
            {
                bonusSpeed = Neg(23f);
            }
            else if (fastOrNo == 4)
            {
                bonusSpeed = 20f;
            }
            else if (fastOrNo == 5)
            {
                bonusSpeed = 2f;
            }
            asteroidRNGSpeed = asteroidRNGSpeed + bonusSpeed;
            if (asteroidRNGSpeed + bonusSpeed <= 0f)
            {
                asteroidRNGSpeed = 40f;
            }
            if (asteroidRNGSpeed >= 195f)
            {
                asteroidRNGSpeed = 90f;
            }
        }
    }
    float Neg(float value)
    {
        float ret;
        ret = value - (2 * value);
        return ret;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    float spawnY;
    float spawnX;
    float asteroidX;
    float asteroidY;
    float cameraX;
    float cameraY;
    float asteroidNewY;
    float asteroidRNGSpeed;
    float asteroidRotate;
    int fastOrNo;
    int superRNG;
    int rotationDirection;
    float bonusSpeed;
    float baseCameraSize;
    public SpriteRenderer asteroid;
    private Camera CameraMainAsteroid;
    // Use this for initialization
    public SpriteRenderer asteroidRend;
    public SpriteRenderer asteroidRend1;
    public SpriteRenderer asteroidRend2;
    public SpriteRenderer asteroidRend3;
    public SpriteRenderer asteroidRend4;
    public SpriteRenderer asteroidRend5;
    public Transform asteroidTransform;
    void Start()
    {
        StartedAstroids();
    }
    // Update is called once per frame
    void Update()
    {
        Asteroid();
    }
    void StartedAstroids()
    {
        CameraMainAsteroid = Camera.main;
        baseCameraSize = 15f;
        CameraMainAsteroid.orthographicSize = baseCameraSize;
        cameraY = CameraMainAsteroid.orthographicSize;
        cameraX = cameraY * (16f / 9f);
        spawnX = Random.Range(2 * Neg(cameraX) - 5f, Neg(cameraX) - 5f);
        spawnY = Random.Range(Neg(cameraY), cameraY);
        asteroidTransform.Translate(spawnX, spawnY, 10f, Space.World);
        float rngColorR;
        float rngColorG;
        float rngColorB;
        rngColorR = Random.Range(0.01f, 0.2f);
        rngColorG = Random.Range(0.01f, 0.2f);
        rngColorB = Random.Range(0.01f, 0.2f);
        asteroidRend.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend1.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend2.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend3.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend4.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRend5.color = new Color(rngColorR, rngColorG, rngColorB, 1f);
        asteroidRNGSpeed = Random.Range(6f, 75f);
        asteroidRotate = Random.Range(20f, 80f);
        rotationDirection = Random.Range(1, 3);
        if (rotationDirection == 1)
        {
            asteroidRotate = Neg(asteroidRotate);
        }
    }
    void Asteroid()
    {
        cameraY = CameraMainAsteroid.orthographicSize;
        cameraX = cameraY * (16f / 9f);
        asteroidX = asteroid.transform.position.x;
        asteroidY = asteroid.transform.position.y;
        asteroid.transform.Translate(asteroidRNGSpeed * Time.deltaTime, 0f, 0f, Space.World);
        asteroid.transform.Rotate(0f, 0f, asteroidRotate * Time.deltaTime);
        if (asteroidX > cameraX + 2f)
        {
            asteroidNewY = Random.Range(Neg(cameraY), cameraY);
            asteroid.transform.Translate((Neg(cameraX) * 2f) - 5f, Neg(asteroidY) + asteroidNewY, 0f, Space.World);
            asteroidRotate = Random.Range(20f, 300f);
            fastOrNo = Random.Range(1, 6);
            superRNG = Random.Range(1, 60);
            rotationDirection = Random.Range(1, 3);
            if (rotationDirection == 1)
            {
                asteroidRotate = Neg(asteroidRotate);
            }
            if (superRNG == 1)
            {
                asteroidRotate = 700f;
            }
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
                bonusSpeed = Neg(37f);
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
                asteroidRNGSpeed = 10f;
            }
            else if (asteroidRNGSpeed <= 5f)
            {
                asteroidRNGSpeed = 99f;
            }
            if (asteroidRNGSpeed >= 123f)
            {
                asteroidRNGSpeed = 20f;
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

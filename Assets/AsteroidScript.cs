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
    int fastOrNo;
    float bonusSpeed;
    public SpriteRenderer asteroid;
    private Camera CameraMainAsteroid;
    // Use this for initialization
    void Start()
    {
        asteroidRNGSpeed = Random.Range(1f, 75f);
        asteroidX = asteroid.transform.position.x;
        CameraMainAsteroid = Camera.main;
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
        asteroidNewY = Random.Range(Neg(cameraY), cameraY);
        if (asteroidX > cameraX)
        {
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
        }

    }
    float Neg(float value)
    {
        float ret;
        ret = value - (2 * value);
        return ret;
    }
}

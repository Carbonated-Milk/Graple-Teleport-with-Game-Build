using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarryControl : MonoBehaviour
{
    public float timeTake;
    private float moveStop;

    private Vector2[] weightedPositions;
    public float distRadius;

    public float newPower;

    private float time;

    public GameObject bounds;

    // Start is called before the first frame update
    void Start()
    {
        moveStop = 1;
        weightedPositions = new Vector2[4];
        ResetPos();
    }

    // Update is called once per frame
    void Update()
    {
        //new positions if finished curve
        if (time > 1f)
        {
            weightedPositions[1] = velocityPos();
            weightedPositions[0] = weightedPositions[3];

            for (int i = 2; i < weightedPositions.Length; i++)
            {
                weightedPositions[i] = RandomSpace();
            }
            time = 0;
        }

        //position
        transform.position = newPosition();
        time += moveStop * Time.deltaTime / timeTake;
    }

    public void ResetPos()
    {
        //picks 4 new points and resets the bezier curve
        time = 0;
        teleportParticals.Play();
        for (int i = 0; i < weightedPositions.Length; i++)
        {
            weightedPositions[i] = RandomSpace();
        }
        transform.position = newPosition();
        teleportParticals.Play();
    }

    public Vector2 RandomSpace()
    {
        //picks random position in a spherical shell around player
        float arround = Random.Range(0, 2 * Mathf.PI);
        float up = Random.Range(0, Mathf.PI);
        return new Vector2(Mathf.Sin(arround) * Mathf.Sin(up), Mathf.Sin(up), Mathf.Cos(arround) * Mathf.Sin(up)) * distRadius * Random.Range(.5f, 1.5f) + player.transform.position;
    }

    public Vector2 RandomSpace()
    {
        //picks random position in a spherical shell around player
        float arround = Random.Range(0, 2 * Mathf.PI);
        float up = Random.Range(0, Mathf.PI);
        return new Vector2(Mathf.Sin(arround) * Mathf.Sin(up), Mathf.Sin(up), Mathf.Cos(arround) * Mathf.Sin(up)) * distRadius * Random.Range(.5f, 1.5f) + player.transform.position;
    }

    public Vector2 newPosition()
    {
        //finds the place boss should be after the time
        Vector2 newPos = Vector2.zero;
        newPos += weightedPositions[0] * (-Mathf.Pow(time, 3f) + 3 * time * time - 3 * time + 1f);
        newPos += weightedPositions[1] * (3 * Mathf.Pow(time, 3f) - 6 * time * time + 3 * time);
        newPos += weightedPositions[2] * (-3 * Mathf.Pow(time, 3f) + 3 * time * time);
        newPos += weightedPositions[3] * Mathf.Pow(time, 3f);
        return newPos;
    }

    public Vector2 velocityPos()
    {
        // picks second point on bezier curve (first one being the last point on the last bezie curve) so that the path looks smooth
        Vector2 velPos = Vector2.zero;
        velPos += weightedPositions[0] * (-3 * Mathf.Pow(time, 2f) + 6 * time - 3);
        velPos += weightedPositions[1] * (9 * Mathf.Pow(time, 2f) - 12 * time + 3);
        velPos += weightedPositions[2] * (-9 * Mathf.Pow(time, 2f) + 6 * time);
        velPos += weightedPositions[3] * 3 * Mathf.Pow(time, 2f);
        return velPos / (distRadius * newPower) + weightedPositions[3];
    }
}

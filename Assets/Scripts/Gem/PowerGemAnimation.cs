using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGemAnimation : MonoBehaviour
{

    public float SpinAmount = 100f;

    public float SwellSpeed = 1f;

    private Vector3 startScale;

    public Vector3 BigScale = Vector3.one * 1.5f;
    public Vector3 SmallScale = Vector3.one * 0.75f;

    private float timer;

    private bool swellSize;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, SpinAmount * Time.deltaTime); //rotates 50 degrees per second around z axis

        timer += Time.deltaTime * SwellSpeed;

        Vector3 newScale;

        if (swellSize)
        {
            newScale = Vector3.Lerp(startScale, BigScale, timer);
        }
        else
        {
            newScale = Vector3.Lerp(startScale, SmallScale, timer);
        }

        // Lerp wants the third parameter to go from 0 to 1 over time. 't' will do that for us.

        transform.localScale = newScale;

        if(timer > 1f)
        {
            timer = 0f;
            swellSize = !swellSize;
            startScale = transform.localScale;
        }
    }
}

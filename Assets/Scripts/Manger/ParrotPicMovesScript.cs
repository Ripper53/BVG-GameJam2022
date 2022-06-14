using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotPicMovesScript : MonoBehaviour
{

    private Vector3 startPos;
    private Vector3 newPos;

    private Vector3 startScale;
    private Vector3 newScale;

    public float MoveAmount;
    public float MoveAmountX2;
    public float MoveAmountY2;
    public float ScaleAmount;
    public bool isCaptain = false;

    public float ZoomOnParrotTime = 14f;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        startScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCaptain)
        {
            timer += Time.deltaTime;

            if(timer > ZoomOnParrotTime)
            {
                newScale = new Vector3(startScale.x + (ScaleAmount * Time.deltaTime), startScale.y + (ScaleAmount * Time.deltaTime), startScale.z);
                this.gameObject.transform.localScale = newScale;
                startScale = newScale;

                newPos = new Vector3(startPos.x + (MoveAmountX2 * Time.deltaTime), startPos.y + (MoveAmountY2 * Time.deltaTime), startPos.z);
                this.gameObject.transform.position = newPos;
                startPos = newPos;
            }
            else
            {
                newPos = new Vector3(startPos.x + (MoveAmount * Time.deltaTime), startPos.y, startPos.z);
                this.gameObject.transform.position = newPos;
                startPos = newPos;
            }
        }
        else
        {
            newPos = new Vector3(startPos.x + (MoveAmount * Time.deltaTime), startPos.y, startPos.z);
            this.gameObject.transform.position = newPos;
            startPos = newPos;
        }

    }
}

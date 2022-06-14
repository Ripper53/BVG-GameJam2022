using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotPicMovesScript : MonoBehaviour
{

    private Vector3 startPos;
    private Vector3 newPos;

    public float MoveAmount;


    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newPos = new Vector3(startPos.x + MoveAmount, startPos.y, startPos.z);
        this.gameObject.transform.position = newPos;
        startPos = newPos;
    }
}

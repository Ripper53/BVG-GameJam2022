using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code from https://answers.unity.com/questions/931917/animate-image-ui-with-sprite-sheet.html


[RequireComponent(typeof(Image))]
public class UI_Sprite_Animation : MonoBehaviour
{
    public float Duration;

    public bool DelayShowImage = true;

    [SerializeField] private Sprite[] sprites;

    private Image image;
    private int index = 0;
    private float timer = 0;
    private float timer2 = 0;

    private Color spriteColor;

    private float delayedStart = 0.0f;

    void Start()
    {
        image = GetComponent<Image>();
        Duration += Random.Range(-0.5f, 0.5f);

        delayedStart = Random.Range(0.0f, 2.0f);

        if(DelayShowImage)
        {
            spriteColor = image.color;
            spriteColor.a = 0.0f;
            image.color = spriteColor;
        }

#if UNITY_EDITOR
        Debug.Log("Delayed Start time: " + delayedStart);
#endif
    }
    private void Update()
    {
        if ((timer += Time.deltaTime) >= (Duration / sprites.Length))
        {
            timer = 0;
            image.sprite = sprites[index];
            index = (index + 1) % sprites.Length;
        }

        if(DelayShowImage)
        {
            timer2 += Time.deltaTime;

            if (timer2 > delayedStart)
            {
                spriteColor.a += 0.005f;
                image.color = spriteColor;
            }
        }
    }
}

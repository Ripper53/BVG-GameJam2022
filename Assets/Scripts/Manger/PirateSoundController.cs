using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateSoundController : MonoBehaviour
{
    public AudioClip[] PirateIdleSFX;
    public AudioClip[] PirateAngrySFX;
    public AudioClip[] PirateFriendlySFX;

    private float timer = 7f;
    public float IdleCooldown = 10f;

    /*Two different Audio Sources*/
    public AudioSource pirateVOSource;

    private int lastPirateIdleSFX = -1;
    private int lastPirateAngrySFX = -1;
    private int lastPirateFriendlySFX = -1;

    // Start is called before the first frame update
    void Start()
    {
        if(IdleCooldown < 10f)
        {
            IdleCooldown = 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update the game timer
        timer += Time.deltaTime;

        //If the timer is greater than the idle cool down timer
        if(timer > IdleCooldown)
        {
            PlayIdlePirateSFX();
        }
    }

    public void PlayIdlePirateSFX()
    {
        //Make sure no other VO is playing before playing anything
        if (!pirateVOSource.isPlaying)
        {
            //Get a new idle SFX to play
            int NextIdleSFX = Random.Range(0, PirateIdleSFX.Length);

            //Only play it if the next one is not equal to the last one that was played
            if (NextIdleSFX != lastPirateIdleSFX)
            {
                //if they are not equal, then play the new idle SFX
                pirateVOSource.PlayOneShot(PirateIdleSFX[NextIdleSFX]);

                //Save the last SFX that was played
                lastPirateIdleSFX = NextIdleSFX;

                //Reset Ithe dle SFX cooldown timer
                timer = 0.0f;
            }
        }
    }

    public void PlayAngryPirateSFX()
    {
        //Make sure no other VO is playing before playing anything
        if (!pirateVOSource.isPlaying)
        {
            //Get a new angry SFX to play
            int NextAngrySFX = Random.Range(0, PirateAngrySFX.Length);

            //Make sure the new SFX is different from the last one
            while (NextAngrySFX == lastPirateAngrySFX)
            {
                NextAngrySFX = Random.Range(0, PirateAngrySFX.Length);
            }

            //Play a friendly pirate SFX
            pirateVOSource.PlayOneShot(PirateAngrySFX[NextAngrySFX]);

            //Save the last SFX that was played
            lastPirateAngrySFX = NextAngrySFX;

            //Reset the Idle SFX cooldown timer
            timer = 0.0f;
        }

    }

    public void PlayHappyFriendlySFX()
    {
        //Make sure no other VO is playing before playing anything
        if (!pirateVOSource.isPlaying)
        {
            //Get a new happy SFX to play
            int NextFriendlySFX = Random.Range(0, PirateFriendlySFX.Length);

            //Make sure the new SFX is different from the last one
            while (NextFriendlySFX == lastPirateFriendlySFX)
            {
                NextFriendlySFX = Random.Range(0, PirateFriendlySFX.Length);
            }

            //Play a friendly pirate SFX
            pirateVOSource.PlayOneShot(PirateFriendlySFX[NextFriendlySFX]);

            //Save the last SFX that was played
            lastPirateFriendlySFX = NextFriendlySFX;

            //Reset the Idle SFX cooldown timer
            timer = 0.0f;
        }
    }
}

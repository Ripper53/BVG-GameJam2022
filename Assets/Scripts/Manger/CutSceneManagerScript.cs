using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManagerScript : PlayerControls
{
    public Image Scene1Image;
    public Image Scene2Image;
    public Image Scene3Image;
    public Image Scene4Image;

    //Blackscreen for fade in fade out
    public Image BlackScreen;

    //Colour used for the screen fade
    private Color colour;

    //Fade rate
    public float FadeRate;

    //Timer
    private float timer;

    //Sounds
    private GameObject soundControllerObject;

    [Range(0.0f, 1.0f)]
    public float MusicVolumneLevel;
    [Range(0.0f, 2.0f)]
    public float SFXVolumneLevel;


    private int songIndex = 0;

    private int sfxIndex1 = 4;
    private int sfxIndex2 = 5;
    private int sfxIndex3 = 6;
    private int sfxIndex4 = 7;
    private int sfxIndex5 = 8;
    private int sfxIndex6 = 9;
    private int sfxIndex7 = 10;

    private bool playSFXOnce1 = true;
    private bool playSFXOnce2 = true;
    private bool playSFXOnce3 = true;
    private bool playSFXOnce4 = true;
    private bool playSFXOnce5 = true;
    private bool playSFXOnce6 = true;
    private bool playSFXOnce7 = true;

    public float Scene0Duration;
    public float Scene1Duration;
    public float Scene2Duration;
    public float Scene3Duration;
    public float Scene4Duration;
    public float Scene5Duration;
    public float Scene6Duration;
    public float Scene7Duration;
    public float Scene8Duration;

    // Start is called before the first frame update
    void Start()
    { 
        //Start with a black screen
        colour = BlackScreen.color;
        colour.a = 1;
        BlackScreen.color = colour;
        BlackScreen.gameObject.SetActive(true);

        soundControllerObject = GameObject.Find("SoundController");
        soundControllerObject.SendMessage("PlayMusic", songIndex);

        soundControllerObject.SendMessage("SetMusicVolumne", MusicVolumneLevel);
        soundControllerObject.SendMessage("SetSFXVolumne", SFXVolumneLevel);

        Scene1Image.gameObject.SetActive(false);
        Scene2Image.gameObject.SetActive(false);
        Scene3Image.gameObject.SetActive(false);
        Scene4Image.gameObject.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Debug.Log(colour.a);
;
        //Load the main game
        if(timer > Scene8Duration)
        {
            GameManager.Singleton.LoadLevel1();
        }

        //Fade to Black
        else if(timer > Scene8Duration - 2.0f)
        {
            FadeToBlack(true);
        }

        //HEAVE HO WE’VE GOT A BOOTY TO STEAL
        else if (timer > Scene7Duration)
        {
            FadeToBlack(false);
            if (playSFXOnce7)
            {
                Scene4Image.gameObject.SetActive(true);
                Scene3Image.gameObject.SetActive(false);
                soundControllerObject.SendMessage("PlayEffects", sfxIndex7);
                playSFXOnce7 = false;
            }
        }


        //Fade to Black
        else if (timer > Scene7Duration - 2.0f)
        {
            FadeToBlack(true);
        }


        //But do not be distracted by this green shimmering ball of feathers!
        //Our captain gave us a mission: examine the glistering
        //Gem stones on this ship and find the booty of the captain and his green parrot, savvy?
        else if (timer > Scene6Duration)
        {
            FadeToBlack(false);
            if (playSFXOnce6)
            {
                Scene3Image.gameObject.SetActive(true);
                Scene2Image.gameObject.SetActive(false);
                soundControllerObject.SendMessage("PlayEffects", sfxIndex6);
                playSFXOnce6 = false;
            }
        }
        //Fade to Black
        else if (timer > Scene6Duration - 2.0f)
        {
            FadeToBlack(true);
        }


        //Our hero traveled across the briney deep and landed on the enemy's clipper.
        //This is the home of cranky pirates and a lousy captain, and blimey, that fabulous green parrot!
        //He’s so beautiful and smart and his calls can be heard from miles away.
        //[image of the ship, captain and green parrot]
        else if (timer > Scene5Duration)
        {
           
            FadeToBlack(false);
            if (playSFXOnce5)
            {
                Scene2Image.gameObject.SetActive(true);
                Scene1Image.gameObject.SetActive(false);
                soundControllerObject.SendMessage("PlayEffects", sfxIndex5);
                playSFXOnce5 = false;
            }
        }


        //Fade to Black
        else if(timer > Scene5Duration - 2.0f)
        {
            FadeToBlack(true);
        }

        //Will ye help them become the best pirrote ever?
        else if (timer > Scene4Duration)
        {
            if (playSFXOnce4)
            {
                soundControllerObject.SendMessage("PlayEffects", sfxIndex4);
                playSFXOnce4 = false;
            }
        }

        //Our hero might be gray but they can definitely see more colours than ye!
        else if (timer > Scene3Duration)
        {
            if (playSFXOnce3)
            {
                soundControllerObject.SendMessage("PlayEffects", sfxIndex3);
                playSFXOnce3 = false;
            }
        }

        //Didn't you know parrots see more colours than humans 
        else if (timer > Scene2Duration)
        {
            if (playSFXOnce2)
            {
                soundControllerObject.SendMessage("PlayEffects", sfxIndex2);
                playSFXOnce2 = false;
            }
        }

        //Ahoy
        //[image of our gray parrot] 
        else if (timer > Scene1Duration)
        {
            FadeToBlack(false);
            if (playSFXOnce1)
            {
                Scene1Image.gameObject.SetActive(true);
                soundControllerObject.SendMessage("PlayEffects", sfxIndex1);
                playSFXOnce1 = false;
            }
        }
    }

    private void FadeToBlack(bool ToBlack)
    {
        if(ToBlack)
        {
            colour.a += FadeRate;
        }
        else
        {
            colour.a -= FadeRate;
        }
        colour.a = Mathf.Clamp(colour.a, 0.0f, 1.0f);
        BlackScreen.color = colour;
    }

    protected override void AddListeners(PlayerInput input)
    {
        input.Ability.Primary.performed += Primary_performed;
    }

    private void Primary_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //if the player hits spacebar, they can skip the intro
        soundControllerObject.SendMessage("StopEffects");
        GameManager.Singleton.LoadLevel1();
    }

    protected override void RemoveListeners(PlayerInput input)
    {
        input.Ability.Primary.performed -= Primary_performed;
    }
}

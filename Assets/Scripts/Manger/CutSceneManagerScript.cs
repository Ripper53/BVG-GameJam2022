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
    public Image ColourChangingParrotImage;
    public Image ColourChangingParrotImage2;

    //Blackscreen for fade in fade out
    public Image BlackScreen;

    //Colour used for the screen fade
    private Color colourFadeToBlack;

    private float colourParrotHue;
    private float colourParrotSat;
    private float colourParrotBri;

    //Fade rate
    public float FadeRate;
    public float RainbowSpeed = 15f;

    //Timer
    private float timer;

    //Sounds
    private GameObject soundControllerObject;

    [Range(0.0f, 1.0f)]
    public float MusicVolumneLevel;
    [Range(0.0f, 1.0f)]
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

    public float Scene0Duration = 0;
    public float Scene1Duration = 2;
    public float Scene2Duration = 4;
    public float Scene3Duration = 9;
    public float Scene4Duration = 15;
    public float Scene5Duration = 21;
    public float Scene6Duration = 43;
    public float Scene7Duration = 60;
    public float Scene8Duration = 64;

    public GameObject SubtitlesObj;
    private TMPro.TextMeshProUGUI subtitlesText;


    private string subtitle0 = "Ahoy!";
    private string subtitle1A = "Did ye know that parrots can see more colours than humans?";
    private string subtitle1B = "Our hero might be gray but they can definitely see more colours than ye!";
    private string subtitle1C = "Will ye help them become the best parrot ever?";

    private string subtitle2A = "Our hero traveled across the briney deep and landed on the enemy's clipper";
    private string subtitle2B = "This is the home of cranky pirates and a lousy captain, and blimey, that fabulous green parrot!";
    private string subtitle2C = "He’s so beautiful and smart and his calls can be heard from miles away";
    
    private string subtitle3A = "But do not be distracted by this green shimmering ball of feathers!";
    private string subtitle3B = "Our captain gave us a mission: examine the glistering Gem stones on this ship";
    private string subtitle3C = "and find the booty of the captain and his green parrot, savvy?";

    private string subtitle4 = "HEAVE HO WE’VE GOT A BOOTY TO STEAL!!";

    // Start is called before the first frame update
    void Start()
    { 
        //Start with a black screen
        colourFadeToBlack = BlackScreen.color;
        colourFadeToBlack.a = 1;
        BlackScreen.color = colourFadeToBlack;
        BlackScreen.gameObject.SetActive(true);

        soundControllerObject = GameObject.Find("SoundController");
        
        soundControllerObject.SendMessage("SetMusicVolumne", MusicVolumneLevel);
        soundControllerObject.SendMessage("SetSFXVolumne", SFXVolumneLevel);

        soundControllerObject.SendMessage("PlayMusic", songIndex);

        Scene1Image.gameObject.SetActive(false);
        Scene2Image.gameObject.SetActive(false);
        Scene3Image.gameObject.SetActive(false);
        Scene4Image.gameObject.SetActive(false);

        colourParrotHue = 0.0f;
        colourParrotSat = 0.0f;
        colourParrotBri = 1.0f;

        subtitlesText = SubtitlesObj.GetComponent<TMPro.TextMeshProUGUI>();
        subtitlesText.text = "";
    }

    private void ChangeParrot1Colour()
    {
        colourParrotHue += RainbowSpeed / 8000;
        colourParrotSat += RainbowSpeed / 1000;
        colourParrotSat = Mathf.Clamp(colourParrotSat, 0.0f, 1.0f);
        if (colourParrotHue > 1.0f)
        {
            colourParrotHue = 0.0f;
        }
        ColourChangingParrotImage.color = Color.HSVToRGB(colourParrotHue, colourParrotSat, colourParrotBri);
        Debug.Log(colourParrotHue);
    }
    private void ChangeParrot2Colour()
    {
        colourParrotHue += RainbowSpeed / 8000;
        colourParrotSat += RainbowSpeed / 1000;
        colourParrotSat = Mathf.Clamp(colourParrotSat, 0.0f, 1.0f);
        if (colourParrotHue > 1.0f)
        {
            colourParrotHue = 0.0f;
        }
        ColourChangingParrotImage2.color = Color.HSVToRGB(colourParrotHue, colourParrotSat, colourParrotBri);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        //Debug.Log(colourFadeToBlack.a);
;
        //Load the main game
        if(timer > Scene8Duration)
        {
            GameManager.Singleton.LoadLevel1();
        }

        //Fade to Black
        else if(timer > Scene8Duration - 0.5f)
        {
            FadeToBlack(true);
        }

        //HEAVE HO WE’VE GOT A BOOTY TO STEAL
        else if (timer > Scene7Duration)
        {
            FadeToBlack(false);
            if (playSFXOnce7)
            {
                subtitlesText.fontSize = 100;
                subtitlesText.text = subtitle4;
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
        else if (timer > Scene6Duration + 10f)
        {
            ChangeParrot2Colour();
            subtitlesText.text = subtitle3C;
        }
        else if(timer > Scene6Duration + 5.0f)
        {
            ChangeParrot2Colour();
            subtitlesText.text = subtitle3B;
        }    
        
        else if (timer > Scene6Duration)
        {
            ChangeParrot2Colour();
            FadeToBlack(false);
            if (playSFXOnce6)
            {
                subtitlesText.text = subtitle3A;
                Scene3Image.gameObject.SetActive(true);
                Scene2Image.gameObject.SetActive(false);
                soundControllerObject.SendMessage("PlayEffects", sfxIndex6);
                playSFXOnce6 = false;
            }
        }
        //Fade to Black
        else if (timer > Scene6Duration - 2.0f)
        {
            colourParrotHue = 0.0f;
            colourParrotSat = 0.0f;
            FadeToBlack(true);
        }


        //Our hero traveled across the briney deep and landed on the enemy's clipper.
        //This is the home of cranky pirates and a lousy captain, and blimey, that fabulous green parrot!
        //He’s so beautiful and smart and his calls can be heard from miles away.
        //[image of the ship, captain and green parrot]
        else if (timer > Scene5Duration + 14.5f)
        {
            subtitlesText.text = subtitle2C;
        }

        else if(timer > Scene5Duration + 5.5f)
        {
            subtitlesText.text = subtitle2B;
        }    
        
        else if (timer > Scene5Duration)
        {
           
            FadeToBlack(false);
            if (playSFXOnce5)
            {
                subtitlesText.text = subtitle2A;
                Scene2Image.gameObject.SetActive(true);
                Scene1Image.gameObject.SetActive(false);
                soundControllerObject.SendMessage("PlayEffects", sfxIndex5);
                playSFXOnce5 = false;
            }
        }


        //Fade to Black
        else if(timer > Scene5Duration - 2.0f)
        {
            ChangeParrot1Colour();
            FadeToBlack(true);
        }

        //Will ye help them become the best pirrote ever?
        else if (timer > Scene4Duration)
        {
            ChangeParrot1Colour();
            if (playSFXOnce4)
            {
                subtitlesText.text = subtitle1C;
                soundControllerObject.SendMessage("PlayEffects", sfxIndex4);
                playSFXOnce4 = false;
            }
        }

        //Our hero might be gray but they can definitely see more colours than ye!
        else if (timer > Scene3Duration)
        {
            if (playSFXOnce3)
            {
                subtitlesText.text = subtitle1B;
                soundControllerObject.SendMessage("PlayEffects", sfxIndex3);
                playSFXOnce3 = false;
            }
        }

        //Didn't you know parrots see more colours than humans 
        else if (timer > Scene2Duration)
        {
            FadeToBlack(false);
            if (playSFXOnce2)
            {
                subtitlesText.fontSize = 70;
                subtitlesText.text = subtitle1A;
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
                subtitlesText.fontSize = 150;
                subtitlesText.text = subtitle0;
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
            colourFadeToBlack.a += FadeRate;
        }
        else
        {
            colourFadeToBlack.a -= FadeRate;
        }
        colourFadeToBlack.a = Mathf.Clamp(colourFadeToBlack.a, 0.0f, 1.0f);
        BlackScreen.color = colourFadeToBlack;
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

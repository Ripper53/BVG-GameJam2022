using ArtificialIntelligence;
using Physics.Checks;
using UnityEngine;

public abstract class CharacterSoundController : MonoBehaviour {
    public VoiceOverData VoiceOverData;
    public float MinTime, MaxTime;
    public WanderAIWork WanderAIWork;

    public Check TalkCheck;

    public PlayVoiceOver PlayVoiceOver;

    private float timer;
    protected void OnEnable() {
        SetTimer();
    }

    private void SetTimer() {
        timer = Random.Range(MinTime, MaxTime);
    }

    private bool CanPlay => VoiceOverData.Speaking == 0 && TalkCheck.Evaluate();

    protected void Update() {
        if (timer > 0f) {
            // Update the game timer.
            timer -= Time.deltaTime;
        } else if (CanPlay) {
            AudioClip clip = WanderAIWork.CurrentState switch {
                WanderAIWork.State.Chase or WanderAIWork.State.Attack => GetAngrySFX(),
                _ => GetIdleSFX(),
            };
            PlayVoiceOver.Play(clip);

            // Reset the Idle SFX cooldown timer.
            SetTimer();
        }
    }

    protected abstract AudioClip GetAngrySFX();
    protected abstract AudioClip GetIdleSFX();

}

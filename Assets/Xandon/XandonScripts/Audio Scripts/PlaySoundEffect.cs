using UnityEngine;
using System.Collections;

public class PlaySoundEffect : MonoBehaviour {

    public GameObject player;
    AudioSource ExplosionEffectsSource;
    public AudioClip[] ExplosionEffects;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ActionZone"))
        {
            PlaySfx();
        }
    }

    void PlaySfx()
    {
        int randClip = Random.Range(0, ExplosionEffects.Length);
        ExplosionEffectsSource.clip = ExplosionEffects[randClip];
        ExplosionEffectsSource.Play();
    }
}

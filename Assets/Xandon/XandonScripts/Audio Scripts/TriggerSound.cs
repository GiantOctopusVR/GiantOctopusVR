using UnityEngine;
using System.Collections;

public class TriggerSound : MonoBehaviour
{
	public AudioClip[] triggerSounds;
	private float changePitch;
	private float changeVolume;
	private AudioSource AS;

	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
	}


	private void OnTriggerEnter(Collider coll)
	{
		StartCoroutine(playEngineSound());
	}

	public IEnumerator playEngineSound()
	{
		AS.clip = triggerSounds [0];
		AS.Play();
		yield return new WaitForSeconds(triggerSounds [0].length);
	}

}
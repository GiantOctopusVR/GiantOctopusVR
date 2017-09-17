using UnityEngine;
using System.Collections;

public class AnimatedSound : MonoBehaviour {

	public AudioClip[] AudioClipsArray; // this is the public value that you can set after you add the script

	private float changePitch;
	private float changeVolume;

	// Use this for initialization
	void Start () {

	}

	void PlayClip()
	{
		// This sets a variable that we will use to adjust the pitch in the audiosource to a random value between 0.8f and 1.2f
		changePitch = Random.Range(0.8f, 1.2f);

		// This sets a variable that we will use to adjust the volume in the audiosource to a random value between 0.2f and 0.5f
		changeVolume = Random.Range(0.2f, 0.5f);

		// This tells the audiosource to load the first clip (clip 0) from the array
		GetComponent<AudioSource>().clip = AudioClipsArray [0];

		// This sets the pitch to the variable we created
		GetComponent<AudioSource>().pitch = changePitch;

		// This sets the volume to the variable we created
		GetComponent<AudioSource> ().volume = changeVolume;

		// This tells the clip to play
		GetComponent<AudioSource>().Play();
	}


	// Plays a random clip from the array when called 
	void PlayClipRandom()
	{
		// This sets a variable that we will use to adjust the pitch in the audiosource to a random value between 0.8f and 1.2f
		changePitch = Random.Range(0.8f, 1.2f);

		// This sets a variable that we will use to adjust the volume in the audiosource to a random value between 0.2f and 0.5f
		changeVolume = Random.Range(0.2f, 0.5f);

		// This tells the clip to randomly load a clip from the array
		GetComponent<AudioSource>().clip = AudioClipsArray [Random.Range (0, AudioClipsArray.Length)];

		// This sets the pitch to the variable we created
		GetComponent<AudioSource>().pitch = changePitch;

		// This sets the volume to the variable we created
		GetComponent<AudioSource> ().volume = changeVolume;

		// This tells the clip to play
		GetComponent<AudioSource>().Play();
	}
}

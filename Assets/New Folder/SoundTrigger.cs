using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundTrigger : MonoBehaviour
{
    private AudioSource audio;

    public string sceneToLoad = "Baseline";

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            audio.Play();
            StartCoroutine(PlaySoundThenChangeScene());
        }
    }

    private IEnumerator PlaySoundThenChangeScene()
    {
        yield return new WaitForSeconds(audio.clip.length);
        SceneManager.LoadScene("Baseline");
    }
}

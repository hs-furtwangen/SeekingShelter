using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public List<AudioClip> SoundBed;
    public List<AudioClip> Sounds;

    public AudioSource Player1;
    public AudioSource Player2;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Player1.clip = SoundBed[0];
        Player1.loop = true;
        Player1.Play();

        Player2.loop = true;
        Player2.Stop();

        //StartCoroutine(Changeto(1, 4f));
        //StartCoroutine(Changeto(2, 8f));
        //StartCoroutine(Changeto(3, 12f));
        //StartCoroutine(Playone(0, 10f));
    }

    IEnumerator Changeto(int i, float after)
    {
        yield return new WaitForSecondsRealtime(after);
        BackgroundChange(i);
    }

    IEnumerator Playone(int i, float after)
    {
        yield return new WaitForSecondsRealtime(after);
        Playsound(i);
    }

    public void BackgroundChange(int i)
    {
        if (i >= SoundBed.Count)
            return;

        if (!Player1.isPlaying)
        {
            if (Player1.clip != SoundBed[i])
            {
                ArmPlayerOne(i);
            }
            StartCoroutine(CrossfadeTwoOne());
        }
        else
        {
            if (Player2.clip != SoundBed[i])
            {
                ArmPlayerTwo(i);
            }
            StartCoroutine(CrossfadeOneTwo());
        }
    }

    private void ArmPlayerOne(int i)
    {
        if (i >= SoundBed.Count)
            return;

        Player1.Stop();
        Player1.volume = 0;
        Player1.clip = SoundBed[i];
    }

    private void ArmPlayerTwo(int i)
    {
        if (i >= SoundBed.Count)
            return;

        Player2.Stop();
        Player2.volume = 0;
        Player2.clip = SoundBed[i];
    }

    IEnumerator CrossfadeOneTwo()
    {
        Player2.Play();

        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Player1.volume = f;
            Player2.volume = 1 - f;
            yield return null;
        }

        Player1.Stop();
    }
    IEnumerator CrossfadeTwoOne()
    {
        Player1.Play();

        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Player2.volume = f;
            Player1.volume = 1 - f;
            yield return null;
        }

        Player2.Stop();
    }

    public void Playsound(int i)
    {
        if (i >= Sounds.Count)
            return;

        var audios = this.gameObject.AddComponent<AudioSource>();
        audios.clip = Sounds[i];
        audios.loop = false;
        audios.Play();

        Destroy(audios, audios.clip.length + 0.5f);
    }
}



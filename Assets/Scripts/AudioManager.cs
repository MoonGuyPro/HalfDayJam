using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Transform leftWall;
    [SerializeField]
    Transform rightWall;
    [SerializeField]
    AudioSource leftWallSoundEffect;
    [SerializeField]
    AudioSource rightWallSoundEffect;
    void Start()
    {
        rightWallSoundEffect.Play();
        leftWallSoundEffect.Play();
    }

    void Update()
    {
        if (CheckIfIsNearWall(leftWall))
        {
            leftWallSoundEffect.pitch = 5;
        }
        else
        {
            leftWallSoundEffect.pitch = 1;
        }
        if (CheckIfIsNearWall(rightWall))
        {
            rightWallSoundEffect.pitch = 5;
        }
        else
        {
            rightWallSoundEffect.pitch = 1;
        }
        ChangeAudioVolume(leftWallSoundEffect, leftWall);
        ChangeAudioVolume(rightWallSoundEffect, rightWall);
    }

    bool CheckIfIsNearWall(Transform wallTransform)
    {
        if (Mathf.Abs(wallTransform.transform.position.x - gameObject.transform.position.x) <= 1.2f)
            return true;
        else
            return false;

    }

    void ChangeAudioVolume(AudioSource wallSoundEffect, Transform wallTransform)
    {
        float volume = 1 - Mathf.Clamp01(Mathf.Abs(wallTransform.transform.position.x - gameObject.transform.position.x)/10);
        Debug.Log(wallSoundEffect.ToString() + " " + volume);
        wallSoundEffect.volume = volume;
    }
}

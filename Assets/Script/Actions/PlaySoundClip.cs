using UnityEngine;

public class PlaySoundClip : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] float volume;


    public void PlayClip()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }
}

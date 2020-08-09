using UnityEngine;
using System.Collections;

public class SoundStopTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            AudioManager3D.Instance.music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);


    }
}

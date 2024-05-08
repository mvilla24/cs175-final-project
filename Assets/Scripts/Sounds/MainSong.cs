using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSong : MonoBehaviour
{
    AudioSource source;

    static bool hasInstance = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (hasInstance)
        {
            Destroy(gameObject);
        }
        hasInstance = true;
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        yield return new WaitForSeconds(2f);
        source.Play();
    }
}

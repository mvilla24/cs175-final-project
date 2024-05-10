using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlurbs : MonoBehaviour
{
    public Animator blurbAnimation;
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.showedBlurbs)
        {
            return;
        }
        GameData.showedBlurbs = true;
        blurbAnimation.Play("StartBlurb");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

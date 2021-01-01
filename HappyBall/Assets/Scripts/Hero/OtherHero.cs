using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherHero : MonoBehaviour
{
    public int OtherHeroId;
    public float OtherHeroSize = MessageConst.HeroInitSize;
    // Start is called before the first frame update
    private static OtherHero _instance;
    public static OtherHero Instance
    {
        get
        {
            return _instance;
        }
    }

    
}

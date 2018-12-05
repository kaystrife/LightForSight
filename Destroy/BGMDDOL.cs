using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDDOL : MonoBehaviour {

    #region Don't Destroy On Load
    private static bool created = false;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }

        else
            Destroy(gameObject);
    }
    #endregion
}

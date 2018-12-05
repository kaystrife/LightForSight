using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ActionLog : MonoBehaviour {

    #region singleton
    public static ActionLog instance=null;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if (instance !=this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Text[] logText;

    [SerializeField]
    string[] logString;

    bool logIsFull;

	// Use this for initialization
	void Start () {

        logIsFull = false;
        

	}
	
	// Update is called once per frame
	void Update () {
		
        if(logIsFull==false && !logString.Contains(""))
        {
            logIsFull = true;
        }
	}

    public void NewLog(string action)
    {
        if(!logIsFull)
        {
            Debug.Log("Here");
            for (int i = 0; i < logText.Length; i++)
            {
                if (logString[i] == "")
                {
                    logString[i] = action;
                    UpdateLog();
                    return;
                }
            }
        }else
        {
            for (int i = 1; i < logText.Length; i++)
            {
                logString[i - 1] = logString[i];
            }

            logString[logText.Length - 1] = action;
        }

        UpdateLog();

    }

    private void UpdateLog()
    {
        for (int i = 0; i < logText.Length; i++)
        {
            logText[i].text = logString[i];
        }
        
    }
}

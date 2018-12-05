using UnityEngine;
using UnityEngine.UI;

public class LogButton : MonoBehaviour {

    Button logButton;
    ActionLog action;
    bool logOpen;
    public Text plusMinus;

	// Use this for initialization
	void Start () {
        logButton = GetComponent<Button>();
        action = ActionLog.instance;
        logOpen = true;
        plusMinus.text = "-";

        if(logButton!=null)
        {
            logButton.onClick.AddListener(HideOrShowLog);
        }
	}
	
    void HideOrShowLog()
    {
        AudioManager.Play("Click");

        if(logOpen)
        {
            action.gameObject.SetActive(false);
            plusMinus.text = "+";
            logOpen = false;

        }else
        {
            action.gameObject.SetActive(true);
            plusMinus.text = "-";
            logOpen = true;
        }
    }
}

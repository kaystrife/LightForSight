using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour {

    public Text userInput;
    public GameObject userInputBox;
    public GameObject returnMenuButton;

    Button button;
    string _userInput;
    TopScoreManager tsm;
    bool submitted;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();
        tsm = TopScoreManager.instance;

        _userInput = "";
        submitted = false;

        if(button!=null)
        {
            button.onClick.AddListener(SubmitUserInput);
        }
	}
	
	void SubmitUserInput()
    {
        _userInput = userInput.text;

        if(_userInput == "")
        {
            _userInput = "???";
        }

        if(!submitted)
        {
            tsm.SubmitName(_userInput);
            userInputBox.SetActive(false);
            returnMenuButton.SetActive(true);
            submitted = true;
        }

    }
}

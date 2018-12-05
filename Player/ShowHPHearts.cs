using UnityEngine;
using UnityEngine.UI;

public class ShowHPHearts : MonoBehaviour {

    Image[] heartsContainer;
    public Sprite fullHeart;
    public Sprite threeForthsHeart;
    public Sprite halfHeart;
    public Sprite oneForthHeart;
    public Sprite emptyHeart;

    Player player;
    float playerHP;


	void Start () {

        heartsContainer = GetComponentsInChildren<Image>();

        if(heartsContainer != null)
        {
            foreach(Image heart in heartsContainer)
            {
                heart.sprite = fullHeart;
            }
        }else
        {
            Debug.Log("Can't get children components");
            Destroy(gameObject);
        }

        player = Player.instance;
	}
	
	void Update () {
        
        UpdateHearts();

	}

    void UpdateHearts()
    {
        playerHP = player.playerStat.currentHP;
        int numOfHearts = (int)playerHP / 4;
        float lastHeartValue = playerHP % 4;

        Debug.Log(numOfHearts);

        for (int j = 0; j < heartsContainer.Length; j++)
        {
            if (j < numOfHearts)
            {
                heartsContainer[j].sprite = fullHeart;
                Debug.Log("Heart " + j + " full");
            }
            else
            {
                heartsContainer[j].sprite = emptyHeart;
            }
        }


        if (lastHeartValue >= 3f)
        {
            heartsContainer[numOfHearts].sprite = fullHeart;
        }
        else if (lastHeartValue < 3f && lastHeartValue >= 2f)
        {
            heartsContainer[numOfHearts].sprite = threeForthsHeart;
        }
        else if (lastHeartValue < 2f && lastHeartValue >= 1f)
        {
            heartsContainer[numOfHearts].sprite = halfHeart;
        }
        else if (lastHeartValue < 1f && lastHeartValue >0.1f)
        {
            heartsContainer[numOfHearts].sprite = oneForthHeart;
        }
    }

}

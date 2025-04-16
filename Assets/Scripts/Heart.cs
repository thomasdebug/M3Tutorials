using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private Image Images;
    private Image[] hearts;
    private int lives;
    private int maxLives = 0;
    // Start is called before the first frame update
    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        int count = 0;
        foreach (Image img in images)
        {

            if (img.name == "Heart")
            {
                count++;
            }
        }
        hearts = new Image[count];
        count = 0;
        foreach (Image img in images)
        {
            if (img.name == "Heart")
            {
                hearts[count] = img;
                count++;
            }
        }
        lives = hearts.Length;
        maxLives = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void pauseGame()
    {

    }
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= maxLives && value >= 0)
            {
                Debug.Log(5);
                lives = value;
                for (int i = 0; i < hearts.Length; i++)
                {
                    if (i < lives)
                    {
                        hearts[i].enabled = true;
                    }
                    else
                    {
                        hearts[i].enabled = false;
                    }
                }
                if (lives == 0) pauseGame();
            }

        }
    }

}

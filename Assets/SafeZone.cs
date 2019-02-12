using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeZone : MonoBehaviour {

    public GameObject Player;
    public float Radius;

    public GameObject AmmoBox;

    public GameObject Zombie1;
    public GameObject Zombie2;

    public Text welcomeText;
    public Text winText;
    public Text loseText;
    public Text restartText;
    public Text hpText;
    public Text addHpText;
    public Text zoombieText;

    public static float hpValue;
    private const float coef = 5.5f;

    private bool GameOver;
    private bool restart;
    private bool resetHP;
    void Start()
    {
        GameOver = false;
        restart = false;
        resetHP = false;
        hpValue = 100.0f;

        welcomeText.text = "Get to the Helicopter!";
        Destroy(welcomeText, 5f);
    }


    //Update is called once per frame
    void Update () {

        if (hpValue <= 0.0f)
        {
            hpValue = 0.0f;
        }

        if (GameOver && resetHP)
        {
            hpValue = 100.0f;
        }

        hpText.text = "HP: " + hpValue;

        if (Input.GetKeyDown (KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        hpValue -= coef * Time.deltaTime;

        Debug.Log(hpValue);

        float dist1 = Vector3.Distance(Player.transform.position, transform.position);

        if (dist1 < Radius && hpValue > 0.0f)
        {
            winText.text = "Escaped!";
            resetHP = true;
            GameOver = true;
        }

        else if (hpValue <= 0.0f && dist1 > Radius)
        {
            loseText.text = "Died!";
            GameOver = true;
        }

        float dist2 = Vector3.Distance(Player.transform.position, AmmoBox.transform.position);

        if (dist2 < Radius)
        {
            hpValue = 100.0f;
            addHpText.text = "Restored";
            Destroy(addHpText, 3f);
        }

        float dist3 = Vector3.Distance(Player.transform.position, Zombie1.transform.position);

        if (dist3 < Radius)
        {
            hpValue = 0.0f;
            zoombieText.text = "Zoombie!";
            GameOver = true;
        }

        float dist4 = Vector3.Distance(Player.transform.position, Zombie2.transform.position);

        if (dist4 < Radius)
        {
            hpValue = 0.0f;
            zoombieText.text = "Zoombie!";
            GameOver = true;
        }

        if (GameOver == true)
        {
            restartText.text = "Press R to restart";
            restart = true;
            return;
        }
    }
}

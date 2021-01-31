using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questSystem : MonoBehaviour
{
    public GameObject[] Objevtives;
    public string[] Riddles;
    public Text riddleDisplay;
    public Transform player;
    public AudioSource audioS;
    public AudioClip treasurePing;

    private int Progress = 0;
    private float dis;

    private void Start()
    {
        for(int i=0; i< Objevtives.Length; i++)
        {
            Objevtives[i].SetActive(false);
        }
    }

    private void Update()
    {
        dis = Vector3.Distance(player.transform.position, Objevtives[Progress].transform.position);

        riddleDisplay.text = "" + Riddles[Progress];
        Objevtives[Progress].SetActive(true);

        if(dis < 5)
        {
            Objevtives[Progress].SetActive(false);
            audioS.PlayOneShot(treasurePing);
            Progress++;
        }

    }

}

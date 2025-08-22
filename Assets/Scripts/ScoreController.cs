using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ScoreController : MonoBehaviour
{
    public GameObject milesTotal;
    public GameObject milesToGo;
    public GameObject endOfLevel;

    public GameObject player;

    private TMP_Text milesTotalText;
    private TMP_Text milesToGoText;


    private float accumDistance = 0;
    private float prevPositionX = 0;
    private float prevPositionY = 0;


    void Start()
    {
        milesTotalText = milesTotal.GetComponent<TMP_Text>();
        milesToGoText = milesToGo.GetComponent<TMP_Text>();

    }

    void Update()
    {
        if (UnityEngine.Input.anyKey)
        {
            Vector3 worldPosition = transform.position;

            SpriteRenderer spriteRenderer = endOfLevel.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Vector3 spriteCenterWorld = spriteRenderer.bounds.center;
                Debug.Log("Sprite Center World Position: " + spriteCenterWorld);
            }
            Vector3 position = player.transform.position;

            float positionX = Math.Abs(position.x);
            float positionY = Math.Abs(position.y);

            accumDistance += Math.Abs(positionX - prevPositionX) + Math.Abs(positionY - prevPositionY);

            prevPositionX = positionX;
            prevPositionY = positionY;
            milesTotalText.text = Math.Round(accumDistance / 10, 1).ToString() + " miles";
        }
    }
}

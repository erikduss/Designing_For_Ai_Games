using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyvernBoss : MonoBehaviour
{
    public float maxHealth = 1000;
    public float currentHealth = 1000;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentHealth -= 250;
            Debug.Log(currentHealth);
        }
    }

    public void StartPhase2()
    {
        gameManager.CollapsePillars();
    }
}

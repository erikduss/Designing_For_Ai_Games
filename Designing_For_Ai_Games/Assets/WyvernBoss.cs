using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyvernBoss : MonoBehaviour, Provokable
{
    public float maxHealth = 1000;
    public float currentHealth = 1000;

    private GameManager gameManager;
    public Transform currentTarget;

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

    public void Provoked(Transform target)
    {
        if(target != null)
        {
            currentTarget = target;
        }
    }

    public void ClearProvoke()
    {
        if (currentTarget != null)
        {
            currentTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void StartPhase2()
    {
        gameManager.CollapsePillars();
    }
}

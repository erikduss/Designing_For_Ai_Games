using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Animator> pillarAnims = new List<Animator>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollapsePillars()
    {
        StartCoroutine(PillarEvent());
    }
    private IEnumerator PillarEvent()
    {
        pillarAnims[0].Play("PillarFalling");
        yield return new WaitForSeconds(.50f);
        pillarAnims[1].Play("PillarFalling");
    }
}

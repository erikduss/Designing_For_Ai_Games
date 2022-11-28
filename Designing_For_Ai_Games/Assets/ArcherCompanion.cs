using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Companion_Mode
{
    NONE,
    FIND_HEALTH,
    PROVOKE,
    ATTACK
}


public class ArcherCompanion : MonoBehaviour
{
    public Companion_Mode currentActiveMode;
    public Transform provokeFocus;
    public Transform attackFocus;

    [SerializeField] private LayerMask targetLayers;
    private float provokeZone = 25;

    [SerializeField] private TextMeshProUGUI companionModeText; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ChangeActiveMode(Companion_Mode.NONE);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeActiveMode(Companion_Mode.FIND_HEALTH);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeActiveMode(Companion_Mode.PROVOKE);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeActiveMode(Companion_Mode.ATTACK);
        }
    }

    private void ChangeActiveMode(Companion_Mode mode)
    {
        currentActiveMode = mode;
        if(mode != Companion_Mode.PROVOKE && provokeFocus != null)
        {
            Provokable focus = provokeFocus.gameObject.GetComponent<Provokable>();
            if (focus != null) focus.ClearProvoke();
        }

        companionModeText.text = "Current Companion Mode: " + currentActiveMode;
        Debug.Log(currentActiveMode);
    }

    public void ProvokeNearbyEnemies()
    {
        provokeFocus = ScanNearBy();
        if (provokeFocus == null)
        {
            ChangeActiveMode(Companion_Mode.NONE);
        }
        else
        {
            Provokable focus = provokeFocus.gameObject.GetComponent<Provokable>();
            if (focus != null) focus.Provoked(this.transform);
        }
    }

    public void EnemyFocus()
    {
        attackFocus = ScanNearBy();
        if (attackFocus == null)
        {
            ChangeActiveMode(Companion_Mode.NONE);
        }
    }

    private Transform ScanNearBy()
    {
        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, provokeZone, targetLayers, QueryTriggerInteraction.UseGlobal);
        Transform closestTarget = null;
        if (nearbyTargets.Length <= 0) return null;
        float closest = 100;

        for (int i = 0; i < nearbyTargets.Length; i++)
        {
            float dist = Vector3.Distance(nearbyTargets[i].transform.position, transform.position);

            if (dist < closest)
            {
                closestTarget = nearbyTargets[i].transform;
                closest = dist;
            }
        }
        return closestTarget;
    }
}

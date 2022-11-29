using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;
using TMPro;

public class SetTMPText : ActionTask
{
    public BBParameter<TextMeshPro> textComponent;
    public BBParameter<string> textToSet;

    protected override void OnExecute()
    {
        if (textComponent == null) EndAction(false);

        if (textComponent != null)
        {
            textComponent.value.text = textToSet.value;
        }

        EndAction(true);
    }
}

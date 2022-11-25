using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class GetObjectRotation : ActionTask
{
    public BBParameter<Transform> transformToRead;
    public BBParameter<Quaternion> QuaterionToSaveTo;

    protected override void OnExecute()
    {
        Quaternion newQuaternion = transformToRead.value.transform.rotation;

        if (newQuaternion == null) EndAction(false);

        QuaterionToSaveTo.value = newQuaternion;
        EndAction(true);
    }
}

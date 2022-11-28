using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Provokable
{
    void Provoked(Transform target);
    void ClearProvoke();
}

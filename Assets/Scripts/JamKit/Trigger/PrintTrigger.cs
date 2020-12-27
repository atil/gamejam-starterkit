using UnityEngine;
using System.Collections;

public class PrintTrigger : TriggerBase
{
    protected override bool TriggerOnce => false;

    // Example trigger usage
    protected override void OnTriggered()
    {
        Debug.Log("triggered!");
    }
}
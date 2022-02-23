using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusTriggerTest : MonoBehaviour
{
    public string messageName;
    public string tagName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagName))
        {
            Fungus.Flowchart.BroadcastFungusMessage(messageName);

            Debug.Log(other.name);
        }
    }
}

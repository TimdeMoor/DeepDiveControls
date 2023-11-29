using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterDelay : MonoBehaviour
{
    [SerializeField][Range(1f, 10f)] private float DelayInSec = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Destroy), DelayInSec);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleNote : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}

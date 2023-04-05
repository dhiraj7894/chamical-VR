using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCatcher : MonoBehaviour
{
    [SerializeField] GameObject _tube;

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log($"Tube: {(other != _tube)} Tag: {(other.tag == "Filler")}");
        Debug.Log($"Other Tag: {other.tag} Name: {other.name}");

        if (other != _tube && other.CompareTag("Filler"))
        {
            print("Hit and Run: " + other.name);
            other.GetComponentInParent<TestTube>().ChangeVolume(0.0005f);
        }
    }
}

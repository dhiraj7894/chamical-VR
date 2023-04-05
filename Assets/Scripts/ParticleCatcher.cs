using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCatcher : MonoBehaviour
{
    [SerializeField] GameObject _tube;

    private void Start()
    {

    }

    public Color GetEndSideColor()
    {
        return _tube.GetComponentInParent<TestTube>().EndSideColor;
    }
    
    public Color GetEndTopColor()
    {
        return _tube.GetComponentInParent<TestTube>().EndTopColor;
    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log($"Tube: {(other != _tube)} Tag: {(other.tag == "Filler")}");
        Debug.Log($"Other Tag: {other.tag} Name: {other.name}");

        if (other != _tube && other.CompareTag("Filler"))
        {
            if (_tube.GetComponentInParent<TestTube>().hasExplosive)
            {
                other.GetComponentInParent<TestTube>().SpawnExplosion(transform.position);
                GetComponent<ParticleSystem>().Stop();

                gameObject.SetActive(false);
                GameManager.Instance.StopGame();

                return;
            }

            print("Hit and Run: " + other.name);
            other.GetComponentInParent<TestTube>().ChangeVolume(0.0005f);
            other.GetComponentInParent<TestTube>().ChangeColor(GetEndSideColor(), GetEndTopColor());
        }
    }
}

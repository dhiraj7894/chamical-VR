using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTube : MonoBehaviour
{
    [SerializeField] float _dropRate; 
    [SerializeField] Renderer _renderer;
    [SerializeField] ParticleSystem _flow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Dot(transform.up, Vector3.down) > 0) && _renderer.material.GetFloat("_Fill") >= 0.2f)
        {
            ChangeVolume(-_dropRate);

            _flow.Play();
        }
        else
        {
            _flow.Stop();
        }

        if (_renderer.material.GetFloat("_Fill") < 0.2f)
        {
            _renderer.material.SetFloat("_Fill", 0);
        }
    }

    public void ChangeVolume(float volume)
    {
        _renderer.material.SetFloat("_Fill", _renderer.material.GetFloat("_Fill") + volume);
    }
}

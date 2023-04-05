using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestTube : MonoBehaviour
{
    public bool hasExplosive;

    [Space]
    [SerializeField] GameObject _win;
    [SerializeField] GameObject _explosion;
    [Space]

    [SerializeField] float _dropRate; 
    [SerializeField] Renderer _renderer;
    [SerializeField] ParticleSystem _flow;

    public Color EndSideColor, EndTopColor;

    // Start is called before the first frame update
    void Start()
    {

    }

    public Color GetSideColor()
    {
        return _renderer.material.GetColor("_SideColor");
    }

    public Color GetTopColor()
    { 
        return _renderer.material.GetColor("_TopColor");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Dot(transform.up, Vector3.down) > 0) && _renderer.material.GetFloat("_Fill") >= 0.4f)
        {
            ChangeVolume(-_dropRate);

            _flow.Play();
        }
        else
        {
            _flow.Stop();
        }

        if (_renderer.material.GetFloat("_Fill") < 0.4f)
        {
            _renderer.material.SetFloat("_Fill", 0);
        }
        else if(_renderer.material.GetFloat("_Fill") > 0.8f)
        {
            Instantiate(_win, _flow.transform.position, Quaternion.identity);
            enabled = false;
        }
    }

    public void ChangeVolume(float volume)
    {
        _renderer.material.SetFloat("_Fill", _renderer.material.GetFloat("_Fill") + volume);
    }


    public void ChangeColor(Color Side, Color Top)
    {
        Color newSide = Color.Lerp(GetSideColor(), Side, .01f);
        _renderer.material.SetColor("_SideColor", newSide);
        
        Color newTop = Color.Lerp(GetTopColor(), Top, .01f);
        _renderer.material.SetColor("_TopColor", newTop);
    }

    public void SpawnExplosion(Vector3 pos)
    {
        Instantiate(_explosion, pos, Quaternion.identity);
    }
}

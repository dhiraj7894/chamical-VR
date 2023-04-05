using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandsPhysics : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Renderer NonPhysicsHands;
    [SerializeField] float MaxDistanceBetweenHands = 0.2f;

    List<Collider> _colliders;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _colliders = GetComponentsInChildren<Collider>().ToList();
    }

    public void EnableColliders()
    {
        foreach (var item in _colliders)
        {
            item.enabled = true;
        }
    }

    public void EnableColliderWithDelay(float delay)
    {
        Invoke(nameof(EnableColliders), delay);
    }
    
    public void DisableColliders()
    {
        foreach (var item in _colliders)
        {
            item.enabled = false;
        }
    }

    private void Update()
    {
        float dis = Vector3.Distance(transform.position, _target.position);

        NonPhysicsHands.enabled = dis > MaxDistanceBetweenHands;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = (_target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion rotationDiffrence = _target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDiffrence.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDiffrenceInDegree = angleInDegree * rotationAxis;

        _rb.angularVelocity = (rotationDiffrenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}

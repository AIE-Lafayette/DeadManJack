using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterBehavior : MonoBehaviour
{
    [SerializeField]
    private BulletBehavior _bulletRef;
    [SerializeField]
    private float _bulletForce;
    [SerializeField]
    private GameObject _owner;

    public GameObject Owner
    {
        get { return _owner; }
    }

    public BulletBehavior BulletRef
    {
        get { return _bulletRef; }
        set { _bulletRef = value; }
    }

    public virtual void Fire()
    {
        GameObject bullet = Instantiate(_bulletRef.gameObject, transform.position, transform.rotation);
        BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
        bulletBehavior.Owner = _owner;
        bulletBehavior.OwnerTag = _owner.tag;     
        bulletBehavior.Rigidbody.AddForce(transform.forward * _bulletForce, ForceMode.Impulse);
    }
}

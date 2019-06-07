using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HeadBird : MonoBehaviour
{


    public class OnHeadShootEventArgs : EventArgs
    {
        public bool HeadShoot=false;
    }
    public EventHandler<OnHeadShootEventArgs> _onHeadShoot;
    private void OnHeadShoot(OnHeadShootEventArgs args)
    {
        if (_onHeadShoot != null)
            _onHeadShoot(this, args);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("head hit");
        if (other.gameObject.tag == "arow")
        {
            OnHeadShoot(new OnHeadShootEventArgs { HeadShoot = true });

        }

    }
}

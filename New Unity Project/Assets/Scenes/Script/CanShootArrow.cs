using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanShootArrow : MonoBehaviour
{
    private int arrowsLeft;
    
    // Start is called before the first frame update
    void Awake()
    {
        arrowsLeft = DataContainer.singleton.PlayerData.player.arrowInQuiver;
    }

    public class OnShootingAllowEventArgs : EventArgs
    {
        public bool allowShootingCheck;
    }

    public EventHandler<OnShootingAllowEventArgs> _allowShooting;

    private void OnShootingAllow(OnShootingAllowEventArgs e)
    {
        if (_allowShooting != null)
            _allowShooting(this, e);
    }



    public void OnMouseClicEventHandler()
    {
        if (arrowsLeft > 0)
        {
            arrowsLeft--;
            OnShootingAllow(new OnShootingAllowEventArgs { allowShootingCheck = true });
        }
        else
        {
            OnShootingAllow(new OnShootingAllowEventArgs { allowShootingCheck = false });
        }
    }
}

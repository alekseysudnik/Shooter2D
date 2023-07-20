using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Shoot()
    { }

    public event EventHandler OnShoot;
    public event EventHandler OnRecharged;
}

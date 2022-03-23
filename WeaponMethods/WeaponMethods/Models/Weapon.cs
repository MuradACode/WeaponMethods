using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponMethods.Models
{
    public class Weapon
    {
        private int _magazine;
        private int _bulletCount;
        private bool _fireMode;
        public int Magazine { get => _magazine; set => _magazine = value; }
        public int BulletCount { get => _bulletCount; set => _bulletCount = value; }
        public bool FireMode { get => _fireMode; set => _fireMode = value; }
        public Weapon(int magazine, int bulletCount, bool fireMode)
        {
            Magazine = magazine;
            BulletCount = bulletCount;
            FireMode = fireMode;
        }
        public void Shoot()
        {
            if (_bulletCount != 0)
            {
                --_bulletCount;
            }
        }
        public void Fire()
        {
            if (_fireMode == true)
            {
                if (_bulletCount != 0)
                {
                    _bulletCount--;
                }
            }
            else
            {
                _bulletCount = 0;
            }
        }
        public int GetRemainBulletCount()
        {
            return _magazine - _bulletCount;
        }
        public void Reload()
        {
            _bulletCount = _magazine;
        }
        public void ChangeFireMode()
        {
            if (_fireMode == true)
            {
                FireMode = false;
            }
            else
            {
                FireMode = true;
            }
        }
    }
}


using Sirenix.OdinInspector;
using UnityEngine;


namespace Jam.LM44
{


    public class InteractionManager : MonoBehaviour
    {
        public PlayMakerFSM fsm;

        public GameObject weaponPrefab;
        public Transform weaponRoot;

        public GameObject bulletPrefab;

        [ReadOnly] public Hitter weapon;

        public void Start()
        {
            if ( weaponPrefab != null )
                Equip(weaponPrefab);
        }

        public void Equip(GameObject prefab)
        {
            var w = Instantiate(prefab, weaponRoot);
            w.transform.localPosition = Vector3.zero;
            w.transform.localRotation = Quaternion.identity;

            weapon = w.GetComponentInChildren<Hitter>();

        }

        public void ActiveWeapon()
        {
            if ( weapon != null )
            weapon.IsOn = true;
        }

        public void DisactiveWeapon()
        {
            if ( weapon != null )
            weapon.IsOn = false;
        }

        public void Update()
        {
            //if (Input.GetKey(KeyCode.Mouse0)) // main shoot
            //{
            //    fsm.SendEvent("do_action_shoot");
            //}

            if (Input.GetKeyDown(KeyCode.Space)) // hit
            {

                fsm.SendEvent("do_action_hit");
            }
        }

        public void ShootBullet()
        {
            var b = Instantiate(bulletPrefab) as GameObject;

            var bullet = b.GetComponent<Bullet>();
            bullet.Shoot(weaponRoot);
        }
    }

}
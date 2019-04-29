
using Sirenix.OdinInspector;
using UnityEngine;


namespace Jam.LM44
{


    public class InteractionManager : MonoBehaviour
    {

        private static InteractionManager m_instance;

        public static InteractionManager instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = GameObject.FindObjectOfType<InteractionManager>();

                }

                return m_instance;
            }
        }

        public PlayMakerFSM fsm;

        public GameObject weaponPrefab;
        public Transform weaponRoot;

        public float tollerateWeight = 5f;

        public GameObject bulletPrefab;

        [ReadOnly] public Hitter weapon;
        [ReadOnly] public GameObject temWeapon;

        public void Start()
        {
            if ( weaponPrefab != null )
                Equip(weaponPrefab);
        }

        public void Equip(GameObject prefab)
        {
            if ( temWeapon != null )
                Destroy(temWeapon);


            temWeapon = Instantiate(prefab, weaponRoot);


            temWeapon.transform.localPosition = Vector3.zero;
            temWeapon.transform.localRotation = Quaternion.identity;
            temWeapon.layer = LayerMask.NameToLayer("Hitter");
            if ( temWeapon.GetComponent<Collider>() != null )
                temWeapon.GetComponent<Collider>().isTrigger = true;

            var temPickable = temWeapon.GetComponent<PickSelectable>();
            if (temPickable != null)
                temPickable.DisableInteraction();

            Destroy(temWeapon.GetComponent<Hitable>());
            
            Destroy(temWeapon.GetComponent<Rigidbody>());

            PlayHitableSound(temWeapon);
            Debug.Log("Equip " + prefab.name);

            Destroy(prefab);
        }

        public void PlayHitableSound(GameObject obj)
        {
            var hitSound = obj.GetComponent<HitSound>();
            if ( hitSound != null )
                AudioSource.PlayClipAtPoint(hitSound.sound,obj.transform.position);
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
            if (Input.GetKey(KeyCode.Space)) // main shoot
            {
                fsm.SendEvent("do_action_shoot");
            }

        }

        public void ShootBullet()
        {

            if (temWeapon != null)
            {
                PlayHitableSound(temWeapon);

                var b = Instantiate(temWeapon) as GameObject;

                var hitter = b.GetComponent<Hitter>();
                if (hitter != null)
                    Destroy(hitter);
                var bullet = b.AddComponent<Bullet>();
                bullet.IsOn = true;

                var rigid = b.GetComponent<Rigidbody>();
                if (rigid == null)
                    rigid = b.AddComponent<Rigidbody>();
                rigid.isKinematic = false;
                bullet.rigidbody = rigid;
                bullet.Shoot(temWeapon.transform);
                bullet.Dmg = temWeapon.GetComponent<PickSelectable>().tempWeight;

                b.GetComponent<Collider>().isTrigger = false;
                b.layer = LayerMask.NameToLayer("Hitter");

                var autoDestory = b.AddComponent<AutoDestory>();
                autoDestory.DestoryTime = 20;
                autoDestory.BeginDestory();
            }
        }
    }

}
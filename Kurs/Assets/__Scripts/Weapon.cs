using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    none,
    blaster,
    spread,
    phazer,
    minigun,
    missile,
    laser,
    rifle,
    shield
}

[System.Serializable]
public class WeaponDefinition
{
    public WeaponType type = WeaponType.none;
    public string letter;

    public Color color = Color.white;
    public GameObject projectilePrefab;
    public Color projectileColor = Color.white;
    public float damageOnHit = 0;
    public float continuousDamage = 0;

    public float delayBetweenShots = 0;
    public float velosity = 20;
}

public class Weapon : MonoBehaviour
{
    static public Transform PROJECTILE_ANCHOR;

    [Header("Set Dynamically")]
    [SerializeField]
    private WeaponType _type = WeaponType.none;
    public WeaponDefinition def;
    public GameObject collar;
    public float lastShotTime;
    private Renderer collarRend;
    private float bulletAngle=1;
    private bool bulletAngleB = true;

    private void Start()
    {
        collar = transform.Find("Collar").gameObject;
        collarRend = collar.GetComponent<Renderer>();

        SetType(type);
        if(PROJECTILE_ANCHOR == null)
        {
            GameObject go = new GameObject("_ProjectileAnchor");
            PROJECTILE_ANCHOR = go.transform;
        }
        GameObject rootGO = transform.root.gameObject;
        if (rootGO.GetComponent<Hero>() != null)
        {
            rootGO.GetComponent<Hero>().fireDelegate += Fire;
        }
    }

  /*  private void Update()
    {
        bulletAngle =Mathf.Cos(bulletAngle + 10)*0.5f;
    }*/

    public WeaponType type
    {
        get { return (_type); }
        set { SetType(value); }
    }
    public void SetType(WeaponType wt)
    {
        _type = wt;
        if(type == WeaponType.none)
        {
            this.gameObject.SetActive(false);
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        def = Main.GetWeaponDefinition(_type);
        collarRend.material.color = def.color;
        lastShotTime = 0;
    }

    public void Fire()
    {
        if (!gameObject.activeInHierarchy) return;
        if(Time.time - lastShotTime < def.delayBetweenShots)//!
        {
            return;
        }
        Projectile p;
        Vector3 vel = Vector3.up * def.velosity;
        if(transform.up.y < 0)
        {
            vel.y = -vel.y;
        }
        switch (type)
        {
            case WeaponType.blaster:
                p = MakeProjectile();
                p.rigid.velocity = vel;
                break;          
            case WeaponType.spread:
                p = MakeProjectile();
                p.rigid.velocity = vel;
                p = MakeProjectile();
                p.transform.rotation = Quaternion.AngleAxis(10, Vector3.back);
                p.rigid.velocity = p.transform.rotation * vel;
                p = MakeProjectile();
                p.transform.rotation = Quaternion.AngleAxis(-10, Vector3.back);
                p.rigid.velocity = p.transform.rotation * vel;
                break;
            case WeaponType.minigun:
                p = MakeProjectile();
                p.transform.rotation = Quaternion.AngleAxis(Time.time * 60f %25*bulletAngle, Vector3.back);
                if (bulletAngleB)
                {
                    bulletAngle = -1;
                    bulletAngleB = false;
                }
                else
                {
                    bulletAngle = 1;
                    bulletAngleB = true;
                }
                p.rigid.velocity = p.transform.rotation * vel;
                break;
            case WeaponType.phazer:
                p = MakeProjectile();
                Vector3 tempPos = p.transform.position;
                float x0 = p.transform.position.x;  
                float theta = Mathf.PI * 6 * Time.time / 2;
                float sin = Mathf.Sin(theta);
                tempPos.x = x0 + 3 * sin;
                tempPos.y += 1.5f;
                p.transform.position = tempPos;
                p.rigid.velocity = vel;
                break;
            case WeaponType.laser:
                p = MakeProjectile();
                p.rigid.velocity = vel;
                break;
            case WeaponType.rifle:
                p = MakeProjectile();
                p.rigid.velocity = vel;
                break;
            case WeaponType.missile:
                p = MakeProjectile();

                break;

        }

       
        }
    public Projectile MakeProjectile()
    {
        GameObject go = Instantiate<GameObject>(def.projectilePrefab);

            go.tag = "ProjectileHero";
            go.layer = LayerMask.NameToLayer("ProjectileHero");
       
        go.transform.position = collar.transform.position;
        go.transform.SetParent(PROJECTILE_ANCHOR, true);
        Projectile p = go.GetComponent<Projectile>();
        p.type = type;
        lastShotTime = Time.time;
        return (p);
    }

}

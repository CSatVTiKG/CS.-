using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_5 : Enemy
{
    [Header("Set in Inspector:Enemy_5")]
    public Part[] parts;
    public GameObject projectilePrefab;
    public float projectileSpeed;

    private Vector3 p0, p1;
    private float timeStart;
    private float duration = 4;
    private float lastShotTime;
    private float bulletAngle = 1;
    private bool bulletAngleB = true;
    private float phase2Iter;
    private int vaveNumber = 1;



    private void Start()
    {
        p0 = p1 = pos;
        InitMovement();

        Transform t;
        foreach (Part prt in parts)
        {
            t = transform.Find(prt.name);
            if (t != null)
            {
                prt.go = t.gameObject;
                prt.mat = prt.go.GetComponent<Renderer>().material;
            }
        }
        lastShotTime = 0;
    }

    
    public override void Move()
    {
        float u = (Time.time - timeStart) / duration;
        if (u >= 1)
        {
            InitMovement();
            u = 0;
        }
        //u = 1 - Mathf.Pow(1 - u, 2);

        pos = (1 - u) * p0 + u * p1;

        if (Time.time - lastShotTime > fireRate)
        {
            if (!Destroyed("LeftWing"))
            {
                FirePhase1LeftWing();
            }
            if (!Destroyed("RightWing"))
            {
                FirePhase1RightWing();
            }
            if (Destroyed("LeftWing") && Destroyed("RightWing")){
                fireRate = 0.3f;
                projectileSpeed = 15;
                FirePhase2();
            }
            if (Destroyed("Body"))
            {
                fireRate = 0.5f;
                projectileSpeed = 25;

                Main.S.enemySpawnPerSecond = 2;
                FirePhase3();
            }
            
            
        }
        
    }

    private void InitMovement()
    {
        p0 = p1;
        float widMinRad = bndCheck.camWidth - bndCheck.radius;
        float hgtMinRad = bndCheck.camHeight - bndCheck.radius;
        p1.x = Random.Range(-widMinRad, widMinRad);
        p1.y = Random.Range(-hgtMinRad, hgtMinRad) + bndCheck.camHeight*0.8f;

        timeStart = Time.time;
    }
    private Part FindPart(string n)
    {
        foreach (Part prt in parts)
        {
            if (prt.name == n)
            {
                return (prt);
            }
        }
        return (null);
    }
    private Part FindPart(GameObject go)
    {
        foreach (Part prt in parts)
        {
            if (prt.go == go)
            {
                return (prt);
            }
        }
        return (null);
    }

    private bool Destroyed(GameObject go)
    {
        return (Destroyed(FindPart(go)));
    }

    private bool Destroyed(string n)
    {
        return (Destroyed(FindPart(n)));
    }

    private bool Destroyed(Part prt)
    {
        if (prt == null)
        {
            return (true);
        }
        return (prt.health <= 0);
    }

    private void ShowLocalizedDamage(Material m)
    {
        m.color = Color.red;
        damageDoneTime = Time.time + showDamageDuration;
        showingDamage = true;
    }
    private void OnCollisionEnter(Collision coll)
    {
        GameObject other = coll.gameObject;
        switch (other.tag)
        {
            case "ProjectileHero":
                Projectile p = other.GetComponent<Projectile>();
                if (!bndCheck.isOnScreen)
                {
                    Destroy(other);
                    break;
                }
                GameObject goHit = coll.contacts[0].thisCollider.gameObject;
                Part prtHit = FindPart(goHit);
                if (prtHit == null)
                {
                    goHit = coll.contacts[0].otherCollider.gameObject;
                    prtHit = FindPart(goHit);
                }
                if (prtHit.protectedBy != null)
                {
                    foreach (string s in prtHit.protectedBy)
                    {
                        if (!Destroyed(s))
                        {
                            Destroy(other);
                            return;
                        }
                    }
                }
                prtHit.health -= Main.GetWeaponDefinition(p.type).damageOnHit;
                ShowLocalizedDamage(prtHit.mat);
                if (prtHit.health <= 0)
                {
                    prtHit.go.SetActive(false);
                }
                bool allDestroyed = true;
                foreach (Part prt in parts)
                {
                    if (!Destroyed(prt))
                    {
                        allDestroyed = false;
                        break;
                    }
                }
                if (allDestroyed)
                {
                    Main.S.ShipDestroyed(this);
                    Destroy(this.gameObject);
                    NextWave();
                    HighScore.currentScore += score;
                }
                Destroy(other);
                break;

        }
    }

    private void FirePhase1RightWing()
    {
        Vector3 vec;

        GameObject projGOR1 = Instantiate<GameObject>(projectilePrefab);
        GameObject projGOR2 = Instantiate<GameObject>(projectilePrefab);
        GameObject projGOR3 = Instantiate<GameObject>(projectilePrefab);
        

        vec = transform.position;

        vec.x += 5;
        projGOR1.transform.position = vec;
        vec.x += 5;
        projGOR2.transform.position = vec;
        vec.x += 5;
        projGOR3.transform.position = vec;


        Rigidbody rigidBR1 = projGOR1.GetComponent<Rigidbody>();
        Rigidbody rigidBR2 = projGOR2.GetComponent<Rigidbody>();
        Rigidbody rigidBR3 = projGOR3.GetComponent<Rigidbody>();

        Projectile projR1 = projGOR1.GetComponent<Projectile>();
        Projectile projR2 = projGOR2.GetComponent<Projectile>();
        Projectile projR3 = projGOR3.GetComponent<Projectile>();


        projR1.type = WeaponType.blaster;
        projR2.type = WeaponType.blaster;
        projR3.type = WeaponType.blaster;


        rigidBR1.velocity = Vector3.down * projectileSpeed;
        rigidBR2.velocity = Vector3.down * projectileSpeed;
        rigidBR3.velocity = Vector3.down * projectileSpeed;

        lastShotTime = Time.time;
    }

    private void FirePhase1LeftWing()
    {
        Vector3 vec;

        GameObject projGOL1 = Instantiate<GameObject>(projectilePrefab);
        GameObject projGOL2 = Instantiate<GameObject>(projectilePrefab);
        GameObject projGOL3 = Instantiate<GameObject>(projectilePrefab);

        vec = transform.position;


        vec = transform.position;
        vec.x -= 5;
        projGOL1.transform.position = vec;
        vec.x -= 5;
        projGOL2.transform.position = vec;
        vec.x -= 5;
        projGOL3.transform.position = vec;


        Rigidbody rigidBL1 = projGOL1.GetComponent<Rigidbody>();
        Rigidbody rigidBL2 = projGOL2.GetComponent<Rigidbody>();
        Rigidbody rigidBL3 = projGOL3.GetComponent<Rigidbody>();

        Projectile projL1 = projGOL1.GetComponent<Projectile>();
        Projectile projL2 = projGOL2.GetComponent<Projectile>();
        Projectile projL3 = projGOL3.GetComponent<Projectile>();


        projL1.type = WeaponType.blaster;
        projL2.type = WeaponType.blaster;
        projL3.type = WeaponType.blaster;


        rigidBL1.velocity = Vector3.down * projectileSpeed;
        rigidBL2.velocity = Vector3.down * projectileSpeed;
        rigidBL3.velocity = Vector3.down * projectileSpeed;


        lastShotTime = Time.time;
    }

    private void FirePhase2()
    {
        Projectile p;
        Vector3 vel = Vector3.down * projectileSpeed;
        p = MakeProjectile();
        p.transform.rotation = Quaternion.AngleAxis(Time.time * 60f % 25 * bulletAngle, Vector3.back);
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
    }

    private void FirePhase3()
    {
        Projectile p;

        Vector3 vel = Vector3.down * projectileSpeed;
        p = MakeProjectile();
        Vector3 tempPos = p.transform.position;


        p = MakeProjectile();
       
        p.transform.rotation = Quaternion.AngleAxis(30 + Time.time*10f, Vector3.back);
        p.rigid.velocity = p.transform.rotation * vel;
        p = MakeProjectile();
   
        p.transform.rotation = Quaternion.AngleAxis(120 + Time.time*10f, Vector3.back);
        p.rigid.velocity = p.transform.rotation * vel;
        p = MakeProjectile();
        
        p.transform.rotation = Quaternion.AngleAxis(-60+Time.time*10f, Vector3.back);
        p.rigid.velocity = p.transform.rotation * vel;
        p = MakeProjectile();
        
        p.transform.rotation = Quaternion.AngleAxis(210 + Time.time*10f, Vector3.back);
        p.rigid.velocity = p.transform.rotation * vel;
    }

    private void NextWave()
    {
        Main.S.enemySpawnPerSecond = 0.5f + vaveNumber * 0.2f;
        fireRate = 1 + vaveNumber * 0.2f;
        if (fireRate >= 2.5f)
        {
            fireRate = 2.5f;
        }
        projectileSpeed = 10 + vaveNumber;
        if(projectileSpeed >= 40)
        {
            projectileSpeed = 40;
        }
        vaveNumber++;
    }

    public Projectile MakeProjectile()
    {
        GameObject go = Instantiate<GameObject>(projectilePrefab);
      
        go.tag = "ProjectileEnemy";
        go.layer = LayerMask.NameToLayer("ProjectileEnemy");
        
        go.transform.position = transform.position;
        
        Projectile p = go.GetComponent<Projectile>();
        p.type = WeaponType.blaster;
        lastShotTime = Time.time;
        return (p);
    }
    
}

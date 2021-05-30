using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    [Header("Set in Inspector: Enemy_1")]
    public float waveFrequency = 2;
    public float waveWidth = 4;
    public float waveRotY = 45;
    public float lastShotTime;
    public WeaponDefinition WD;

    public GameObject projectilePrefab;
    public float projectileSpeed;

    private float x0;
    private float birthTime;

    

    private void Start()
    {

        x0 = pos.x;
        birthTime = Time.time;
        lastShotTime = 0;
        
    }



    
    public override void Move()
    {
        
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);
        if (Time.time - lastShotTime > fireRate)
        {
            Fire();
        }

        base.Move();
    }

    private void Fire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        

        Projectile proj = projGO.GetComponent<Projectile>();
        proj.type = WD.type;

        rigidB.velocity = Vector3.down * projectileSpeed;
        lastShotTime = Time.time;
    }


}

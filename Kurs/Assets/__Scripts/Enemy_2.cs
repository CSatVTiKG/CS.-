using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    [Header("Set in Inspector: Enemy_2")]
    public float sinEccentricity = 0.6f;
    public float lifeTime = 10;

    [Header("Set Dynamically: Enemy_2")]
    public Vector3 p0;
    public Vector3 p1;
    public float birthTime;
    public GameObject projectilePrefab;
    public float projectileSpeed;
    private float lastShotTime;


    private void Start()
    {
        p0 = Vector3.zero;
        p0.x = -bndCheck.camWidth - bndCheck.radius;
        p0.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        p1 = Vector3.zero;
        p1.x = bndCheck.camWidth + bndCheck.radius;
        p1.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        if (Random.value > 0.5f)
        {
            p0.x *= -1;
            p1.x *= -1;
        }

        birthTime = Time.time;
        lastShotTime = 0;
    }

    public override void Move()
    {
        float u = (Time.time - birthTime) / lifeTime;

        if (u > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        u = u + sinEccentricity * (Mathf.Sin(u * Mathf.PI * 2));

        pos = (1 - u) * p0 + u * p1;

        if (Time.time - lastShotTime > fireRate)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Vector3 vec;
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        GameObject projGO1 = Instantiate<GameObject>(projectilePrefab);
        GameObject projGO2 = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        vec = transform.position;
        vec.x += 2;
        projGO1.transform.position = vec;
        vec = transform.position;
        vec.x -= 2;
        projGO2.transform.position = vec;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        Rigidbody rigidB1 = projGO1.GetComponent<Rigidbody>();
        Rigidbody rigidB2 = projGO2.GetComponent<Rigidbody>();

        Projectile proj = projGO.GetComponent<Projectile>();
        Projectile proj1 = projGO1.GetComponent<Projectile>();
        Projectile proj2 = projGO2.GetComponent<Projectile>();
        proj.type = WeaponType.blaster;
        proj1.type = WeaponType.blaster;
        proj2.type = WeaponType.blaster;

        proj1.transform.rotation = Quaternion.AngleAxis(10, Vector3.back);
        proj2.transform.rotation = Quaternion.AngleAxis(-10, Vector3.back);

        rigidB.velocity = Vector3.down * projectileSpeed;

        rigidB1.velocity = Vector3.down * projectileSpeed;
        rigidB2.velocity = Vector3.down * projectileSpeed;
        
        lastShotTime = Time.time;
    }

}

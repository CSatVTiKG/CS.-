using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;
    static Dictionary<WeaponType, WeaponDefinition> WEAP_DICT;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;

    public float enemyDefaultPadding = 1.5f;

    public WeaponDefinition[] weaponDefinitions;
    public GameObject prefabPowerUp;
    public WeaponType[] powerUpFrequency = new WeaponType[]
                        {   WeaponType.blaster,
                            WeaponType.blaster,
                            WeaponType.spread,
                            WeaponType.shield 
                        };

    private BoundsCheck bndCheck;
    private float timeToBoss=120f;
    private float timeBetweenBosses = 120f;
    
    

    private void Awake()
    {
        S = this;

        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

        WEAP_DICT = new Dictionary<WeaponType, WeaponDefinition>();
        foreach(WeaponDefinition def in weaponDefinitions)
        {
            WEAP_DICT[def.type] = def;
        }
        InvokeRepeating("SpawnBoss", timeToBoss,timeBetweenBosses);
    }

    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, prefabEnemies.Length-2);//сюды можно босса запихать
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }

    public void SpawnBoss()
    {
        GameObject go = Instantiate<GameObject>(prefabEnemies[prefabEnemies.Length-1]);

        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding-100;
        float xMax = bndCheck.camWidth - enemyPadding+50;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;
        timeBetweenBosses /= 2;
        if(timeBetweenBosses <= 10)
        {
            timeBetweenBosses = 10;
        }
        enemySpawnPerSecond = 0.1f;
    }


    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        HighScore.currentScore = 0;
        SceneManager.LoadScene("_Scene_0");
    }


    static public WeaponDefinition GetWeaponDefinition (WeaponType wt)
    {
        if (WEAP_DICT.ContainsKey(wt))
        {
            return (WEAP_DICT[wt]);
        }
        return (new WeaponDefinition());
    }

    public void ShipDestroyed(Enemy e)
    {
        if(Random.value<=e.powerUpDropChance)
        {
            int idx = Random.Range(0, powerUpFrequency.Length);
            WeaponType puType = powerUpFrequency[idx];

            GameObject go = Instantiate(prefabPowerUp) as GameObject;
            PowerUp pu = go.GetComponent<PowerUp>();
            pu.SetType(puType);

            pu.transform.position = e.transform.position;
        }
    }
}

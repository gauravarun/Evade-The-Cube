using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject catcherPrefab;
    public Vector2 SpwanRangeX;
    
    void Start()
    {
        InvokeRepeating(nameof(SpwanEvader), 0 , 2.0f);
        InvokeRepeating(nameof(SpwanCatcher), 1.0f , 2.0f);
    
    }

    private void SpwanCatcher()
    {
        SpwanEnemy(EnemyType.Catcher);
    }
    private void SpwanEvader()
    {
        SpwanEnemy(EnemyType.Evader);
    }    

    private void SpwanEnemy(EnemyType enemyType)
    {
        Vector3 spwanPosition = new Vector3 (
            Random.Range(SpwanRangeX[0], SpwanRangeX[1]),
            enemyPrefab.transform.position.y,
            enemyPrefab.transform.position.z);

        if (enemyType == EnemyType.Evader)
        {
            Instantiate(
               enemyPrefab,
               spwanPosition,
               enemyPrefab.transform.rotation);

        } else 
        {
            Instantiate(
               catcherPrefab,
               spwanPosition,
               catcherPrefab.transform.rotation);
        }
        
    }
}    


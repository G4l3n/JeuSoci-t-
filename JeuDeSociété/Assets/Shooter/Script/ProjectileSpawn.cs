using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject BallPrefab;

    public void Shoot()
    {
        StartCoroutine(SpawnProjectil());
    }
    IEnumerator SpawnProjectil()
    {
        BallPrefab.SetActive(true);
        GameObject Ball = Instantiate(BallPrefab, this.transform.position, transform.rotation, transform);
        Destroy(Ball, 3f);
        yield return new WaitForSeconds(1.5f);
    }

}
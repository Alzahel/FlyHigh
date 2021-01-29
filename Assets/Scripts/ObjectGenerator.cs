using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject scrolling = null;

    [SerializeField] Transform playerPosition = null;
    [SerializeField] float minSpawnTime = 3;
    [SerializeField] float maxSpawnTime = 3;
    [SerializeField] float minDropTime = 3;
    [SerializeField] float maxDropTime = 3;

    [SerializeField] float spawnZoneStartX = -5;
    [SerializeField] float spawnZoneEndX = 5;
    

    [SerializeField] private GameObject obj = null;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Instantiation());
    }

    private IEnumerator Instantiation()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

       
        
        var GO =Instantiate(obj, new Vector3(Random.Range(spawnZoneStartX,spawnZoneEndX),playerPosition.position.y + 8, 0), Quaternion.identity);
        StartCoroutine(Drop(GO));
        StartCoroutine(Instantiation());
    }

    private void OnDrawGizmos()
    {
        Vector3 spawnZoneStart = new Vector3(spawnZoneStartX, transform.position.y, transform.position.z);
        Vector3 spawnZoneTarget = new Vector3(spawnZoneEndX, transform.position.y, transform.position.z);
        Gizmos.DrawLine(spawnZoneStart, spawnZoneTarget);
    }

    private IEnumerator Drop(GameObject GO)
    {
        float timeBeforeDrop = Random.Range(minDropTime, maxDropTime);

        StartCoroutine(ScaleOverTime(GO, timeBeforeDrop));
        
        yield return new WaitForSeconds(timeBeforeDrop);
        GO.transform.SetParent(scrolling.transform);
    } 
    
    IEnumerator ScaleOverTime(GameObject GO, float time)
    {
        var originalScale = GO.transform.localScale;

        float currentTime = 0.0f;
         
        do
        {
            GO.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
}

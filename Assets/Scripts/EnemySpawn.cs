using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private GameObject _objectForSpawn;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[gameObject.transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = gameObject.transform.GetChild(i);
        }

        StartCoroutine(SpawnCooldown());
    }

    private IEnumerator SpawnCooldown()
    {
        var waitForSeconds = new WaitForSeconds(_spawnCooldown);

        for (int i = 0; i < _spawnPoints.Length;i++)
        {
            Instantiate(_objectForSpawn, _spawnPoints[i].position, Quaternion.identity);

            if (i >= _spawnPoints.Length-1)
            {
                i = -1;
            }

            yield return waitForSeconds;
        }
        
    }
}

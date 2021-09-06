using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _apple;
    [SerializeField] private int _gridXMax;
    [SerializeField] private int _gridXMin;
    [SerializeField] private int _gridYMax;
    [SerializeField] private int _gridYMin;
    [SerializeField] private int _appleCount;
    private Vector2Int _applePosition;
    
    void Start()
    {
        SpawnApple();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnApple()
    {
       

        for(int i = 0; i < _appleCount; i++)
        {
            int randomX = Random.Range(_gridXMin, _gridXMax);
            int randomY = Random.Range(_gridYMin, _gridYMax);
            Instantiate(_apple, new Vector3(randomX, randomY), transform.rotation);
        }
        
    }
}

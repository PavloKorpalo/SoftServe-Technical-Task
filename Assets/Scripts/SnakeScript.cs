using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{

    public int Score;
    public bool IsDestroyed;
    [SerializeField] private GameObject _tail;
    [SerializeField] private float _snakeMoveTimer;
    [SerializeField] private float _snakeMoveTimerMax;
    [SerializeField] private int _snakeBodySize;
    [SerializeField] private int _offset;
    private Vector2Int _snakeDirection;
    private Vector2Int _snakePosition;
    private List<Vector2Int> _snakeMovePositionList;
   
   
    
   


    public void Awake()
    {
        
        _snakeMovePositionList = new List<Vector2Int>();
        _snakePosition = new Vector2Int(0, 0);
        _snakeMoveTimer = _snakeMoveTimerMax;
        //_snakeDirection = new Vector2Int(0, 0);
        Score = 0;
        IsDestroyed = false;

    }

    private void Update()
    {
        SnakeMovement();
    }

    private void SnakeMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            if (_snakeDirection.y != -_offset)
            {
                _snakeDirection.y += _offset;
                _snakeDirection.x = 0;
                
            }
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            if(_snakeDirection.y != -_offset)
            {
                _snakeDirection.y -= _offset;
                _snakeDirection.x = 0;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(_snakeDirection.x != -_offset)
            {
                _snakeDirection.x += 1;
                _snakeDirection.y = 0;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_snakeDirection.x != _offset)
            {
                _snakeDirection.x += -_offset;
                _snakeDirection.y = 0;
            }
        }

        _snakeMoveTimer += Time.deltaTime;
        if(_snakeMoveTimer >= _snakeMoveTimerMax)
        {

            _snakeMoveTimer -= _snakeMoveTimerMax;
            _snakeMovePositionList.Insert(0, _snakePosition);
            _snakePosition += _snakeDirection;


            if(_snakeMovePositionList.Count >= _snakeBodySize + 1)
            {
                _snakeMovePositionList.RemoveAt(_snakeMovePositionList.Count - 1);
            }
            
            for(int i = 0; i < _snakeMovePositionList.Count; i++)
            {

                Vector2Int snakeMovePosition = _snakeMovePositionList[i];
                _tail = (GameObject) Instantiate(_tail, new Vector3(snakeMovePosition.x, snakeMovePosition.y, 0), transform.rotation);
                

                if(_snakePosition == snakeMovePosition || _snakePosition == _snakeMovePositionList[0])
                {
                    _snakeBodySize = 0;
                    Destroy(this.gameObject);
                    Debug.Log("Game Over");
                    IsDestroyed = true;
                }

                Destroy(_tail, _snakeMoveTimerMax);
            }
        }

        transform.position = new Vector3(_snakePosition.x, _snakePosition.y, 0);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(_snakeDirection));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            Debug.Log("collision");
            Destroy(collision.gameObject);
            _snakeBodySize += 1;
            Score += 1;
           
        }

        if (collision.CompareTag("Wall"))
        {
            Debug.Log("Game Over");
            Destroy(this.gameObject);
            _snakeBodySize = 0;
            Score = 0;
            IsDestroyed = true;
        }

    }

    private float GetAngleFromVector(Vector2Int direction)
    {
        float t = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (t < 0)
            t += 360;
        return t;
    }
}


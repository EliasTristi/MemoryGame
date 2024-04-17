using Memory.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    private MemoryBoard _board;

    //temp
    private float _timer = 0;
    private float _interval = 2f;

    void Start()
    {
        _board = new MemoryBoard(3, 3);
        Debug.Log(_board.ToString());
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _interval)
        {
            foreach (var tile in _board.Tiles)
                Debug.Log(tile.ToString() + $" {tile.MemoryCardID}");

            _timer = 0;
        }
    }
}

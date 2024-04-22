using Memory.Models;
using Memory.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    //variables
    private MemoryBoard _board;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _memoryBoard;

    //temp
    private float _timer = 0;
    private float _interval = 2f;

    void Start()
    {
        _board = new MemoryBoard(3, 3);

        var boardView = _memoryBoard.GetComponent<MemoryBoardView>();
        boardView.SetUpMemoryBoard(_board, _tilePrefab);
    }

    void Update()
    {
        //_timer += Time.deltaTime;

        //if (_timer >= _interval)
        //{
        //    foreach (var tile in _board.Tiles)
        //        Debug.Log(tile.ToString() + $" {tile.MemoryCardID}");

        //    _timer = 0;
        //}
    }
}

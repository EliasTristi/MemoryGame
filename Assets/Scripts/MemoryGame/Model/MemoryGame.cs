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
    [SerializeField] private Material[] _materials;
    [SerializeField] private GameObject _playerOne;
    [SerializeField] private GameObject _playerTwo;

    //temp
    private float _timer = 0;
    private float _interval = 2f;

    void Awake()
    {
        _board = new MemoryBoard(3, 3);

        var boardView = _memoryBoard.GetComponent<MemoryBoardView>();

        boardView.PlayerViewOne = _playerOne.GetComponent<PlayerView>();
        boardView.PlayerViewTwo = _playerTwo.GetComponent<PlayerView>();
        
        boardView.SetUpMemoryBoard(_board, _tilePrefab, _materials);
    }

    void Update()
    {
        
    }
}

using Memory.Models;
using Memory.Models.States;
using Memory.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    //variables
    private MemoryBoard _board;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _memoryBoard;
    [SerializeField] private Material[] _materials;
    [SerializeField] private GameObject _playerOne;
    [SerializeField] private GameObject _playerTwo;
    [SerializeField] private Button _resetButton;

    void Awake()
    {
        _board = new MemoryBoard(3, 3);

        var boardView = _memoryBoard.GetComponent<MemoryBoardView>();

        boardView.PlayerViewOne = _playerOne.GetComponent<PlayerView>();
        boardView.PlayerViewTwo = _playerTwo.GetComponent<PlayerView>();
        
        boardView.SetUpMemoryBoard(_board, _tilePrefab, _materials);
    }

    private void Start()
    {
        _resetButton.onClick.AddListener(TestMethod);
    }

    private void TestMethod()
    {
        _board.ResetTiles = _board.Tiles.Where(t => t.State.State != TileStates.Hidden).ToList();
        Debug.Log($"Button pressed, count of reset tiles: {_board.ResetTiles.Count}");

        _board.BoardState = new BoardResettingState(_board);
        foreach (var tile in _board.ResetTiles)
        {
            tile.State = new TileHiddenState(tile);
        }


    }
}

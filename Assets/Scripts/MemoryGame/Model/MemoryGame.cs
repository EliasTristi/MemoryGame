using Memory.Models;
using Memory.Models.States;
using Memory.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
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
    [SerializeField] private Button _cheatButton;

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
        _cheatButton.onClick.AddListener(CheatButton);
    }

    private void CheatButton()
    {
        if (_board.PreviewingTiles.Count == 1 && _board.BoardState.State == BoardStates.OnePreview)
        {
            var firstTile = _board.PreviewingTiles[0];
            var tileID = firstTile.MemoryCardID;

            var allTiles = _board.Tiles;
            allTiles.Remove(firstTile);

            var secondTile = allTiles.Where(t => t.MemoryCardID == tileID).FirstOrDefault();

            secondTile.Board.BoardState.AddPreview(secondTile);

        }
    }
}

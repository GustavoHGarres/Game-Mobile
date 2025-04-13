using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container; // ok

    //public GameObject level;
    public List<GameObject> levels;
    
    [Header("Pieces")]
    public List<LevelPieceBase> levelPieces; // ok
    public int piecesNumber = 5; // ok

    [SerializeField] public int _index;
    private GameObject _currentLevel;

    private List<LevelPieceBase> _spawnedPieces;
  
    
    private void Awake()
    {
        SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();  
            }
        }
        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;   
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void CreateLevelPieces()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for(int i = 0; i < piecesNumber; i++);
        {
            CreateLevelPiece();
        }

    }

    private void CreateLevelPiece()
    {
     var piece = levelPieces[Random.Range(0, levelPieces.Count)];
     var spawnedPieces = Instantiate(piece, container);

     if(_spawnedPieces.Count > 0)
     {
        var lastPiece = _spawnedPieces[_spawnedPieces.Count -1];
        spawnedPieces.transform.position = lastPiece.endPiece.position;
     }

     _spawnedPieces.Add(spawnedPieces);
    }

    private  void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            SpawnNextLevel();
        }
    }
}

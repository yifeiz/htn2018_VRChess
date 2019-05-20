using ChessDotNet;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue>
    {

        [SerializeField]
        private List<TKey> keysList = new List<TKey>();
        public List<TKey> KeysList
        {
            get { return keysList; }
            set { keysList = value; }
        }

        [SerializeField]
        private List<TValue> valuesList = new List<TValue>();
        public List<TValue> ValuesList
        {
            get { return valuesList; }
            set { valuesList = value; }
        }

        private Dictionary<TKey, TValue> dictionaryData = new Dictionary<TKey, TValue>();
        public Dictionary<TKey, TValue> DictionaryData
        {
            get { return dictionaryData; }
            set { dictionaryData = value; }
        }

        public TValue this[TKey key]
        {
            get { return dictionaryData[key]; }
            set { dictionaryData[key] = value; }
        }

        public void Awake()
        {
            Debug.Log("hello222");

            try
            {
                for (int i = 0; i < keysList.Count; i++)
                {
                    dictionaryData.Add(keysList[i], valuesList[i]);
                }

            }
            catch (Exception)
            {
                Debug.LogError("KeysList.Count is not equal to ValuesList.Count. It shouldn't happen!");
            }

        }

        public void OnEnable() { }

        public void Add(TKey key, TValue data)
        {
            dictionaryData.Add(key, data);
            keysList.Add(key);
            valuesList.Add(data);
        }

        public void Remove(TKey key)
        {
            valuesList.Remove(dictionaryData[key]);
            keysList.Remove(key);
            dictionaryData.Remove(key);

        }

        public bool ContainsKey(TKey key)
        {
            return DictionaryData.ContainsKey(key);
        }

        public bool ContainsValue(TValue data)
        {
            return DictionaryData.ContainsValue(data);
        }

        public void Clear()
        {
            DictionaryData.Clear();
            keysList.Clear();
            valuesList.Clear();
        }
    }

    [Serializable]
    public class BoardPositions : SerializableDictionary<string, Transform> { };

    public BoardPositions boardPos;

    private Color32 copper = new Color32(223, 141, 56, 255);
    private ChessGame game;
    private GameObject selectedPiece;
    private string selectedSquare;
    private string inputCommand;

    public bool MovePiece(string origin, string dest)
    {
        Move move = new Move(origin, dest, game.WhoseTurn);

        if (game.IsValidMove(move))
        {
            Debug.Log(game.WhoseTurn + " from " + origin + " to " + dest + " successful.");

            MoveType type = game.ApplyMove(move, true);

            GameObject pieceToMove = GetPieceAt(origin);
            pieceToMove.transform.Translate(Vector3.up * (boardPos[dest].position.z - pieceToMove.transform.position.z));
            pieceToMove.transform.Translate(Vector3.right * (boardPos[dest].position.x - pieceToMove.transform.position.x));
            return true;
        }

        Debug.Log(game.WhoseTurn + " from " + origin + " to " + dest + " failed.");
        return false;
    }

    public GameObject GetPieceAt(string index)
    {
        Collider[] hitColliders = Physics.OverlapSphere(boardPos[index].position, 1);

        for (int i = 0; i < hitColliders.Count(); i++)
        {
            if (hitColliders[i].gameObject.transform.tag.Contains("Piece"))
            {
                return hitColliders[i].gameObject;
            }
        }

        return null;
    }

    public void SetSelectedPiece(GameObject piece)
    {
        // Deselect previous selected piece
        if ((selectedPiece) && (selectedPiece != piece))
        {
            Renderer rend = selectedPiece.GetComponent<Renderer>();
            if (selectedPiece.name.Contains("White"))
            {
                rend.material.color = copper;
            }
            else if (selectedPiece.name.Contains("Black"))
            {
                rend.material.color = Color.black;
            }
        }
        selectedPiece = piece;

        if (piece)
        { // This is a bootleg solution that needs to be fixed.
            Collider[] sumirekoCollider = Physics.OverlapSphere(piece.transform.position, 1);
            for (int i = 0; i < sumirekoCollider.Count(); i++)
            {
                if (Regex.IsMatch(sumirekoCollider[i].gameObject.name, @"^[A-H][1-8]$"))
                {
                    selectedSquare = sumirekoCollider[i].gameObject.name;
                    break;
                }
            }
        }
        else
        {
            selectedSquare = "";
        }
    }

    public GameObject GetSelectedPiece()
    {
        return selectedPiece;
    }


    // Game Init. Put any pre-loading stuff in here.
    void Start()
    {
        game = new ChessGame();
        selectedPiece = null;
        selectedSquare = "";
        inputCommand = "";

        boardPos.Awake();

        foreach (KeyValuePair<string, Transform> entry in boardPos.DictionaryData)
        {
            Debug.Log(entry.Key);
        }

        foreach (KeyValuePair<string, Transform> entry in boardPos.DictionaryData)
        {
            Collider[] hitColliders = Physics.OverlapSphere(entry.Value.position, 1);

            for (int i = 0; i < hitColliders.Count(); i++)
            {
                if (hitColliders[i].gameObject.transform.tag.Contains("Piece"))
                {
                    hitColliders[i].gameObject.transform.position =
                        new Vector3(entry.Value.position.x,
                                    hitColliders[i].gameObject.transform.position.y,
                                    entry.Value.position.z);

                    break;
                }
            }
        }

        MovePiece("E2", "E4");
        MovePiece("G8", "H6");
        MovePiece("F1", "A6");
        MovePiece("C7", "C5");
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedPiece && Input.GetMouseButtonDown(0))
        {
            SetSelectedPiece(null);
        }

        if (selectedSquare != "")
        {
            if (Input.anyKeyDown)
            {
                inputCommand += Input.inputString;
                inputCommand = inputCommand.ToUpper();
                Debug.Log("Currently Selected: " + selectedSquare + "\nTarget: " + inputCommand);
            }

            if (inputCommand.Length >= 2)
            {
                if (Regex.IsMatch(inputCommand, @"^[A-H][1-8]$"))
                {
                    bool moveResult = MovePiece(selectedSquare, inputCommand);
                }
                SetSelectedPiece(null);
                inputCommand = "";
            }
        }
    }
}

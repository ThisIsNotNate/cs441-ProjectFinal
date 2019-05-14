using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject lPiece, iPiece, oPiece, tPiece, zPiece;
    GameObject spawnPoint;
    List<GameObject> pieces;
    Queue<GameObject> pieceQ;
    // Start is called before the first frame update
    void Start()
    {
        pieces = new List<GameObject>();
        pieceQ = new Queue<GameObject>();

        spawnPoint = GameObject.Find("SpawnPoint");

        pieces.Add(lPiece);
        pieces.Add(iPiece);
        pieces.Add(oPiece);
        pieces.Add(tPiece);
        pieces.Add(zPiece);
        extendQueue();
        extendQueue();
        spawnNext();
    }

    // Update is called once per frame
    void Update()
    {
        if(pieceQ.Count <= 5)
        {
            extendQueue();
        }
    }

    public void spawnNext()
    {

        Instantiate(pieceQ.Dequeue(), spawnPoint.transform.position, Quaternion.identity);
    }

    void extendQueue()
    {
        Shuffle(pieces);
        foreach(GameObject piece in pieces)
        {
            pieceQ.Enqueue(piece);
        }
    }

    void Shuffle<GameObject>(List<GameObject> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            int k = Random.Range(0,4);
            n--;
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

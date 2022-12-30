using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _availableBones = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<5; i++)
        {
            int random = Random.Range(0, _availableBones.Count - 1);
            _availableBones[random].SetActive(true);
            _availableBones.RemoveAt(random);
        }
    }

}

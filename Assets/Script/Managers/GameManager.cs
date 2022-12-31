using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private int _maxBonesCollect;
    private int _bonesCollected;
    private bool _allBonesCollected = false;
    private bool _oneTime = false;


    private UIManager _uiManager;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError(gameObject.name + "Failed to connect to UIManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UICommunication();
        SetAllbonesCollected();
    }

    private void UICommunication()
    {
        _uiManager.UpdateMaxBonestoCollect(_maxBonesCollect);
    }

    #region Update Bones

    public void BonesCollected(bool allBonesCollected)
    {
        _allBonesCollected = allBonesCollected;
    }

    public void UpdateCollectedBones(int bones)
    {
        _bonesCollected = bones;
        if (_bonesCollected == _maxBonesCollect)
        {
            if (_oneTime == false)
            {
                ActivateDestPoint();
                _oneTime = true;
            }
        }
    }

    private void SetAllbonesCollected()
    {
        if(_bonesCollected == _maxBonesCollect)
        {
            _allBonesCollected = true;
        }
    }
    #endregion

    #region Activate Destination Point

    private void ActivateDestPoint()
    {
            _spawnManager.ActivateDestPoint();
    }

    #endregion
}

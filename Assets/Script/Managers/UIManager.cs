using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Variables



    [Header("Texts")]
    [SerializeField]
    private TextMeshProUGUI _bonesCollectedText;

    [Header("Variables")]
    private int _bonesCollected;
    private int _maxBonesToCollect;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _bonesCollected = 0;

        _bonesCollectedText.SetText("Score: " + 0);
    }

    // Update is called once per frame
    void Update()
    {
        SetBoneCount();
    }

    #region BonesCollected

    public void UpdateCollectedBones(int bones)
    {
        _bonesCollected = bones;
    }

    public void UpdateMaxBonestoCollect(int maxBones)
    {
        _maxBonesToCollect = maxBones;
    }

    private void SetBoneCount()
    {
        _bonesCollectedText.SetText("Bones Collected: " + _bonesCollected + " / " + _maxBonesToCollect);
    }

    #endregion
}

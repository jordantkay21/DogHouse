using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    private bool _isGameOver;

    [SerializeField]
    private GameObject _layer1;
    [SerializeField]
    private GameObject _layer2;
    [SerializeField]
    private GameObject _layer3;
    [SerializeField]
    private GameObject _layer4;
    [SerializeField]
    private GameObject _layer5;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(PlayLayers());
    }

    #region EnableLayers
    private void EnableLayer1()
    {
        _layer1.SetActive(true);
        _layer2.SetActive(false);
        _layer3.SetActive(false);
        _layer4.SetActive(false);
        _layer5.SetActive(false);
    }

    private void EnableLayer2()
    {
        _layer1.SetActive(false);
        _layer2.SetActive(true);
        _layer3.SetActive(false);
        _layer4.SetActive(false);
        _layer5.SetActive(false);
    }

    private void EnableLayer3()
    {
        _layer1.SetActive(false);
        _layer2.SetActive(false);
        _layer3.SetActive(true);
        _layer4.SetActive(false);
        _layer5.SetActive(false);
    }

    private void EnableLayer4()
    {
        _layer1.SetActive(false);
        _layer2.SetActive(false);
        _layer3.SetActive(false);
        _layer4.SetActive(true);
        _layer5.SetActive(false);
    }

    private void EnableLayer5()
    {
        _layer1.SetActive(false);
        _layer2.SetActive(false);
        _layer3.SetActive(false);
        _layer4.SetActive(false);
        _layer5.SetActive(true);
    }
    #endregion

    IEnumerator PlayLayers()
    {
        while (_isGameOver == false)
        {
            EnableLayer1();
            yield return new WaitForSeconds(.5f);
            EnableLayer2();
            yield return new WaitForSeconds(.5f);
            EnableLayer3();
            yield return new WaitForSeconds(.5f);
            EnableLayer4();
            yield return new WaitForSeconds(.5f);
            EnableLayer5();
            yield return new WaitForSeconds(.5f);
        }
    }

    public void SetGameOver(bool isGameOver)
    {
        _isGameOver = isGameOver;
    }
}

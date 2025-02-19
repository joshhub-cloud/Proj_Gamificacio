using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class Seller : MonoBehaviour
{
    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    public GameObject Shop_UI;
    private ThirdPersonController TPC;
    private bool _canBuy = true;
    private float time = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(_canBuy)
        {
            VCamDisable.gameObject.SetActive(false);
            VCamEnable.gameObject.SetActive(true);
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            Camera.main.cullingMask &= ~(1  << 8);
            TPC = other.GetComponent<ThirdPersonController>();
            TPC.canMove = false;
            Shop_UI.SetActive(true);
            _canBuy = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitForABit());
    }


    public void ExitStore ()
    {
        TPC.canMove = true;
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= ~(1 << 8);
        Shop_UI.SetActive(false);
    }    

    private IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(time);
        _canBuy = true;
    }    
}

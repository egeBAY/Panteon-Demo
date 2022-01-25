using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.FinishGame();
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        else if(other.tag == "Opponent")
        {
            other.gameObject.SetActive(false);
        }
    }

}

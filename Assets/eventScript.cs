using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventScript : MonoBehaviour
{
    GameObject eventPopup;
    public float eventChance, chanceRoll;
    mainScript mS;

    // Start is called before the first frame update
    void Start()
    {
        mS = GameObject.Find("truck").GetComponent<mainScript>();
        eventPopup = GameObject.Find("Canvas/EventPopup");
        eventPopup.SetActive(false);
    }

    public void runEvent()
    {
        chanceRoll = (Random.Range(0, 100));
        if(chanceRoll < eventChance)
        {
            eventPopup.SetActive(true);
            mS.stopStart();
            mS.eventInProgress = true;
        }
    }
}

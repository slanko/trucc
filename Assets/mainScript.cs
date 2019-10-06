using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class mainScript : MonoBehaviour
{
    public cityScript cCScript;
    public GameObject currentCity, destinationCity = null;
    public float timeUntilNextEvent, travelTime;
    public int travelTimeInt;
    public Dropdown citiesDropdown;
    Text stopStartText;
    NavMeshAgent nav;
    bool inCity = true, truckStopped;
    eventScript eS;
    public bool eventInProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        eS = GameObject.Find("GOD").GetComponent<eventScript>();
        stopStartText = GameObject.Find("Canvas/stopStartButton/Text").GetComponent<Text>();
        nav = GetComponent<NavMeshAgent>();
        citiesDropdown = GameObject.Find("Canvas/citiesDropdown").GetComponent<Dropdown>();
        populateCitiesDropdown();
        nav.isStopped = true;

        //we need this bit for the uhhhh dropdown i think
        citiesDropdown.onValueChanged.AddListener(delegate 
        {
            DropdownValueChanged(citiesDropdown);
        }
        );
    }

    // Update is called once per frame
    void Update()
    {
        //check if truck is stopped
        if (nav.isStopped == false)
        {
            truckStopped = false;
            stopStartText.text = "STOP";
            travelTime = travelTime + 1 * Time.deltaTime;
        }
        else
        {
            truckStopped = true;
            stopStartText.text = "START";
        }

        travelTimeInt = Mathf.RoundToInt(travelTime);
        //event checkz
        if (travelTimeInt % 5 == 0 && travelTimeInt > 0)
        {
            if(eventInProgress == false)
            {
                eS.runEvent();
            }
        }

        //city checking and stuff?? maybe for the dropdown i think
        if (currentCity != destinationCity && nav.isStopped == false)
        {
            citiesDropdown.gameObject.SetActive(false);
        }
        else
        {
            citiesDropdown.gameObject.SetActive(true);
        }
    }

    void populateCitiesDropdown()
    {
        List<string> options = new List<string>();

        citiesDropdown.ClearOptions();
        cCScript = currentCity.GetComponent<cityScript>();
        foreach(var option in cCScript.adjacentCities)
        {
            options.Add(option.name);
        }
        options.Insert(0, currentCity.name);
        citiesDropdown.AddOptions(options);
    }

    void DropdownValueChanged(Dropdown change)
    {
        destinationCity = cCScript.adjacentCities[change.value - 1];
        nav.SetDestination(destinationCity.transform.position);
        nav.isStopped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "City")
        {
            if(other.transform.name == destinationCity.transform.name)
            {
                currentCity = destinationCity;
                Invoke("stopStart", 0.25f);
                populateCitiesDropdown();
                inCity = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "City")
        {
            inCity = false;
        }
    }

    public void stopStart()
    {
        if(nav.isStopped == false)
        {
            nav.isStopped = true;
        }
        else
        {
            nav.isStopped = false;
        }

    }
}

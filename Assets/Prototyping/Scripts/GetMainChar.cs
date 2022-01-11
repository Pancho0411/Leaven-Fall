using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{

    public GameObject Chase, Ember, Lea, Leo, Bree, Neo, Max;

    private GameObject myChar;

    private readonly string selectedCharacter = "SelectedCharacter";

    void Awake()
    {
        myChar = this.GetComponent<GameObject>();
    }

    void Start()
    {
        int getCharacter;
        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch (getCharacter)
        {
            case 1:
                myChar = Instantiate(Chase);
                PlayerPrefs.SetInt(selectedCharacter, 5);
                break;
            case 2:
                myChar = Instantiate(Lea);
                PlayerPrefs.SetInt(selectedCharacter, 5);
                break;
            case 3:
                myChar = Instantiate(Leo);
                PlayerPrefs.SetInt(selectedCharacter, 5);
                break;
            case 4:
                myChar = Instantiate(Bree);
                PlayerPrefs.SetInt(selectedCharacter, 5);
                break;
            case 5:
                myChar = Instantiate(Ember);
                PlayerPrefs.SetInt(selectedCharacter, 5);
                break;
            case 6:
                myChar = Instantiate(Neo);
                PlayerPrefs.SetInt(selectedCharacter, 5);
                break;
            case 7:
                myChar = Instantiate(Max);
                PlayerPrefs.SetInt(selectedCharacter, 5);
                break;
            default:
                myChar = Instantiate(Ember);
                PlayerPrefs.SetInt(selectedCharacter, 5);
                break;
        }
    }


}

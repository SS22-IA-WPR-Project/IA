using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownGUIController : MonoBehaviour
{

    Dropdown m_Dropdown;
    int m_DropdownValue;
    public AccessoriesCharacter ace;


    // Start is called before the first frame update
    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();
        m_DropdownValue = m_Dropdown.value;
        Debug.Log("Starting Dropdown Value : " + m_Dropdown.value);
        

    }

    // Update is called once per frame
    void Update()
    {
        m_DropdownValue = m_Dropdown.value;
        Debug.Log("Starting Dropdown Value : " + m_Dropdown.value);
        ace.glasses(m_DropdownValue);

    }
}

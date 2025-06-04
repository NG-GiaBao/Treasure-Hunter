using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BoxHandler : MonoBehaviour
{
    //[SerializeField] private GameObject Box;
    [SerializeField] private List<GameObject> m_Boxes = new();
    [SerializeField] private int m_NumberBoxHaveDiamonds = 3;
    

    [SerializeField] private List<GameObject> m_Diamonds = new();
    [SerializeField] private List<int> choseIndexBox = new();
    [SerializeField] private List<int> uniqueIndex = new();
    // Start is called before the first frame update
    void Start()
    {
        AssignDiamondsToBoxes();
    }

    // Update is called once per frame
    private void AssignDiamondsToBoxes()
    {
        m_Boxes.Clear();
        foreach (Transform box in this.transform)
        {
            m_Boxes.Add(box.gameObject);
        }
      

        while (choseIndexBox.Count < m_NumberBoxHaveDiamonds)
        {
            int randomBoxIndex = Random.Range(0, m_Boxes.Count);
            if (!choseIndexBox.Contains(randomBoxIndex))
            {
                choseIndexBox.Add(randomBoxIndex);

                Box boxcomponent = m_Boxes[randomBoxIndex].GetComponent<Box>();

                boxcomponent.ChangeStateOfBoxes();

                int indexDiamond = GetRandomDiamondIndex();
                GameObject diamond = Instantiate(m_Diamonds[indexDiamond],boxcomponent.transform.position,Quaternion.identity, boxcomponent.transform);
                diamond.SetActive(false);
                string diamondName = m_Diamonds[indexDiamond].name;
                if (diamondName.Contains("(Clone)"))
                {
                    diamondName = diamondName.Replace("(Clone)", "");
                }
                diamond.GetComponent<DiamondCollider>().DiamondType = diamondName;
            }
        }
    }
    private int GetRandomDiamondIndex()
    {

        int index;
        do
        {
            index = Random.Range(0, m_Diamonds.Count); 
        }
        while (uniqueIndex.Contains(index)); 

        uniqueIndex.Add(index); 
        return index;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public enum Map
    {
        Map1,
        Map1Under,
    }
    [SerializeField]
    Map map1;
    [SerializeField]
    GameObject map;
    [SerializeField]
    GameObject undermap;
    // Start is called before the first frame update
    void Start()
    {
        undermap.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map1 == Map.Map1)
            {
                map1 = Map.Map1Under;
            }
            else if (map1 == Map.Map1Under)
            {
                map1 = Map.Map1;
            }
        }
        switch (map1)
        {
            case Map.Map1:
                map.gameObject.SetActive(true);
                undermap.gameObject.SetActive(false);
                break;
            case Map.Map1Under:
                map.gameObject.SetActive(false);
                undermap.gameObject.SetActive(true);
                break;
        }
    }
}

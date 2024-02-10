using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseItem : MonoBehaviour
{
    //public GameObject itemP;
    public string Name;
    public int life;
    public string descripcion;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

    void Start()
    {
      //GetComponent<SpriteRenderer>().sprite = icon1;


    }

    //public virtual void setup(string _name, string _descp, int _vida)
    //{
      //  name = _name;
      //  vida = _vida;
      //  descp = _descp;
        //GetComponent<SpriteRenderer>().sprite = icon1;
    //}

    void Update()
    {
        
    }
}

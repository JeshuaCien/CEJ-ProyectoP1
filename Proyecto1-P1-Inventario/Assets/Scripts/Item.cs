using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Se crea un objeto scriptable y se le asignan los valores de nombre, rareza etc.
[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    //public Sprite icon;

    [Header ("Only gameplay")]
    public string Name;
    public int ID;
    public int life;
    public string descripcion;
    public Rareza rareza;
    public Tipo tipo;
    public Habilidad habilidad;
    

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Only Both")]
    public Sprite image;
}

public enum Rareza
{
    RAROX2 = 0,
    RARO = 1,
    COMUN = 2
}

public enum Tipo
{
    Invierno = 0,
    Armadura = 1,
    Casual = 2,
    Intercambio = 3
}

public enum Habilidad
{
    Proteccion = 0,
    Counter = 1,
    PFrio = 2,
    Intercambio = 3,
    Curar = 4
}

//public enum ItemType
//{
//    BuildingBlobk,
//    Tool
//}

//public enum ActionType
//{
//    Dig,
//    Mine
//}

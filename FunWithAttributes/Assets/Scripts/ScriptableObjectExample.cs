using UnityEngine;

//this is an awesome way to create a new Scriptable Object in your project using the Create Menu!
[CreateAssetMenu(fileName = "SO_Example", menuName ="ScriptableObjects/NewExample", order = 0)]
public class ScriptableObjectExample : ScriptableObject
{
    public string scriptableName = "Slim Shady";


}

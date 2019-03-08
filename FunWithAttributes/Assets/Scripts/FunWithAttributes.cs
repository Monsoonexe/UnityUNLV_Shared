using UnityEngine;

//https://unity3d.college/2017/05/22/unity-attributes/ // guide I found
//https://assetstore.unity.com/packages/tools/utilities/naughtyattributes-129996 // if you want more awesome custom attributes for free!
//http://www.unity3dtechguru.com/2019/02/unity3d-attributes.html // a different guide someone showed me

[DisallowMultipleComponent]//only one instance of this Component allowed on a GameObject at a time
[ExecuteInEditMode]//Update and other functions are called in Edit Mode. May not behave exactly like in Play Mode
[SelectionBase]//This GameObject will be highlighted in the Hierarchy when a child mesh is clicked
[RequireComponent(typeof(BoxCollider))]//if this Component does not exist, add it 
public class FunWithAttributes : MonoBehaviour
{
    [Header("<--SerializeField Example-->")]//bold text in Inspector

    private string string_00 = "Private string_00";

    public string string_01 = "Public String_01";

    [HideInInspector]//hide a public variable from developers
    public string string_02 = "[HideInInspector] public String_02";

    [SerializeField]//show a private variable to developers
    private string string_03 = "[SerializeField] private string_03"; //hooray for encapsulation!


    //[Space(25)]//adds space below header
    [Header("<--Range Example-->")]
    [Space(25)]//adds space above header

    [Tooltip("This is a tooltip that tells the developer what's up on mouse over. \n This is a ranged Int!")]//mouse over name property
    [Range(-5f, 5f)]
    [SerializeField]
    private float rangedFloat = 0.0f;

    [Tooltip("An Int that's capped in the Inspector!")]
    [Range(-3, 5)]//restrict variable using a slider
    [SerializeField]
    private int rangedInt = 0;

    [Tooltip("The developer can set this to anything at all!")]
    [SerializeField]
    private float unhingedFloat = 0.0f;

    [Space(10)]
    [Header("<--Text Area and MultiLine-->")]

    [Tooltip("Regular, boring old string.")]
    [SerializeField]
    private string regularString = "I'm just a little bit caught in the middle/ life is a maze and love is a riddle/ I don't know where to go can't do it along/ I've tried and I don't know why/ Slow it down make it stop/ or else my ";

    [Space(10)]
    [TextArea]//nice text field with scroll bar
    [SerializeField]
    private string textArea = "Depicted as a short, pudgy, Italian plumber who resides in the Mushroom Kingdom, his adventures generally center upon rescuing Princess Peach from the Koopa villain Bowser. His younger brother and sidekick is Luigi.";


    [Space(10)]
    [Multiline]//multi line text area
    [SerializeField]
    private string multiLineString = "Happiness is when what you think, what you say, and what you do are in harmony. \nYou must be the change you want to see in the world. \nAn eye for an eye makes the whole world blind. \nBeer is proof God loves us and wants us to be happy.";
    
    [Header("<--Context Menu Items-->")]

    [ContextMenuItem("Random value between +-10", "GetRandomInt")]//right click on the name of the field to get a menu with this option in it. calls the function
    [ContextMenuItem("Set Value To 100", "SetValueTo100")]
    [Tooltip("Right-click to get some options!")]
    [SerializeField]
    private int rightClickForOptions = 0;

    [Header("<--Colors!!!-->")]
    [Space(10)]

    [SerializeField]
    private Color normalColor;

    [SerializeField]
    [ColorUsage(false)]//show alpha ?
    private Color restrictAlphaAccessColor;//alpha is 0!

    private static GameObject sphereInstance;//don't worry about this yet
    private static readonly Vector3 sphereMoveSpeed = new Vector3(5, 5, 5);

    [Header("Custom Struct (hidden unless marked serializeable)")]//invisible unless the Struct is marked with attribute!
    public RichsStruct[] serializedListOfStructs;//This won't show up in the Inspector unless RichsStruct is marked [System.Serializeable]! 

    //Awake is called while the game boots up, or as soon as it is created. Awake is called before Start()
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rangedFloat = 500;//[Range] attribute only works in Inspector! Can still be changed in code!
        Debug.Log("colorNoAlpha.a (alpha): " + restrictAlphaAccessColor.a);
    }

    // Update is called once per frame (in EditMode, frames are only drawn when something in the scene gets updated. Try changing a different object's Transform)
    void Update()
    {
        if (sphereInstance)
        {
            Debug.Log("The sphere moved!!");
            sphereInstance.transform.Translate(sphereMoveSpeed * Time.deltaTime);
        }
    }

    [ContextMenu("GetRandomInt")]
    private void GetRandomInt()
    {
        rightClickForOptions = (int)Random.Range(-10f, 10f);
    }

    /// <summary>
    /// This is a helpful summary of the function!  Sets the value to given value, or just 100.
    /// </summary>
    /// <param name="value">Default value of 100. But set it to whatever you want.</param>
    [ContextMenu("Set value to 100")]
    private void SetValueTo100()
    {
        rightClickForOptions = 100;
    }

    [UnityEditor.MenuItem("Rich's Functions/Create a Sphere")]
    public static void CreateASphere()
    {
        sphereInstance = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
    }
    
    /// <summary>
    /// This function is tagged "deprecated".
    /// </summary>
    [System.Obsolete("This method is obsolete and will be deprecated in a later version of Rich's project. Use Method B instead.")]
    public static void OutdatedFunction()
    {
        Debug.Log("I'm a boring old log message!");
        Debug.LogWarning("I'm a Warning! Move along now, but don't get comfortable!");
        Debug.LogError("I'M AN ERROR! WTF, dude? Pay more attention! I'm the poor man's exception handler!");
    }
}

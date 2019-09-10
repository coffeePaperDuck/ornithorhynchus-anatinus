using UnityEngine;

namespace Anatinus.My_Scripts.Gameplay
{
    public class objectExecute : MonoBehaviour
    {
        public bool execute = false;
        bool executed = false;
        public GameObject go;
        public string scriptName;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        void OnCollisionEnter(Collision collision)
        {
            execute = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (execute == true && executed == false)
            {
                //We have a string holding a script name
                //We need to fetch the Type
                System.Type MyScriptType = System.Type.GetType(scriptName + ",Assembly-CSharp");
                //Now that we have the Type we can use it to Add Component
                gameObject.AddComponent(MyScriptType);
                executed = true;
            }
        }
    }
}

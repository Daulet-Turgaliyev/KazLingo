using TMPro;
using UnityEngine;

namespace Client.Scripts.UI
{
    public class TMP_InputFieldWithOutCaret : TMP_InputField
    {
        protected override void Start()
        {
            TMP_SelectionCaret delete = GetComponentInChildren<TMP_SelectionCaret>();
            if (delete != null)
            {
                Destroy(delete.gameObject);
            }
        }
        
        
    }
}
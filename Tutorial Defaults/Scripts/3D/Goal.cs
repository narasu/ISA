using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Timer.Instance.SetText();
            GetComponent<ChangeScene>()?.OnClick();

        }
            
    }
}

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
            UIManager.Instance.SetText();
            GetComponent<ChangeScene>()?.OnClick();

        }
            
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIManager.Instance.SetText();
            GetComponent<ChangeScene>()?.OnClick();
        }
    }
}

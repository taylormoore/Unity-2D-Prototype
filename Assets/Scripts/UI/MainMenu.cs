using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

	void Update ()
    {
		if ( Input.GetButtonDown( "Submit" ) )
        {
            SceneManager.LoadScene("Main");
        }
	}
}

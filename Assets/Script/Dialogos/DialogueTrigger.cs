using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogo;

	public void TriggerDialogo()
	{
		FindObjectOfType<DialogueManager>().StarDialogue(dialogo);
	}


}

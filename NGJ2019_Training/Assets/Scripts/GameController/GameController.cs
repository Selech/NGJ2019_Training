using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public float CurrentHighPoint;

    public int StartTimeCountDownFrom = 2;
    private GameControllerCommunicator[] communicationObjects = new GameControllerCommunicator[0];
    // Start is called before the first frame update
    void Start()
    {
        communicationObjects = GameObject.FindObjectsOfType<GameControllerCommunicator>();
        StartCoroutine(StartGameStartCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void UsePower(GameControllerCommunicator user)
	{
		foreach (var item in communicationObjects)
		{
			if(item.GetComponent<PlayerController>() != null && item.GetInstanceID() != user.GetInstanceID())
			{
				//item.FuckMeUp()
			}
		}
	}


    private IEnumerator StartGameStartCountDown()
    {
        print("Game starting in " + StartTimeCountDownFrom + " seconds");
        yield return new WaitForSeconds(StartTimeCountDownFrom);
        NotifyGameStarted();
    }

    private void NotifyGameStarted()
    {

        print("GAME STARTED");
        foreach (var communicator in communicationObjects)
        {
            communicator.OnGameStart();
        }
    }
}

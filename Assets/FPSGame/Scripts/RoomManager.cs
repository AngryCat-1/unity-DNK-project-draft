using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;


public class RoomManager : MonoBehaviourPunCallbacks
{
	public static RoomManager Instance;

	void Awake()
	{
		if(Instance)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		Instance = this;
	}

	public override void OnEnable()
	{
		base.OnEnable();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public override void OnDisable()
	{
		base.OnDisable();
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if(scene.buildIndex == 2) // We're in the game scene
		{
			
			
			PhotonNetwork.Instantiate("MultiPlayer", Vector3.zero, Quaternion.identity);
		 var gb1 = Instantiate(FindObjectOfType<MultiPlayerManager>().gbmultiplayer);


			FindObjectOfType<InstantiaterObject>().IndexProcedure(gb1);
		//	
		//	gb1.GetComponentInChildren<GameManager>().Playerrefabloader = Instantiate(gb1.GetComponentInChildren<GameManager>().refabloader);
		//	gb1.GetComponentInChildren<GameManager>().Playerrefabloader.name = "Playerrefabloader";


			//FindObjectOfType<InstantiaterObject>().IndexProcedure(gb1);


		}

		}
	}


    

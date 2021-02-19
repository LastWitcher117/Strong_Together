using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoManager : MonoBehaviour
{
	public float BPM = 145;
	private float _lastSyncTime = 0;
	private uint _beatsSinceSync = 0;

	void Start()
	{
		syncBPM();
	}

	void Update()
	{
		//Check beat timer and trigger beat if neccessary
		if (Time.time > _lastSyncTime + (beatsPerMinuteToDelay(BPM) * _beatsSinceSync))
		{
			beat();
		}
	}

	private static float beatsPerMinuteToDelay(float beatsPerMinute)
	{
		//beats per second = beatsPerMinute / 60
		return 1.0f / (beatsPerMinute / 60.0f);
	}

	private void beat()
	{
		_beatsSinceSync++;
		//TODO Fire your beat event off here to your listeners
		print("beat!");
	}

	/// <summary>
	/// Restart BPM timer
	/// </summary>
	public void syncBPM()
	{
		_lastSyncTime = Time.time;
		_beatsSinceSync = 0;
		beat(); //NB: beat is now synced immedately instead of after a 1 beat delay
	}
}

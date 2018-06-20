using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	// VOLUME METHODS

	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	// UNLOCKED LEVEL METHODS

	public static void UnlockLevel (int level) {
		if (level < Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); 
		} else {
			Debug.LogError("Trying to unlock level which is not included");
		}
	}

	public static bool IsLevelUnlocked (int level) {
		int keyValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		if (keyValue == 1 && level < Application.levelCount - 1) {
			return true;
		} else if (keyValue == 0 && level < Application.levelCount - 1) {
			return false;
		} else {
			Debug.LogError("Level index too high");
			return false;
		}
	}

	// DIFFICULTY METHODS

	public static void SetDifficulty (float diffLevel) {
		if (diffLevel >= 1f && diffLevel <= 3f) { 
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, diffLevel);
		} else {
			Debug.LogError("Difficulty takes inproper value");
		}
	}

	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}



}



















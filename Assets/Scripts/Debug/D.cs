using UnityEngine;

public static class D
{
	public static void Error(object message)
	{
		Debug.LogError(message);
	}

	public static void Log(object message)
	{
		Debug.Log(message);
	}

	public static void Warning(object message)
	{
		Debug.LogWarning(message);
	}
}
using UnityEngine;
using UnityEngine.Events;

public static class MessageDispatcherExtensions
{
	public static void RemoveAllListeners<TMessage>(this GameObject gameObject) where TMessage : MessageDispatcherBase
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction handler) where TMessage : MessageDispatcher
	{
	}

	public static void AddListener<TMessage, T>(this GameObject gameObject, UnityAction<T> handler) where TMessage : MessageDispatcher<T>
	{
	}

	public static void AddListener<TMessage, T1, T2>(this GameObject gameObject, UnityAction<T1, T2> handler) where TMessage : MessageDispatcher<T1, T2>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<int> handler) where TMessage : MessageDispatcher<int>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<bool> handler) where TMessage : MessageDispatcher<bool>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<AnimationEvent> handler) where TMessage : MessageDispatcher<AnimationEvent>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<float[], int> handler) where TMessage : MessageDispatcher<float[], int>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<Collision> handler) where TMessage : MessageDispatcher<Collision>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<Collision2D> handler) where TMessage : MessageDispatcher<Collision2D>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<ControllerColliderHit> handler) where TMessage : MessageDispatcher<ControllerColliderHit>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<float> handler) where TMessage : MessageDispatcher<float>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<Joint2D> handler) where TMessage : MessageDispatcher<Joint2D>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<GameObject> handler) where TMessage : MessageDispatcher<GameObject>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<RenderTexture, RenderTexture> handler) where TMessage : MessageDispatcher<RenderTexture, RenderTexture>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<Collider> handler) where TMessage : MessageDispatcher<Collider>
	{
	}

	public static void AddListener<TMessage>(this GameObject gameObject, UnityAction<Collider2D> handler) where TMessage : MessageDispatcher<Collider2D>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction handler) where TMessage : MessageDispatcher
	{
	}

	public static void RemoveListener<TMessage, T>(this GameObject gameObject, UnityAction<T> handler) where TMessage : MessageDispatcher<T>
	{
	}

	public static void RemoveListener<TMessage, T1, T2>(this GameObject gameObject, UnityAction<T1, T2> handler) where TMessage : MessageDispatcher<T1, T2>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<int> handler) where TMessage : MessageDispatcher<int>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<bool> handler) where TMessage : MessageDispatcher<bool>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<AnimationEvent> handler) where TMessage : MessageDispatcher<AnimationEvent>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<float[], int> handler) where TMessage : MessageDispatcher<float[], int>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<Collision> handler) where TMessage : MessageDispatcher<Collision>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<Collision2D> handler) where TMessage : MessageDispatcher<Collision2D>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<ControllerColliderHit> handler) where TMessage : MessageDispatcher<ControllerColliderHit>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<float> handler) where TMessage : MessageDispatcher<float>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<Joint2D> handler) where TMessage : MessageDispatcher<Joint2D>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<GameObject> handler) where TMessage : MessageDispatcher<GameObject>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<RenderTexture, RenderTexture> handler) where TMessage : MessageDispatcher<RenderTexture, RenderTexture>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<Collider> handler) where TMessage : MessageDispatcher<Collider>
	{
	}

	public static void RemoveListener<TMessage>(this GameObject gameObject, UnityAction<Collider2D> handler) where TMessage : MessageDispatcher<Collider2D>
	{
	}

	public static void RemoveAllListeners<TMessage>(this Component component) where TMessage : MessageDispatcherBase
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction handler) where TMessage : MessageDispatcher
	{
	}

	public static void AddListener<TMessage, T>(this Component component, UnityAction<T> handler) where TMessage : MessageDispatcher<T>
	{
	}

	public static void AddListener<TMessage, T1, T2>(this Component component, UnityAction<T1, T2> handler) where TMessage : MessageDispatcher<T1, T2>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<int> handler) where TMessage : MessageDispatcher<int>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<bool> handler) where TMessage : MessageDispatcher<bool>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<AnimationEvent> handler) where TMessage : MessageDispatcher<AnimationEvent>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<float[], int> handler) where TMessage : MessageDispatcher<float[], int>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<Collision> handler) where TMessage : MessageDispatcher<Collision>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<Collision2D> handler) where TMessage : MessageDispatcher<Collision2D>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<ControllerColliderHit> handler) where TMessage : MessageDispatcher<ControllerColliderHit>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<float> handler) where TMessage : MessageDispatcher<float>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<Joint2D> handler) where TMessage : MessageDispatcher<Joint2D>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<GameObject> handler) where TMessage : MessageDispatcher<GameObject>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<RenderTexture, RenderTexture> handler) where TMessage : MessageDispatcher<RenderTexture, RenderTexture>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<Collider> handler) where TMessage : MessageDispatcher<Collider>
	{
	}

	public static void AddListener<TMessage>(this Component component, UnityAction<Collider2D> handler) where TMessage : MessageDispatcher<Collider2D>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction handler) where TMessage : MessageDispatcher
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<int> handler) where TMessage : MessageDispatcher<int>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<bool> handler) where TMessage : MessageDispatcher<bool>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<AnimationEvent> handler) where TMessage : MessageDispatcher<AnimationEvent>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<float[], int> handler) where TMessage : MessageDispatcher<float[], int>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<Collision> handler) where TMessage : MessageDispatcher<Collision>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<Collision2D> handler) where TMessage : MessageDispatcher<Collision2D>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<ControllerColliderHit> handler) where TMessage : MessageDispatcher<ControllerColliderHit>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<float> handler) where TMessage : MessageDispatcher<float>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<Joint2D> handler) where TMessage : MessageDispatcher<Joint2D>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<GameObject> handler) where TMessage : MessageDispatcher<GameObject>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<RenderTexture, RenderTexture> handler) where TMessage : MessageDispatcher<RenderTexture, RenderTexture>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<Collider> handler) where TMessage : MessageDispatcher<Collider>
	{
	}

	public static void RemoveListener<TMessage>(this Component component, UnityAction<Collider2D> handler) where TMessage : MessageDispatcher<Collider2D>
	{
	}
}

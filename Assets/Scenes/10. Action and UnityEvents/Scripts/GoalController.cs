using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
	[SerializeField] private UnityEvent OnEnter;

	private void OnTriggerEnter(Collider collision)
	{
		// 1. sem parâmetro
		// 2. com parâmetro estático (inspector)
		// 3. com parâmetro dinâmico (código-fonte)
		OnEnter?.Invoke(); 
	}

}

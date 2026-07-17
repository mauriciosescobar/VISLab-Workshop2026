using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
	[SerializeField] private Transform spawnPoint;
	[SerializeField] private int objectsToGenerate = 1000;
	[SerializeField] private Transform objectModelPrefab;

	public void Generate()
    {


        for(int count = 0; count < objectsToGenerate; count++)
        {

            Transform _instance = Instantiate(objectModelPrefab, spawnPoint.position, Quaternion.identity, transform);

            Destroy(_instance.gameObject, 10);

        }


    }
}

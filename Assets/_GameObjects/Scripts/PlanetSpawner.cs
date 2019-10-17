using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> planets;
    [SerializeField] int numberOfPlanets;
    [SerializeField] GameObject area;
    [Range(1,1000)]
    [SerializeField] float planetScale=1;
    void Start()
    {
        Collider cubeCollider = area.GetComponent<Collider>();
        for(int i = 0; i < numberOfPlanets; i++) {
            float x = area.transform.position.x + Random.Range(-cubeCollider.bounds.extents.x, cubeCollider.bounds.extents.x);
            float y = area.transform.position.y + Random.Range(-cubeCollider.bounds.extents.y, cubeCollider.bounds.extents.y);
            float z = area.transform.position.z + Random.Range(-cubeCollider.bounds.extents.z, cubeCollider.bounds.extents.z);
            GameObject planet = Instantiate(planets[Random.Range(0,planets.Count)], new Vector3(x, y, z), Quaternion.identity);
            planet.transform.localScale = new Vector3(planetScale, planetScale, planetScale);
        }
    }
}

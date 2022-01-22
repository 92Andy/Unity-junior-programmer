using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    private float spawnRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (targets.Count == 0)
            throw new MissingComponentException("Their are no Targets!");
        StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            var randomIndex = Random.Range(0, targets.Count);
            Instantiate(targets.ElementAt(randomIndex));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

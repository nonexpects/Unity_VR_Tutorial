using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterMove : MonoBehaviour
{
    public Transform heroTr;
    private WaitForSeconds wfs;
    public NavMeshAgent MonsterAgent;
    public Animator animator;
    public Vector3 targetPosition;

    private void OnEnable()
    {
        StartCoroutine(CheckMonster());
        Debug.Log("OnEnable");
    }

    IEnumerator CheckMonster()
    {
        while (true)
        {
            yield return wfs;
            MonsterAgent.autoBraking = true;
            MonsterAgent.speed = 1f;
            ApproachTarget(heroTr.position);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        heroTr = player.GetComponent<Transform>();

        wfs = new WaitForSeconds(0.4f);

        MonsterAgent = GetComponent<NavMeshAgent>();
        MonsterAgent.autoBraking = false;

        animator = GetComponent<Animator>();
    }

    void ApproachTarget(Vector3 pos)
    {
        if (MonsterAgent.isPathStale) return;
        MonsterAgent.destination = pos;
        MonsterAgent.isStopped = false;
    }
}

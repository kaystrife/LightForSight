using UnityEngine;
using UnityEngine.AI;

public class TutorialLightSphere : MonoBehaviour {

    public GameObject burst;
    public NavMeshAgent playerAgent;
    TutorialWeakenLight lightSource;
   

	// Use this for initialization
	void Start () {
        lightSource = TutorialWeakenLight.instance;

	}

    private void Update()
    {
        if (playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Burst();
            }
        }
    }

    public void MoveToInteraction(NavMeshAgent playerAgent)
    {

        this.playerAgent = playerAgent;
        playerAgent.destination = transform.position;
        playerAgent.stoppingDistance = 5.0f;
    }

    void Burst()
    {
        Instantiate(burst, transform.position, transform.rotation);
        AudioManager.Play("GlassBreak");
        lightSource.lightSource.intensity += 1;
        TutorialManager.tutorialLightSphereNum++;
        Destroy(gameObject);
    }
}

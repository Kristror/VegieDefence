using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject playerPrefab;
    
    private Player player;
    private PlayerMovement playerMovment;

    public void Start()
    {
        GameObject playerObject = GameObject.Instantiate(playerPrefab);
        player = playerObject.GetComponent<Player>();
        playerMovment = playerObject.GetComponent<PlayerMovement>();
    }
    void Update()
    {
        player.FrameUpdate();
        playerMovment.FrameUpdate();
    }
}

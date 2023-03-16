using UnityEngine;

public class RayCameraPlayer : MonoBehaviour
{
    private float rayMaxDistance = 5f;
    private Transform _screenTarget;
    private bool _screenDetected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        // Envoyer un rayon à partir de la position de la caméra
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hitInfo;

        // Vérifier si le rayon a touché un objet
        if (Physics.Raycast(ray, out hitInfo, rayMaxDistance))
        {
            Video video = hitInfo.transform.GetComponent<Video>();
            if (video != null)
            {
                _screenDetected = true;
                Debug.Log("Je regarde l'écran: " + hitInfo.transform.name);
            }
            // Afficher le nom de l'objet touché dans la console

        }
    }

    public void HoverEnterUnmute()
    {
        if (_screenDetected == true)
        {
            gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioMute(0, false);
        }
    }
    public void HoverExitMute()
    {


        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioMute(0, true);

    }

}

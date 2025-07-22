using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    private AudioSource aud;
    private GameObject director;
    private ParticleSystem particleSys;
    private GameDirector m_GDirect;
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
        particleSys = GetComponent<ParticleSystem>();
        m_GDirect = director.GetComponent<GameDirector>();
    }
    private void Update()
    {
        if(m_GDirect != null && m_GDirect.time <= 0.0f)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0) == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);            // RoundToInt : 정수형으로 반올림으로 한다.
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Apple"))
        {
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
            var main = particleSys.main;
            main.startColor = Color.white;
        }
        if(other.gameObject.CompareTag("Bomb"))
        {
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb();
            var main = particleSys.main;
            main.startColor = Color.black;
        }
        GetComponent<ParticleSystem>().Play();

        Destroy(other.gameObject);
    }
}

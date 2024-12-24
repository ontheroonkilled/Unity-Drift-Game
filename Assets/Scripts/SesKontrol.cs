using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SesKontrol : MonoBehaviour
{
    public static SesKontrol Instance { get; private set; }
    public Slider sesSlider;
    private const string SES_PREFS = "OyunSesi";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += YeniSahneyiAyarla;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void YeniSahneyiAyarla(Scene scene, LoadSceneMode mode)
    {
        // Her sahne yüklendiğinde slider'ı bul ve ayarla
        sesSlider = GameObject.FindObjectOfType<Slider>();
        if (sesSlider != null)
        {
            sesSlider.value = AudioListener.volume;
            sesSlider.onValueChanged.RemoveAllListeners();
            sesSlider.onValueChanged.AddListener(SesAyarla);
        }
    }

    void Start()
    {
        // İlk açılışta kaydedilmiş ses seviyesini yükle
        float kaydedilmisSes = PlayerPrefs.GetFloat(SES_PREFS, 1f);
        
        if (sesSlider != null)
        {
            sesSlider.value = kaydedilmisSes;
            sesSlider.onValueChanged.AddListener(SesAyarla);
        }
        
        AudioListener.volume = kaydedilmisSes;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= YeniSahneyiAyarla;
    }

    public void SesAyarla(float deger)
    {
        AudioListener.volume = deger;
        PlayerPrefs.SetFloat(SES_PREFS, deger);
        PlayerPrefs.Save();
    }
}

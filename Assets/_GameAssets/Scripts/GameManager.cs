using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //¿Estado del juego?

    public Text textMaxima;

    [SerializeField]

    private int record;

    [SerializeField]
    private int puntuacion;
    [SerializeField]
    private bool sonido;
    [SerializeField]
    private float volumenSonido;
    [SerializeField]
    private int numeroVidas;//Número de vidas totales
    [SerializeField]
    private int vidaMaxima;//Salud por cada vida
    [SerializeField]
    private int vidaActual;//Cantidad de vida de la vida actual
    //???
    [Header("User Interface")]
    [SerializeField]
    private Text textPuntuacion;
    [SerializeField]
    private GameObject panelCorazonLleno;
    [SerializeField]
    private GameObject corazonLleno;
    [SerializeField]
    private GameObject panelCorazonVacio;
    [SerializeField]
    private GameObject corazonVacio;
    [SerializeField]
    private GameObject panelInventario;
    [SerializeField]
    private GameObject prefabItem;

    //Array de Imágenes correspondiente a los corazones
    public Image[] corazones;

    public GameObject juegoAcabado;

    //Lista de items en el inventario
    public List<Item.ItemValues> inventario = new List<Item.ItemValues>();

    private bool invencible;

    private bool isAndroid;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public GameObject menuPausa;

    public GameObject gameOver;

    private bool enPausa = false;

    [SerializeField]

    private Text textoFinal;

    public GameObject menuFin;

    private Scene escena;

    private void Start()
    {
        record = PlayerPrefs.GetInt("Record:", 0);
        textMaxima.text = "Record:" + record;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            print("Me Pauso");


            Pausa();

        }



    }

    private void Awake()
    {
        Scene escena = SceneManager.GetActiveScene();
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            //Damos dimensión al array de corazones
            corazones = new Image[numeroVidas];
            vidaActual = vidaMaxima;
            for (int i = 0; i < numeroVidas; i++)
            {
                //Creación y asignación de padre en un paso
                GameObject corazon = Instantiate(corazonLleno, panelCorazonLleno.transform);
                //Almacenamos cada corazón en su posición en el array
                corazones[i] = corazon.GetComponent<Image>();

                Instantiate(corazonVacio, panelCorazonVacio.transform);
                /*
                //Creación y asignación de padre en dos pasos
                GameObject x = Instantiate(corazonLleno);
                x.transform.SetParent(panelCorazonLleno.transform);
                */
                /*
                //Creación no asignándole padre (lo crea como hijo del raiz)
                Instantiate(corazonLleno);
                */
            }
            if (PlayerPrefs.HasKey("Puntuacion"))
            {
                AddPuntuacion(PlayerPrefs.GetInt("Puntuacion"));
            }
            if (PlayerPrefs.HasKey("sonido"))
            {
                bool sonido = bool.Parse(PlayerPrefs.GetString("sonido"));
                float volumen = PlayerPrefs.GetFloat("volumen");
                if (sonido == false)
                {
                    AudioListener.volume = 0;
                }
                else
                {
                    AudioListener.volume = volumen;
                }
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                isAndroid = true;
            }
            else
            {
                isAndroid = false;
            }
        }
    }

    public void AddPuntuacion(int incrementoPuntos)
    {
        puntuacion += incrementoPuntos;
        if (textPuntuacion != null)
        {
            textPuntuacion.text = puntuacion.ToString();
        }
    }

    public void Invencibilizador()
    {
        print("Soy Invencible");
        invencible = true;
        Invoke("Negador", 15.0f);
    }

    public void Negador()
    {
        print("He dejado de ser invencible");
        invencible = false;
    }

    public void Victoria()
    {
        Time.timeScale = 0;
        juegoAcabado.SetActive(true);
        GuardarPuntuacionMaxima();

    }

    //public void HacerDanyo(int danyo)
    //{
    //    vidaActual -= danyo;
    //    corazones[numeroVidas - 1].fillAmount = (float)vidaActual / (float)vidaMaxima;
    //    if (vidaActual <= 0)
    //    {
    //        vidaActual = vidaMaxima - Mathf.Abs(vidaActual);
    //        numeroVidas--;
    //        corazones[numeroVidas - 1].fillAmount = (float)vidaActual / (float)vidaMaxima;
    //    }
    //}

    public void HacerDanyo(int danyo)
    {
        if (invencible == false)
        {
            if (numeroVidas <= 0) return;
            vidaActual -= danyo;
            corazones[numeroVidas - 1].fillAmount =
                (float)vidaActual / (float)vidaMaxima;
            if (vidaActual <= 0)
            {
                int vidaResidual = Mathf.Abs(vidaActual);
                numeroVidas--;
                if (numeroVidas <= 0)
                {
                    Time.timeScale = 0;
                    gameOver.SetActive(true);
                    print("GAME OVER");
                    return;

                }
                vidaActual = vidaMaxima;
                if (vidaResidual > 0)
                {
                    HacerDanyo(vidaResidual);
                }
                GuardarPuntuacionMaxima();
            }
        }
    }


    public void GuardarCheckpoint(Vector3 position)
    {
        PlayerPrefs.SetFloat("x", position.x);
        PlayerPrefs.SetFloat("y", position.y);
        PlayerPrefs.SetFloat("z", position.z);
        PlayerPrefs.SetInt("Puntuacion", puntuacion);


        PlayerPrefs.Save();

    }

    public void AddItem(GameObject item)
    {
        //Agregar el nombre del item al inventario (es una lista de nombres)
        inventario.Add(item.GetComponentInChildren<Item>().GetItemName());

        //Creamos el item del UI
        GameObject nuevoItem = Instantiate(prefabItem, panelInventario.transform);
        Sprite sprite = item.GetComponentInChildren<SpriteRenderer>().sprite;
        nuevoItem.GetComponent<Image>().sprite = sprite;
        nuevoItem.GetComponent<Image>().enabled = true;
    }
    public bool HasItem(Item.ItemValues itemBuscado)
    {
        foreach (Item.ItemValues item in inventario)
        {
            if (itemBuscado == item)
            {
                return true;
            }
        }
        return false;
    }

    public void Pausa()
    {
        Time.timeScale = 0;
        menuPausa.SetActive(true);


    }

    public void SalirPausa()
    {

        Time.timeScale = 1;
        menuPausa.SetActive(false);
    }


    public bool IsAndroid()
    {
        return isAndroid;
    }




    public void MostrarEscenaPrincipal()
    {
        SceneManager.LoadScene("MenuScene");

    }

    public void RecargarNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void PasarNivel()
    {
        SceneManager.LoadScene("Nivel2");
    }

    public void GuardarPuntuacionMaxima()
    {
        int record = PlayerPrefs.GetInt("Record:", 0);
        if (puntuacion > record)
        {
            PlayerPrefs.SetInt("Record:", puntuacion);
            PlayerPrefs.Save();
        }
    }


    public void JuegoAcabado()
    {
        Time.timeScale = 0;
        textoFinal.text = puntuacion.ToString();
        menuFin.SetActive(true);

    }

    public void GuardarPuntuacionLvl()
    {
        PlayerPrefs.SetInt("Puntuacion", puntuacion);
    }

    public void CargarPuntuacion()
    {
        puntuacion = PlayerPrefs.GetInt("Record" + escena.name, 0);


    }
}

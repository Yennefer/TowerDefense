using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BuildMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject menuButtons;

    [SerializeField]
    private Button buttonPrefab;

    private string builderId;

    private UnityAction<GameObject> builderListener;

    public void Awake()
    {
        builderListener = SelectPrefub;
    }

    public void OnEnable()
    {
        EventManager.RegisterListener(Events.selectPrefub.ToString(), builderListener);
    }

    public void OnDisable()
    {
        EventManager.UnregisterListener(Events.selectPrefub.ToString(), builderListener);
    }

    public void SelectClick(GameObject prefab)
    {
        menuButtons.gameObject.SetActive(false);
        EventManager.TriggerEvent(Events.buildPrefub.ToString() + builderId, prefab);
    }

    private void SelectPrefub(GameObject builder)
    {
        TurretsBuilder builderObj = builder.GetComponent<TurretsBuilder>();
        builderId = builderObj.GetId();
        CreateMenu(builderObj.GetTurretsToBuild());
        menuButtons.gameObject.SetActive(true);
    }

    private void CreateMenu(GameObject[] prefubs)
    {
        ClearMenu();
        for (int i = 0; i < prefubs.Length; i++)
        {
            GameObject prefab = prefubs[i];
            Button button = Instantiate(buttonPrefab);
            button.transform.SetParent(menuButtons.transform, false);
            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.position = new Vector3(Screen.width / 2, Screen.height / 2 - i * 50, 0);
            button.GetComponentInChildren<Text>().text = prefab.name;
            button.onClick.AddListener(() => SelectClick(prefab));
        }
    }

    private void ClearMenu()
    {
        foreach (Transform button in menuButtons.transform)
        {
            GameObject.Destroy(button.gameObject);
        }
    }
}
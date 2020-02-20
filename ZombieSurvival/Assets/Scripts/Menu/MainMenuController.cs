using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Dropdown m_listSelector;
    [SerializeField] string m_path;

    List<FileInfo> m_levelList;
    // Start is called before the first frame update
    void Start()
    {
        if (m_listSelector)
        {
            m_levelList = new List<FileInfo>();
            List<string> levelList = new List<string>();
            /*levelList.Add("Level 1");
            levelList.Add("Level 2");*/
            string lvlPath = $"{Application.dataPath}/{m_path}";
            DirectoryInfo lvlDirectory = new DirectoryInfo(lvlPath);
            //m_levelList = lvlDirectory.GetFiles("*.psd|*.png");

            m_levelList.AddRange(lvlDirectory.GetFiles("*.png"));
            //m_levelList.AddRange(lvlDirectory.GetFiles("*.psd"));// lvlDirectory.GetFiles("*.psd");


            foreach (var file in m_levelList)
            {
                levelList.Add(file.Name);
            }

            m_listSelector.ClearOptions();
            m_listSelector.AddOptions(levelList);
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void LoadLevel()
    {
        FileInfo file = m_levelList[m_listSelector.value];
        var test = file.FullName;
        //var test2 = Resources.Load(file.FullName);

        /*string testPath = "Levels/level_test_4";
        Texture2D lvlSprite = Resources.Load<Texture2D>(testPath);*/
        Texture2D lvlSprite = LoadImage(file.FullName);

        StaticDataHandler.LoadedLevel = lvlSprite;

        SceneManager.LoadScene((int)Scenes.Game, LoadSceneMode.Single);
    }

    public Texture2D LoadImage(string filePath)
    {
        if (File.Exists(filePath))
        {
            byte[] fileData;
            fileData = File.ReadAllBytes(filePath);
            Texture2D result = new Texture2D(2, 2);
            result.LoadImage(fileData); //..this will auto-resize the texture dimensions.

            return result;
        }
        else
        {
            return null;
        }
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}

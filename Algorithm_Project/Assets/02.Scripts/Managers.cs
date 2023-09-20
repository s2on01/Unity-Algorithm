using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;                                 //�Ŵ����� �̱������� ����
    public static Managers Instance { get { return s_instance; } }

    private static bool isInitialized = false;
    public void Awake()                                             //Awake �������� Init() 
    {
        Init();
    }
    public static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();                   //�ν��Ͻ��� ã�Ƽ� manager ����
            isInitialized = true; // �ʱ�ȭ �Ϸ�
        }
    }
    public bool IsInitialized()
    {
        return isInitialized;
    }

    SGProjectileManager _projectileManager = new SGProjectileManager();         //Manager ������ projectilManager 
    SGShotManager _shotManager = new SGShotManager();                           //Manager ������ shotManager

    public static SGShotManager ShotManager { get { return Instance?._shotManager; } }          //SGShotManager ���ٽ� �ν��Ͻ� ���� 
    public static SGProjectileManager projectileManager { get { return Instance?._projectileManager; } } //SGProjectileManager ���ٽ� �ν��Ͻ� ���� 


}
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectFactory : MonoBehaviour
{
    private Scene _scene;
    protected T CreateGameObgectInstance<T>(T prefab) where T : MonoBehaviour
    {
        if (!_scene.isLoaded)
        {
            if (Application.isEditor)
            {
                _scene = SceneManager.GetSceneByName(name);
                if (!_scene.isLoaded)
                {
                    _scene = SceneManager.CreateScene(name);
                }
            }
            else
            {
                _scene = SceneManager.CreateScene(name);
            }
        }
        T incstance = Instantiate(prefab);
        SceneManager.MoveGameObjectToScene(incstance.gameObject, _scene);
        return incstance;
    }
}

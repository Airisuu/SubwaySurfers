using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   [SerializeField]

   private Animator Fade;
   [SerializeField]

   private string FadeAnimationName;

   public void GoToSceneWithFade(string sceneName)
   {
        StartCoroutine(LoadSceneAfterFade(sceneName));
   }

   private IEnumerator LoadSceneAfterFade(string sceneName)
   {
    Fade.Play(FadeAnimationName, 0, 0f);
    yield return new WaitForSeconds(Fade.GetCurrentAnimatorStateInfo(0).length);
    SceneManager.LoadScene(sceneName);
   }

}

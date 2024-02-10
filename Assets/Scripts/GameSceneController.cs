using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SMT
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField]
        private HK.UI.HKUIDocument uiDocument;

        [SerializeField]
        private AudioSource endSound;

        [SerializeField]
        private int endRange;

        void Start()
        {
            var document = Instantiate(uiDocument);
            var gameLoopArea = document.Q("GameLoopArea");
            var gameEndArea = document.Q("GameEndArea");
            var countLabel = document.Q<TMP_Text>("CountLabel");
            var endCountLabel = document.Q<TMP_Text>("EndCountLabel");
            var currentCount = 0;
            var endCount = Random.Range(0, endRange);
            var scope = new CancellationTokenSource();
            if (currentCount >= endCount)
            {
                EndProcess();
                return;
            }
            gameLoopArea.SetActive(true);
            gameEndArea.SetActive(false);
            countLabel.SetText("{0}", currentCount);
            this.GetAsyncUpdateTrigger()
                .Subscribe(_ =>
                {
                    if (Keyboard.current.wasUpdatedThisFrame)
                    {
                        currentCount++;
                        countLabel.SetText("{0}", currentCount);
                        if (currentCount >= endCount)
                        {
                            EndProcess();
                        }
                    }
                })
                .AddTo(scope.Token);
            void EndProcess()
            {
                endSound.PlayOneShot(endSound.clip);
                scope.Cancel();
                scope.Dispose();
                endCountLabel.SetText("{0}", currentCount);
                gameLoopArea.SetActive(false);
                gameEndArea.SetActive(true);
            }
        }
    }
}

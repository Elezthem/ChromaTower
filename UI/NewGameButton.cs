using UnityEngine.UI;

namespace RectangleTrainer.ChromaTower.UI
{
    public class NewGameButton : Button
    {
        private Text label;
        [UnityEngine.SerializeField] private string restartLabel = "Заново";

        protected override void Start()
        {
            base.Start();
            label = GetComponentInChildren<Text>();
        }

        public void SwitchToReplayLabel()
        {
            label.text = restartLabel;
        }
    }
}
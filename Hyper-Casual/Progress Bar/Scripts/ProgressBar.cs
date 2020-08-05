using System;
using UnityEngine;
using UnityEngine.UI;

namespace SelfishCoder.Utilities.HyperCasual
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(RectTransform)),DisallowMultipleComponent]
    public class ProgressBar : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        [Header("Dependencies")] 
        [SerializeField] private Image backgroundArea = default;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private Image fillArea= default;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private Text currentLevelArea= default;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private Text nextLevelArea= default;

        /// <summary>
        /// 
        /// </summary>
        [Header("Configuration")] 
        [SerializeField] private Color backgroundColor = Color.white;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private Color fillColor = new Color(255, 167, 167, 255);

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private float minimumProgress = 0;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private float maximumProgress = 100;

        /// <summary>
        /// 
        /// </summary>
        [Header("Values")] 
        [SerializeField, Range(0, 100)] private float progress = 0;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int currentLevelNumber = 1;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int nextLevelNumber = 2;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public float Progress
        {
            get => progress;
            private set
            {
                progress = Mathf.Clamp(value, minimumProgress, maximumProgress);
                fillArea.fillAmount = progress / maximumProgress;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CurrentLevelNumber
        {
            get => currentLevelNumber;
            private set
            {
                currentLevelNumber = value <= 1 ? 1 : value;
                currentLevelArea.text = currentLevelNumber.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NextLevelNumber
        {
            get => nextLevelNumber;
            private set
            {
                nextLevelNumber = value < 2 ? 2 : value;
                nextLevelArea.text = nextLevelNumber.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color BackgroundColor
        {
            get => backgroundColor;
            private set
            {
                backgroundColor = value;
                backgroundArea.color = backgroundColor;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color FillColor
        {
            get => fillColor;
            private set
            {
                fillColor = value;
                fillArea.color = fillColor;
            }
        }

        #endregion

        #region Events

        public event Action<float> ProgressChanged; 

        #endregion
        
        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            this.SetInitialValues();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetInitialValues()
        {
            backgroundArea.color = BackgroundColor;
            fillArea.color = FillColor;
            fillArea.fillAmount = Progress;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newProgress"></param>
        public void SetProgress(float newProgress)
        {
            this.Progress = newProgress;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="levelNumber"></param>
        public void SetCurrentLevel(int levelNumber)
        {
            this.CurrentLevelNumber = levelNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        public void SetBackgroundColor(Color color)
        {
            this.backgroundColor = color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        public void SetFillColor(Color color)
        {
            this.fillColor = color;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newProgress"></param>
        private void OnProgressChanged(float newProgress)
        {
            ProgressChanged?.Invoke(newProgress);
        }

        #endregion
    }
}
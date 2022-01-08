using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Slider _progressFill;
        [SerializeField] private Text _loadingInfo;
        [SerializeField] private float _barSpeed;
        
        private float _targetProgress;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public async void Load(Queue<ILoadingOperation> loadingOperations)
        {
            _canvas.enabled = true;
            StartCoroutine(UpdateProgressBar());
            
            foreach (var operation in loadingOperations)
            {
                ResetFill();
                _loadingInfo.text = operation.Description;

                await operation.Load(OnProgress);
                await WaitForBarFill();
            }

            _canvas.enabled = false;
        }

        private void ResetFill()
        {
            _progressFill.value = 0;
            _targetProgress = 0;
        }

        private void OnProgress(float progress)
        {
            _targetProgress = progress;
        }

        private async Task WaitForBarFill()
        {
            while (_progressFill.value < _targetProgress)
            {
                await Task.Delay(1);
            }
            await Task.Delay(TimeSpan.FromSeconds(0.15f));
        }

        private IEnumerator UpdateProgressBar()
        {
            while (_canvas.enabled)
            {
                if(_progressFill.value < _targetProgress)
                    _progressFill.value += Time.deltaTime * _barSpeed;
                yield return null;
            }
        }
    }
}
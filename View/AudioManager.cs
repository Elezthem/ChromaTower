using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RectangleTrainer.ChromaTower.View
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioClip bounce;
        [SerializeField] AudioClip damage;

        private AudioSource source;
        public GameObject panel_loading;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        public void Initialize(Engine.ChromaTower tower)
        {
            tower.OnDamage += PlayDamage;
            tower.OnSuccessfulHit += PlayBounce;
        }

        private void PlayClip(AudioClip clip)
        {
            if (source.isPlaying) source.Stop();
            source.clip = clip;
            source.Play();
        }

        public void PlayBounce() => PlayClip(bounce);
        public void PlayDamage() => PlayClip(damage);

        public void click_menu()
        {
            panel_loading.SetActive(true); 
            SceneManager.LoadSceneAsync(0 , LoadSceneMode.Single); 
        }
    }
}

// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;

namespace DoozyUI.UIButton.Sound
{
    public partial class SoundModule : MonoBehaviour
    {
        void Reset()
        {
            if (GetUIButton.onHoverEnterSoundModule == this) reactTo = UIButton.ReactTo.OnHoverEnter;
            else if (GetUIButton.onHoverExitSoundModule == this) reactTo = UIButton.ReactTo.OnHoverExit;
            else if (GetUIButton.onPointerDownSoundModule == this) reactTo = UIButton.ReactTo.OnPointerDown;
            else if (GetUIButton.onPointerUpSoundModule == this) reactTo = UIButton.ReactTo.OnPointerUp;
            else if (GetUIButton.onClickSoundModule == this) reactTo = UIButton.ReactTo.OnClick;
            else if (GetUIButton.onDoubleClickSoundModule == this) reactTo = UIButton.ReactTo.OnDoubleClick;
            else if (GetUIButton.onLongClickSoundModule == this) reactTo = UIButton.ReactTo.OnLongClick;
        }

        void Awake()
        {
            rectTransfrom = GetComponent<RectTransform>();
            if (rectTransfrom == null)
            {
                if (debugThis)
                    Debug.Log(name + " - UIButton.SoundModule - Reacts to " + reactTo.ToString() + " - There is no RectTransform component attached to the gameobject. In order for the SoundModule to work you should have a gameobject with a RectTransfrom and an UIButton components attached.");
                return;
            }
            uiButton = GetComponent<UIButton>();
            if (uiButton == null)
            {
                if (debugThis)
                    Debug.Log(name + " - UIButton.SoundModule - Reacts to " + reactTo.ToString() + " - There is no UIButton component attached to the gameobject. In order for the SoundModule to work you should have a gameobject with a RectTransfrom and an UIButton components attached.");
                return;
            }
            if (!IsTheButtonEventEnabled())
            {
                if (debugThis)
                    Debug.Log(name + " - UIButton.SoundModule - Reacts to " + reactTo.ToString() + " - The event " + reactTo + " is not enabled in the UIButton. In order for the SoundModule to work you should have that event enabled.");
                return;
            }
            if (string.IsNullOrEmpty(sound.soundName) && sound.audioClip == null)
            {
                enabled = false;
                if (debugThis)
                    Debug.Log(name + " - UIButton.SoundModule - Reacts to " + reactTo.ToString() + " - No sound has been set on the gameobject. In order for the SoundModule to work you should set at least one sound source(string or AudioClip). This component has been disabled.");
                return;
            }

            loadedAudioClip = GetLoadedSound();
            if (loadedAudioClip == null)
                return;
        }

        void OnEnable()
        {
            AddListeners();
        }

        void OnDisable()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            switch (reactTo)
            {
                case UIButton.ReactTo.OnHoverEnter: GetUIButton.OnHoverEnter.AddListener(PlaySound); break;
                case UIButton.ReactTo.OnHoverExit: GetUIButton.OnHoverExit.AddListener(PlaySound); break;
                case UIButton.ReactTo.OnPointerDown: GetUIButton.OnPointerDown.AddListener(PlaySound); break;
                case UIButton.ReactTo.OnPointerUp: GetUIButton.OnPointerUp.AddListener(PlaySound); break;
                case UIButton.ReactTo.OnClick: GetUIButton.OnClick.AddListener(PlaySound); break;
                case UIButton.ReactTo.OnDoubleClick: GetUIButton.OnDoubleClick.AddListener(PlaySound); break;
                case UIButton.ReactTo.OnLongClick: GetUIButton.OnLongClick.AddListener(PlaySound); break;
            }
        }

        private void RemoveListeners()
        {
            switch (reactTo)
            {
                case UIButton.ReactTo.OnHoverEnter: GetUIButton.OnHoverEnter.RemoveListener(PlaySound); break;
                case UIButton.ReactTo.OnHoverExit: GetUIButton.OnHoverExit.RemoveListener(PlaySound); break;
                case UIButton.ReactTo.OnPointerDown: GetUIButton.OnPointerDown.RemoveListener(PlaySound); break;
                case UIButton.ReactTo.OnPointerUp: GetUIButton.OnPointerUp.RemoveListener(PlaySound); break;
                case UIButton.ReactTo.OnClick: GetUIButton.OnClick.RemoveListener(PlaySound); break;
                case UIButton.ReactTo.OnDoubleClick: GetUIButton.OnDoubleClick.RemoveListener(PlaySound); break;
                case UIButton.ReactTo.OnLongClick: GetUIButton.OnLongClick.RemoveListener(PlaySound); break;
            }
        }

        private bool IsTheButtonEventEnabled()
        {
            switch (reactTo)
            {
                case UIButton.ReactTo.OnHoverEnter: return GetUIButton.useOnHoverEnter;
                case UIButton.ReactTo.OnHoverExit: return GetUIButton.useOnHoverExit;
                case UIButton.ReactTo.OnPointerDown: return GetUIButton.useOnPointerDown;
                case UIButton.ReactTo.OnPointerUp: return GetUIButton.useOnPointerUp;
                case UIButton.ReactTo.OnClick: return GetUIButton.useOnClick;
                case UIButton.ReactTo.OnDoubleClick: return GetUIButton.useOnDoubleClick;
                case UIButton.ReactTo.OnLongClick: return GetUIButton.useOnLongClick;
                default: return false;
            }
        }

        /// <summary>
        /// Plays the loaded sound
        /// </summary>
        public void PlaySound()
        {
            var go = new GameObject("TempAudio - " + loadedAudioClip.name);
            go.transform.position = transform.position;
            var audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = loadedAudioClip;
            audioSource.volume = volume;
            audioSource.Play();
            Destroy(go, loadedAudioClip.length);
        }

        /// <summary>
        /// Returns an audioClip from the selected sound source
        /// </summary>
        public AudioClip GetLoadedSound()
        {
            switch (soundSource)
            {
                case SoundSource.String:
                    if (string.IsNullOrEmpty(sound.soundName))
                    {
                        Debug.Log(name + " - UIButton.SoundModule - Reacts to " + reactTo.ToString() + " - No soundfile name has been set on the gameobject (yet you selected SoundSource.String as the sound source). In order for the SoundModule to work you should set at least one sound (string or AudioClip). Check your settings.");
                        return null;
                    }
                    else
                    {
                        AudioClip tempAudioClip = Resources.Load(sound.soundName) as AudioClip;
                        if (tempAudioClip == null)
                        {
                            Debug.Log(name + " - UIButton.SoundModule - Reacts to " + reactTo.ToString() + " - No soundfile with the name " + sound.soundName + " has been found in a Resources folder. Check the the file exists or that you spelled the file name right.");
                            return null;
                        }
                        return tempAudioClip;
                    }
                case SoundSource.AudioClip:
                    if (sound.audioClip == null)
                    {
                        Debug.Log(name + " - UIButton.SoundModule - Reacts to " + reactTo.ToString() + " - No audioClip has been referenced (yet you selected SoundSource.AudioClip as the sound source). In order for the SoundModule to work you should set at least one sound (string or AudioClip). Check your settings.");
                        return null;

                    }
                    else
                    {
                        return sound.audioClip;
                    }
            }

            return null;
        }
    }
}

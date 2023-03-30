using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeController : MonoBehaviour
{
	[SerializeReference] AudioSource m_audioSource;
	[SerializeReference] List<AudioClip> m_seClips;

	public void PlaySe(string clipName)
	{
		//--- “¯ˆê‚Ì–¼‘O‚ğ’Tõ
		foreach(AudioClip clip in m_seClips)
		{
			// ˆê’v‚µ‚È‚¢•¨‚ÍƒXƒ‹[
			if (clipName != clip.name) continue;

			//--- ˆê’v‚µ‚½SE‚ğÄ¶
			m_audioSource.clip = clip;
			m_audioSource.Play();
			return;
		}
	}
}
/*
 * Code Artifact Name: MusicClass
 * Description: Controls background music playback across scenes.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 11/05/24
 * Revision History:
 *   - 11/05/24: Initial creation of the script by Zain Ghosheh.
 * Preconditions:
 *   - AudioSource component must be attached to the GameObject.
 * Acceptable Input Values:
 *   - Audio clips must be properly assigned to the AudioSource.
 * Unacceptable Input Values:
 *   - Null or invalid AudioSource references.
 * Postconditions:
 *   - Background music plays or stops as requested.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - None.
 * Side Effects:
 *   - Background music playback state is modified.
 * Invariants:
 *   - MusicClass instance persists across scenes.
 * Known Faults:
 *   - Does not handle multiple audio tracks.
 */

using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private AudioSource _audioSource; // AudioSource component for playing music.

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); // Ensure this GameObject persists across scenes.
        _audioSource = GetComponent<AudioSource>(); // Retrieve the AudioSource component.
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return; // Skip if music is already playing.
        _audioSource.Play(); // Start playing the music.
    }

    public void StopMusic()
    {
        _audioSource.Stop(); // Stop the music.
    }
}

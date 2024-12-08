/*
 * Code Artifact Name: Parallax
 * Description: Creates a parallax scrolling effect for the background to simulate depth.
 * Programmer's Name: [Your Name]
 * Date Created: [Original creation date]
 * Revision History:
 *   - [Date 1]: Initial creation of the script by [Author's Name].
 * Preconditions:
 *   - A Renderer component with a material must be assigned to the GameObject.
 * Acceptable Input Values:
 *   - Speed should be a float between 0 and 0.5.
 * Unacceptable Input Values:
 *   - Null references to Renderer or materials.
 * Postconditions:
 *   - The background material offset changes over time, creating a scrolling effect.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - NullReferenceException if the Renderer or material is not assigned.
 * Side Effects:
 *   - Modifies the texture offset of the material.
 * Invariants:
 *   - The scrolling speed remains within the defined range.
 * Known Faults:
 *   - May not behave as expected if the material lacks a "_MainTex" property.
 */

using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mat; // Reference to the material applied to the background.
    float distance; // Tracks the accumulated scrolling distance.
    [Range(0f, 0.5f)] public float speed = 0.2f; // Speed of the scrolling effect.

    void Start()
    {
        mat = GetComponent<Renderer>().material; // Retrieve the material from the Renderer component.
    }

    void Update()
    {
        if (GameManager.Instance.isPlaying) // Check if the game is active.
        {
            distance += Time.deltaTime * speed; // Increment the scrolling distance based on time and speed.
            mat.SetTextureOffset("_MainTex", Vector2.right * distance); // Update the texture offset to create the scrolling effect.
        }
    }
}

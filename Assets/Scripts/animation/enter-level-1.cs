using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter : MonoBehaviour
{
    public static bool isAnimationFinished = false;

    private IEnumerator MoveAndFade(float startY, float endY, float duration)
    {
        float elapsed = 0;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float newY = Mathf.Lerp(startY, endY, t);
            float newOpacity = Mathf.Lerp(0, 1, t); // Reversed opacity

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newOpacity);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position and opacity are exactly as specified
        transform.position = new Vector3(transform.position.x, endY, transform.position.z);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1); // Reversed opacity

        isAnimationFinished = true;
    }

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
        }
        StartCoroutine(StartMoveAndFadeAfterDelay(3.55f, 1.5f, 2f, 2f)); // Increased delay and duration

        // Get the animator component
        Animator animator = GetComponent<Animator>();

        // If the animator component exists and the "s" key is pressed, trigger the "walkDown" animation
        if (animator != null && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("walkDown", true);
        }
    }

    private IEnumerator StartMoveAndFadeAfterDelay(float startY, float endY, float duration, float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveAndFade(startY, endY, duration));
    }
}
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomScaler : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private SpriteRenderer sprite;
    
    float _duration = 0f;
    private Coroutine _coroutine;
    private bool _isTouched = false;
    
    private void Start()
    {
        _coroutine = StartCoroutine(ChangeScale());
    }

    private IEnumerator ChangeScale()
    {
        float randomScale = Random.Range(2f, 5f);
        float randomDuration = Random.Range(2f, 5f) * 0.1f;
        while (_duration <= 1f)
        {
            float scale = animationCurve.Evaluate(_duration) * randomScale;
            transform.localScale = new Vector3(scale, scale, 1f);
            _duration += Time.deltaTime * randomDuration;
            yield return null;
        }
        Destroy(this.gameObject);
    }

    private IEnumerator FadeOut()
    {
        while (sprite.color.a >= 0f)
        {
            var color = sprite.color;
            color.a -= 0.02f;
            sprite.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_isTouched) return;
        _isTouched = true;
        StopCoroutine(_coroutine);
        StartCoroutine(FadeOut());
    }
}

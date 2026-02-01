// Assets/Scripts/Rooms/PurpleRoom/SymbolicToys.cs
using UnityEngine;
using System.Collections;

public class SymbolicToys : MonoBehaviour
{
    [System.Serializable]
    public class Toy
    {
        public GameObject toyObject;
        public string toyName;
        public float rotationSpeed;
        public float bounceHeight;
    }
    
    public Toy[] toys;
    public float activationDelay = 0.5f;
    
    void Start()
    {
        StartCoroutine(ActivateToysSequentially());
    }
    
    IEnumerator ActivateToysSequentially()
    {
        foreach (Toy toy in toys)
        {
            if (toy.toyObject != null)
            {
                toy.toyObject.SetActive(true);
                StartCoroutine(AnimateToy(toy));
                yield return new WaitForSeconds(activationDelay);
            }
        }
    }
    
    IEnumerator AnimateToy(Toy toy)
    {
        Vector3 startPosition = toy.toyObject.transform.position;
        float time = 0f;
        
        while (toy.toyObject.activeSelf)
        {
            // Rotación
            toy.toyObject.transform.Rotate(Vector3.up, toy.rotationSpeed * Time.deltaTime);
            
            // Efecto de rebote (simulando juguete)
            float bounce = Mathf.Sin(time * 2f) * toy.bounceHeight;
            toy.toyObject.transform.position = startPosition + Vector3.up * bounce;
            
            time += Time.deltaTime;
            yield return null;
        }
    }
    
    // Método para cuando la "Muerte Roja" entra en contacto
    public void OnDeathApproaches()
    {
        // Los juguetes dejan de moverse (fin de la infancia)
        foreach (Toy toy in toys)
        {
            if (toy.toyObject != null)
            {
                Rigidbody rb = toy.toyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.useGravity = true;
                    rb.isKinematic = false;
                }
            }
        }
        
        StartCoroutine(FadeToys());
    }
    
    IEnumerator FadeToys()
    {
        float fadeDuration = 3f;
        float elapsedTime = 0f;
        
        while (elapsedTime < fadeDuration)
        {
            foreach (Toy toy in toys)
            {
                if (toy.toyObject != null)
                {
                    Renderer renderer = toy.toyObject.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        Color color = renderer.material.color;
                        color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
                        renderer.material.color = color;
                    }
                }
            }
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
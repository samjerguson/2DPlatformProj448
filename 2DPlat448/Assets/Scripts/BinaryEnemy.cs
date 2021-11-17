using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryEnemy : MonoBehaviour
{
    public float risingRate;
    public float frameRate;
    public Material mat;
    public List<Texture> texture;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextureChange());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * risingRate * Time.deltaTime); //binary code block moves UP (I had to turn it upside down)       
    }

    IEnumerator TextureChange()
    {
        int i = 0;
        while(true)
        {
            i++;
            mat.mainTexture = texture[i % 21];
            yield return new WaitForSeconds(frameRate);
        }
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralllax : MonoBehaviour
{
    [SerializeField]
    Material texture;

    private void Update()
    {
        texture.mainTextureOffset += new Vector2(GameManager.instance.Speed * Time.deltaTime, 0);
    }

    /*
    += adicionar Ex: 10 += 2
                        12

    -= subtrair por Ex: 10 -= 2
                            8

    *= multiplicar Ex: 10 *= 2
                           20

    /= dividir Ex: 10 /= 2
                       5

    == comparar Ex: 10 == 10
                        verdadeiro

    = atribuição Ex: 10 = 2
                        2

    != diferente Ex: 10 != 2
                        verdadeiro

    <= menor ou igual Ex: 10 <= 2 ou 10 <= 10
                               verdadeiro e verdadeiro

    >=

    & && 

    and True e True = true
        true e false = false
        false e true =  false
        false e false = false

    | ||
    or True e True = true
        true e false = true
        false e true =  true
        false e false = false

    => { }

     */
}

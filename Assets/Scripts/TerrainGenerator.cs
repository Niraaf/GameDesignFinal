using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TerrainGenerator : MonoBehaviour
{
    public GameObject[] flatGround;
    public GameObject[] upperSoil;
    public GameObject[] lowerSoil;
    
    public GameObject[] groundDown;
    public GameObject[] downTransition1;
    public GameObject[] downTransition2;
    
    public GameObject[] groundUp;
    public GameObject[] upTransition1;
    public GameObject[] upTransition2;
    
    float maxLeft;
    float leftY;

    float maxRight;
    float rightY;

    float renderDistance;

    public GameObject soldier;
 
    // Start is called before the first frame update
    void Start() {
        maxLeft = -0.6F;
        leftY = -2F;

        maxRight = 0.6F;
        rightY = -2f;

        renderDistance = Screen.width/50;
    }
 
    void Update() {
        if(transform.position.x - renderDistance < maxLeft) {
            float temp = Random.Range(0, 99); // flat ground
            if(temp < 34) {
                Instantiate(flatGround[Random.Range(0, flatGround.Length - 1)], new Vector3(maxLeft, leftY, 0), transform.rotation);
                for(float a = leftY - 1.2F; a > leftY - 8.4F; a -= 1.2F) {
                    if(a == leftY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    }
                }
            } else if(temp >= 34 && temp <= 66) { //ground goes up
                Instantiate(downTransition2[Random.Range(0, downTransition2.Length - 1)], new Vector3(maxLeft, leftY, 0), transform.rotation);
                for(float a = leftY - 1.2F; a > leftY - 8.4F; a -= 1.2F) {
                    if(a == leftY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    }
                }
                maxLeft -= 1.2F;
                Instantiate(downTransition1[Random.Range(0, downTransition1.Length - 1)], new Vector3(maxLeft, leftY, 0), transform.rotation);
                for(float a = leftY - 1.2F; a > leftY - 8.4F; a -= 1.2F) {
                    if(a == leftY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    }
                }
                leftY += 1.2F;
                Instantiate(groundDown[Random.Range(0, groundDown.Length - 1)], new Vector3(maxLeft, leftY, 0), transform.rotation);
            } else if (temp > 66) { // ground goes down
                Instantiate(upTransition2[Random.Range(0, upTransition2.Length - 1)], new Vector3(maxLeft, leftY, 0), transform.rotation);
                leftY -= 1.2F;
                Instantiate(upTransition1[Random.Range(0, upTransition1.Length - 1)], new Vector3(maxLeft, leftY, 0), transform.rotation);
                for(float a = leftY - 1.2F; a > leftY - 8.4F; a -= 1.2F) {
                    if(a == leftY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    }
                }
                maxLeft -= 1.2F;
                Instantiate(groundUp[Random.Range(0, groundUp.Length - 1)], new Vector3(maxLeft, leftY, 0), transform.rotation);
                for(float a = leftY - 1.2F; a > leftY - 8.4F; a -= 1.2F) {
                    if(a == leftY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxLeft, a, 0), transform.rotation);
                    }
                }
            }
            float temp2 = Random.Range(0, 99);
            if(temp2 < 10) Instantiate(soldier, new Vector3(maxLeft, leftY + 5F, 0), transform.rotation); 
            maxLeft -= 1.2F;
            
        }
        if(transform.position.x + renderDistance > maxRight) {
            float temp = Random.Range(0, 99);
            if(temp < 34) { // flat ground
                Instantiate(flatGround[Random.Range(0, flatGround.Length - 1)], new Vector3(maxRight, rightY, 0), transform.rotation);
                for(float a = rightY - 1.2F; a > rightY - 8.4F; a -= 1.2F) {
                    if(a == rightY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    }
                }
            } else if( temp >= 34 && temp <= 66) { // ground goes up
                Instantiate(groundUp[Random.Range(0, groundUp.Length - 1)], new Vector3(maxRight, rightY, 0), transform.rotation);
                for(float a = rightY - 1.2F; a > rightY - 8.4F; a -= 1.2F) {
                    if(a == rightY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    }
                }
                maxRight += 1.2F;
                Instantiate(upTransition1[Random.Range(0, upTransition1.Length - 1)], new Vector3(maxRight, rightY, 0), transform.rotation);
                for(float a = rightY - 1.2F; a > rightY - 8.4F; a -= 1.2F) {
                    if(a == rightY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    }
                }
                rightY += 1.2F;
                Instantiate(upTransition2[Random.Range(0, upTransition2.Length - 1)], new Vector3(maxRight, rightY, 0), transform.rotation);
            } else if( temp > 66) { // ground goes down
                Instantiate(groundDown[Random.Range(0, groundDown.Length - 1)], new Vector3(maxRight, rightY, 0), transform.rotation);
                rightY -= 1.2F;
                Instantiate(downTransition1[Random.Range(0, downTransition1.Length - 1)], new Vector3(maxRight, rightY, 0), transform.rotation);
                for(float a = rightY - 1.2F; a > rightY - 8.4F; a -= 1.2F) {
                    if(a == rightY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    }
                }
                maxRight += 1.2F;
                Instantiate(downTransition2[Random.Range(0, downTransition2.Length - 1)], new Vector3(maxRight, rightY, 0), transform.rotation);
                for(float a = rightY - 1.2F; a > rightY - 8.4F; a -= 1.2F) {
                    if(a == rightY - 1.2F) { // instantiate upper soil
                        Instantiate(upperSoil[Random.Range(0, upperSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    } else { // instantiate lower soil
                        Instantiate(lowerSoil[Random.Range(0, lowerSoil.Length - 1)], new Vector3(maxRight, a, 0), transform.rotation);
                    }
                }
            }
            float temp2 = Random.Range(0, 99);
            if(temp2 < 10) Instantiate(soldier, new Vector3(maxRight, rightY + 5F, 0), transform.rotation); 
            maxRight += 1.2F;
        }
    }
}
 

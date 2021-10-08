using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class PLayer : MonoBehaviour
{
    [SerializeField] Image HealthBar;
    public float sped;
    PhotonView view;
    const float maxHealth = 100f;
    float currrentHealth = maxHealth;
    public float damage=5f;
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * sped * Time.deltaTime;
            transform.position += (Vector3)moveAmount;
        }

    }
 
    [PunRPC]
   
   
   void takeDamage()
    {
       if (Input.GetKeyDown(KeyCode.F))
       {
        currrentHealth -= damage;
            HealthBar.fillAmount = currrentHealth / maxHealth;
       }

    }
     void FixedUpdate()
     {
        
       
     }
    void Player2TakeDamage()
    {

        if (!view.IsMine)
        {
            takeDamage();
        }
    
      
    }
   
}

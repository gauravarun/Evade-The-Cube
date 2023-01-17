using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public HudManager hudManager;
  public Transform leftwall;
  public Transform rightwall;

  private Stats m_Stats;

  private void Awake()
  {
    m_Stats = GetComponent<Stats>();
    hudManager.UpdateHealthText( m_Stats.health);
  }



  private void Update()
  {

    if(m_Stats.health <= 0)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    float horziontalInput = Input.GetAxis("Horizontal");
    float horizontalPosition = transform.position.x + horziontalInput * speed * Time.deltaTime;
    float playerSize = transform.localScale.x / 2;
   if (horizontalPosition - playerSize<= leftwall.position.x + leftwall.localScale.x / 2)
   {
     return;
   
   }
   if (horizontalPosition + playerSize >= rightwall.position.x - rightwall.localScale.x / 2)
   {
     return;
   
   }
    
    
    transform.position = new Vector3(
        horizontalPosition,
        1,
        transform.position.z );
    
  } 

  public void ReceiveDamage()
  {
    m_Stats.UpdateHealth(10);
    hudManager.UpdateHealthText(m_Stats.health);
  }  
}


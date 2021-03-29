using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    GameObject projectile, gun;
    [SerializeField] 
    private float shootCooldown = 0.5f;
    private bool canShoot = true;

    private ComboController _comboController;
    
    private Animator _animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "PlayerProjectiles";
    
    private void Start()
    {
        _comboController = ComboController.instance;
        _animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _animator.SetBool("cast", true);
        }
        else
        {
            _animator.SetBool("cast", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && canShoot){
            _animator.SetBool("isAttacking", true);
        }
        else
        {
            _animator.SetBool("isAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _comboController.AddWord(0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _comboController.AddWord(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _comboController.AddWord(2);
        } else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _comboController.CastWords();
        }
    }
    
    IEnumerator ReduceCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
    
    public void Fire()
    {
        canShoot = false;
        Instantiate(projectile, gun.transform.position, transform.rotation, projectileParent.transform);
        StartCoroutine(ReduceCooldown());
    }

}

using System.Collections;
using UnityEngine;

namespace SojaExiles
{
    public class opencloseStallDoor : MonoBehaviour
    {
        public Animator openandclose;
        public bool open;
        public Transform Player;

        void Start()
        {
            open = false;
        }

        void Update()
        {
            float dist = Vector3.Distance(Player.position, transform.position);

            if (dist < 1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (open == false)
                    {
                        StartCoroutine(opening());
                    }
                    else
                    {
                        StartCoroutine(closing());
                    }
                }
            }
        }

        IEnumerator opening()
        {
            print("you are opening the door");
            openandclose.Play("OpeningStall");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("you are closing the door");
            openandclose.Play("ClosingStall");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}
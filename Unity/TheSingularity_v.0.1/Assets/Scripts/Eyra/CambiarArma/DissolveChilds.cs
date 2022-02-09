using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DissolveExample
{
    public class DissolveChilds : MonoBehaviour
    {
        // Start is called before the first frame update
        List<Material> materials = new List<Material>();
        bool PingPong = false;
        PlayerMove PlayerMove;
        float value;
        void Start()
        {
            PlayerMove = FindObjectOfType<PlayerMove>();

            var renders = GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renders.Length; i++)
            {
                materials.AddRange(renders[i].materials);
            }
            value = 0;
        
        }

        private void Reset()
        {

            Start();
            SetValue(0);
        }

        // Update is called once per frame
        void Update()
        {

            if (PlayerMove.atackjugador == true)
            {
                
                if(value >= 0)
                {
                    value -= 1 * Time.deltaTime;
                }
                
                for (int i = 0; i < materials.Count; i++)
                {
                    materials[i].SetFloat("_Dissolve", value);
                }
            }
            if(PlayerMove.atackjugador == false)
            {
                
                if(value <= 1)
                {
                    value += 1 * Time.deltaTime;
                }
                

                for (int i = 0; i < materials.Count; i++)
                {
                    materials[i].SetFloat("_Dissolve", value);
                }
            }

        }

        //IEnumerator enumerator()
        //{

        //    //float value =         while (true)
        //    //{
        //    //    Mathf.PingPong(value, 1f);
        //    //    value += Time.deltaTime;
        //    //    SetValue(value);
        //    //    yield return new WaitForEndOfFrame();
        //    //}
        //}

        public void SetValue(float value)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].SetFloat("_Dissolve", value);
            }
        }
    }
}
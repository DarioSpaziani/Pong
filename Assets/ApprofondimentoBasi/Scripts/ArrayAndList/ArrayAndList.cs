using System.Collections.Generic;
using UnityEngine;

namespace LezioneBasi 
{

    public class ArrayAndList : MonoBehaviour {
        private int[] numbersArray = new int[5]; //è possibile inserire i dati dell'array anche in fase di dichiarazione
        private int[] numbersArrayDeclared = { 100, 200 };
    
        private List<int> numbersOnList = new List<int>();
    
        private void Start() {
            Array();
            ListFunc();
        }
    
        #region Array
        private void Array() {
            numbersArray[0] = 0;
            numbersArray[1] = 10;
            numbersArray[2] = 20;
            numbersArray[3] = 30;
            numbersArray[4] = 40;
    
            print(numbersArray[0]);
            print(numbersArray[1]);
    
    
            for (int i = 0; i < numbersArrayDeclared.Length; i++) //possiamo accedere alla grandezza dell'array tramite Length
            {
                print(numbersArrayDeclared[i]);
            }
    
            foreach (int i in numbersArrayDeclared) {
                print(i);
            }
    
            print("Lunghezza : " + numbersArray.Length);
        }
        
    
        #endregion
    
        #region List
    
        private void ListFunc() {
            numbersOnList.Add(35);
            numbersOnList.Add(47);
            numbersOnList.Add(58);
            numbersOnList.Add(67);
            numbersOnList.Add(75);
            
            print(numbersOnList[0]);
            print(numbersOnList[1]);
            print(numbersOnList[2]);
            print(numbersOnList.Count -1); //per accedere all'ultimo membro si prende la lunghezza - 1, poichè la numerazione delle liste parte da 0 e non da 1.
        }
        
        #endregion
        
    }

}



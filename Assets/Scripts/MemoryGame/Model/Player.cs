using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class Player : ModelBaseClass
    {
        public string Name {  get; set; }
        public int Score { get; set; }
        public bool IsActive { get; set; }
        public float Elapsed {  get; set; }
    }
}